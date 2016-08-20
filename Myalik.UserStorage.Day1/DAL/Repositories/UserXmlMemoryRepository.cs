// <copyright file="UserXmlMemoryRepository.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace DAL.Repositories
{
    using Entities;
    using Interface;
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Container;
    using Generator.Generators;
    using Generator.Generators.Interface;

    [Serializable]
    public class UserXmlMemoryRepository : MemoryRepository<DalUser>, IUserRepository
    {
        /// <summary>
        /// Xml file name.
        /// </summary>
        private string xmlFileName;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserXmlMemoryRepository"/> class.
        /// </summary>
        /// <param name="xmlFileName">Xml file name.</param>
        public UserXmlMemoryRepository(string xmlFileName)
        {
            this.xmlFileName = !string.IsNullOrEmpty(xmlFileName) ? xmlFileName : "repository.xml";
            this.LoadFromXml();
        }

        /// <summary>
        /// Add visa to the user's visa collection.
        /// </summary>
        /// <param name="userId">User where visa need to be stored.</param>
        /// <param name="visaInfo">Information about a visa.</param>
        public void AddVisaByUserId(int userId, DalVisaInfo visaInfo)
        {
            var firstOrDefault = entities.FirstOrDefault(e => e.Id == userId);
            firstOrDefault?.Visa.Add(visaInfo);
        }

        /// <summary>
        /// Remove visa form the user's visa collection.
        /// </summary>
        /// <param name="userId">User where visa need to be deleted.</param>
        /// <param name="visaInfo">Information about a visa.</param>
        public void RemoveVisaByUserId(int userId, DalVisaInfo visaInfo)
        {
            var firstOrDefault = entities.FirstOrDefault(e => e.Id == userId);
            firstOrDefault?.Visa.Remove(visaInfo);
        }

        /// <summary>
        /// Function saves any information to Xml.
        /// </summary>
        public void SaveToXml()
        {
            var userSerializableContainer = new UserSerializableContainer
            {
                Users = entities.ToList(),
                Current = generator.Current,
                Prev = generator.Prev,
            };
            var formatter = new XmlSerializer(typeof(UserSerializableContainer));
            using (var fs = new FileStream(this.xmlFileName, FileMode.Create))
            {
                formatter.Serialize(fs, userSerializableContainer);
            }
        }

        /// <summary>
        /// Function loads information from Xml.
        /// </summary>
        public void LoadFromXml()
        {
            if (!File.Exists(this.xmlFileName))
            { 
                return;
            }

            var formatter = new XmlSerializer(typeof(UserSerializableContainer));
            using (var fs = new FileStream(this.xmlFileName, FileMode.OpenOrCreate))
            {
                var userSerializableContainer = (UserSerializableContainer)formatter.Deserialize(fs);
                this.entities = userSerializableContainer.Users;
                this.generator = new FibIdGenerator(userSerializableContainer.Current, userSerializableContainer.Prev);
            }
        }

        /// <summary>
        /// Creates a new object that is a copy of the current user xml memory repository instance.
        /// </summary>
        /// <returns>New object that is a copy of the current instance.</returns>
        public new object Clone()
        {
            return new UserXmlMemoryRepository(string.Copy(this.xmlFileName))
            {
                entities = entities.Select(item => item).ToList(),
                xmlFileName = string.Copy(this.xmlFileName),
                generator = (IGenerator)generator.Clone(),
            };
        }
    }
}
