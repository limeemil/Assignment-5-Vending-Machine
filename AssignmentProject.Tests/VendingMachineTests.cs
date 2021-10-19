using System;
using Xunit;
using AssignmentProject.Model;
using System.Collections.Generic;

namespace AssignmentProject.Tests
{
    public class VendingMachineTests
    {
        [Fact]
        public void ShouldPurchaseProduct()
        {
            Drink soda = new Drink(15, "Soda");
            Snack chocolate = new Snack(10, "Chocolate bar");
            List<Product> testProducts = new List<Product>();
            testProducts.Add(soda);
            VendingMachine vendingMachine = new VendingMachine(testProducts);

            Assert.Throws<ArgumentOutOfRangeException>(() => vendingMachine.Purchase(soda));
            vendingMachine.InsertMoney(50);
            Drink purchasedSoda = vendingMachine.Purchase(soda) as Drink;
            Assert.Equal(soda, purchasedSoda);
            Assert.Equal(35, vendingMachine.MoneyPool);
            Assert.Equal(soda.Use(), purchasedSoda.Use());

            Snack purchasedChocolate = vendingMachine.Purchase(chocolate) as Snack;
            Assert.Equal(chocolate, purchasedChocolate);
            Assert.Equal(25, vendingMachine.MoneyPool);
            Assert.Equal(chocolate.Use(), purchasedChocolate.Use());
        }

        [Fact]
        public void ShouldShowAllProducts()
        {
            Drink soda = new Drink(15, "Soda");
            Snack chips = new Snack(50, "Chips");
            Toy beyblade = new Toy(199, "Beyblade");
            List<Product> testProducts = new List<Product>();
            testProducts.Add(soda);
            testProducts.Add(chips);
            testProducts.Add(beyblade);
            VendingMachine vendingMachine = new VendingMachine(testProducts);
            Assert.Equal(testProducts, vendingMachine.ShowAll());
        }

        [Fact]
        public void ShouldInsertMoney()
        {
            Snack chips = new Snack(50, "Chips");
            List<Product> testProducts = new List<Product>();
            testProducts.Add(chips);
            VendingMachine vendingMachine = new VendingMachine(testProducts);
            vendingMachine.InsertMoney(50);
            Assert.Equal(50, vendingMachine.MoneyPool);
            vendingMachine.InsertMoney(100);
            Assert.Equal(150, vendingMachine.MoneyPool);
            Assert.Throws<ArgumentException>(() => vendingMachine.InsertMoney(45));
        }

        [Fact]
        public void ShouldEndTransaction()
        {
            Toy beyblade = new Toy(199, "Beyblade");
            List<Product> testProducts = new List<Product>();
            testProducts.Add(beyblade);
            VendingMachine vendingMachine = new VendingMachine(testProducts);
            vendingMachine.InsertMoney(1000);
            vendingMachine.InsertMoney(500);
            vendingMachine.InsertMoney(50);
            vendingMachine.InsertMoney(10);
            vendingMachine.InsertMoney(2);
            vendingMachine.InsertMoney(1);
            int[] change = vendingMachine.EndTransaction();
            int[] expectedChange = new int[] { 1, 1, 0, 0, 1, 0, 1, 0, 1, 1 };
            Assert.Equal(expectedChange, change);
        }
    }
}
