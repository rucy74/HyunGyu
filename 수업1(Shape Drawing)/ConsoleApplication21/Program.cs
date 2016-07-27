using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication21
{
    class Program
    {
        static void Main(string[] args)
        {
            const int height = 20;
            const int width = 20;
            List < Shape > shapes = new List<Shape>();
            shapes.Add(new Circle(height,width,width/2,height/2));
            shapes.Add(new Rectangle(height,width,width/2,height/2));
            shapes.Add(new Triangle(height,width,width/2,width/3,height/2));

            /*foreach(Shape s in shapes)
            {
                s.Draw();
            }*/
            shapes[2].Draw();

        }
    }
}
