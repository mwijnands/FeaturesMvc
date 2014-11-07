using System;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Optimization;

namespace XperiCode.FeaturesMvc.Bundling
{
    public static class FeatureExtensions
    {
        public static Bundle IncludeForFeatures(this Bundle bundle, params string[] virtualPaths)
        {
            var assembly = Assembly.GetCallingAssembly();
            return bundle.IncludeForFeatures(assembly, virtualPaths);
        }

        public static Bundle IncludeForFeatures(this Bundle bundle, string virtualPath, params IItemTransform[] transforms)
        {
            var assembly = Assembly.GetCallingAssembly();
            return bundle.IncludeForFeatures(assembly, virtualPath, new FeatureExtractor(), transforms);
        }

        public static Bundle IncludeForFeatures(this Bundle bundle, Assembly assembly, params string[] virtualPaths)
        {
            foreach (var virtualPath in virtualPaths)
            {
                bundle.IncludeForFeatures(assembly, virtualPath, new FeatureExtractor(), new IItemTransform[] {});
            }
            return bundle;
        }

        public static Bundle IncludeForFeatures(this Bundle bundle, Assembly assembly, string virtualPath, params IItemTransform[] transforms)
        {
            return bundle.IncludeForFeatures(assembly, virtualPath, new FeatureExtractor(), transforms);
        }

        internal static Bundle IncludeForFeatures(this Bundle bundle, Assembly assembly, string virtualPath, IFeatureExtractor featureExtractor, params IItemTransform[] transforms)
        {
            bundle.IncludeForRootFeatures(assembly, virtualPath, featureExtractor, transforms);

            foreach (var areaName in assembly.GetAreaNames())
            {
                bundle.IncludeForAreaFeatures(assembly, virtualPath, featureExtractor, areaName, transforms);
            }

            return bundle;
        }

        internal static void IncludeForRootFeatures(this Bundle bundle, Assembly assembly, string virtualPath, IFeatureExtractor featureExtractor, params IItemTransform[] transforms)
        {
            string absoluteVirtualPath = VirtualPathUtility.ToAbsolute(virtualPath).Substring(1);

            foreach (var feature in assembly.GetFeatures(featureExtractor))
            {
                var featureVirtualPath = VirtualPathUtility.Combine(string.Format("~/Features/{0}/", feature), absoluteVirtualPath);

                if (BundleTable.VirtualPathProvider.DirectoryExists(VirtualPathUtility.GetDirectory(featureVirtualPath)))
                {
                    bundle.Include(featureVirtualPath, transforms);
                }
            }
        }

        internal static void IncludeForAreaFeatures(this Bundle bundle, Assembly assembly, string virtualPath, IFeatureExtractor featureExtractor, string areaName, params IItemTransform[] transforms)
        {
            string absoluteVirtualPath = VirtualPathUtility.ToAbsolute(virtualPath).Substring(1);

            foreach (var feature in assembly.GetAreaFeatures(featureExtractor, areaName))
            {
                var featureVirtualPath = VirtualPathUtility.Combine(string.Format("~/Areas/{0}/Features/{1}/", areaName, feature), absoluteVirtualPath);

                if (BundleTable.VirtualPathProvider.DirectoryExists(VirtualPathUtility.GetDirectory(featureVirtualPath)))
                {
                    bundle.Include(featureVirtualPath, transforms);
                }
            }
        }

        internal static string[] GetFeatures(this Assembly assembly, IFeatureExtractor featureExtractor)
        {
            var controllerNamespaces = assembly.GetControllerNamespaces();
            var features = featureExtractor.ExtractFeaturesFromControllerNamespaces(controllerNamespaces).ToArray();
            return features;
        }

        internal static string[] GetAreaFeatures(this Assembly assembly, IFeatureExtractor featureExtractor, string areaName)
        {
            var controllerNamespaces = assembly.GetControllerNamespaces();
            var features = featureExtractor.ExtractFeaturesFromAreaControllerNamespaces(controllerNamespaces, areaName).ToArray();
            return features;
        }
    }
}
