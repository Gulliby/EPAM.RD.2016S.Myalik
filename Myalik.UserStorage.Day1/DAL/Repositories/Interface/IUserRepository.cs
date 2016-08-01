using DAL.Entities;

namespace DAL.Repositories.Interface
{
    
    public interface IUserRepository : IMemoryRepository<DalUser>, IXmlRepository<DalUser>
    {
        void AddVisaByUserId(int userId, DalVisaInfo visaInfo);
        void RemoveVisaByUserId(int userId, DalVisaInfo visaInfo);
    }
}
