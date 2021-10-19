using AssignmentProject.Model;
using System;
using System.Collections.Generic;

namespace AssignmentProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Drink soda = new Drink(15, "Soda");
            List<Product> testProducts = new List<Product>();
            testProducts.Add(soda);
            VendingMachine vendingMachineP = new VendingMachine(testProducts);
            Drink purchasedSoda = vendingMachineP.Purchase(soda) as Drink;
            Console.WriteLine(purchasedSoda.Examine().Item1);
        }
    }
}
