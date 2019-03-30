using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Ismaylova.Task_1
{  
   public class ReaderFile
    {
        private const string FileIn = "input.txt";
        private const string FileOut = "output.txt";

        public List<Point> Reader()
        {
            List<double> coordinates = new List<double>();
            List<Point> points = new List<Point>();
            using (StreamReader fileIn = new StreamReader(FileIn))
            {
                string[] FromFile = fileIn.ReadToEnd().Split(new[] { ' ', ',', '\r', '\n', ';', '(', ')', 'A', 'B', 'C', '=' },
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(item => item.Trim())
                    .Where(item => !string.IsNullOrEmpty(item)).ToArray();
                foreach (var s in FromFile)
                {
                    if (!double.TryParse(s, out var value))
                    {
                        throw new ArgumentException("Error in reading data");
                    }
                    else
                    {
                        coordinates.Add(value);
                    }
                }
            }
            if (coordinates.Count != 6)
            {
                throw new ArgumentException("Error in reading data");
            }
            else
            {
                for (int i = 0; i < coordinates.Count; i += 2)
                    points.Add(new Point(coordinates[i], coordinates[i + 1]));
                return points;
            }
        }

        public void Out(double p, double s)
        {
            using (StreamWriter fileOut = new StreamWriter(FileOut))
            {
                fileOut.WriteLine("Perimeter of a triangle {0}", p);
                fileOut.WriteLine("Area of a triangle {0}", s);
            }
        }
    }
}
