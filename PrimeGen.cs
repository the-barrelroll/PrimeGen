using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        private bool[,] board = new bool[0,0];

        //Sets a few basic variables and finds the first 10000 primes
        public PrimeGen()
        {
            InitializeComponent();
            textBoxSize.Text = "20";
            primeFinder.GetPrimeAtIndex(10000);
            //MessageBox.Show(primeFinder.PrimeList.Last().ToString());
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
            for (int i = 0; i < 10000; i++)
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
            MessageBox.Show(res/(size*size)/100 + @"%");
        }//buttonCheck10000_Click

        //Changes the size
        private void textBoxSize_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBoxSize.Text, out size);
            ClientSize = new Size(Math.Max(180 + size * 20 + 400, 380), Math.Max(180 + size * 20 + 400, 380));
            panelMap.Invalidate();
            board = new bool[size, size];
            panelMap.Size = new Size(size * 20 + 400, size * 20 + 400);
        }//textBoxSize_TextChanged

        //Generate everything based on the number that was put in
        private void textBoxSeed_TextChanged(object sender, EventArgs e)
        {
            bool parse = long.TryParse(textBoxSeed.Text, out currentSeed);
            if (parse)
            {
                currentSeed = MakeSeed(currentSeed);
                labelActualSeed.Text = currentSeed.ToString();
                int hp = (int)(currentSeed % (double)primeFinder.GetPrimeAtIndex(10) / primeFinder.GetPrimeAtIndex(10) * 96 + 5);
                textBoxHP.Text = hp.ToString();
                int mp = (int)(currentSeed % (double)primeFinder.GetPrimeAtIndex(15) / primeFinder.GetPrimeAtIndex(15) * 46 + 5);
                textBoxMP.Text = mp.ToString();
                int attack = (int)(currentSeed % (double)primeFinder.GetPrimeAtIndex(20) / primeFinder.GetPrimeAtIndex(20) * 20 + 1);
                textBoxAttack.Text = attack.ToString();
                int defense = (int)(currentSeed % (double)primeFinder.GetPrimeAtIndex(25) / primeFinder.GetPrimeAtIndex(25) * 20 + 1);
                textBoxDefense.Text = defense.ToString();
                int speed = (int)(currentSeed % (double)primeFinder.GetPrimeAtIndex(30) / primeFinder.GetPrimeAtIndex(30) * 5 + 1);
                textBoxSpeed.Text = speed.ToString();
                bool[,] x = new bool[size, size];
                bool[,] y = new bool[size, size];
                board = new bool[size + 20,size + 20];
                for(int i = 0; i < size + 20; i++)
                    for (int j = 0; j < size + 20; j++)
                        board[i, j] = false;
                //int number = 0;
                //Makes 2 matrices which later get used to see whether the bool should be true of false (used in drawing the map)
                /*for (int k = 0; k < size; k++)
                {
                    for (int l = 0; l < size; l++)
                    {
                        x[k, l] = (int)(currentSeed % (double)primeFinder.GetPrimeAtIndex(number + 100) / primeFinder.GetPrimeAtIndex(number + 100) * 100) % 2 == 0;
                        number++;
                        y[k, l] = (int)(currentSeed % (double)primeFinder.GetPrimeAtIndex(number + 200) / primeFinder.GetPrimeAtIndex(number + 200) * 100) % 2 == 1;
                        number++;
                    }
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        board[i, j] = x[i, j] || y[i, j];
                    }
                }*/
                Room[] rooms = new Room[(int)(currentSeed % (double)primeFinder.GetPrimeAtIndex(4000) / primeFinder.GetPrimeAtIndex(4000) * size/2 + 4)];
                for (int i = 0; i < rooms.Length; i++)
                {
                    rooms[i] = new Room();
                    rooms[i].roomsize = (int)(currentSeed%(double) primeFinder.GetPrimeAtIndex(4100 + i)/primeFinder.GetPrimeAtIndex(4100 + i) * (size) + 4);
                    rooms[i].roomwidth = (int) (currentSeed%(double) primeFinder.GetPrimeAtIndex(4200 + i)/primeFinder.GetPrimeAtIndex(4200 + i) * (rooms[i].roomsize - 4) + 2);
                    rooms[i].roomheigth = rooms[i].roomsize - rooms[i].roomwidth;
                    rooms[i].roomx = (int)(currentSeed % (double)primeFinder.GetPrimeAtIndex(4300 + i) / primeFinder.GetPrimeAtIndex(4300 + i) * 
                        size);
                    rooms[i].roomy = (int)(currentSeed % (double)primeFinder.GetPrimeAtIndex(4400 + i) / primeFinder.GetPrimeAtIndex(4400 + i) *
                        size);
                    //MessageBox.Show(rooms[i].roomwidth + " " + rooms[i].roomheigth + " " + rooms[i].roomx + " " +
                      //              rooms[i].roomy);
                }
                foreach (Room room in rooms)
                {
                    for (int i = room.roomx; i < room.roomwidth + room.roomx && i < size + 20; i++)
                    {
                        for (int j = room.roomy; j < room.roomheigth + room.roomy && j < size + 20; j++)
                        {
                            board[i, j] = true;
                        }
                    }
                }
            }
            panelMap.Invalidate();
        }//textBoxSeed_TextChanged

        //Paints the map
        private void panelMap_Paint(object sender, PaintEventArgs e)
        {
            Panel obj = (Panel) sender;
            e.Graphics.FillRectangle(Brushes.White, 0, 0, obj.Width, obj.Height);
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                    if (board[i, j])
                        e.Graphics.FillRectangle(Brushes.Black, i * 20, j * 20, 20, 20);
                    //else
                      //  e.Graphics.FillRectangle(Brushes.White, i * 20, j * 20, 20, 20);
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

    public class Room
    {
        public int roomsize, roomwidth, roomheigth, roomx, roomy;

    }

    public class PrimeFinder
    {
        public List<int> PrimeList { get; } = new List<int> { 2, 3, 5 };
        //What nr was the last prime found
        
        //Checks if the specified number is a prime
        private void CheckPrime(double currentNr)
        {
            //Starts checkking from the rounded root + 1, because that's the most efficient
            int root = (int)Math.Sqrt(currentNr) / 2 * 2 + 1;
            bool isPrime = true;
            //Actual check to see if a number is prime or not
            int lim = GetIndexOfPrime(root);
            for (int count = 0; count <= lim; count++)
            {
                if (currentNr % PrimeList[count] == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            //Adds the number if it is a prime
            if (isPrime)
            {
                PrimeList.Add((int)currentNr);
            }
        }//CheckPrime

        //Generates primes until the asked index
        private void GeneratePrimesUntilIndex(int nr)
        {
            //Where to start looking for primes
            double currentNr = PrimeList.Last() + 2;
            while (PrimeList.Count < nr)
            {
                CheckPrime(currentNr);
                currentNr += 2;
            }
        }//GeneratePrimesUntilIndex

        //Generates prime until the asked nr
        public void GeneratePrimesUntilNumber(int nr)
        {
            double currentNr = PrimeList.Last() + 2;
            while (PrimeList.Last() < nr)
            {
                CheckPrime(currentNr);
                currentNr += 2;
            }
        }//GeneratePrimesUntilNumber

        //Get a certain prime. If the prime is not in the list, it will generate until there
        public int GetPrimeAtIndex(int nr)
        {
            if (nr > PrimeList.Count)
                GeneratePrimesUntilIndex(nr);
            return PrimeList[nr - 1];
        }//GetPrimeAtIndex

        //Gets the index of the given prime. returns -1 if not found
        public int GetIndexOfPrime(int nr)
        {
            return PrimeList.FindIndex(x => x >= nr);
        }//GetIndexOfPrime

        //Finds the next closest prime of the given number
        public int ClosestNextPrime(int nr)
        {
            return PrimeList.Find(x => x >= nr);
        }//ClosestNextPrime

        //Shows a messagebox with all the current primes
        public void ShowPrimes()
        {
            string result = "[1] " + PrimeList[0];
            for (int i = 1; i < PrimeList.Count; i++)
                result += ", [" + (i + 1) + "] " + PrimeList[i];
            MessageBox.Show(result);
        }//ShowPrimes
    }
}
