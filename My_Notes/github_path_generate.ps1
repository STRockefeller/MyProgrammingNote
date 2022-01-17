﻿$createFileName = "github_path_generate.md"
$linkPath="https://github.com/STRockefeller/MyProgrammingNote/tree/master/My_Notes"

function searchNote($location,[string]$header)
{
    if($header -eq ""){$header="##"}

    $files = $location|Get-ChildItem -File
    $dirs = $location|Get-ChildItem -Directory

    foreach($dir in $dirs)
    {
        $name = $($dir.Name)
        "$header $name"
        $newLocation = "$location\$name"
        $newHeader = "#$header"
        searchNote $newLocation $newHeader
    }

    foreach($file in $files)
    {
        $name = $($file.Name)
        $link=$file.PSpath.Replace($localPath,$linkPath).Replace("\","/").Replace(" ","%20").Replace("#","%23")

        "* [$name]($link)"
    }
}

function startup()
{
    "# Github Note Path"
    Get-Date
    "generated by github_path_generate.ps1"
    searchNote (pwd)
}

Set-Location $PSScriptRoot
$localPath = "Microsoft.PowerShell.Core\FileSystem::$pwd"
startup|Out-File $createFileName