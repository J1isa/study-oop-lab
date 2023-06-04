using System;
using System.Collections.Generic;

namespace StudentApplication
{
    interface IAnimal
    {
        string GetHabitat();
    }
    interface IPlant
    {
        decimal GetPrice();
    }
    class Organism
    {
        // Поля объекта класса "Организм"
        protected string name;
        protected string description;
        protected string type;

        // Виртуальные свойства доступа к полям объекта класса "Организм"
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual string Type
        {
            get { return type; }
            set { type = value; }
        }

        // Конструктор объекта класса "Организм"
        public Organism(string name, string description, string type)
        {
            this.name = name;
            this.description = description;
            this.type = type;
        }

        // Метод для вывода информации об организме
        public virtual string PrintInfo()
        {
            return $"{type} {name}: {description}.";
        }
    }

    class Animal : Organism, IAnimal
    {
        // Поля объекта класса "Животное"
        private string habitat;

        // Свойства доступа к полям объекта класса "Животное"
        public string Habitat
        {
            get { return habitat; }
            set { habitat = value; }
        }

        // Конструктор объекта класса "Животное"
        public Animal(string name, string description, string type, string habitat) : base(name, description, type)
        {
            this.habitat = habitat;
        }

        // Реализация метода интерфейса IAnimal
        public string GetHabitat()
        {
            return habitat;
        }

        // Переопределенный метод для вывода информации об организме
        public override string PrintInfo()
        {
            return $"{base.PrintInfo()} Обитает в {habitat}.";
        }
    }

    class Plant : Organism, IPlant
    {
        // Поля объекта класса "Растение"
        private decimal price;

        // Свойства доступа к полям объекта класса "Растение"
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        // Конструктор объекта класса "Растение"
        public Plant(string name, string description, string type, decimal price) : base(name, description, type)
        {
            this.price = price;
        }

        // Реализация метода интерфейса IPlant
        public decimal GetPrice()
        {
            return price;
        }

        // Переопределенный метод для вывода информации об организме
        public override string PrintInfo()
        {
            return $"{base.PrintInfo()} Цена: {price} рублей.";
        }
    }
    static class AnimalExtensions
    {
        public static string GetHabitatInfo(this IAnimal animal)
        {
            return $"Место обитания: {animal.GetHabitat()}";
        }
    }
    static class PlantExtensions
    {
        public static string GetPriceInfo(this IPlant plant)
        {
            return $"Цена: {plant.GetPrice()} рублей";
        }
    }
    class MedicineChest
    {
        // Поля объекта класса "Аптечка"
        private string name;
        private List<Organism> organisms = new List<Organism>();

        // Свойства доступа к полям объекта класса "Аптечка"
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Конструктор объекта класса "Аптечка"
        public MedicineChest(string name)
        {
            this.name = name;
        }

        // Метод для добавления организма в аптечку
        public void AddOrganism(Organism organism)
        {
            organisms.Add(organism);
        }

        // Метод для удаления организма из аптечки
        public void RemoveOrganism(Organism organism)
        {
            organisms.Remove(organism);
        }

        // Метод для вывода всех организмов в аптечке
        public void PrintOrganisms()
        {
            foreach (Organism organism in organisms)
            {
                Console.WriteLine(organism.PrintInfo());
            }
        }

        // Метод для определения стоимости всех растений в аптечке
        public decimal GetTotalPlantPrice()
        {
            decimal totalPrice = 0;
            foreach (Organism organism in organisms)
            {
                if (organism is Plant)
                {
                    Plant plant = (Plant)organism;
                    totalPrice += plant.Price;
                }
            }
            return totalPrice;
        }

        public List<Organism> GetOrganisms()
        {
            return organisms;
        }
    }

