namespace TerrarioSharp;

using AnyObject = Dictionary<string, object>;

public delegate Result<T> ParserHandler<T>(string input, int index, AnyObject? state = default);

public record class Parser<TResult>(ParserHandler<TResult> Handler, string? Name = default)
{
    public Result<TResult> Parse(string input, AnyObject? state = null)
    {
        throw new NotImplementedException();
    }

    public Parser<U> Map<U>(Func<TResult, U> fn)
    {
        return new Parser<U>((input, index, state) => {
            var result = Handler(input, index, state);
            if (!result.Success) return Failure<U>(result.Index);

            return Success(result.Index, fn(result.Value!));
        });
    }

    public Parser<string> Text()
    {
        return new Parser<string>((input, index, state) => {
            var result = Handler(input, index, state);
            if (!result.Success) return Failure<string>(result.Index);

            var text = input[(index)..(result.Index)];
            return Success(result.Index, text);
        });
    }

    public Parser<TResult[]> Many(int min, Parser<object>? terminator = default)
    {
        return terminator != null ? T.ManyWithout(this, min, terminator) : T.Many(this, min);
    }

    public Parser<TResult?> Option()
    {
        return T.Alt(this, T.Succeeded(null));
    }

    private Result<U> Failure<U>(int index) => new (false, index, default);
    private Result<U> Success<U>(int index, U value) => new (true, index, value);
}
