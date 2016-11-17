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
    public partial class PrimeGen : Form
    {
        PrimeFinder primeFinder = new PrimeFinder();
        public PrimeGen()
        {
            InitializeComponent();
            panel1.Size = new Size(size*20, size*20);
            ClientSize = new Size(size*20 + 180, 180 + size*20);
            
            //
            primeFinder.GetPrime(10000).ToString();
        }

        private static int size = 10;
        
        private long currentSeed = 0;
        bool[,] board = new bool[size,size];

        private void textBoxSeed_TextChanged(object sender, EventArgs e)
        {
            bool parse = long.TryParse(textBoxSeed.Text, out currentSeed);
            if (parse)
            {
                currentSeed = MakeSeed(currentSeed);
                labelActualSeed.Text = currentSeed.ToString();
                int hp = (int)(currentSeed % (double)primeFinder.GetPrime(10) / primeFinder.GetPrime(10) * 95 + 5);
                textBoxHP.Text = hp.ToString();
                int mp = (int)(currentSeed % (double)primeFinder.GetPrime(15) / primeFinder.GetPrime(15) * 45 + 5);
                textBoxMP.Text = mp.ToString();
                int attack = (int)(currentSeed % (double)primeFinder.GetPrime(20) / primeFinder.GetPrime(20) * 19 + 1);
                textBoxAttack.Text = attack.ToString();
                int defense = (int)(currentSeed % (double)primeFinder.GetPrime(25) / primeFinder.GetPrime(25) * 19 + 1);
                textBoxDefense.Text = defense.ToString();
                int speed = (int)(currentSeed % (double)primeFinder.GetPrime(30) / primeFinder.GetPrime(30) * 4 + 1);
                textBoxSpeed.Text = speed.ToString();
                int[,] x = new int[size, size];
                int[,] y = new int[size, size];
                int number = 0;
                for (int k = 0; k < size; k++)
                {
                    for (int l = 0; l < size; l++)
                    {
                        x[k, l] = (int)(currentSeed % (double)primeFinder.GetPrime(number + 100) / primeFinder.GetPrime(number + 100) * 20);
                        y[k, l] = (int)(currentSeed % (double)primeFinder.GetPrime(number + 200) / primeFinder.GetPrime(number + 200) * 20);
                        number ++;
                    }
                }
                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                    {
                        board[i, j] = x[i, j] % 2 == 0 || y[i, j] % 2 == 0;
                    }
            }
            
            panel1.Invalidate();
        }

        private static long MakeSeed(long seed)
        {
            if (seed < 0)
                seed -= 7 * 3468667;
            else
                seed += 7 * 3468667;
                switch (seed%10)
                {
                    //all numbers are primes, taken from: https://primes.utm.edu/lists/small/small.html#10
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
                }
            
        }
    }

    public class PrimeFinder
    {
        private int lastPrimeCount = 3;

        public List<int> PrimeList { get; } = new List<int> {2,3,5};

        public int GetPrime(int nr)
        {
            if (nr > PrimeList.Count)
                GeneratePrimesUntil(nr);
            return PrimeList[nr - 1];
        }

        public void ShowPrimes()
        {
            string result = "[1] " + PrimeList[0];
            for (int i = 1; i < PrimeList.Count; i++)
                result += ", [" + (i + 1) + "] " + PrimeList[i];
            MessageBox.Show(result);
        }

        private void GeneratePrimesUntil(int nr)
        {
            double currentNr = PrimeList.Last() + 1;
            while (lastPrimeCount < nr)
            {
                int root = (int)Math.Sqrt(currentNr);
                bool isPrime = true;
                if (currentNr%2 == 1)
                {
                    
                    for (int count = (root / 2) * 2 + 1; count >= 3; count-= 2)
                    {
                        if (currentNr%count == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                }
                else
                {
                    isPrime = false;
                }
                if (isPrime)
                {
                    lastPrimeCount++;
                    PrimeList.Add((int)currentNr);
                }
                currentNr++;
            }
        }
    }
}
