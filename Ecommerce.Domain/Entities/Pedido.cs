using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Pedido
    {
        public Guid? Id = Guid.NewGuid();
        public string cliente {  get; set; }
        public string enderecoEntrega { get; set; }
    }
}
