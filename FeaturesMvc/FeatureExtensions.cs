using System;
using System.Linq;
using System.Web.Mvc;

namespace XperiCode.FeaturesMvc
{
    public static class FeatureExtensions
    {
        public static void AddFeatureSupportForRazorViewEngine(this ViewEngineCollection viewEngineCollection)
        {
            var razorViewEngine = viewEngineCollection.OfType<RazorViewEngine>().SingleOrDefault();
            if (razorViewEngine != null)
            {
                var areaFeatureViewPaths = new string[]
                {
                    "~/Areas/{2}/Features/{1}/Views/{0}.cshtml",
                    "~/Areas/{2}/Features/{1}/Views/{0}.vbhtml"
                };
                razorViewEngine.AreaMasterLocationFormats = areaFeatureViewPaths.Concat(razorViewEngine.AreaMasterLocationFormats).ToArray();
                razorViewEngine.AreaPartialViewLocationFormats = areaFeatureViewPaths.Concat(razorViewEngine.AreaPartialViewLocationFormats).ToArray();
                razorViewEngine.AreaViewLocationFormats = areaFeatureViewPaths.Concat(razorViewEngine.AreaViewLocationFormats).ToArray();

                var featureViewPaths = new string[]
                {
                    "~/Features/{1}/Views/{0}.cshtml",
                    "~/Features/{1}/Views/{0}.vbhtml"
                };
                razorViewEngine.MasterLocationFormats = featureViewPaths.Concat(razorViewEngine.MasterLocationFormats).ToArray();
                razorViewEngine.PartialViewLocationFormats = featureViewPaths.Concat(razorViewEngine.PartialViewLocationFormats).ToArray();
                razorViewEngine.ViewLocationFormats = featureViewPaths.Concat(razorViewEngine.ViewLocationFormats).ToArray();
            }
        }
    }
}
