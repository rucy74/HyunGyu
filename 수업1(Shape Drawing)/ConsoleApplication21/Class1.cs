using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication21
{
    public class Shape
    {
        protected int X { get; private set; }
        protected int Y { get; private set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public Shape(int x,int y)
        {
            X = x;
            Y = y;
        }

        public virtual void Draw()
        {
            Console.WriteLine("Performing base class drawing tasks");
        }
    }
    class Circle : Shape
    {
        public Circle(int height, int width,int x, int y) : base(x,y)
        {
            Height = height;
            Width = width;
        }            

        public override void Draw()
        {
            for (int i = Height; i >= 0; i--) 
            {
                for (int j = 0; j <= Width; j++) 
                {
                    if (( ((Y - i) * (Y - i)) * ((Width * Width)) + ( ((X - j) * (X - j)) * ((Height * Height)) ) ) 
                        <= (Width*Width*Height*Height/4)) Console.Write("* ");
                    else Console.Write("  ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("Drawing a Circle");
            base.Draw();
        }
    }
    class Rectangle : Shape
    {
        public Rectangle(int height, int width, int x, int y) : base(x,y)
        {
            Height = height;
            Width = width;
        }
        public override void Draw()
        {
            for (int i = Height; i >=0; i--)
            {
                for (int j = 0; j <= Width; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("Drawing a Rectangle");
            base.Draw();
        }
    }
    class Triangle : Shape
    {
        private int Length { get; set; }
        public Triangle(int height, int width,int length, int x, int y) : base(x,y)
        {
            Height = height;
            Width = width;
            Length = length;
        }
        public override void Draw()
        {
            for (int i = Height; i >= 0; i--)
            {
                for (int j = 0; j <= Width; j++) // (Height)*x - (Length - Width) * y = (Height * Width)
                {
                    if (
                        /*( Math.Abs( -Height * X + Length * Y) / Math.Sqrt((Height* Height) + (Length * Length))) <
                        (Math.Abs(-Height * j+ Length * i) / Math.Sqrt((Height * Height) + (Length * Length))) &&
                        (Math.Abs(Height * X + (Width - Length) * Y + (Height * Width)) / Math.Sqrt((Height * Height) + (Length - Width) * (Length - Width))) >
                        (Math.Abs(Height * j + (Width - Length) * i + (Height * Width)) / Math.Sqrt((Height * Height) + (Length - Width) * (Length - Width))))*/
                        (Length*i - Height*j <= 0) && ((Length - Width) * i <= Height * ( j - Width)))
                        Console.Write("* ");
                    else Console.Write("  ");
                }
                Console.WriteLine(""); 
            }
            Console.WriteLine("Drawing a Triangle");
            base.Draw();
        }
    }
}

