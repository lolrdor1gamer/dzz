using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz
{
    class Program
    {
        public char symb;
        public char inp;
        public int CharX, CharY, dx, dy;
        Random rand = new Random();
        const int widht = 10;
        const int height = 10;
        int[,] pole = new int[widht,height];
        static void Main(string[] args)
        {
            Program pgm = new Program();
            pgm.start();
        }
        void start()
        {
            init();
            while (The_End() != true)
            {
                draw();
                input();
                logic();
            }
        }
        void draw()
        {
            for(int i=0; i<height;i++)
            {
                for(int j=0;j<widht;j++)
                {
                    if (CharX == j && CharY == i) Console.Write('@');
                    else Console.Write(pole[i, j]);

                }
            }
        }
        void init()
        {
            Console.WriteLine( "goint to init..." );
            int sharp_freq = 30;
            for(int i=0;i<height;i++)
            {
                for (int j = 0; j < widht; j++)
                {
                    int randomize = rand.Next(100);
                    if (randomize < sharp_freq)
                        symb = '#';
                    else
                        symb = ' ';
                    pole[i, j] = symb;
                        
                }
            }
            CharX = rand.Next(widht - 1);
            CharY = rand.Next(height - 1);
        }
        void input()
        {
            inp = (char)Console.Read();
            dx = 0;
            dy = 0;
            if(inp=='w'||inp=='W')
            {
                dy = -1;
            }
            if (inp == 'a' || inp == 'A')
            {
                dx = -1;
            }
            if (inp == 's' || inp == 'S')
            {
                dy = 1;
            }
            if (inp == 'd' || inp == 'D')
            {
                dx = 1;
            }        
        }
        bool The_End()
        {
            return false;
        }
        bool can_go(int newX,int NewY)
        {
            if (pole[newX, NewY] == '#') return false;
            if (newX < 0 || NewY < 0 || newX > widht || NewY > height) return false;
            return true;
        }
        void go(int newX, int NewY)
        {
            CharX = newX;
            CharY = NewY;
        }
        void try_go(int newX, int NewY)
        {
            if (can_go(newX, NewY)) go(newX, NewY);
        }
        void logic()
        {
            try_go(CharX + dx, CharY + dy);
        }
    }
}
