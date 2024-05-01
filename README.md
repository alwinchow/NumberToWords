# NumberToWords


## Summary

Web API develop using Visual Studio 2022 Community Version with .NET 8
UnitTest using MSTest

API GET convertnumeric/input

Example:
http://localhost:5092/convertnumeric/input

Max Input = UInt64 (18,446,744,073,709,551,615)

## Building the Solution

.NET SDK installed on your machine

1. Open a terminal or command prompt.
2. Navigate to the root directory of the solution.
3. Run the following command:

   dotnet build

## Hosting as a Console Application

1. Navigate to the output directory of the build (typically bin/Debug or bin/Release).
2. Run the executable file (TechTest2024.exe) from the terminal or command prompt.

## Integrating into other projects

To integrate the solution into other .NET projects, follow these steps:

Reference the compiled assembly (TechTest2024.dll) in your project.
Use the IterativeStringConcatenationService.ToWords() method to convert string numeric values into words.