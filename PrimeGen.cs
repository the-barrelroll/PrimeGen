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
        private PrimeFinder primeFinder = new PrimeFinder();
        private int size;
        private long currentSeed;
        private bool[,] board;

        //Sets a few basic variables and finds the first 10000 primes
        public PrimeGen()
        {
            InitializeComponent();
            textBoxSize.Text = "20";
            primeFinder.GetPrime(10000).ToString();
        }//PrimeGen
        
        //generates a random seed
        private void buttonRandom_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            textBoxSeed.Text = (Math.Round((float) random.NextDouble(), 8) * 100000000).ToString();
        }//buttonRandom_Click

        //Checks 10000 random seeds to check the distribution
        private void buttonCheck10000_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            double[,] boardworth = new double[size,size];
            for (int i = 0; i < 1000; i++)
            {
                textBoxSeed.Text = (Math.Round((float)random.NextDouble(), 8) * 100000000).ToString();
                for (int j = 0; j < size; j++)
                    for (int k = 0; k < size; k++)
                        if (board[j, k])
                            boardworth[j, k]++;
            }
            double res = 0;
            foreach (var i in boardworth)
            {
                res += i;
            }
            MessageBox.Show(res/(size*size)/10 + @"%");
        }//buttonCheck10000_Click

        //Changes the size
        private void textBoxSize_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBoxSize.Text, out size);
            ClientSize = new Size(Math.Max(180 + size * 20, 380), Math.Max(180 + size * 20, 380));
            panelMap.Invalidate();
            board = new bool[size, size];
            panelMap.Size = new Size(size * 20, size * 20);
        }//textBoxSize_TextChanged

        //Generate everything based on the number that was put in
        private void textBoxSeed_TextChanged(object sender, EventArgs e)
        {
            bool parse = long.TryParse(textBoxSeed.Text, out currentSeed);
            if (parse)
            {
                currentSeed = MakeSeed(currentSeed);
                labelActualSeed.Text = currentSeed.ToString();
                int hp = (int)(currentSeed % (double)primeFinder.GetPrime(10) / primeFinder.GetPrime(10) * 96 + 5);
                textBoxHP.Text = hp.ToString();
                int mp = (int)(currentSeed % (double)primeFinder.GetPrime(15) / primeFinder.GetPrime(15) * 46 + 5);
                textBoxMP.Text = mp.ToString();
                int attack = (int)(currentSeed % (double)primeFinder.GetPrime(20) / primeFinder.GetPrime(20) * 20 + 1);
                textBoxAttack.Text = attack.ToString();
                int defense = (int)(currentSeed % (double)primeFinder.GetPrime(25) / primeFinder.GetPrime(25) * 20 + 1);
                textBoxDefense.Text = defense.ToString();
                int speed = (int)(currentSeed % (double)primeFinder.GetPrime(30) / primeFinder.GetPrime(30) * 5 + 1);
                textBoxSpeed.Text = speed.ToString();
                int[,] x = new int[size, size];
                int[,] y = new int[size, size];
                int number = 0;
                //Makes 2 matrices which later get used to see whether the bool should be true of false (used in drawing the map)
                for (int k = 0; k < size; k++)
                {
                    for (int l = 0; l < size; l++)
                    {
                        x[k, l] = (int)(currentSeed % (double)primeFinder.GetPrime(number + 100) / primeFinder.GetPrime(number + 100) * 20);
                        number++;
                        y[k, l] = (int)(currentSeed % (double)primeFinder.GetPrime(number + 200) / primeFinder.GetPrime(number + 200) * 20);
                        number++;
                    }
                }
                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                    {
                        board[i, j] = x[i, j] % 2 == 0 || y[i, j] % 2 == 0;
                    }
            }
            panelMap.Invalidate();
        }//textBoxSeed_TextChanged

        //Paints the map
        private void panelMap_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (board[i, j])
                        e.Graphics.FillRectangle(Brushes.Black, i * 20, j * 20, 20, 20);
                    else
                        e.Graphics.FillRectangle(Brushes.White, i * 20, j * 20, 20, 20);
        }//panelMap_Paint

        //Makes a more interestin seed out of the given number
        private static long MakeSeed(long seed)
        {
            if (seed < 0)
                seed -= 7 * 3468667;
            else
                seed += 7 * 3468667;
            switch (seed % 10)
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
        }//MakeSeed
    }

    public class PrimeFinder
    {
        public List<int> PrimeList { get; } = new List<int> { 2, 3, 5 };
        //What nr was the last prime found
        private int lastPrimeCount = 3;

        //Get a certain prime. If the prime is not in the list, it will generate until there
        public int GetPrime(int nr)
        {
            if (nr > PrimeList.Count)
                GeneratePrimesUntil(nr);
            return PrimeList[nr - 1];
        }//GetPrime

        //Shows a messagebox with all the current primes
        public void ShowPrimes()
        {
            string result = "[1] " + PrimeList[0];
            for (int i = 1; i < PrimeList.Count; i++)
                result += ", [" + (i + 1) + "] " + PrimeList[i];
            MessageBox.Show(result);
        }//ShowPrimes

        //Generates primes until the asked nr
        private void GeneratePrimesUntil(int nr)
        {
            //Where to start looking for primes
            double currentNr = PrimeList.Last() + 2;
            while (lastPrimeCount < nr)
            {
                //Starts checkking from the rounded root + 1, because that's the most efficient
                int root = (int)Math.Sqrt(currentNr) / 2 * 2 + 1;
                bool isPrime = true;
                //Actual check to see if a number is prime or not
                for (int count = root; count >= 3; count-= 2)
                {
                    if (currentNr%count == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                //Adds the number if it is a prime
                if (isPrime)
                {
                    lastPrimeCount++;
                    PrimeList.Add((int)currentNr);
                }
                currentNr += 2;
            }
        }//GeneratePrimesUntil
    }
}
