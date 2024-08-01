# cb975d73-1af2-4bc2-8112-055ea25b6919
Code test

# Testing  
Run tests as normal using a preferred IDE such as Visual Studio, or through the command line using the following command  
```
dotnet test .\codetest.testing\CodeTest.Testing.csproj
```
  
## Test coverage reports
Ensure the necessary prerequisite package 'coverlet' is installed by running 'coverlet.ps1' from an administrator powershell window.  
Ensure all necessary script installation permissions are met before attempting this installation, to prevent permission related errors.
  
Run the following command from the root directory of the repository:  
```
dotnet build
coverlet .\CodeTest.Testing\bin\Debug\net8.0\codetest.testing.dll --target "dotnet" --targetargs "test --no-build"
```
