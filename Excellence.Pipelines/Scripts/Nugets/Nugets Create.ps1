$currentDirectory = $PSCommandPath | Split-Path;
$configuration = "Release";

& (Join-Path $currentDirectory "Nuget Create Pipelines.Core.ps1") -configuration $configuration;
& (Join-Path $currentDirectory "Nuget Create Pipelines.ps1") -configuration $configuration;
