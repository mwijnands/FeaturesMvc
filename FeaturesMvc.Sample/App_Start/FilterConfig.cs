﻿using System.Web.Mvc;

namespace XperiCode.FeaturesMvc.Sample.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
