namespace SecondAttempt
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	using System.Xml.Serialization;
	using System.IO;

	public class XmlManager<T>
	{
		public Type Type;

		public XmlManager()
		{
			Type = typeof(T);
		}

		public T Load(string path)
		{
			T instance;
			try
			{
				using (TextReader reader = new StreamReader(path))
				{
					XmlSerializer xml = new XmlSerializer(Type);
					instance = (T)xml.Deserialize(reader);
				}
				return instance;
			}
			catch { throw new LoadGameException("You don't have any saved games to load!"); }
		}

		public void Save(String path, object obj)
		{
			using (TextWriter writer = new StreamWriter(path))
			{
				XmlSerializer xml = new XmlSerializer(Type);
				xml.Serialize(writer, obj);
			}
		}
	}
}
