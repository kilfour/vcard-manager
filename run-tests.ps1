# PowerShell script (Windows / cross-platform PowerShell Core)
# File: run-tests.ps1

param(
    [ValidateSet("unit", "integration")][string]$Mode = "unit"
)

$filter = if ($Mode -eq "unit") { "Category!=Integration" } else { "Category=Integration" }
dotnet test --filter $filter

