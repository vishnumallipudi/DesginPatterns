using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPrinciples
{
    public enum Size { small, medium, large, huge }

    public enum Color { black, blue, orange, yellow }

    public class Product
    {
        public string Name;
        public Size Size;
        public Color Color;
        public Product(string name, Size size, Color color)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Product name cannot be null...");
            }

            this.Name = name;
            this.Size = size;
            this.Color = color;
        }
    }

    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var product in products)
                if (product.Size == size)
                    yield return product;
        }
        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var product in products)
                if (product.Color == color)
                    yield return product;
        }
        public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products,
            Size size, Color color)
        {
            foreach (var product in products)
                if (product.Color == color && product.Size == size)
                    yield return product;
        }
    }

    public interface ISpecification<T>
    {
        bool IsSatisfied(T product);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }
    public class ColorSpecification : ISpecification<Product>
    {
        Color color;
        public ColorSpecification(Color color)
        {
            this.color = color;
        }
        public bool IsSatisfied(Product product)
        {
            return product.Color == this.color;
        }
    }
    public class SizeSpecification : ISpecification<Product>
    {
        Size size;
        public SizeSpecification(Size size)
        {
            this.size = size;
        }
        public bool IsSatisfied(Product product)
        {
            return product.Size == this.size;
        }
    }
    public class AndSpecification : ISpecification<Product>
    {
        ISpecification<Product> first, second;
        public AndSpecification(ISpecification<Product> first, ISpecification<Product> second)
        {
            this.first = first ?? throw new ArgumentException($"{nameof(first)} cannot be null");
            this.second = second ?? throw new ArgumentException($"{nameof(second)} cannot be null");
        }
        public bool IsSatisfied(Product product)
        {
            return first.IsSatisfied(product) && second.IsSatisfied(product);
        }
    }
    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var item in items)
            {
                if (spec.IsSatisfied(item))
                {
                    yield return item;
                }
            }
        }
    }
}
