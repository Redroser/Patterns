using System;
using Patterns.Strategy;
using Patterns.Observer;
using Patterns.Decorator;
using Patterns.FactoryMethod;
using Patterns.Singleton;
using Patterns.CommandPattern;
using Patterns.AdapterPattern;
using Patterns.TemplateMethod;
using Patterns.IteratorPattern;
using Patterns.Composite;
using Patterns.BuilderPattern;
using System.Threading;
using System.Collections.Generic;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //Strategy();
            //Observer();
            //Decorator();
            //FactoryMethod();
            //Singleton();
            //Command();
            //Adapter();
            //TemplateMethod();
            //Iterator();
            //Composite();
            //Builder();
        }

        public static void Strategy() {
            // Проверка работы паттерна Strategy

            Solder solder = new Solder(new GunShooting());
            solder.Fire();
            solder.SolderStrategy = new MachineGunShooting();
            solder.Fire();
        }
        public static void Observer() {
            // Проверка работы паттерна Observer

            TempSensor sensor1 = new TempSensor();
            TempSensor sensor2 = new TempSensor();
            WeatherController weatherController = new WeatherController(sensor1);
            sensor1.SetTemperature(25.4);
            sensor1.SetTemperature(28.5);
            sensor2.AddObserver(weatherController);
            sensor1.SetTemperature(26.1);
            sensor2.SetTemperature(15.8);
            sensor2.SetTemperature(14.0);
            sensor1.SetTemperature(23.9);
            sensor1.RemoveObserver(weatherController);
            sensor1.SetTemperature(24.3);
            sensor2.SetTemperature(15.2);
        }
        public static void Decorator() {
            // Проверка работы паттерна Decorator

            Burger burger1 = new ChickenBurger();
            burger1 = new Cheese(burger1);
            Console.WriteLine("Название: {0}", burger1.Name);
            Console.WriteLine("Цена: {0}", burger1.GetCost());

            Burger burger2 = new PorkBurger();
            burger2 = new Cucumbers(burger2);
            Console.WriteLine("Название: {0}", burger2.Name);
            Console.WriteLine("Цена: {0}", burger2.GetCost());
        }
        public static void FactoryMethod() {
            CarDeveloper hondaDev = new HondaDeveloper("Завод в Йокогаме");
            Car hondaHRV = hondaDev.Create("HR-V");

            CarDeveloper toyotaDev = new ToyotaDeveloper("Завод в Токио");
            Car toyotaSupra = toyotaDev.Create("Supra");
        }
        public static void Singleton() {
            (new Thread(() =>
            {
                UniqObject russia = UniqObject.getInstance("Mother Russia");
                Console.WriteLine(russia.Name);

            })).Start();
            UniqObject usa = UniqObject.getInstance("Great America");
            Console.WriteLine(usa.Name);
        }
        public static void Command() {
            Pult pult = new Pult();
            TV tv = new TV();
            pult.SetCommand(new List<Command>() { new TVOnCommand(tv), new TVOffCommand(tv)});
            pult.PressButton(0);
            pult.PressUndo(0);
            pult.PressButton(1);
            pult.PressUndo(1);
        }
        public static void Adapter() {
            Driver driver = new Driver();
            Bus bus = new Bus();
            DogTeam dogTeam = new DogTeam();
            driver.Travel(bus);
            ITransport dogTeamTransport = new DogTeamToTransportAdapter(dogTeam);
            driver.Travel(dogTeamTransport);
        }
        public static void TemplateMethod() {
            Tea tea = new Tea();
            Coffee coffee = new Coffee();
            tea.PrepareDrink();
            Console.WriteLine("--------------------------------");
            coffee.PrepareDrink();
        }
        public static void Iterator() {
            Library library = new Library();
            Reader reader = new Reader();
            reader.SeeBooks(library);
        }
        public static void Composite() {
            // Паттерн Компоновщик

            Component fileSystem = new Directory("Файловая система");
            // определяем новый диск
            Component diskC = new Directory("Диск С");
            // новые файлы
            Component pngFile = new File("12345.png");
            Component docxFile = new File("Document.docx");
            // добавляем файлы на диск С
            diskC.Add(pngFile);
            diskC.Add(docxFile);
            // добавляем диск С в файловую систему
            fileSystem.Add(diskC);
            // выводим все данные
            fileSystem.Print();
            Console.WriteLine();
            // удаляем с диска С файл
            diskC.Remove(pngFile);
            // создаем новую папку
            Component docsFolder = new Directory("Мои Документы");
            // добавляем в нее файлы
            Component txtFile = new File("readme.txt");
            Component csFile = new File("Program.cs");
            docsFolder.Add(txtFile);
            docsFolder.Add(csFile);
            diskC.Add(docsFolder);

            fileSystem.Print();
        }
        public static void Builder() {
            // содаем объект пекаря
            Baker baker = new Baker();
            // создаем билдер для ржаного хлеба
            BreadBuilder builder = new RyeBreadBuilder();
            // выпекаем
            Bread ryeBread = baker.Bake(builder);
            Console.WriteLine(ryeBread.ToString());
            // оздаем билдер для пшеничного хлеба
            builder = new WheatBreadBuilder();
            Bread wheatBread = baker.Bake(builder);
            Console.WriteLine(wheatBread.ToString());
        }
    }
}
