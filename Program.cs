using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq.Expressions;

namespace Banksimulator_SOS23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bankmanager bankmanager = new Bankmanager();        //skapar objekt från klassen med samma namn för att kunna köra funktionen Run
            bankmanager.Run();
        }
    }
}