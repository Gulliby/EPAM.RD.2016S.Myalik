using NLog;

namespace BLL.MainBllLogger
{
    public static class BllLogger
    {
        private static volatile Logger instance;
        private static readonly object syncRoot = new object();

        public static bool BooleanSwitch { get; set; } = true;

        public static Logger Instance
        {
            get
            {
                if (instance != null) return instance;
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = LogManager.GetCurrentClassLogger();
                }
                return instance;
            }
        }
    }
}
