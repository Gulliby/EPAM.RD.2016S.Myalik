// <copyright file="IXmlRepository.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace DAL.Repositories.Interface
{
    using Entities.Interface;

    /// <summary>
    /// Xml repository interface.
    /// </summary>
    /// <typeparam name="TEntity">Custom entity.</typeparam>
    public interface IXmlRepository<TEntity> : IRepository<TEntity>
        where TEntity : IDalEntity
    {
        /// <summary>
        /// Function saves any information to Xml.
        /// </summary>
        void SaveToXml();

        /// <summary>
        /// Function loads information from Xml.
        /// </summary>
        void LoadFromXml();
    }
}
