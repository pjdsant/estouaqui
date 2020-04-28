using log4net;
using log4net.Repository.Hierarchy;

namespace EstouAqui
{
    public class LogHelper
    {
        public static ILog GetInstance
        {
            get
            {
                return LogManager.GetLogger(typeof(Logger));
            }
        }
    }
}
