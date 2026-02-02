using System;
using System.Collections.Generic;
using System.Text;

namespace Task1_point3D
{
    internal class Point3D : ICloneable, IComparable<Point3D>
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D() : this(0, 0, 0) { }
        public Point3D(double x, double y) : this(x, y, 0) { }
        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"Point Coordinattes : ({X}, {Y}, {Z})";
        }

        public override bool Equals(object? obj)
        {
            var right = obj as Point3D;
            if (right == null) return false;
            if(right.GetType() != this.GetType()) return false;
            return right.X == this.X && right.Y == this.Y && right.Z == this.Z ;

        }

        public int CompareTo(Point3D other)
        {
            double dis1 = Math.Sqrt(Math.Pow(this.X, 2) + Math.Pow(this.Y, 2) + Math.Pow(this.Z, 2));
            double dis2 = Math.Sqrt(Math.Pow(other.X, 2) + Math.Pow(other.Y, 2) + Math.Pow(other.Z, 2));
            return dis1.CompareTo(dis2);
        }

        public object Clone()
        {
            return new Point3D()
            {
                X = this.X,
                Y = this.Y,
                Z = this.Z,
            };
        }
    }
}