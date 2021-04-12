using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    class Box
    {
        private const string INVALID_SIDE_EXC_MSG = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;            
        }

        public double Length 
        { 
            get
            {
                return length;
            }
            private set
            {
                ValidateInput(value, nameof(Length));
                length = value;
            }
        }
        public double Width
        { 
            get
            {
                return width;
            }
            private set
            {
                ValidateInput(value, nameof(Width));
                width = value;
            }
        }
        public double Height 
        { 
            get
            {
                return height;
            }
            private set
            {
                ValidateInput(value, nameof(Height));
                height = value;
            }
        }

        public double Volume => Height * Width * Length;

        public double LateralSurfaceArea => 2 * Length * Height + 2 * Width * Height;

        public double SurfaceArea => 2 * Length * Height + 2 * Length * Width + 2 * Height * Width;

        private void ValidateInput(double param, string paramName)
        {
            if (param <= 0)
            {
                throw new ArgumentException($"{String.Format(INVALID_SIDE_EXC_MSG, paramName)}");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {SurfaceArea:F2}");
            sb.AppendLine($"Lateral Surface Area - {LateralSurfaceArea:F2}");
            sb.AppendLine($"Volume - {Volume:F2}");
            return sb.ToString();
        }
    }
}
