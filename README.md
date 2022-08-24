# Sequential-Guid

NuGet Package to generate SQL Server Friendly Sequential Guid

## Usage

Add as Dependency to service collection:
This will register this Package as Singelton

```csharp
    using SequentialGuid;

    services.AddSequentialGuid();
```

Add With Dependency Injection to where its needed:

```csharp
    using SequentialGuid;
    private readonly ISequentialGuid _sequentialGuid;
    public class Example(ISequentialGuid sequentialGuid)
    {
        _sequentialGuid = sequentialGuid;
    }
    public void ExampleMethod()
    {
        var guid = _sequentialGuid.Next();
    }
```
