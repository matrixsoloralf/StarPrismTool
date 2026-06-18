using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using StarPrismTools.Infrastructure;

namespace StarPrismTools.Data.Json
{
	public class JsonFileStore : IJsonFileStore
	{
		private static readonly Encoding Utf8WithoutBom = new UTF8Encoding(false);

		public OperationResult<T> Load<T>(string filePath) where T : class
		{
			try
			{
				if (!File.Exists(filePath))
				{
					return OperationResult<T>.Fail("JSON file does not exist: " + filePath);
				}

				using (FileStream stream = File.OpenRead(filePath))
				{
					DataContractJsonSerializer serializer = CreateSerializer(typeof(T));
					return OperationResult<T>.Ok((T)serializer.ReadObject(stream));
				}
			}
			catch (Exception ex)
			{
				return OperationResult<T>.Fail("Failed to load JSON file: " + filePath, ex);
			}
		}

		public OperationResult Save<T>(string filePath, T value, bool createBackup = true) where T : class
		{
			try
			{
				string directory = Path.GetDirectoryName(filePath);
				if (!string.IsNullOrEmpty(directory))
				{
					Directory.CreateDirectory(directory);
				}

				if (createBackup && File.Exists(filePath))
				{
					File.Copy(filePath, filePath + ".bak", true);
				}

				string json = SerializePretty(value, typeof(T));
				File.WriteAllText(filePath, json, Utf8WithoutBom);
				return OperationResult.Ok("JSON file saved: " + filePath);
			}
			catch (Exception ex)
			{
				return OperationResult.Fail("Failed to save JSON file: " + filePath, ex);
			}
		}

		private static DataContractJsonSerializer CreateSerializer(Type type)
		{
			return new DataContractJsonSerializer(type, new DataContractJsonSerializerSettings
			{
				UseSimpleDictionaryFormat = true
			});
		}

		private static string SerializePretty(object value, Type type)
		{
			using (MemoryStream rawStream = new MemoryStream())
			{
				CreateSerializer(type).WriteObject(rawStream, value);
				rawStream.Position = 0;

				using (XmlDictionaryReader reader = JsonReaderWriterFactory.CreateJsonReader(rawStream, XmlDictionaryReaderQuotas.Max))
				using (MemoryStream formattedStream = new MemoryStream())
				{
					XmlWriterSettings settings = new XmlWriterSettings
					{
						Encoding = Utf8WithoutBom,
						Indent = true
					};

					using (XmlDictionaryWriter writer = JsonReaderWriterFactory.CreateJsonWriter(formattedStream, Utf8WithoutBom, false, settings.Indent))
					{
						writer.WriteNode(reader, true);
					}

					return Utf8WithoutBom.GetString(formattedStream.ToArray());
				}
			}
		}
	}
}
