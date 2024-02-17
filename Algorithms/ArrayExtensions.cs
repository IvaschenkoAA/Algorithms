namespace Algorithms;

public static class ArrayExtensions
{
    public static TItem? SafetyGetItem<TItem>(this TItem[] array, int i)
    {
        if (i < 0 || i >= array.Length)
            return default;

        return array[i];
    }

    public static TItem? SafetyGetItem<TItem>(this TItem[,] matrix, int i, int j)
    {
        if (i < 0 || j < 0 || i >= matrix.GetLength(0) || j >= matrix.GetLength(1))
            return default;

        return matrix[i, j];
    }
}