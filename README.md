# Code test sample


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
