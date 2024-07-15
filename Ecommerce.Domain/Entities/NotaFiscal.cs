using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class NotaFiscal
    {
        public Guid? PedidoId { get; }
        public string Cliente { get; }
        public string EnderecoEntrega { get; }

        public NotaFiscal(Pedido pedido)
        {
            PedidoId = pedido.Id;
            Cliente = pedido.cliente;
            EnderecoEntrega = pedido.enderecoEntrega;
        }
    }
}
