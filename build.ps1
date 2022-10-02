Param (
    [switch] $release
)
$configuration = 'debug'
if ($release -eq $true) {
    $configuration = 'release'
}

$prefix = ((new-object -COM Shell.Application).Namespace(0x05).Self.Path)
$modsFolder = Join-Path $prefix 'Captain of Industry\Mods'
$modName = Split-Path $pwd -Leaf
[xml] $csproj = Get-Content (Get-ChildItem -Filter "${modName}.csproj" -Depth 0)
$targetFramework = $csproj.GetElementsByTagName("TargetFramework")[0].'#text'
$source = Join-Path $pwd "bin\Debug\${targetFramework}"
$destination = Join-Path $modsFolder $modName

dotnet build -c $configuration
if ($configuration -eq 'debug') {
    ROBOCOPY $source $destination *.dll *.pdb /S /IM
}