    class Program // главный класс программы
    {
        static void Main(string[] args)
        {
            MedicineChest medicineChest = new MedicineChest("Моя аптечка");

            // Добавление объектов классов "Животное" и "Растение" в аптечку
            medicineChest.AddOrganism(new Animal("Лев", "Крупный млекопитающий", "Хищник", "Саванна"));
            medicineChest.AddOrganism(new Plant("Кактус", "Растение семейства кактусовых", "Кактус", 20));
            // Использование делегата для получения информации об организмах в аптечке
            Func<Organism, string> getInfo = (organism) =>
            {
                if (organism is IAnimal)
                {
                    return $"{organism.PrintInfo()} {((IAnimal)organism).GetHabitatInfo()}";
                }
                else if (organism is IPlant)
                {
                    return $"{organism.PrintInfo()} {((IPlant)organism).GetPriceInfo()}";
                }
                else
                {
                    return organism.PrintInfo();
                }
            };
            // Вывод информации об организмах в аптечке
            Console.WriteLine("Организмы в аптечке:");
            foreach (Organism organism in medicineChest.GetOrganisms())
            {
                Console.WriteLine(getInfo(organism));
            }

            Console.ReadKey();

            Console.WriteLine("Добро пожаловать в учет лекарственных организмов!");

            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Добавить организм");
                Console.WriteLine("2. Удалить организм");
                Console.WriteLine("3. Вывести все организмы");
                Console.WriteLine("4. Вывести стоимость растений в аптечке");
                Console.WriteLine("5. Выйти из программы");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
                {
                    Console.WriteLine("Ошибка ввода. Повторите попытку.");
                }

                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Выберите тип организма:");
                        Console.WriteLine("1. Животное");
                        Console.WriteLine("2. Растение");

                        int organismChoice;
                        while (!int.TryParse(Console.ReadLine(), out organismChoice) || organismChoice < 1 || organismChoice > 2)
                        {
                            Console.WriteLine("Ошибка ввода. Повторите попытку.");
                        }

                        Console.Write("\nВведите название организма: ");
                        string name = Console.ReadLine();

                        Console.Write("Введите описание организма: ");
                        string description = Console.ReadLine();

                        switch (organismChoice)
                        {
                            case 1:
                                Console.Write("Введите место обитания животного: ");
                                string habitat = Console.ReadLine();

                                Animal animal = new Animal(name, description, "Животное", habitat);
                                medicineChest.AddOrganism(animal);

                                Console.WriteLine($"\n{animal.PrintInfo()} успешно добавлено в аптечку!\n");

                                break;

                            case 2:
                                Console.Write("Введите цену растения (в рублях): ");
                                decimal price;
                                while (!decimal.TryParse(Console.ReadLine(), out price) || price <= 0)
                                {
                                    Console.WriteLine("Ошибка ввода. Повторите попытку.");
                                }

                                Plant plant = new Plant(name, description, "Растение", price);
                                medicineChest.AddOrganism(plant);

                                Console.WriteLine($"\n{plant.PrintInfo()} успешно добавлено в аптечку!\n");

                                break;
                        }

                        break;

                    case 2:
                        List<Organism> organismsToRemove = medicineChest.GetOrganisms();

                        if (organismsToRemove.Count == 0)
                        {
                            Console.WriteLine("Аптечка пуста, нет организмов для удаления.\n");
                            break;
                        }

                        Console.WriteLine("Выберите организм для удаления:");

                        for (int i = 0; i < organismsToRemove.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {organismsToRemove[i].PrintInfo()}");
                        }

                        int deleteIndex;
                        while (!int.TryParse(Console.ReadLine(), out deleteIndex) || deleteIndex < 1 || deleteIndex > organismsToRemove.Count)
                        {
                            Console.WriteLine("Ошибка ввода. Повторите попытку.");
                        }

                        try
                        {
                            medicineChest.RemoveOrganism(organismsToRemove[deleteIndex - 1]);
                            Console.WriteLine($"\n{organismsToRemove[deleteIndex - 1].PrintInfo()} успешно удалено из аптечки!\n");
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine($"Ошибка: организма под номером {deleteIndex} не существует в аптечке!\n");
                        }

                        break;

                    case 3:
                        Console.WriteLine("Организмы в аптечке:");
                        foreach (Organism organism in medicineChest.GetOrganisms())
                        {
                            Console.WriteLine(organism.PrintInfo());
                            if (organism is IAnimal)
                            {
                                Console.WriteLine(((IAnimal)organism).GetHabitatInfo());
                            }
                            else if (organism is IPlant)
                            {
                                Console.WriteLine(((IPlant)organism).GetPriceInfo());
                            }
                        }
                        Console.WriteLine();
                        break;

                    case 4:
                        Console.WriteLine($"Стоимость лекарственных растений в аптечке {medicineChest.Name}: {medicineChest.GetTotalPlantPrice()} рублей\n");
                        break;

                    case 5:
                        Console.WriteLine("До свидания!");
                        return;
                }
            }

        }
    }
}