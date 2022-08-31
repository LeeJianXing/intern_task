using System;

namespace Task1
{
    public abstract class GeometricFigures
    {   
        public abstract void Move(double x,double y);
        public abstract void Rotate(double x,double y,double z);
        public abstract void PrintShapePos();
    }
    public class Point:GeometricFigures
    {
        public double px,py;

        public point(double x,double y)
        {
            this.px = x;
            this.py = y;
        }
        public override void Move(double x ,double y)
        {
            this.px += x;
            this.py += y;
        }
        public override void PrintShapePos()
        {
            Console.WriteLine("Point coordinate is at {0} , {1}",this.px,this.py);
        }

    }
    public class Line:GeometricFigures
    {
        public double lx,ly;

        public line(double x,double y)
        {
            this.lx = x;
            this.ly = y;      
        }
        public override void Move(double x, double y)
        {
            this.lx += x;
            this.ly += y;   
        }
        public override void PrintShapePos()
        {
            Console.WriteLine("Line coordinate is at {0} , {1}",lx,ly);
        }   
    }
    public class Circle:GeometricFigures
    {
        public double cx,cy;

        public Circle(x,y)
        {
           this.cx = x;
           this.cy = y;
        }
        public override void Move(double x ,double y)
        {
           this.cx += x;
           this.cy += y;
        }
        public override void PrintShapePos()
        {
           Console.WriteLine("Circle coordinate is at {0} , {1}",cx,cy);
        } 
    }
    public class Aggregation:GeometricFigures
    {
        

    }
}

