using CatalogService.Api.Web.Models;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
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
        private IConfiguration configuration;

        public KafkaProducer(IConfiguration configuration)
        {
            this.configuration = configuration;
            var host = configuration.GetSection("Kafka").GetValue<string>("Host");
            var config = new ProducerConfig()
            {
                BootstrapServers = host
            };
            producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task KafkaMessage(ProductMessage productMessage)
        {
            string value = JsonConvert.SerializeObject(productMessage);
            var topic = configuration.GetSection("Kafka").GetValue<string>("Topic");
            await producer.ProduceAsync(topic, new Message<Null, string>() { Value = value });
            producer.Flush(TimeSpan.FromSeconds(10));

        }
    }
}
