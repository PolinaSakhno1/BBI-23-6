using System.Xml.Serialization;

namespace lab9.serializers;

public class MyBinarySerializer<T> : MySerializer<T> where T : class // показываем, что наш обобщенный тип данных является классом
{
    public override T Read(string filename)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
        {
            return xmlSerializer.Deserialize(fs) as T;
        }
    }

    public override void Write(T t, string filename)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        using (FileStream fs = new FileStream(filename, FileMode.Create))
        {
            xmlSerializer.Serialize(fs, t);
        }
    }
}
