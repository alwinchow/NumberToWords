# Load the compiled C# assembly
Add-Type -Path "..\TechTest2024\bin\Debug\net8.0\TechTest2024.dll"

# Interactive testing
$number = Read-Host "Enter the number:"
$words = [IterativeStringConcatenationService]::ToWords([double]$number)
Write-Host "Result: $words"