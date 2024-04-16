using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll_create_ellipse
{
    internal class Ellipse
    {
        public double X { get; set; } // Координата X центра
        public double Y { get; set; } // Координата Y центра
        public double MajorAxis { get; set; } // Длина большой оси
        public double MinorAxis { get; set; } // Длина малой оси
        public Color Color { get; set; } // Цвет линии
        public Color FillColor { get; set; } // Цвет заливки

        public Ellipse(double x, double y, double majorAxis, double minorAxis, Color color, Color fillColor)
        {
            X = x;
            Y = y;
            MajorAxis = majorAxis;
            MinorAxis = minorAxis;
            Color = color;
            FillColor = fillColor;
        }

        public double CalculateLength()
        {
            // Приближенная формула длины эллипса
            return Math.PI * (MajorAxis + MinorAxis);
        }

        public double CalculateArea()
        {
            return Math.PI * MajorAxis * MinorAxis;
        }

        public void Draw(Form form)
        {
            Graphics graphics = form.CreateGraphics();
            Pen pen = new Pen(Color, 2);
            SolidBrush brush = new SolidBrush(FillColor);
            graphics.DrawEllipse(pen, (float)(X - MajorAxis / 2), (float)(Y - MinorAxis / 2), (float)MajorAxis, (float)MinorAxis);
            graphics.FillEllipse(brush, (float)(X - MajorAxis / 2), (float)(Y - MinorAxis / 2), (float)MajorAxis, (float)MinorAxis);
        }
    }
}
