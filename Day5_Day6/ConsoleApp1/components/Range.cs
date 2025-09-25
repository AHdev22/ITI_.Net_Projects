using System;

public class Range<T> where T : IComparable<T>
{
    private T min;
    private T max;

    public Range(T min, T max)
    {
        if (min.CompareTo(max) > 0)
            throw new ArgumentException("Minimum cannot be greater than maximum.");
        this.min = min;
        this.max = max;
    }

    public bool IsInRange(T value)
    {
        return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
    }

    public dynamic Length()
    {
        return (dynamic)max - (dynamic)min;
    }
}
