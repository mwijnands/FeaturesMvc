nuget pack ../FeaturesMvc/FeaturesMvc.csproj -Symbols -Build -Prop Configuration=Release
nuget pack ../FeaturesMvc.Bundling/FeaturesMvc.Bundling.csproj -Symbols -Build -IncludeReferencedProjects -Prop Configuration=Release
pause