using Ecommerce.Domain.Entities;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.ServicoPedidos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {
        private IBus _bus;

        public PedidosController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async void Post([FromBody] Pedido pedido)
        {
            await _bus.Publish(pedido);
        }
    }
}
