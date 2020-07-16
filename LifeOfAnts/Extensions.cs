using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace LifeOfAnts.Logic
{
	public static class Extensions
	{
		public static T DeepCloneExtensions<T>(this T obj)
		{
			using (MemoryStream stream = new MemoryStream())
			{
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(stream, obj);
				stream.Position = 0;

				return (T)formatter.Deserialize(stream);
			}
		}
		public static int MyRandomNumberGenerator(int min, int max)
        {
			Random generator = new Random();
			return generator.Next(min, max + 1);

        }
	}
}
