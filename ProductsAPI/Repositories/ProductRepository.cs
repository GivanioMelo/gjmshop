using ProductsAPI.Domain;
using Repositories.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Repositories
{
    public class ProductRepository : MongoRepository<Product>
    {
        public ProductRepository(IMongoDbSettings settings) : base(settings)
        {
        }
    }
}
