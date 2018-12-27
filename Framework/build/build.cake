Task("Clean")
    .Does(() =>
{
    DotNetCoreClean("../src/Sparta.sln");
});

Task("Build")
    .Does(() =>
{
    DotNetCoreBuild("../src/Sparta.sln");
});

Task("Pack")
    .Does(() =>
{
    var settings = new DotNetCorePackSettings
    {
         Configuration = "Release",
         OutputDirectory = @"C:\local-nuget"
    };

     DotNetCorePack("../src/Sparta.sln", settings);
});

Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Build")
    .IsDependentOn("Pack")
    ;

RunTarget("Default");