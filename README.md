# Sequential-Guid

NuGet Package to generate SQL Server Friendly Sequential Guid

## Usage

1. Get Next Guid

```csharp
    using SequentialGuid;

    public void ExampleMethod()
    {
       var guid = GuidInstance.Next();
    }
```

2. Get Current Guid

```csharp
    using SequentialGuid;

    public void ExampleMethod()
    {
       var guid = GuidInstance.GetCurrentGuid();
    }
```


3. Seed First Guid

```csharp
    using SequentialGuid;

    public void ExampleMethod()
    {
       var guid = GuidInstance.SetSeed(Guid.NewGuid());
    }
```
