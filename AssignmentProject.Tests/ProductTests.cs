using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AssignmentProject.Model;

namespace AssignmentProject.Tests
{
    public class ProductTests
    {
        [Fact]
        public void ShouldExamineProduct()
        {
            Drink soda = new Drink(15, "Soda");
            Snack chips = new Snack(50, "Chips");
            Toy beyblade = new Toy(199, "Beyblade");
            List<Product> testProducts = new List<Product>();
            testProducts.Add(soda);
            testProducts.Add(chips);
            testProducts.Add(beyblade);
            Tuple<int, String> expectedDrink = new Tuple<int, string>(15, "Soda");
            Tuple<int, String> expectedSnack = new Tuple<int, string>(50, "Chips");
            Tuple<int, String> expectedToy = new Tuple<int, string>(199, "Beyblade");
            Assert.Equal(expectedDrink, soda.Examine());
            Assert.Equal(expectedSnack, chips.Examine());
            Assert.Equal(expectedToy, beyblade.Examine());
        }
        [Fact]
        public void ShouldUseProduct()
        {
            Drink soda = new Drink(15, "Soda");
            Snack chips = new Snack(50, "Chips");
            Toy beyblade = new Toy(199, "Beyblade");
            List<Product> testProducts = new List<Product>();
            testProducts.Add(soda);
            testProducts.Add(chips);
            testProducts.Add(beyblade);
            Assert.Equal("How refreshing!", soda.Use());
            Assert.Equal("So tasty!", chips.Use());
            Assert.Equal("Having fun yet?", beyblade.Use());
        }
    }
}
