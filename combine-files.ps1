$ErrorActionPreference = 'Stop'

$outputFile = 'script-examples.txt'

if (Test-Path -Path $outputFile)
{
    Remove-Item -Path $outputFile
}

$directories = Get-ChildItem -Path ./v3 -Directory | Sort-Object -Property Name

foreach ($directory in $directories)
{
    "===== DIRECTORY: $($directory.Name) =====", '' | Add-Content -Path $outputFile

    $files = Get-ChildItem -Path $directory -File | Sort-Object -Property Name
    foreach ($file in $files)
    {
        "===== FILE: $($file.Name) =====", '' | Add-Content -Path $outputFile

        $content = Get-Content -Path $file

        while ($content[-1] -eq '')
        {
            $content = $content[0..($content.Count - 2)]
        }

        $content += ''

        $content | Add-Content -Path $outputFile
    }
}