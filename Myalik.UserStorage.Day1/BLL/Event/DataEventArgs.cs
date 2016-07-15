using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Interface;

namespace BLL.Event
{
    public class DataEventArgs : EventArgs
    {
        #region Private Fields

        #endregion

        #region Propetries

        public IUserRepository UserRepository { get; }

        #endregion

        #region Constructors

        public DataEventArgs(IUserRepository userRepository)
        {
            if (userRepository == null)
                throw new ArgumentNullException(nameof(userRepository));
            UserRepository = userRepository;
        }

        #endregion

    }
}
