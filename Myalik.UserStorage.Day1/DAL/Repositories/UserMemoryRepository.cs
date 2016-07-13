using DAL.Entities;
using DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserMemoryRepository : MemoryRepository<DalUser>, IUserRepository
    {
        public void AddVisaByUserId(int userId, DalVisaInfo visaInfo)
        {
            entities.FirstOrDefault(e => e.Id == userId);
        }

        public void RemoveVisaByUserId(int userId, DalVisaInfo visaInfo)
        {
            entities.FirstOrDefault(e => e.Id == userId);
        }
    }
}
