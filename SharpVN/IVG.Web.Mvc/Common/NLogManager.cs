using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVG.Web.Mvc.Common
{
    public static class NLogManager
    {
        public static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
    }
}