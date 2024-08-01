# Code test sample
Code test showing required number sequencing and testing.
SonarLint was used for linting - a few warnings have been intentionally left in. Can be seen in the build logs in either an IDE or git hub actions
Code test coverage can be shown in an IDE or by using the command line shown in the section below
Containerization has been included, but the full usage and deployment of this was deemed out of scope. I can elaborate on this if required. The target is ECR/ECS in Amazon AWS. The docker file is found under the main /CodeTest project.

# Usage
The main CodeTest project produces a console application that can be run with arguments. Alternatively, there are a number of tests that can be used to examine output also.

```
Usage:           CodeTest "[num1] [num2] ..."
Example:         CodeTest "1 2 45 987 0 67"

Input:
[num1] [num2]:   A single or list of numbers seperated by a single space
```

# Testing  
Run tests as normal using a preferred IDE such as Visual Studio, or through the command line using the following command  
```
dotnet test .\codetest.testing\CodeTest.Testing.csproj
```
  
## Test coverage reports
Ensure all necessary powershell script installation permissions are met before attempting this installation, to prevent permission related errors.
Ensure the necessary prerequisite package 'coverlet' is installed by running the following command from an administrator powershell window:
```
dotnet tool install -g coverlet.console
```
  
Run the following command from the root directory of the repository:  
```
dotnet build
coverlet .\CodeTest.Testing\bin\Debug\net8.0\codetest.testing.dll --target "dotnet" --targetargs "test --no-build"
```
