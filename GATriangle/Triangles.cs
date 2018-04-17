using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GATriangle
{
    class Triangles
    {
        private Triangle[] triangles;

        public Triangles(Random rand, int numOfTriangles)
        {
            triangles = new Triangle[numOfTriangles];
            InitTriangles(rand);
        }

        public Triangles(int numOfTriangles)
        {
            triangles = new Triangle[numOfTriangles];
        }

        public int Count
        {
            get { return triangles.Length; }
        }

        public Triangle[] TArray
        {
            get { return triangles; }
            set { triangles = value; }
        }

        private void InitTriangles(Random rand)
        {
            for (int i = 0; i < triangles.Length; i++)
            {
                triangles[i] = new Triangle(rand);
            }
        }
    }
}
