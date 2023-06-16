using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoArchitectureDataAccess;

namespace DemoArchitectureCore
{
    public class BusinessLayer
    {
        private readonly DataLayer _dataLayer;

        public BusinessLayer(DataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public List<Product> GetProducts()
        {
            return _dataLayer.GetProducts();
        }
    }
}
