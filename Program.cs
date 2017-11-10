using System;
using Serilog;

namespace serilog.bug.destructuring
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Destructure.ByTransformingWhere<Type>(type => true, type => new { FullName = type.FullName })
                .WriteTo.Console()
                .CreateLogger();

            Log.Information("{@Type}", typeof(string));
        }
    }
}
