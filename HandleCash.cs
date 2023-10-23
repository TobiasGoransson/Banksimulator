using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banksimulator_SOS23
{
    internal class HandleCash
    {
        int tusen = int.MaxValue;
        int femHundra = int.MaxValue;
        int femtio = int.MaxValue;
        int hundra = int.MaxValue;
        int tjugo = int.MaxValue;
        int tio = int.MaxValue;
        int fem = int.MaxValue;
        int en = int.MaxValue;
        int uttag = int.MaxValue;
        int sum;

        public int RunDeposit()                                                                             //Funktion som hanterar alla insättningar
        {
            Console.WriteLine("How much money do you want to deposit and in which denominations");
            Console.WriteLine("How many thousand notes");
            tusen = int.Parse(Console.ReadLine());
            Console.WriteLine("How many fivehundred notes");
            femHundra = int.Parse(Console.ReadLine());
            Console.WriteLine("How many hundered notes");
            hundra = int.Parse(Console.ReadLine());
            Console.WriteLine("how many fifty notes");
            femtio = int.Parse(Console.ReadLine());
            Console.WriteLine("How many twenty notes");
            tjugo = int.Parse(Console.ReadLine());
            Console.WriteLine("How many tens");
            tio = int.Parse(Console.ReadLine());
            Console.WriteLine("How many fives");
            fem = int.Parse(Console.ReadLine());
            Console.WriteLine("How many ones");
            en = int.Parse(Console.ReadLine());

            sum = (tusen * 1000) + (femHundra * 500) + (hundra * 100) + (femtio * 50) + (tjugo * 20) + (tio * 10) + (fem * 5) + (en * 1); //summerar insättningen
            
            Console.WriteLine();
            Console.WriteLine("You whant to deposit ");
            Cash();                                                                                         //Funktionen Cash ger tillbaka en bekräftelse på vad du fört in
            return sum;
        }

        private void Cash()                                                                                 //Funktionen Cash ser också till att bara de valörer som nyttjas skrivs ut
        {
            
            if (tusen > 0)
            {
                Console.WriteLine(tusen + " thousands");
            }
            if (femHundra > 0)
            {
                Console.WriteLine(femHundra + " fivehundreds");
            }
            if (hundra > 0)
            {
                Console.WriteLine(hundra + " hundreds");
            }
            if (femtio > 0) 
            {
                Console.WriteLine(femtio + " fifties");
            }
            if (tjugo > 0)
            {
                Console.WriteLine(tjugo + " twenties");
            }
            if (tio > 0)
            {
                Console.WriteLine(tio + " tens");
            }
            if (fem > 0)
            {
                Console.WriteLine(fem + " fives");
            }
            if (en > 0)
            {
                Console.WriteLine(en + " ones");
            } 
            Console.WriteLine();
            Console.WriteLine("The Sum is " + sum);
        }
        public int RunWithDraw()                                                    //funktion som hanterar uttag 
        {
            Console.WriteLine("How much do you what to w");
            uttag = int.Parse(Console.ReadLine());

            tusen = uttag / 1000;                                                   //tar summan och räknar ut vilka valörer som kunden skall få tillbaka
            int rest1 = uttag % 1000;
            femHundra = rest1 / 500;
            int rest2 = rest1 % 500;
            hundra = rest2 / 100;
            int rest3 = rest2 % 100;
            femtio = rest3 / 50;
            int rest4 = rest3 % 50;
            tjugo = rest4 / 20;
            int rest5 = rest4 % 20;
            tio = rest5 / 10;
            int rest6 = rest5 % 10;
            fem = rest6 / 5;
            int rest7 = rest6 % 5;
            en = rest7 / 1;

            Console.WriteLine();
            Console.WriteLine("You will get ");
            Cash();                                                                  //Funktionen Cash ger tillbaka vilka valörer som kunden skall få tillbaka

            return uttag;
        }
    }
}
