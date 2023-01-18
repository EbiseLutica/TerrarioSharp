namespace TerrarioSharp;

/// <summary>
/// パーサーの実行結果。
/// </summary>
public record struct Result<T>(bool Success, int Index, T? Value = default);
