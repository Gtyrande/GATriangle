using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GATriangle
{
    class Triangle
    {
        private PointF[] points = new PointF[3];
        private Color color;

        public Triangle(Random rand)
        {
            InitTriangle(rand);
        }

        public Color Color
        {
            get { return color; }
        }

        public PointF[] Points
        {
            get { return points; }
        }

        private void InitTriangle(Random rand)
        {
            float x1 = (float)(8 + 64 * rand.NextDouble());
            float x2 = x1 + rand.Next(-20, 21);
            float x3 = x1 + rand.Next(-20, 21);

            if (x2 > 80)
            {
                x2 = 80;
            }
            else if (x2 < 0)
            {
                x2 = 0;
            }

            if (x3 > 80)
            {
                x3 = 80;
            }
            else if (x3 < 0)
            {
                x3 = 0;
            }

            float y1 = (float)(8 + 64 * rand.NextDouble());
            float y2 = y1 + rand.Next(-20, 21);
            float y3 = y1 + rand.Next(-20, 21);

            if (y2 > 80)
            {
                y2 = 80;
            }
            else if (y2 < 0)
            {
                y2 = 0;
            }

            if (y3 > 80)
            {
                y3 = 80;
            }
            else if (y3 < 0)
            {
                y3 = 0;
            }

            points[0] = new PointF(x1, y1);
            points[1] = new PointF(x2, y2);
            points[2] = new PointF(x3, y3);

            color = Color.FromArgb(rand.Next(0,256), rand.Next(0, 256), rand.Next(0, 256));
        }

        public void ChangePoints(Random rand)
        {
            float x1 = (float)(8 + 64 * rand.NextDouble());
            float x2 = x1 + rand.Next(-20, 21);
            float x3 = x1 + rand.Next(-20, 21);

            if (x2 > 80)
            {
                x2 = 80;
            }
            else if (x2 < 0)
            {
                x2 = 0;
            }

            if (x3 > 80)
            {
                x3 = 80;
            }
            else if (x3 < 0)
            {
                x3 = 0;
            }

            float y1 = (float)(8 + 64 * rand.NextDouble());
            float y2 = y1 + rand.Next(-20, 21);
            float y3 = y1 + rand.Next(-20, 21);

            if (y2 > 80)
            {
                y2 = 80;
            }
            else if (y2 < 0)
            {
                y2 = 0;
            }

            if (y3 > 80)
            {
                y3 = 80;
            }
            else if (y3 < 0)
            {
                y3 = 0;
            }

            points[0].X = x1;
            points[1].X = x2;
            points[2].X = x3;
            points[0].Y = y1;
            points[1].Y = y2;
            points[2].Y = y3;

        }
    }
}
