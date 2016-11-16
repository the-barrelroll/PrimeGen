using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generation_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel1.Size = new Size(size*20, size*20);
            ClientSize = new Size(size*20 + 180, 180 + size*20);
            PrimeFinder primeFinder = new PrimeFinder();
            MessageBox.Show(primeFinder.GetPrime(5).ToString());
            primeFinder.ShowPrimes();
            
        }

        private static int size = 10;
        //private PrimeList<int> primes = new PrimeList<int>();

        private long currentSeed = 0;
        bool[,] board = new bool[size,size];

        private void textBoxSeed_TextChanged(object sender, EventArgs e)
        {
            bool parse = long.TryParse(textBoxSeed.Text, out currentSeed);
            if (parse)
            {
                currentSeed = MakeSeed(currentSeed);
                labelActualSeed.Text = currentSeed.ToString();
                textBoxHP.Text = (currentSeed % 90 + 10).ToString();
                textBoxMP.Text = (currentSeed % 45 + 5).ToString();
                textBoxAttack.Text = (currentSeed % 19 + 1).ToString();
                textBoxDefense.Text = (currentSeed % 19 + 1).ToString();
                textBoxSpeed.Text = (currentSeed % 4 + 1).ToString();
                int[,] x = new int[size, size];
                int[,] y = new int[size, size];
                int number = 0;
                for (int k = 0; k < size; k++)
                {
                    for (int l = 0; l < size; l++)
                    {
                        x[k, l] = (int)currentSeed % (100 + number);
                        y[k, l] = (int)currentSeed % (200 + number);
                        number += k * l;
                    }
                }
                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                    {
                        board[i, j] = x[i, j] % 7 == 0 || y[i, j] % 7 == 0;
                    }
            }
            
            panel1.Invalidate();
        }

        private int Prime(int prime)
        {

            return prime;
        }

        private static long MakeSeed(long seed)
        {
            if (seed < 0)
                seed -= 7 * 3468667;
            else
                seed += 7 * 3468667;
                switch (seed%10)
                {
                    //all numbers are primes, takin from: https://primes.utm.edu/lists/small/small.html#10
                    case 0:
                        seed *= 3367900313;
                        break;
                    case 1:
                        seed *= 5915587277;
                        break;
                    case 2:
                        seed *= 1500450271;
                        break;
                    case 3:
                        seed *= 3267000013;
                        break;
                    case 4:
                        seed *= 5754853343;
                        break;
                    case 5:
                        seed *= 4093082899;
                        break;
                    case 6:
                        seed *= 9576890767;
                        break;
                    case 7:
                        seed *= 3628273133;
                        break;
                    case 8:
                        seed *= 2860486313;
                        break;
                    case 9:
                        seed *= 5463458053;
                        break;
                }
            return seed;
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            textBoxSeed.Text = (Math.Round((float) random.NextDouble(), 8) * 100000000).ToString();
            //textBoxSeed.Text = Random;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    if (board[i,j])
                        e.Graphics.FillRectangle(Brushes.Black, i * 20, j * 20, 20, 20);
                    else
                        e.Graphics.FillRectangle(Brushes.White, i * 20, j * 20, 20, 20);
                    //MessageBox.Show(i + j.ToString());
                }
            
        }
    }

    public class PrimeFinder
    {
        private List<int> primes = new List<int>();
        private int lastPrime = 3;
        private int lastPrimeCount = 2;

        public PrimeFinder()
        {
            primes.Add(1);
            primes.Add(2);
        }

        public int GetPrime(int nr)
        {
            if (nr > primes.Count)
                GeneratePrimesUntil(nr);
            return primes[nr - 1];
        }

        public void ShowPrimes()
        {
            string result = "[1] " + primes[0];
            for (int i = 1; i < primes.Count; i++)
                result += ", [" + (i + 1) + "] " + primes[i];
            MessageBox.Show(result);
        }

        private void GeneratePrimesUntil(int nr)
        {
            double currentNr = lastPrime;
            while (lastPrimeCount < nr)
            {
                double root = Math.Round(Math.Sqrt(currentNr), 8);
                bool isPrime = true;
                if (currentNr%2 == 1)
                {
                    for (double count = 2; count <= root; count++)
                    {
                        if (currentNr%count == 0)
                            isPrime = false;
                    }
                }
                else
                {
                    isPrime = false;
                }
                if (isPrime)
                {
                    lastPrimeCount++;
                    lastPrime = (int)currentNr;
                    primes.Add(lastPrime);
                }
                currentNr++;
            }
        }
    }
}
