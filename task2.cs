using System;


namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string Input_Str ="",Trash_Symbols_Str="";
            bool isPalindrome = true;

            Console.WriteLine("\nThis is Palindrome checker,please enter a string. ");    
            Input_Str = Console.ReadLine();
            
            if (string.IsNullOrEmpty(Input_Str))
            {
                Console.WriteLine("Input cannot be empty string");
                Environment.Exit(0);
            }

            if (Input_Str.Length > 1)
            {              
                int i,j,mid_point;

                mid_point = Convert.ToInt32(Math.Round(Convert.ToDouble(Input_Str.Length / 2)));    
                i = 0;
                j = Input_Str.Length - 1;

                while (i <= mid_point && j >= mid_point)
                {         
                    if (Input_Str[i] != Input_Str[j])
                    {                     
                        if (!Char.IsLetterOrDigit(Input_Str[i]) && !Char.IsLetterOrDigit(Input_Str[j]))
                        {                    
                            if (noDuplicateStr(Trash_Symbols_Str,Input_Str[i]) == true)
                            {                   
                                Trash_Symbols_Str = Trash_Symbols_Str + string.Concat(Input_Str[i]);
                            }
                            if (noDuplicateStr(Trash_Symbols_Str,Input_Str[j]) == true)
                            {                      
                               Trash_Symbols_Str = Trash_Symbols_Str + string.Concat(Input_Str[j]);
                            }            
                            i++;
                            j--;
                        }
                        else if (!Char.IsLetterOrDigit(Input_Str[i]))
                        {                   
                            if (noDuplicateStr(Trash_Symbols_Str,Input_Str[i]) == true)
                            {                          
                                Trash_Symbols_Str = Trash_Symbols_Str + string.Concat(Input_Str[i]);
                            }
                            i++;                              
                        }
                        else if (!Char.IsLetterOrDigit(Input_Str[j]))
                        {                          
                            if (noDuplicateStr(Trash_Symbols_Str,Input_Str[j]) == true)
                            {
                                Trash_Symbols_Str = Trash_Symbols_Str + string.Concat(Input_Str[j]);  
                            }          
                            j--;            
                        }
                        else
                        {
                            isPalindrome = false;
                            i++;
                            j--;
                        }               
                    } 
                    else if (Input_Str[i] == Input_Str[j])
                    {
                        if (!Char.IsLetterOrDigit(Input_Str[i]) && !Char.IsLetterOrDigit(Input_Str[j]))
                        {
                            if(noDuplicateStr(Trash_Symbols_Str,Input_Str[i]) == true)
                            {
                                Trash_Symbols_Str = Trash_Symbols_Str + string.Concat(Input_Str[i]);
                            }
                        }
                        i++;
                        j--;
                    } 
                }            
                Console.WriteLine("\nInputString: {0}",Input_Str);
                Console.WriteLine("TrashSymbolsString: {0}",Trash_Symbols_Str);
                Console.WriteLine("Result should be: {0}",isPalindrome);
            }  
            else
            {
                Console.WriteLine("Please input at least 2 or more characters !");
            }
        }

        public static bool noDuplicateStr (string input,char x)
        {           
            if (input.IndexOf(x) == -1)
            {
                return true;
            }                                                  
            return false;     
        }
    }
}
