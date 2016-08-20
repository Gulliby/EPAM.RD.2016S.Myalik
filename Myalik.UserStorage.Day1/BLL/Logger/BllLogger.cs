// <copyright file="BllLogger.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace BLL.MainBllLogger
{
    using NLog;

    public static class BllLogger
    {
        /// <summary>
        /// Sync root instance.
        /// </summary>
        private static readonly object SyncRoot = new object();

        /// <summary>
        /// Logger instance.
        /// </summary>
        private static volatile Logger instance;  

        /// <summary>
        /// Gets or sets a value indicating whether the logger was used.
        /// </summary>
        public static bool BooleanSwitch { get; set; } = true;
        
        /// <summary>
        /// Gets an instance of logger.(SingleTon)
        /// </summary>
        public static Logger Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }

                lock (SyncRoot)
                {
                    if (instance == null)
                    {
                        instance = LogManager.GetCurrentClassLogger();
                    }
                }

                return instance;
            }
        }
    }
}
