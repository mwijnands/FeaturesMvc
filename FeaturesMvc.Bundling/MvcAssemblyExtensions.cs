using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace XperiCode.FeaturesMvc.Bundling
{
    internal static class MvcAssemblyExtensions
    {
        internal static string[] GetAreaNames(this Assembly assembly)
        {
            var areaNamespaces = GetAreaNamespaces(assembly);
            var areaNames = areaNamespaces.Select(ns => ns.Split('.').Last()).ToArray();
            return areaNames;
        }

        internal static string[] GetAreaNamespaces(this Assembly assembly)
        {
            var areaRegistrations = assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(AreaRegistration))).ToList();
            var namespaces = areaRegistrations.Select(areaRegistration => areaRegistration.Namespace).Distinct().ToArray();
            return namespaces;
        }

        internal static string[] GetControllerNamespaces(this Assembly assembly)
        {
            var controllers = assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Controller))).ToList();
            var namespaces = controllers.Select(controller => controller.Namespace).Distinct().ToArray();
            return namespaces;
        }
    }
}