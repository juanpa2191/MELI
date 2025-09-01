using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoLibre.Core.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string id)
            : base($"Product with ID {id} was not found.")
        {
        }
    }
}
