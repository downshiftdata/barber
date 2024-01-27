Param( `
    [parameter(Mandatory=$true, HelpMessage="Environment")] $Environment, `
    [parameter(Mandatory=$true, HelpMessage="ServerName")] $ServerName, `
    [parameter(Mandatory=$true, HelpMessage="DatabaseName")] $DatabaseName
);

$rootPath = (Split-Path $MyInvocation.MyCommand.Path);

function DeployScript([String] $path)
{
    Write-Host "$path";
    try
    {
        Invoke-Sqlcmd `
            -InputFile $path `
            -ServerInstance $ServerName `
            -Database $DatabaseName `
            -ErrorAction Stop;
    }
    catch
    {
        Write-Host("Error:{0},File:{1},Line:{2},Message:{3}" -f `
            $_.Exception.InnerException.Number, `
            $path, `
            $_.Exception.InnerException.LineNumber, `
            $_.Exception.InnerException.Message) `
            -ForegroundColor Red
        Exit 1;
    }
}

function DeployFolder([String] $path, [String] $folderName)
{
    Write-Host "Folder: $path\$folderName";
    Get-ChildItem "$path\$folderName" -Filter "*.sql" -Recurse `
        | Foreach-Object { DeployScript $_.FullName };
}

Get-ChildItem $rootPath -Filter "_*.sql" -Recurse `
    | Foreach-Object { DeployScript $_.FullName };

DeployFolder $rootPath "table" ;

DeployFolder $rootPath "data";

DeployFolder $rootPath "procedure" 

If ($Environment -in "dev", "test")
{
    DeployFolder $rootPath "test";
}
