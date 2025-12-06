namespace AdventOfCode2025.Utilities;

internal static class InputReader
{
    public static string[] ReadAsStringArray(string path)
    {
        return File.ReadAllLines(GetAbsolutePath(path));
    }

    public static string ReadAsString(string path)
    {
        return File.ReadAllLines(GetAbsolutePath(path))[0];
    }

    private static string GetAbsolutePath(string path)
    {
        return $"{Environment.GetEnvironmentVariable("INPUT_DIRECTORY")}/{path}";
    }
}
