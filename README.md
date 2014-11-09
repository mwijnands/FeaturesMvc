# FeaturesMvc

`FeaturesMvc` enables a feature-based project structure for ASP.NET MVC. It currently consists of 2 projects. `FeaturesMvc` enables views to be resolved from within a features folder. `FeaturesMvc.Bundling` enables easily including javascript, CSS, etc. from within feature folders in bundles (using [Bundling and Minification](http://www.asp.net/mvc/overview/performance/bundling-and-minification)).

As a picture says more than a thousand words, this is what your project structure could look like (left is the default structure, right is the feature-based structure):

![](https://raw.githubusercontent.com/mwijnands/FeaturesMvc/master/Docs/structure-comparison.png)

In short, this structure keeps all files that encompass a feature, closer together. the default structure will quickly become a mess as a project grows. The features structure also works within `MVC Areas` so you can group features together in an `Area`.

[![Build status](http://img.shields.io/appveyor/ci/mwijnands/featuresmvc.svg?style=flat)](https://ci.appveyor.com/project/mwijnands/featuresmvc) [![NuGet version](http://img.shields.io/nuget/v/XperiCode.FeaturesMvc.svg?style=flat)](https://www.nuget.org/packages/XperiCode.FeaturesMvc) [![NuGet version](http://img.shields.io/nuget/v/XperiCode.FeaturesMvc.Bundling.svg?style=flat)](https://www.nuget.org/packages/XperiCode.FeaturesMvc.Bundling)

## Installation

The `FeaturesMvc` packages are available at [NuGet](https://www.nuget.org/packages?q=XperiCode.FeaturesMvc).

If you want the full package that resolves views from features folders including bundling support, install `FeaturesMvc.Bundling` by running the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console):

> #### Install-Package XperiCode.FeaturesMvc.Bundling

If you only want views to be resolved from features folders, install `FeaturesMvc` by running the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console):

> #### Install-Package XperiCode.FeaturesMvc

## Documentation

To let ASP.NET MVC resolve views from within `~/Features/<FeatureName>/Views`, you have to add Features support to the Razor ViewEngine. `FeaturesMvc` includes an extension method to do just that. Execute the following code at application startup:

```c#
using XperiCode.FeaturesMvc;
//...
ViewEngines.Engines.AddFeatureSupportForRazorViewEngine();
```

Now you can add a Features folder to the root of your MVC Web Application, and start to add features. **Note that the name of a feature folder should be the same name as the name of the feature controller.**

Because the root folder of your views is now `/Features` instead of `/Views`, your views will not find `_ViewStart.cshtml` anymore (if you are using it) and the `Web.config` from the `/Views` folder will not be used. **Therefore you will need to copy over the `_ViewStart.cshtml` and `Web.config` from the `/Views` folder to the `/Features` folder.**

That is all that is necessary to get the basic functionality working.

### Javascript and stylesheet

If you also want your javascript files and stylesheets separated by feature, you'll need to make changes to the `Web.config` that is in the `/Features` folder. By default, there is a `BlockViewHandler` present that will prevent files from being downloaded from within the `/Views` folder. As you copied over that `Web.config` to the `/Features` folder, it is not possible to download javascript and stylesheets from the `/Features` folder either.

So what we want to do, is only block views from being downloaded directly from the features folder, but allow any other files (like javscript and stylesheets). So change the handler from this:
```xml
<add name="BlockViewHandler" path="*" verb="*" preCondition="integratedMode" type="System.Web.HttpNotFoundHandler" />
```
To this:
```xml
<add name="BlockViewHandlerCS" path="*.cshtml" verb="*" preCondition="integratedMode" type="System.Web.HttpNotFoundHandler" />
<add name="BlockViewHandlerVB" path="*.vbhtml" verb="*" preCondition="integratedMode" type="System.Web.HttpNotFoundHandler" />
```

### Bundling and minification

Documentation is coming. In the meantime, check out the [sample project on GitHub](https://github.com/mwijnands/FeaturesMvc/tree/master/FeaturesMvc.Sample).