namespace TerrarioSharp;

using System.Text.RegularExpressions;

public static class T
{
    public static Parser<T[]> Many<T>(Parser<T> parser, int min)
    {
        throw new NotImplementedException();
    }

    public static Parser<T[]> ManyWithout<T>(Parser<T> parser, int min, Parser<object> terminator)
    {
        throw new NotImplementedException();
    }

    public static Parser<string> Str(Regex pattern)
    {
        return StrWithRegex(pattern);
    }

    public static Parser<string> Str(string value)
    {
        return StrWithString(value);
    }

    public static Parser<string> StrWithRegex(Regex pattern)
    {
        throw new NotImplementedException();
    }

    public static Parser<string> StrWithString(string value)
    {
        throw new NotImplementedException();
    }
}
