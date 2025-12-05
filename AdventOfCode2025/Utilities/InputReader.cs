namespace AdventOfCode2025.Utilities;

internal static class InputReader
{
    public static string[] ReadAsStringArray(string path)
    {
        return File.ReadAllLines($"{Environment.GetEnvironmentVariable("INPUT_DIRECTORY")}/{path}");
    }
}
