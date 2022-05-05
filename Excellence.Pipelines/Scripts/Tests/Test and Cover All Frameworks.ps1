$currentDirectory = $PSCommandPath | Split-Path;
$frameworks = @("net5.0","net6.0");
$testAndCoverFilePath = Join-Path $currentDirectory "Test and Cover.ps1";

for ($a = 0; $a -lt $frameworks.Length ; $a++)
{
    & $testAndCoverFilePath -configuration "Release" -framework $frameworks[$a];
}
