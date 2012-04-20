// Copyright 2007-2012 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit
{
    using Distributor.Configuration;
    using Logging;
    using Saga;
    using Saga.SubscriptionConfigurators;

    public static class SagaWorkerConfiguratorExtensions
    {
        static readonly ILog _log = Logger.Get(typeof(SagaWorkerConfiguratorExtensions));

        /// <summary>
        /// Configure a saga subscription
        /// </summary>
        /// <typeparam name="TSaga"></typeparam>
        /// <param name="configurator"></param>
        /// <param name="sagaRepository"></param>
        /// <returns></returns>
        public static SagaSubscriptionConfigurator<TSaga> Saga<TSaga>(
            this WorkerConfigurator configurator, ISagaRepository<TSaga> sagaRepository)
            where TSaga : class, ISaga
        {
            if (_log.IsDebugEnabled)
                _log.DebugFormat("Subscribing Saga: {0}", typeof(TSaga));

            var sagaConfigurator = new SagaSubscriptionConfiguratorImpl<TSaga>(sagaRepository);

            //        var busServiceConfigurator = new SubscriptionBusServiceBuilderConfiguratorImpl(sagaConfigurator);

            //      configurator.AddConfigurator(busServiceConfigurator);

            return sagaConfigurator;
        }
    }
}