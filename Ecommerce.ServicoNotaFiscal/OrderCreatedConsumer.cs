using Ecommerce.Domain.Entities;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ServicoNotaFiscal
{
    public class OrderCreatedConsumer : IConsumer<Pedido>
    {
        public OrderCreatedConsumer() { }

        public Task Consume(ConsumeContext<Pedido> context)
        {
            Pedido pedido = context.Message;
            Console.WriteLine(context.Message);
            GerarLog(pedido, Path.Combine("notas", $"{pedido.Id}.txt"));

            return Task.CompletedTask;
        }

        public void GerarLog(Pedido pedido, string caminhoArquivo)
        {

            string directoryPath = Path.GetDirectoryName(caminhoArquivo);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            using (StreamWriter writer = new StreamWriter(caminhoArquivo))
            {
                writer.WriteLine("Nota Fiscal");
                writer.WriteLine("=============");
                writer.WriteLine($"Pedido ID: {pedido.Id}");
                writer.WriteLine("Data: " + DateTime.UtcNow);
                writer.WriteLine($"Cliente: {pedido.cliente}");
                writer.WriteLine($"Endereço de Entrega: {pedido.enderecoEntrega}");
            }

        }
    }
}
