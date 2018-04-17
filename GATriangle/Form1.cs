using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GATriangle
{
    public partial class Form1 : Form
    {
        const float pOfCrossover = 0.7f;
        const float pOfMutation = 0.2f;
        const int numOfTriangles = 160;
        const int sizeOfPopulation = 30;
        Random rand = new Random();

        Bitmap[] bmp = new Bitmap[sizeOfPopulation];
        Bitmap bestBmp = new Bitmap(80, 80);
        Bitmap displayBmp = new Bitmap(80, 80);
        Bitmap bmpFirefox;
        Triangles[] newTriangles;

        float[] colorDistance = new float[sizeOfPopulation];
        float currentBestColorDistance;
        float bestColorDistance;
        float[] fitValue = new float[sizeOfPopulation];
        int best = -1;
        int recordIterationTimes = 0;
        bool needSave = false;

        public Form1()
        {
            InitializeComponent();
            bmpFirefox = new Bitmap(firefoxPicture.Image);
            startIteration.Enabled = false;
            endIteration.Enabled = false;
        }

        private void InitPop()
        {
            newTriangles = new Triangles[sizeOfPopulation];
            for (int i = 0; i < newTriangles.Length; i++)
            {
                newTriangles[i] = new Triangles(rand, numOfTriangles);
            }
        }

        private void DrawTriangles()
        {
            bmp[0] = new Bitmap(80, 80);
            SolidBrush brush = new SolidBrush(Color.Black);

            for (int i = 1; i < bmp.Length; i++)
            {
                bmp[i] = bmp[0];
            }

            for (int i = 0; i < bmp.Length; i++)
            {
                Graphics g = Graphics.FromImage(bmp[i]);
                for (int j = 0; j < newTriangles[i].Count; j++)
                {
                    brush.Color = Color.FromArgb(100, newTriangles[i].TArray[j].Color);
                    g.FillPolygon(brush, newTriangles[i].TArray[j].Points);
                }
            }
        }

        private void CalFitValue()
        {
            long rMean = 0;
            long r = 0;
            long g = 0;
            long b = 0;

            for (int i = 0; i < colorDistance.Length; i++)
            {
                colorDistance[i] = 0;
            }

            for (int i = 0; i < newTriangles.Length; i++)
            {
                for (int j = 1; j < 80; j++)
                {
                    for (int k = 1; k < 80; k++)
                    {
                        rMean = (bmp[i].GetPixel(j, k).R + bmpFirefox.GetPixel(j, k).R) / 2;
                        r = bmp[i].GetPixel(j, k).R - bmpFirefox.GetPixel(j, k).R;
                        g = bmp[i].GetPixel(j, k).G - bmpFirefox.GetPixel(j, k).G;
                        b = bmp[i].GetPixel(j, k).B - bmpFirefox.GetPixel(j, k).B;
                        colorDistance[i] += (long)Math.Sqrt((((512 + rMean) * r * r) >> 8) + 
                            4 * g * g + (((767 - rMean) * b * b) >> 8));
                    }
                }
            }

            Best();
            for (int i = 0; i < fitValue.Length; i++)
            {
                fitValue[i] = colorDistance[i] - currentBestColorDistance * 0.95f;
            }
            for (int i = 0; i < fitValue.Length; i++)
            {
                fitValue[i] = 1 / fitValue[i];
            }

            float sum = 0;
            for (int i = 0; i < fitValue.Length; i++)
            {
                sum += fitValue[i];
            }
            for (int i = 0; i < fitValue.Length; i++)
            {
                fitValue[i] = fitValue[i] / sum;
            }
        }

        private void Best()
        {
            float min = 1e+37f;
            for (int i = 0; i < colorDistance.Length; i++)
            {
                if (colorDistance[i] < min)
                {
                    min = colorDistance[i];
                    best = i;
                }
            }

            currentBestColorDistance = min;
            if (recordIterationTimes == 0)
            {
                bestColorDistance = min;
            }

            if (currentBestColorDistance < bestColorDistance)
            {
                bestColorDistance = currentBestColorDistance;
                bestBmp = bmp[best];
                needSave = true;
            }
        }

        private void SelectNext()
        {
            Triangles[] tempTriangles = new Triangles[sizeOfPopulation];

            List<float> randList = new List<float>();
            for (int i = 0; i < sizeOfPopulation; i++)
            {
                randList.Add((float)rand.NextDouble());
            }
            randList.Sort();

            // Example: 0.1 0.2 0.3 0.4 ... → 0.1 0.3 0.6 1.0 ...
            float[] pFitValue = new float[sizeOfPopulation];
            float sum;
            for (int i = 0; i < sizeOfPopulation; i++)
            {
                sum = 0;
                for (int j = 0; j < i + 1; j++)
                {
                    sum += fitValue[j];
                }
                pFitValue[i] = sum;
            }
            pFitValue[sizeOfPopulation - 1] = 1.0f;

            // 
            int m = 0;
            int n = 0;
            while (m < sizeOfPopulation)
            {
                if (randList[m] < pFitValue[n])
                {
                    tempTriangles[m] = newTriangles[n];
                    m++;
                }
                else
                {
                    n++;
                }
            }

            newTriangles = tempTriangles;
        }

        private void Crossover()
        {
            Triangles[] tempTriangles = new Triangles[sizeOfPopulation];
            int cPoint;
            Triangles temp = new Triangles(numOfTriangles);

            for (int i = 0; i < sizeOfPopulation - 1; i += 2)
            {
                if (rand.NextDouble() < pOfCrossover)
                {
                    cPoint = rand.Next(numOfTriangles);
                    for (int j = 0; j < cPoint; j++)
                    {
                        temp.TArray[j] = newTriangles[i].TArray[j];
                    }
                    for (int j = cPoint; j < numOfTriangles; j++)
                    {
                        temp.TArray[j] = newTriangles[i + 1].TArray[j];
                    }
                    tempTriangles[i] = temp;

                    for (int j = 0; j < cPoint; j++)
                    {
                        temp.TArray[j] = newTriangles[i + 1].TArray[j];
                    }
                    for (int j = cPoint; j < numOfTriangles; j++)
                    {
                        temp.TArray[j] = newTriangles[i].TArray[j];
                    }
                    tempTriangles[i + 1] = temp;
                }
                else
                {
                    tempTriangles[i] = newTriangles[i];
                    tempTriangles[i + 1] = newTriangles[i + 1];
                }
            }

            newTriangles = tempTriangles;
        }

        private void Mutation()
        {
            Triangles[] tempTriangles = new Triangles[sizeOfPopulation];
            int mPoint;

            for (int i = 0; i < sizeOfPopulation; i++)
            {
                if (rand.NextDouble() < pOfMutation)
                {
                    tempTriangles[i] = newTriangles[i];
                    for (int j = 0; j < 10; j++)
                    {
                        mPoint = rand.Next(numOfTriangles);
                        tempTriangles[i].TArray[mPoint].ChangePoints(rand);
                    }
                }
                else
                {
                    tempTriangles[i] = newTriangles[i];
                }
            }

            newTriangles = tempTriangles;
        }

        private void drawTriangle_Click(object sender, EventArgs e)
        {
            drawTriangle.Enabled = false;
            InitPop();
            DrawTriangles();
            CalFitValue();

            bestBmp = bmp[best];
            trianglesPicture.Image = bestBmp;
            startIteration.Enabled = true;

            string fileName = @"D:\Downloads\GATriangles1\init_Iteration.bmp";
            bestBmp.Save(fileName);
        }

        private void startIteration_Click(object sender, EventArgs e)
        {
            endIteration.Enabled = true;
            string fileName;

            for (int i = 0; i < addIterationTimes.Value; i++)
            {
                recordIterationTimes++;
                iterationTimes.Text = recordIterationTimes.ToString();
                SelectNext();
                Crossover();
                Mutation();

                DrawTriangles();
                CalFitValue();

                if (needSave)
                {
                    fileName = @"D:\Downloads\GATriangles\" +
                        (i + 1).ToString() + "th_Iteration.bmp";
                    trianglesPicture.Image = bestBmp;
                    bestBmp.Save(fileName);
                    needSave = false;
                }
            }

            trianglesPicture.Image = bestBmp;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void endIteration_Click(object sender, EventArgs e)
        {
            // Clear the image
            bmp[0] = new Bitmap(80, 80);
            trianglesPicture.Image = bmp[0];

            // Reset information displayed
            drawTriangle.Enabled = true;
            addIterationTimes.Value = 0;
            iterationTimes.Text = 0.ToString();

            // Reset population
            newTriangles = null;
        }
    }
}
