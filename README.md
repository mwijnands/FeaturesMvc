# FeaturesMvc

`FeaturesMvc` enables a feature-based project structure for ASP.NET MVC. It currently consists of 2 projects. `FeaturesMvc` enables views to be resolved from within a features folder. `FeaturesMvc.Bundling` enables easily including javascript, CSS, etc. from within feature folders in bundles (using [Bundling and Minification](http://www.asp.net/mvc/overview/performance/bundling-and-minification)).

As a picture says more than a thousand words, this is what your project structure could look like (left is the default structure, right is the feature-based structure):

![](https://raw.githubusercontent.com/mwijnands/FeaturesMvc/master/Docs/structure-comparison.png)

In short, this structure keeps all files that encompass a feature, closer together. the default structure will quickly become a mess as a project grows. The features structure also works within `MVC Areas` so you can group features together in an `Area`.

[![Build status](http://img.shields.io/appveyor/ci/mwijnands/featuresmvc.svg?style=flat)](https://ci.appveyor.com/project/mwijnands/featuresmvc) [![NuGet version](http://img.shields.io/nuget/v/XperiCode.FeaturesMvc.svg?style=flat)](https://www.nuget.org/packages/XperiCode.FeaturesMvc) [![NuGet version](http://img.shields.io/nuget/v/XperiCode.FeaturesMvc.Bundling.svg?style=flat)](https://www.nuget.org/packages/XperiCode.FeaturesMvc.Bundling)

## Installation

The `FeaturesMvc` packages are available at [NuGet](https://www.nuget.org/packages?q=XperiCode.FeaturesMvc).

If you want the full package that resolves views from features folders including bundling support, install `FeaturesMvc.Bundling` by running the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console):

> ### Install-Package XperiCode.FeaturesMvc.Bundling

If you only want views to be resolved from features folders, install `FeaturesMvc` by running the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console):

> ### Install-Package XperiCode.FeaturesMvc
> 
## Documentation

Documentation is coming. In the meantime, check out the [sample project on GitHub](https://github.com/mwijnands/FeaturesMvc/tree/master/FeaturesMvc.Sample).