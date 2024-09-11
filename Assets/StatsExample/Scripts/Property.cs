using System;
using System.Collections.Generic;

public abstract class Property<T>: IReadOnlyProperty<T> where T: IComparable
{
    public event Action<T> Changed;

    private T _value;

    public Property(T value)
    {
        Value = value;
    }

    public T Value
    {
        get => _value;
        set
        {
            if(IsValid(value) == false)
                throw new ArgumentException(nameof(value)); 

            T oldValue = _value;

            _value = value;

            if (_value.CompareTo(oldValue) != 0)
                Changed?.Invoke(_value);
        }
    }

    protected abstract bool IsValid(T value);
}

public class NotLimitedProperty<T> : Property<T> where T : IComparable
{
    public NotLimitedProperty(T value) : base(value)
    {
    }

    protected override bool IsValid(T value) => true;
}

public class NotLessZeroProperty<T> : Property<T> where T : IComparable
{
    public NotLessZeroProperty(T value) : base(value)
    {
    }

    protected override bool IsValid(T value)
    {
        if(Comparer<T>.Default.Compare(value, default(T)) < 0)
            return false;
        else
            return true;
    }
}

public interface IReadOnlyProperty<T>
{
    event Action<T> Changed;
    T Value { get; }
}

public class Mover
{
    private NotLessZeroProperty<float> _speed = new(5);

    public IReadOnlyProperty<float> Speed => _speed;    
} 