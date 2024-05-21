namespace lab9.serializers;

public abstract class MySerializer<T> where T : class // показываем, что наш обобщенный тип данных является классом
{
    public abstract void Write(T t, string filename);

    public abstract T Read(string filename);
}