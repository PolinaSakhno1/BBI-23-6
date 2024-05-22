using ProtoBuf;

namespace lab9.serializers;

public class MyXmlSerializer<T> : MySerializer<T> where T : class // показываем, что наш обобщенный тип данных является классом
{
    public override T Read(string filename)
    {
        using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
        {
            return Serializer.Deserialize<T>(fs);
        }
    }

    public override void Write(T t, string filename)
    {
        using (FileStream fs = new FileStream(filename, FileMode.Create))
        {
            Serializer.Serialize(fs, t);
        }
    }
}
