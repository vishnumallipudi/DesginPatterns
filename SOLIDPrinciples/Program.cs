using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPrinciples
{
    class Program
    {
        static void Main(string[] args)
        {
            var apple = new Product("Apple", Size.small, Color.orange);
            var tree = new Product("Tree", Size.large, Color.yellow);
            var house = new Product("House", Size.huge, Color.blue);

            Product[] products = { apple, tree, house };

            var pf = new ProductFilter();
            Console.WriteLine("Orange Products(old):");
            foreach (var product in pf.FilterByColor(products, Color.orange))
            {
                Console.WriteLine($" - {product.Name} is orange");
            }

            var bf = new BetterFilter();
            Console.WriteLine("Orange Products(new):");
            foreach (var item in bf.Filter(products, new ColorSpecification(Color.orange)))
            {
                Console.WriteLine($" - {item.Name} is orange");
            }

            foreach (var item in bf.Filter(products,
                new AndSpecification(new ColorSpecification(Color.yellow),new SizeSpecification(Size.large))))
            {
                Console.WriteLine($" - {item.Name} is yellow and large");
            }

            Console.ReadLine();
        }
    }
}
