using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interface
{
    public interface IUserMemoryRepository : IMemoryRepository<User>
    {
        void AddVisaByUserId(int userId, VisaInfo visaInfo);
        void RemoveVisaByUserId(int userId, VisaInfo visaInfo);
    }
}
