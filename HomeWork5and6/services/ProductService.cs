using HomeWork5and6.Domains.Entities;

namespace HomeWork5and6.services
{
    public class ProductService
    {
        // В реальном проекте здесь будет внедрение репозитория через DI (IProductRepository)
        public ProductService() { }

        public Product CreateProduct(string name, decimal price)
        {
            var product = new Product(Guid.NewGuid(), name, price);

            // Здесь код сохранения в базу данных: _repository.Add(product);

            return product;
        }
    }
}