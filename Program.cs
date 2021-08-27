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
            //Начало Условие 1
            DateTime dtStart = DateTime.Now;

            for (int i = 0; i < 100000; i++)
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

            //Результаты теста:

            //Цикл 100000 итераций без вывода на консоль
            //Start: 22.08.2021 23:42:34
            //Finish: 22.08.2021 23:42:36
            //Duration: 00:00:01.3137308

            //Цикл 100000 итераций с выводом на консоль
            //Start: 22.08.2021 23:44:16
            //Finish: 22.08.2021 23:45:21
            //Duration: 00:01:04.4306550

            //Конец Условие 1
            */

            /************************************************************************
            Условие 2: Сериализовать/десериализовать CSV с сохранением в файл.
            ************************************************************************/
            /*
            //Начало Условие 2
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

            //Результаты теста:

            //Цикл 100000 итераций без вывода на консоль
            //Start: 26.08.2021 22:04:32
            //Finish: 26.08.2021 22:07:34
            //Duration: 00:03:01.8301611

            //Конец Условие 2
            */

            /************************************************************************
            Условие 3: Сериализовать/десериализовать JSON без сохранения в файл.
            ************************************************************************/
            
            //Начало Условие 3

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

            //Результаты теста:

            //Цикл 100000 итераций без вывода на консоль
            //Start: 26.08.2021 23:25:06
            //Finish: 26.08.2021 23:25:09
            //Duration: 00:00:02.8499072

            //Start: 26.08.2021 23:25:47
            //Finish: 26.08.2021 23:26:10
            //Duration: 00:00:22.2223795
            //Конец Условие 3


            /************************************************************************
            Условие 4: Сериализовать/десериализовать JSON с сохранением в файл.
            ************************************************************************/
            /*
            //Начало Условие 4

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

            //Результаты теста:

            //Цикл 100000 итераций без вывода на консоль
            //Start: 26.08.2021 22:45:10
            //Finish: 26.08.2021 22:47:38
            //Duration: 00:02:27.9410906

            //Конец Условие 4
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
