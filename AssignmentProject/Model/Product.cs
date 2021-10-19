using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentProject.Model
{
    public abstract class Product
    {
        private int price;
        private String description;

        public Product(int price, String description)
        {
            this.price = price;
            this.description = description;
        }

        public abstract Tuple<int, String> Examine();
        public abstract String Use();
    }
}
