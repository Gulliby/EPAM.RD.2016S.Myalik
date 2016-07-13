using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interface
{
    public interface IUserRepository : IRepository<DalUser>
    {
        void AddVisaByUserId(int userId, DalVisaInfo visaInfo);
        void RemoveVisaByUserId(int userId, DalVisaInfo visaInfo);
    }
}
