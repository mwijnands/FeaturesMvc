using System;
using System.Collections.Generic;
using System.Linq;

namespace XperiCode.FeaturesMvc.Bundling
{
    internal class FeatureExtractor : IFeatureExtractor
    {
        public IEnumerable<string> ExtractFeaturesFromAreaControllerNamespaces(string[] controllerNamespaces, string areaName)
        {
            foreach (var controllerNamespace in controllerNamespaces)
            {
                string feature = ExtractFeatureFromControllerNamespace(controllerNamespace, areaName);
                if (!string.IsNullOrWhiteSpace(feature))
                {
                    yield return feature;
                }
            }
        }

        internal string ExtractFeatureFromControllerNamespace(string controllerNamespace, string areaName)
        {
            var namespaceSegments = controllerNamespace.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            var sequentialSegmentsToFind = new string[] { "Areas", areaName, "Features" };
            var lastSegmentIndexToSearch = (namespaceSegments.Length - sequentialSegmentsToFind.Length);

            for (int firstSegmentToFindIndex = 0; firstSegmentToFindIndex < lastSegmentIndexToSearch; firstSegmentToFindIndex++)
            {
                if (SequentialSegmentsFoundAtIndex(namespaceSegments, sequentialSegmentsToFind, firstSegmentToFindIndex))
                {
                    return namespaceSegments[firstSegmentToFindIndex + 3];
                }
            }
            return string.Empty;
        }
  
        internal bool SequentialSegmentsFoundAtIndex(string[] namespaceSegments, string[] sequentialSegmentsToFind, int index)
        {
            return namespaceSegments[index].Equals(sequentialSegmentsToFind[0], StringComparison.InvariantCultureIgnoreCase) &&
                   namespaceSegments[index + 1].Equals(sequentialSegmentsToFind[1], StringComparison.InvariantCultureIgnoreCase) &&
                   namespaceSegments[index + 2].Equals(sequentialSegmentsToFind[2], StringComparison.InvariantCultureIgnoreCase);
        }

        public IEnumerable<string> ExtractFeaturesFromControllerNamespaces(string[] controllerNamespaces)
        {
            foreach (var controllerNamespace in controllerNamespaces)
            {
                string feature = ExtractFeatureFromControllerNamespace(controllerNamespace);
                if (!string.IsNullOrWhiteSpace(feature))
                {
                    yield return feature;
                }
            }
        }

        internal string ExtractFeatureFromControllerNamespace(string controllerNamespace)
        {
            var namespaceSegments = controllerNamespace.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var featuresSegmentIndex = namespaceSegments.FindIndex(segment => segment.Equals("Features", StringComparison.InvariantCultureIgnoreCase));

            if (SecondPreviousNamespaceSegmentIsAreasSegment(namespaceSegments, featuresSegmentIndex))
            {
                return string.Empty;
            }

            if (featuresSegmentIndex >= 0 && namespaceSegments.Count > featuresSegmentIndex + 1)
            {
                return namespaceSegments[featuresSegmentIndex + 1];
            }

            return string.Empty;
        }
  
        internal bool SecondPreviousNamespaceSegmentIsAreasSegment(IList<string> namespaceSegments, int segmentIndex)
        {
            return segmentIndex > 1 && namespaceSegments[segmentIndex - 2].Equals("Areas", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
