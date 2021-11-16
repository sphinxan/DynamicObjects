using System;
using System.IO;

// Файл Classes.txt хранит данные об имеющихся типах объектах:
// ClassId; ClassName
// 1;       Crocodile
// 2;       Human

// Файл Properties.txt хранит информацию о полях объектов:
// ClassId; PropertyId; PropertyName; PropertyType
// 1;       1;          Color;        string
// 1;       2;          Length;       int
// 2;       1;          Name;         string
// 2;       2;          Age;          int

// Файл Objects.txt содержит данные о значениях полей у конкретного объекта:
// ClassId; ObjectId; PropertyId; PropertyValue
// 1;       MyCrocodile;   1;     green
// 1;       MyCrocodile;   2;     150
// 2;       Ivan;          1;     Ivan
// 2;       Ivan;          2;     20
// 2;       AnotherHuman;  1;     Oleg
// 2;       AnotherHuman;  2;     18

//Таким образом у нас создано два объекта: один Crocodile и два Human. 
//Создайте объектную модель, считайте из файла данные и сконструируйте объекты для использования в программном коде.

namespace DynamicObjects
{
    public class Class
    {
        public int ClassId { get; private set; }
        public string ClassName { get; private set; }

        public Class(int id, string name)
        {
            ClassId = id;
            ClassName = name;
        }

        public void ReadFile()
        {
            var file = new StreamReader("Classes.txt");
            file.ReadLine();

            while (!file.EndOfStream)
            {
                var array = file.ReadLine().Split(';');
                new Class(Convert.ToInt32(array[0]), array[1]);
            }
        }

    }


    public class Property
    {
        public Class ClassId;
        public int PropertyId;
        public string PropertyName;
        public string PropertyType;

        public Property(Class classId, int id, string name, string type)
        {
            ClassId = classId;
            PropertyId = id;
            PropertyName = name;
            PropertyType = type;
        }

        public void ReadFile()
        {
            var file = new StreamReader("Properties.txt");
            file.ReadLine();

            while(!file.EndOfStream)
            {
                var array = file.ReadLine().Split(';');
                //new Property(array[0], Convert.ToInt32(array[1]), array[2], array[3]);
            }
        }

    }


    public class Object
    {
        public Class ClassId { get; private set; }
        public int ObjectId { get; private set; }

        public Property PropertyId { get; private set; }
        public string PropertyValue { get; private set; }
        
        public Object(Class classId, int id, Property propertyId, string value)
        {
            ClassId = classId;
            ObjectId = id;
            PropertyId = propertyId;
            PropertyValue = value;
        }

        public void ReadFile()
        {
            var file = new StreamReader("Objects.txt");
            file.ReadLine();

            while(!file.EndOfStream)
            {
                var array = file.ReadLine().Split(';');
                //new Object();
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
