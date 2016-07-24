﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Interface;

namespace BLL.Event
{
    public class FullDataChangedEventArgs<TRepository> : EventArgs 
        where TRepository: IUserRepository
    {
        #region Private Fields

        #endregion

        #region Propetries

        public TRepository Repository { get; }

        #endregion

        #region Constructors

        public FullDataChangedEventArgs(TRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));
            Repository = repository;
        }

        #endregion

    }
}