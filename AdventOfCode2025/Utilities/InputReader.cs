namespace AdventOfCode2025.Utilities;

internal static class InputReader
{
    public static string[] ReadAsStringArray(string path)
    {
        return File.ReadAllLines(path);
    }
}
