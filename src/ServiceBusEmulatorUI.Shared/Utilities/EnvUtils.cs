namespace ServiceBusEmulatorUI.Shared.Utilities;

public static class EnvUtils
{
    public static string GetEnvVar(this string key)
    {
        var value = Environment.GetEnvironmentVariable(key);

        if (string.IsNullOrEmpty(value))
            throw new InvalidOperationException($"Cannot find environment variable with key: {key}");

        return value;
    }

    public static TStruct GetEnvVar<TStruct>(this string key)
        where TStruct : struct
    {
        var value = GetEnvVar(key);

        // Feel like this will blow up dramatically at some point
        return (TStruct)Convert.ChangeType(value, typeof(TStruct));
    }
}
