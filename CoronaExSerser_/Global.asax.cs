﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace שרת_שנה_ג
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings
       .Add(new System.Net.Http.Formatting.RequestHeaderMapping("Accept",
       "text/html",
       StringComparison.InvariantCultureIgnoreCase,
       true,
       "application/json"));
        }
    }
}
