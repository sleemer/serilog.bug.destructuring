# serilog.bug.destructuring
This repo contains example to reproduce the bug of serilog destructuring

## Test environment:
- Serilog 2.5.0
- MacOS Sierra 10.12.6
- .Net Core 2.0.2

Code:
```csharp
Log.Logger = new LoggerConfiguration()
      .Destructure.ByTransformingWhere<Type>(
          type => true, 
          type => new { FullName = type.FullName })
      .WriteTo.Console()
      .CreateLogger();

Log.Information("{@Type}", typeof(string));
```

Expected behavior:
[13:19:38 INF] {FullName = System.String}

Actual behavior:
[13:21:53 INF] Capturing the property value threw an exception: InvalidCastException

