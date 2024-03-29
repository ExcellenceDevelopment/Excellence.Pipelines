param
(
    $configuration = "Release",
    $framework = "net8.0"
);

$solutionDirectoryPath = $PSCommandPath | Split-Path | Split-Path | Split-Path;
$solutionFileName = "Excellence.Pipelines.sln";
$solutionFilePath = Join-Path $solutionDirectoryPath $solutionFileName;

$localDirectoryPath = Join-Path $solutionDirectoryPath  "Local";

$testResultsDirectoryPath = Join-Path $localDirectoryPath "Tests" $framework;

$testCoverageDirectoryPath = Join-Path $testResultsDirectoryPath "Coverage";
$testCoverageFilePath = Join-Path $testCoverageDirectoryPath "coverage.xml";
$testCoverageReportsDirectoryPath = Join-Path $testCoverageDirectoryPath "Reports";

dotnet coverage collect dotnet test $solutionFilePath --configuration $configuration --framework $framework --output $testCoverageFilePath --output-format "cobertura";

ReportGenerator -reports:$testCoverageFilePath -targetdir:$testCoverageReportsDirectoryPath -reporttypes:"Html_Dark";
