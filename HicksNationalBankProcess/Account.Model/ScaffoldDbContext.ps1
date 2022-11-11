[string]$dbContextName = "AccountDbContext"

[string]$entitiesFolder = "Entities"

 

[string]$connString = "Data Source=localhost;Initial Catalog=HicksNational; Trusted_Connection=True;"

 

[string[]]$tables = "account.HicksNationalAccount",

                    "account.HicksNationalAccountOwner",

                    "ref.HicksNationalAccountType"

                    

[string]$dbContext = ""

[string]$modelFolder = ""

[string]$scaffoldCommand = ""

[string]$table = ""

 

$dbContext = Join-Path -Path $PSScriptRoot -ChildPath "$($dbContextName).cs"

$modelFolder = Join-Path -Path $PSScriptRoot -ChildPath $entitiesFolder

 

Write-Host "Begin scaffolding..."

$scaffoldCommand = "dotnet ef dbcontext scaffold ""$($connString)"" Microsoft.EntityFrameworkCore.SqlServer -d -f -o ""$($entitiesFolder)"" -c ""$($dbContextName)"" --context-dir ""./"" --verbose --json"

foreach ($table in $tables) {

  $scaffoldCommand += " -t $($table)"

}

Invoke-Expression -Command $scaffoldCommand | Write-Host

 

Write-Host "Complete"