$solutionPath=".\\Excellence.Pipelines\\Excellence.Pipelines.sln";
$configuration="Release";
$verbosity="normal";

dotnet build $solutionPath --configuration $configuration &&
dotnet test $solutionPath --configuration $configuration --framework "net5.0" --no-build --verbosity $verbosity &&
dotnet test $solutionPath --configuration $configuration --framework "net6.0" --no-build --verbosity $verbosity;
