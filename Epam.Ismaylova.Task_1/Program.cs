using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Ismaylova.Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            ReaderFile reader = new ReaderFile();
            List<Point> coordinates = new List<Point>(reader.Reader());
            Triangle triangle = new Triangle(coordinates);
            reader.Out(triangle.Perimetr,triangle.Square);
        }
    }
}
