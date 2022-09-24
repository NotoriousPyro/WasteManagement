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
$source = Join-Path $pwd 'bin\Debug\net46'
$destination = Join-Path $modsFolder $modName

dotnet build -c $configuration
if ($configuration -eq 'debug') {
    ROBOCOPY $source $destination *.dll *.pdb /S
}
