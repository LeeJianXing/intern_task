using System;
using System.Text.RegularExpressions;

namespace Cexercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int x,y;
           Console.Write("Please enter minefield row : ");
           x = Int32.Parse(Console.ReadLine());
           Console.Write("Please enter minefield column : ");
           y = Int32.Parse(Console.ReadLine());
           
           string[,] array = new string[x,y]; // set up the minefield size
           string bombSymbol = "X", safePathSymbol = "√", dog = "Totoshka", girl = "Ally", dog_regex = @"\b" + dog + @"\b", girl_regex =  @"\b" + girl + @"\b"; 
           int arr_row_len = array.GetLength(0), arr_col_len = array.GetLength(1), safePath, currentRowPath = 0, count = 1, prev_safe_path, AllyRowPath = 0, prev2_safe_path;
    
           // set a random number that is inside array boundaries
           Random safePathRng = new Random();   
           safePath = safePathRng.Next(0,arr_col_len);
           prev_safe_path = safePath; 
           
           // loop one extra time after reach array max row because ally always one step behind dog
           for (int i = 0; i < arr_row_len + 1; i++)
           { 
                prev2_safe_path = prev_safe_path;
                prev_safe_path = safePath; 
                
                if (i < arr_row_len)
                {
                    safePath = SetSafePath(safePath,currentRowPath,arr_col_len,safePathRng,array,safePathSymbol);
                    SetBombPath(currentRowPath, arr_col_len, array, bombSymbol);
                    currentRowPath += VisualizeMineField(currentRowPath, arr_col_len, array, safePath, dog, girl, dog_regex, count, girl_regex, prev_safe_path,arr_row_len,AllyRowPath);
                }       
                if (i > 0)   
                {         
                    AllyRowPath += AllyPosition(AllyRowPath, safePath, dog_regex, girl, prev_safe_path, girl_regex, array,arr_col_len,currentRowPath,prev2_safe_path);    
                }    
                count++;                  
           }  
           Console.WriteLine("Thanks " + dog + ", " + girl + " pass through the minefield ! ");
        }  

        public static int SetSafePath(int safePath, int currentRowPath, int arr_col_len, Random safePathRng, string[,] array, string safePathSymbol)
        { 
            bool inMinIndex = false;
            bool inMaxIndex = false;

               switch (currentRowPath)
               {
                  case 0:
                     array[currentRowPath,safePath] = safePathSymbol; 
                     return safePath;
                  case > 0:
                     if (safePath - 1 >= 0)
                     {
                        inMinIndex = true;
                     }
                     if (safePath + 2 <= arr_col_len)
                     {
                        inMaxIndex = true;
                     } 
                     if (inMinIndex == true && inMaxIndex == true)
                     {
                        safePath = safePathRng.Next(safePath - 1,safePath + 2);
                        array[currentRowPath,safePath] = safePathSymbol;
                        return safePath; 
                     }
                     else if (inMinIndex == true)
                     {
                        safePath = safePathRng.Next(safePath - 1,safePath);
                        array[currentRowPath,safePath] = safePathSymbol; 
                        return safePath;           
                     }
                     else if (inMaxIndex == true)  // until here inMaxIndex is confirm true only 3 condition avaliable
                     {
                        safePath = safePathRng.Next(safePath,safePath + 2);
                        array[currentRowPath,safePath] = safePathSymbol;
                        return safePath;          
                     }
                     else
                     {  // for minefield that only have 2 coloum
                        safePath = safePathRng.Next(safePath,safePath + 1);
                        array[currentRowPath,safePath] = safePathSymbol;
                        return safePath; 
                     }
               }
               // this code wont run just write it to prevent error from system
               return 0;
        }

        public static void SetBombPath(int currentRowPath, int arr_col_Len, string[,] arr, string bombSymbol) 
        {
             // set bomb path
            for (int i = 0; i < arr_col_Len; i++)
            {                   
                if (String.IsNullOrEmpty(arr[currentRowPath,i]) == true)
                {  
                    arr[currentRowPath,i] = bombSymbol;
                }    
            }      
        } 

        public static int VisualizeMineField(int currentRowPath,int arr_col_len,string[,] array, int safePath, string dog, string girl, string dog_regex, int count, string girl_regex, int prev_safe_path, int arr_row_len, int AllyRowPath)
        {  
           // part 1 show current minefield
           Console.WriteLine("-----------------------------------------------------------------");
           Console.WriteLine("\nCurrent {0} out of {1} row in minefield: \n",count, arr_row_len);
           for (int i = 0; i <= currentRowPath; i++)
           {
                for(int j = 0; j < arr_col_len; j++)
                {               
                  Console.Write("{0} | ",array[i,j]); 
                }
                Console.WriteLine("");
           }

           // part 2 Dog position
           Console.WriteLine("\nTotoshka position: \n");
            if(currentRowPath > 0) 
            {
                // remove dog string from previous position
                array[AllyRowPath,prev_safe_path] = Regex.Replace(array[AllyRowPath,prev_safe_path],dog_regex,"");
            }     
           // Totoshka go to the safe path
           array[currentRowPath,safePath] =  array[currentRowPath,safePath] + string.Concat(" ",dog);
           // Show Totoshka current position
            for (int i = 0; i <= currentRowPath; i++)
            {
                for(int j = 0; j < arr_col_len; j++)
                {
                    Console.Write("{0} | ",array[i,j]); 
                }
                Console.WriteLine("");
            }   

            if (currentRowPath == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Ally position: Not in minefield");
            } 
            return 1;         
        }

        public static int AllyPosition(int AllyRowPath, int safePath, string dog_regex, string girl, int prev_safe_path, string girl_regex, string[,] array, int arr_col_len, int currentRowPath, int prev2_safe_path)
        {
        
           
            Console.WriteLine("");
            if (AllyRowPath - 1 >= 0) 
            {
              // remove previous Ally position string
               array[AllyRowPath - 1,prev2_safe_path] = Regex.Replace(array[AllyRowPath - 1, prev2_safe_path],girl_regex,"");
            }
             // add girl string to dog previous position
            array[AllyRowPath,prev_safe_path] = array[AllyRowPath,prev_safe_path] + string.Concat(" ",girl);
            
            // if Totoshka reach the last row
            if ((AllyRowPath + 1) == currentRowPath)
            {
               Console.WriteLine("Totoshka position: OUT OF MINEFIELD :) \n");
               array[AllyRowPath,prev_safe_path] = Regex.Replace(array[AllyRowPath,prev_safe_path],dog_regex,"");
            }
            
            // show Ally position
            Console.WriteLine("Ally position: \n");

            for (int i = 0; i <= AllyRowPath; i++)
            {
                for(int j = 0; j < arr_col_len; j++)
                {
                    Console.Write("{0} | ",array[i,j]); 
                }
                Console.WriteLine("");
            } 
            Console.WriteLine("");

            // if Ally reach the last row
            if (((AllyRowPath + 1) == currentRowPath) && (Regex.IsMatch(array[AllyRowPath,prev_safe_path],girl) == true))
            {
                Console.WriteLine("Ally position: OUT OF MINEFIELD :)");
                Console.WriteLine("");
            }         
            return 1;
        }
       
    }
}