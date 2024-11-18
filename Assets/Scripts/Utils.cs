public static class Utils
{
    public static bool IsLayerMatched(int value, int layer)
    {
        return value == (value | 1 << layer);
    }
}