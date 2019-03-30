using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Ismaylova.Task_1
{
    public class Triangle
    {
        private Point _a;
        private Point _b;
        private Point _c;

        public Triangle(List <Point> coordinates)
        {
            Assert(coordinates);
        }
        
        public Point A { get { return _a; } set { if (ExistTrinagle(value, _b, _c)) _a = value; else { throw new ArgumentException("There is no such triangle."); } } }
        public Point B { get { return _b; } set { if (ExistTrinagle(_a, value, _c)) _b = value; else { throw new ArgumentException("There is no such triangle."); } } }
        public Point C { get { return _c; } set { if (ExistTrinagle(_a, _b, value)) _c = value; else { throw new ArgumentException("There is no such triangle."); } } }
        public void Assert(List<Point> coordinates)
        { 
            if ((ExistTrinagle(coordinates[0], coordinates[1], coordinates[2]))){
                _a = coordinates[0];
                _b = coordinates[1];
                _c = coordinates[2];
            }
            else {
                throw new ArgumentException("There is no such triangle.");
            }
        }

        public double Perimetr
        {
            get
            {
                return Length(A.x, A.y) + Length(B.x, B.y) + Length(C.x, C.y);
            }
        }
        public double Square
        {
            get
            {
                double p = Perimetr / 2;
                return Math.Sqrt(p * (p - Length(A.x, A.y)) * (p - Length(B.x, B.y)) * (p - Length(C.x, C.y)));
            }
        }

        private bool ExistTrinagle(Point A,Point B,Point C)
        {
            return (((Length(A.x, A.y) + Length(B.x, B.y)) > Length(C.x, C.y)) &&
                ((Length(A.x, A.y) + Length(C.x, C.y)) > Length(B.x, B.y)) &&
                ((Length(B.x, B.y) + Length(C.x, C.y)) > Length(A.x, A.y)));
        }

        private double Length(double x, double y)
        {
            return Math.Sqrt(x * x + y * y);
        }
    }
}
