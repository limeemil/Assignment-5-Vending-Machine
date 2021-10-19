using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentProject.Model
{
    public class Drink : Product
    {
        private int price;
        private String description;

        public Drink(int price, String description) : base(price, description)
        {
            this.price = price;
            this.description = description;
        }

        public override Tuple<int, String> Examine()
        {
            return new Tuple<int, String>(price, description);
        }

        public override String Use()
        {
            return "How refreshing!";
        }
    }
}
