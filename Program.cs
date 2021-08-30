using System;
using System.Runtime.Serialization;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            /************************************************************************   
            ВНИМАНИЕ:   Для каждого из условий (1,2,3) ниже необходимо 
                        раскомментировать соответствующие блоки кода ориентируясь на 
                        соответствующую нумерацию в комментариях.
            ************************************************************************/

            /************************************************************************
            Условие 1: Сериализовать/десериализовать CSV без сохранения в файл.
            ************************************************************************/
            
            /*
            
            DateTime dtStart = DateTime.Now;

            for (int i = 0; i < 1000; i++)
            {
                //Сериализация
                F f = new F(1, 2, 3, 4, 5);

                var CSV = Serializer.SerializeFromObjectToCSV(f);
                Console.WriteLine("Сериализация:");
                Console.WriteLine(CSV);

                //Десериализация
                var obj = Serializer.DeserializeFromCSVToObject(CSV);
                Console.WriteLine("Десериализация:");
                Console.WriteLine($"{obj.I1},{obj.I2},{obj.I3},{obj.I4},{obj.I5}");
            }

            Console.WriteLine($"Start: {dtStart}{Environment.NewLine}Finish: {DateTime.Now}{Environment.NewLine}Duration: {DateTime.Now.Subtract(dtStart)}");

            */
            

            /************************************************************************
            Условие 2: Сериализовать/десериализовать CSV с сохранением в файл.
            ************************************************************************/
            
            /*
            
            DateTime dtStart = DateTime.Now;

            for (int i = 0; i < 100000; i++)
            {
                //Сериализация
                F f = new F(1, 2, 3, 4, 5);
                Serializer.SerializeFromObjectToCSVFile("CSVSerialized.csv", f);

                //Десериализация
                F f1 = Serializer.DeserializeFromCSVFileToObject("CSVSerialized.csv");
                //Console.WriteLine($"{f1.I1},{f1.I2},{f1.I3},{f1.I4},{f1.I5}");
            }

            Console.WriteLine($"Start: {dtStart}{Environment.NewLine}Finish: {DateTime.Now}{Environment.NewLine}Duration: {DateTime.Now.Subtract(dtStart)}");

            */

            /************************************************************************
            Условие 3: Сериализовать/десериализовать JSON без сохранения в файл.
            ************************************************************************/

            /*

            DateTime dtStart = DateTime.Now;

            for (int i = 0; i < 100000; i++)
            {
                //Сериализация
                F f = new F(1, 2, 3, 4, 5);
                var json = Serializer.SerializeFromObjectToJSON(f);

                //Десериализация
                F f1 = Serializer.DeserializeFromJSONToObject(json);
                Console.WriteLine($"{f1.I1},{f1.I2},{f1.I3},{f1.I4},{f1.I5}");
            }

            Console.WriteLine($"Start: {dtStart}{Environment.NewLine}Finish: {DateTime.Now}{Environment.NewLine}Duration: {DateTime.Now.Subtract(dtStart)}");

            */

            /************************************************************************
            Условие 4: Сериализовать/десериализовать JSON с сохранением в файл.
            ************************************************************************/
            /*

            DateTime dtStart = DateTime.Now;

            for (int i = 0; i < 100000; i++)
            {
                //Сериализация
                F f = new F(1, 2, 3, 4, 5);
                Serializer.SerializeFromObjectToJSONFile("JSONSerialized.json", f);

                //Десериализация
                F f1 = Serializer.DeserializeFromJSONFileToObject("JSONSerialized.json");
                //Console.WriteLine($"{f1.I1},{f1.I2},{f1.I3},{f1.I4},{f1.I5}");
            }

            Console.WriteLine($"Start: {dtStart}{Environment.NewLine}Finish: {DateTime.Now}{Environment.NewLine}Duration: {DateTime.Now.Subtract(dtStart)}");

            */

        }
    }

    [DataContract]
    public class F
    {
        [DataMember]
        public int I1 { get; set; }
        [DataMember]
        public int I2 { get; set; }
        [DataMember]
        public int I3 { get; set; }
        [DataMember]
        public int I4 { get; set; }
        [DataMember]
        public int I5 { get; set; }

        public F()
        {
            I1 = 0;
            I2 = 0;
            I3 = 0;
            I4 = 0;
            I5 = 0;
        }

        public F( int i1, int i2, int i3, int i4, int i5)
        {
            I1 = i1;
            I2 = i2;
            I3 = i3;
            I4 = i4;
            I5 = i5;
        }      
    }
}
