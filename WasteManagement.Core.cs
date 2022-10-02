using System;

public static class Core
{
    public static string Name => System.Reflection.Assembly.GetCallingAssembly().GetName().Name;
    public static string Version => System.Reflection.Assembly.GetCallingAssembly().GetName().Version.ToString();
    public static int VersionInt => int.Parse(Version.Replace(".", ""));
    public static void LogWithVersion(
        Action<string> logger,
        string message
    ) => logger($"{Core.Name}[{Core.Version}]: {message}");
}
