using CatalogService.Api.Web.Models;
using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Api.Web.Producer
{
    public class KafkaProducer
    {
        private IProducer<Null, string> producer;

        public KafkaProducer()
        {
            var config = new ProducerConfig()
            {
                BootstrapServers = "localhost:9092"
            };
            producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task KafkaMessage(ProductMessage productMessage)
        {
            string value = JsonConvert.SerializeObject(productMessage);

            await producer.ProduceAsync("demo1", new Message<Null, string>() { Value = value });
            producer.Flush(TimeSpan.FromSeconds(10));

        }
    }
}
