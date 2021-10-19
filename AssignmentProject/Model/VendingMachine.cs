using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentProject.Model
{
    public class VendingMachine : IVending
    {
        private List<Product> products;
        private readonly int[] moneyDen;
        private int moneyPool;

        public VendingMachine(List<Product> products)
        {
            this.products = products;
            moneyDen = new int[] { 1000, 500, 200, 100, 50, 20, 10, 5, 2, 1 };
            moneyPool = 0;
        }

        public int MoneyPool { get => moneyPool; }

        public Product Purchase(Product product)
        {
            if (moneyPool < product.Examine().Item1)
            {
                throw new ArgumentOutOfRangeException("Insufficient funds.");
            }
            moneyPool -= product.Examine().Item1;
            return product;
        }

        public List<Product> ShowAll()
        {
            return products;
        }

        public void InsertMoney(int money)
        {
            bool success = false;
            foreach (int value in moneyDen)
            {
                if (money == value)
                {
                    moneyPool += money;
                    success = true;
                }
            }
            if (!success)
            {
                throw new ArgumentException(money + "is not a valid denomination.");
            }
        }

        public int[] EndTransaction()
        {
            int[] change = new int[moneyDen.Length];

            for (int i = 0; i < moneyDen.Length; i++)
            {
                change[i] = moneyPool / moneyDen[i];
                if (i < moneyDen.Length - 1)
                {
                    moneyPool %= moneyDen[i];
                }
            }
            return change;
        }
    }
}
