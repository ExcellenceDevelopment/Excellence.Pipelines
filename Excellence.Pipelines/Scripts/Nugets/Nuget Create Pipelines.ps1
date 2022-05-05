param ($configuration = "Release");

$solutionDirectoryPath = $PSCommandPath | Split-Path | Split-Path | Split-Path;
$projectFilePath = Join-Path $solutionDirectoryPath "Sources" "Infrastructure" "Excellence.Pipelines" "Excellence.Pipelines.csproj";
$outputDirectoryPath = Join-Path $solutionDirectoryPath "Local" "Nugets";

dotnet pack $projectFilePath --configuration $configuration --output $outputDirectoryPath;
