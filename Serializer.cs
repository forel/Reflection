using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Reflection
{
    public static class Serializer
    {
        private static string[] Delimiter = new string[] { "\r\n", "\n", "\r" };

        /************************************************************************
        Условие 1: Сериализовать/десериализовать CSV без сохранения в файл
        ************************************************************************/
        public static string SerializeFromObjectToCSV(F obj)
        {
            return CSVHeader(obj) + CSVValue(obj);
        }

        public static F DeserializeFromCSVToObject(string csv)
        {
            F f = new F();

            string[] Rows = csv.Split(Serializer.Delimiter, StringSplitOptions.RemoveEmptyEntries);
            var CountHeaders = Rows[0].Split(',').Length;
            string[] Headers = new string[CountHeaders];

            for (int i = 0; i < Rows.Count(); i++)
            {
                string[] rowValues = Rows[i].Split(',');

                for (int j = 0; j < rowValues.Count(); j++)
                {
                    //Получаем наименование заголовков для мэппинга со свойствами объекта при установке значений
                    if (i == 0)
                    {
                        Headers[j] = rowValues[j];
                    }
                    else
                    {
                        f.GetType().GetProperty(Headers[j]).SetValue(f, Convert.ToInt32(rowValues[j]), null);
                    }
                }
            }

            return f;
        }

        /************************************************************************
        Условие 2: Сериализовать/десериализовать CSV с сохранением в файл 
        ************************************************************************/
        public static void SerializeFromObjectToCSVFile(string filePath, F obj)
        {
            FileOperations.CSVWriter(filePath, CSVHeader(obj) + CSVValue(obj));
        }

        public static F DeserializeFromCSVFileToObject(string filePath)
        {
            F f = new F();
            string csv = FileOperations.CSVReader(filePath);
            string[] Rows = csv.Split(Serializer.Delimiter, StringSplitOptions.RemoveEmptyEntries);
            var CountHeaders = Rows[0].Split(',').Length;
            string[] Headers = new string[CountHeaders];

            for (int i = 0; i < Rows.Count(); i++)
            {
                string[] rowValues = Rows[i].Split(',');

                for (int j = 0; j < rowValues.Count(); j++)
                {
                    //Получаем наименование заголовков для мэппинга со свойствами объекта при установке значений
                    if (i == 0)
                    {
                        Headers[j] = rowValues[j];
                    }
                    else
                    {
                        f.GetType().GetProperty(Headers[j]).SetValue(f, Convert.ToInt32(rowValues[j]), null);
                    }
                }
            }

            return f;
        }

        /************************************************************************
        Условие 3: Сериализовать/десериализовать JSON без сохранения в файл
        ************************************************************************/
        public static string SerializeFromObjectToJSON(F obj)
        {
            string json = string.Empty;
            var jsonFormatter = new DataContractJsonSerializer(typeof(F));
            using (var ms = new MemoryStream())
            {
                jsonFormatter.WriteObject(ms, obj);
                ms.Position = 0;
                StreamReader sr = new StreamReader(ms);
                json = sr.ReadToEnd();

                return json;
            }
        }
        
        public static F DeserializeFromJSONToObject(string json)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(F));
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var f = jsonFormatter.ReadObject(ms) as F;
                return f;
            }
        }
        
        /************************************************************************
        Условие 4: Сериализовать/десериализовать JSON с сохранением в файл 
        ************************************************************************/
        public static void SerializeFromObjectToJSONFile(string filePath, F obj)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(F));
            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, obj);
            }
        }

        public static F DeserializeFromJSONFileToObject(string filePath)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(F));
            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                var f = jsonFormatter.ReadObject(fs) as F;
                return f;
            }
        }

        public static string CSVHeader(F f)
        {
            string header = String.Empty;
            Type type = f.GetType();
            PropertyInfo[] props = type.GetProperties();

            foreach (PropertyInfo prop in props)
            {
                if (String.IsNullOrEmpty(header))
                {
                    header = prop.Name;
                }
                else
                {
                    header = header + ',' + prop.Name;
                }
            }

            header = header + Environment.NewLine;
            return header;
        }

        public static string CSVValue(F f)
        {
            string value = String.Empty;
            Type type = f.GetType();
            PropertyInfo[] props = type.GetProperties();

            foreach (PropertyInfo prop in props)
            {
                if (String.IsNullOrEmpty(value))
                {
                    value = prop.GetValue(f).ToString();
                }
                else
                {
                    value = value + ',' + prop.GetValue(f).ToString();
                }
            }

            value = value + Environment.NewLine;
            return value;
        }
    }
}
