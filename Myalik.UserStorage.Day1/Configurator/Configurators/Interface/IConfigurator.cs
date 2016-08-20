// <copyright file="IConfigurator.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace Configurator.Configurators.Interface
{
    using System.Collections.Generic;
    using System.Net;
    using BLL.Services;

    /// <summary>
    /// Configurator interface.
    /// </summary>
    public interface IConfigurator
    {
        /// <summary>
        /// Configure the services.
        /// </summary>
        /// <param name="countOfMasterServices">Count of master services</param>
        /// <param name="countOfSlaveServices">Count of slave services.</param>
        /// <param name="filePath">File path.</param>
        /// <param name="connections">Collection of slave services.</param>
        /// <param name="masterService">Configured master service.</param>
        /// <param name="slaveServices">Configured slave services.</param>
        void Config(int countOfMasterServices, int countOfSlaveServices, string filePath, IList<IPEndPoint> connections, out MasterService masterService, out IList<SlaveService> slaveServices);
    }
}
