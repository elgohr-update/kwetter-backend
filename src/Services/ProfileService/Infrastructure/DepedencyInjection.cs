﻿using Confluent.Kafka;
using Kwetter.Services.ProfileService.Application.Common.Interfaces;
using Kwetter.Services.ProfileService.Infrastructure.Producer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kwetter.Services.ProfileService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            ProducerConfig config = new ProducerConfig
            {
                BootstrapServers = configuration.GetValue<string>("ProducerConfig:BootstrapServers"),            
            };
            services.AddSingleton<IProducer>(_ => new KafkaProducer(config));
            return services;
        }
    }
}