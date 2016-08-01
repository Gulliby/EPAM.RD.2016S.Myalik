using DAL.Entities;
using DAL.Repositories.Interface;
using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using DAL.Container;
using Generator.Generators;
using Generator.Generators.Interface;

namespace DAL.Repositories
{
    [Serializable]
    public class UserXmlMemoryRepository : MemoryRepository<DalUser>, IUserRepository
    {
        private string xmlFileName;
        public UserXmlMemoryRepository(string xmlFileName)
        {
            this.xmlFileName = !string.IsNullOrEmpty(xmlFileName) ? xmlFileName : "repository.xml";
            LoadFromXml();
        }

        public void AddVisaByUserId(int userId, DalVisaInfo visaInfo)
        {
            var firstOrDefault = entities.FirstOrDefault(e => e.Id == userId);
            firstOrDefault?.Visa.Add(visaInfo);
        }

        public void RemoveVisaByUserId(int userId, DalVisaInfo visaInfo)
        {
            var firstOrDefault = entities.FirstOrDefault(e => e.Id == userId);
            firstOrDefault?.Visa.Remove(visaInfo);
        }

        public void SaveToXml()
        {
            var sContainer = new UserSerializableContainer
            {
                Users = entities.ToList(),
                Current = generator.Current,
                Prev = generator.Prev,
            };
            var formatter = new XmlSerializer(typeof(UserSerializableContainer));
            using (var fs = new FileStream(xmlFileName, FileMode.Create))
            {
                formatter.Serialize(fs, sContainer);
            }
        }

        public void LoadFromXml()
        {
            if (!File.Exists(xmlFileName))
                return;
            var formatter = new XmlSerializer(typeof(UserSerializableContainer));
            using (var fs = new FileStream(xmlFileName, FileMode.OpenOrCreate))
            {
                var sContainer = (UserSerializableContainer)formatter.Deserialize(fs);
                entities = sContainer.Users;
                generator = new FibIterator(sContainer.Current, sContainer.Prev);
            }
        }

        public new object Clone()
        {
            return new UserXmlMemoryRepository(string.Copy(xmlFileName))
            {
                entities = entities.Select(item => item).ToList(),
                xmlFileName = string.Copy(xmlFileName),
                generator = (IGenerator)generator.Clone(),
            };
        }
    }
}
