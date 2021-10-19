using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentProject.Model
{
    public interface IVending
    {
        public Product Purchase(Product product);

        public List<Product> ShowAll();

        public void InsertMoney(int money);

        public int[] EndTransaction();
    }
}
