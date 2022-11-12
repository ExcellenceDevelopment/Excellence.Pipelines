param
(
    $configuration = "Release",
    $framework = "net7.0"
);

$solutionDirectoryPath = $PSCommandPath | Split-Path | Split-Path | Split-Path;
$solutionFileName = "Excellence.Pipelines.sln";
$solutionFilePath = Join-Path $solutionDirectoryPath $solutionFileName;

$testAssemblyDirectoryPath = Join-Path $solutionDirectoryPath "Tests\Excellence.Pipelines.Tests\bin\$configuration\$framework"

$localDirectoryPath = Join-Path $solutionDirectoryPath  "Local";

$testResultsDirectoryPath = Join-Path $localDirectoryPath "Tests" $framework;

$testCoverageResultsDirectoryPath = Join-Path $testResultsDirectoryPath "TestCoverageResults";
$testCoverageResultsReportsDirectoryPath = Join-Path $testCoverageResultsDirectoryPath "Reports";
$testCoverageCoverletJsonFilePath = Join-Path $testCoverageResultsDirectoryPath "coverlet.json";
$testCoverageCoverletOutputFormat = "cobertura";

coverlet $testAssemblyDirectoryPath `
         --target "dotnet" `
         --targetargs "test $solutionFilePath --framework $framework --configuration $configuration --verbosity minimal --logger ""trx;LogFileName=TestResults.trx"" --logger ""html;LogFileName=TestResults.html"" --logger ""console;verbosity=normal"" --results-directory $testResultsDirectoryPath --no-build" `
         --merge-with $testCoverageCoverletJsonFilePath `
         --format $testCoverageCoverletOutputFormat `
         --output "$testCoverageResultsDirectoryPath/"

ReportGenerator -reports:(Join-Path $testCoverageResultsDirectoryPath "*.xml") -targetdir:$testCoverageResultsReportsDirectoryPath -reporttypes:"Html_Dark";
