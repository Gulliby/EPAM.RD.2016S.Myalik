using System;

namespace DAL.Entities.Interface
{
    public interface IDalEntity : ICloneable
    {
        int Id { get; set; }       
    }
}
