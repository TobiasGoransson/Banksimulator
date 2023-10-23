using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banksimulator_SOS23
{
    internal class Account                                      //klass för att hantera konton
    {
        public string name { get; set; } = "h";
        public int accountNo { get; set; }
        public int PIN { get; set; } 
        public int balance { get; set; }


        

        public static int newAccountNo = 500646400;             //alla nya konton får ett löpnummer 

        public Account(string name, int PIN ,int balance)       //konstruktor för objekt account 
        {
            this.name = name;
            this.accountNo = newAccountNo++;
            this.PIN = PIN;
            this.balance = balance;
        }



        public void PrintInfo()                                 //funktion för att skriva ut kontona snyggt i meny1
        {
            if (name.Length <= 6)
            {
                Console.WriteLine(name + " \t\t\t " + accountNo);
            }
            else if (name.Length > 6 || name.Length <= 12)
            {
                Console.WriteLine(name + " \t\t " + accountNo);
            }
            else
            {
                Console.WriteLine(name + " \t " + accountNo);
            }

        }
        
    }
   




}


