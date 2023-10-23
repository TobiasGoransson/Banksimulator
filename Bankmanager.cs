using Banksimulator_SOS23;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Banksimulator_SOS23
{



    internal class Bankmanager
    {
        int pinTry = int.MaxValue;
        bool meny1 = true;
        int pinAttempts;

        List<Account> accounts = new List<Account>();               //Lista på konton

        public Bankmanager()
        {
            accounts.Add(new Account("Salery", 5454, 25000));       //Konton som användaren startar med 
            accounts.Add(new Account("Savings", 1212, 60000));
            accounts.Add(new Account("Retirement", 8585, 90000));
            accounts.Add(new Account("Child1", 9696, 12000));
        }


        public void Run()
        {
            //Välkomstmeddelande
            Console.WriteLine("Welcome to the bank");            
            while (meny1 == true)
            {
                Console.WriteLine();                                //Grund meny loopar igenom alla konton som finns i listan
                Console.WriteLine("What would you like to do");
                Console.WriteLine();
                Console.WriteLine("Account name \t \t Account number");

                for (int i = 0; i < accounts.Count; i++)
                {
                    accounts[i].PrintInfo();
                }
                Console.WriteLine();
                Console.WriteLine("[O]pen a new account");          //Default alternativ i menyn
                Console.WriteLine();
                Console.WriteLine("[Q]uit");
                Console.WriteLine();

                string val1 = Console.ReadLine();                                   //läser in användarens val 
                val1 = val1.Substring(0, 1).ToUpper() + val1.Substring(1).ToLower(); //Gör om texten så att den matchar kontonamnens format

                pinAttempts = 0;
                for (int i = 0; i < accounts.Count; i++)                            //Loopar igenom listan med konto för att se vilket som kunden vill använda
                {
                    if (val1 == accounts[i].name || val1 == accounts[i].accountNo.ToString()) //Kunden kan välja om hon vill identifiera konto med namn eller kontonummer
                    {
                        bool pinEntered = TryPIN(accounts[i]);                                  // När kunden valt konto får hon föra in en pin funktionen Trypin kallas
                        if (pinEntered)
                        {
                            Meny2(accounts[i]);                                                 //Om trypin är true går vi vidare till meny2
                        }
                    }
                }
                if (val1 == "O")                                                                // väljer kunden ett O kallas funktionen Addaccount
                {
                    AddAccount();
                }
                if (val1 == "Q")                                                                // Väljer kunden Q kommer programmet att avslutas med en avskeds fras
                {
                    Console.WriteLine("Thank you for using us");
                    Console.WriteLine("Live long and prosper");
                    meny1 = false;
                }
                else if (pinAttempts<3)                                                         //Om kunden skriver in något som inte finns i menyen kommer denna text som förtydligar menyn att användas
                {                                                                               //Men endast om kunden inte skrivit in fel PIN 3ggr
                    Console.WriteLine();
                    Console.WriteLine("Invalid choice");
                    Console.WriteLine("Please enter \t account name or ");
                    Console.WriteLine("\t \t account number");
                    Console.WriteLine("\t \t [O] to open an account");
                    Console.WriteLine("\t \t [Q] to quit");
                    Console.WriteLine();
                }
                                
            }
        }



        private bool TryPIN(Account accounts)                                                   //funktionen som kollar pin 
        {
            bool pin = false;
            while (!pin && pinAttempts < 3)                                                     //när kunden gjort sitt val får hen föra in matchande PIN
            {                                                                                   //Om kunden skriver fel mer än 3ggr kommer vi tillbaka till huvudmenyn (meny1)

                try
                {
                    Console.WriteLine("Enter PIN");
                    pinTry = int.Parse(Console.ReadLine());
                    if (accounts.PIN == pinTry)
                    {
                        pin = true;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("You've entered the wrong PIN  ");
                        Console.WriteLine();
                        pinAttempts++;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid PIN");
                    Console.WriteLine("Your PIN can't only contain numbers");
                    pinAttempts++;
                }
            }
            if (pinAttempts >= 3)
            {
                Console.WriteLine();
                Console.WriteLine("You have entered the wrong PIN 3 times");
                Console.WriteLine("You will return to main menu");
                Console.WriteLine();
            }
            return pin;
        }


        private void Meny2(Account accounts)                                            //Funktionen meny2
        {
            bool meny2 = true;
            while (meny2)
            {
                Console.WriteLine();
                Console.WriteLine("What do you whant to do");                           //Väl inne på ett konto kan användaren välja vad som skall göras
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Balance");
                Console.WriteLine("9. Quit");
                try 
                { 
                    int val2 = int.Parse(Console.ReadLine());
                
                    switch (val2)
                    {
                        case 1:
                            HandleCash deposit = new HandleCash();
                            int sum = deposit.RunDeposit();                              //hämtar funktionen deposit från klassen HandleCash

                            accounts.balance += sum;                                     //Lägger till summan till kontots saldo
                            Console.WriteLine();
                            Console.WriteLine("Your new balance is " + accounts.balance);
                            break;

                        case 2:
                            HandleCash withDraw = new HandleCash();
                            int uttag = withDraw.RunWithDraw();                          //hämtar funktionen withDraw från klassen HandleCash                           
                            if (accounts.balance - uttag > 0)                            // kontrollerar om det finns tillräckligt med pengar på kontot
                            {
                                accounts.balance -= uttag;
                                Console.WriteLine();
                                Console.WriteLine("Your new balance is " + accounts.balance);
                                Console.WriteLine();
                            }
                            else if (accounts.balance - uttag < 0)
                            {
                                Console.WriteLine("You don't have enough fonds");
                                Console.WriteLine();
                            }
                            break;

                        case 3:                                                           //kolla saldo
                            Console.WriteLine("Your balance is " + accounts.balance);
                            Console.WriteLine();
                            break;

                        case 9:
                            meny2 = false;                                                //Går tillbaka till meny1
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Please only enter Numbers");
                }
            }
        }


        private void AddAccount()                                                           //Funktionen för att lägga till ett konto
        {
            Console.WriteLine("Name your account");
            string name = Console.ReadLine();
            name = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();            //kunden får välja ett namn och programmet gör om namnets 
            try                                                                             //så att det fr samma format som andra konton i listan
            {
                Console.WriteLine("asign a PIN kode");
                int pin = int.Parse(Console.ReadLine());

                HandleCash deposit = new HandleCash();                                      //när man sätter in pengar på det nya kontot kallas funktionen deposit från klassen HandleCash
                int balance = deposit.RunDeposit();

                accounts.Add(new Account(name, pin, balance));                              //Det nya kontot läggs till i listan
               
            }
            catch
            {
                Console.WriteLine("Your PIN neds to be numbers ");
            }
        }   
    }
}

        
