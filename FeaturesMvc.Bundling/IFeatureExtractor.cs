using System;
using System.Collections.Generic;

namespace XperiCode.FeaturesMvc.Bundling
{
    public interface IFeatureExtractor
    {
        IEnumerable<string> ExtractFeaturesFromControllerNamespaces(string[] controllerNamespaces, string areaName);
        IEnumerable<string> ExtractFeaturesFromControllerNamespaces(string[] controllerNamespaces);
    }
}