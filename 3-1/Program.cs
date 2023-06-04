using System;
using System.Collections.Generic;

namespace StudentApplication
{
    class Plant
    {
        // Поля объекта класса "Растение"
        private string name;
        private string description;
        private decimal price;

        // Свойства доступа к полям объекта класса "Растение"
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        // Конструктор объекта класса "Растение"
        public Plant(string name, string description, decimal price)
        {
            this.name = name;
            this.description = description;
            this.price = price;
        }

        // Метод для вывода информации о растении
        public override string ToString()
        {
            return $"{name}: {description}. Цена: {price}";
        }
    }

    class MedicineChest
    {
        // Поля объекта класса "Аптечка"
        private string name;
        private List<Plant> plants = new List<Plant>();

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

        // Метод для добавления растения в аптечку
        public void AddPlant(Plant plant)
        {
            plants.Add(plant);
        }

        // Метод для удаления растения из аптечки
        public void RemovePlant(Plant plant)
        {
            plants.Remove(plant);
        }

        // Метод для вывода всех растений в аптечке
        public void PrintPlants()
        {
            foreach (Plant plant in plants)
            {
                Console.WriteLine(plant.ToString());
            }
        }

        // Метод для определения стоимости всех растений в аптечке
        public decimal GetTotalPlantPrice()
        {
            decimal totalPrice = 0;
            foreach (Plant plant in plants)
            {
                totalPrice += plant.Price;
            }
            return totalPrice;
        }
        public List<Plant> GetPlants()
        {
            return plants;
        }
    }
    class Program // главный класс программы
    {
        static void Main(string[] args)
        {
            MedicineChest medicineChest = new MedicineChest("Моя аптечка");

            Console.WriteLine("Добро пожаловать в учет лекарственных растений!");

            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Добавить растение");
                Console.WriteLine("2. Удалить растение");
                Console.WriteLine("3. Вывести все растения");
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
                        Console.Write("Введите название растения: ");
                        string name = Console.ReadLine();

                        Console.Write("Введите описание растения: ");
                        string description = Console.ReadLine();

                        decimal price;
                        Console.Write("Введите цену растения (в рублях): ");
                        while (!decimal.TryParse(Console.ReadLine(), out price) || price <= 0)
                        {
                            Console.WriteLine("Ошибка ввода. Повторите попытку.");
                        }

                        Plant plant = new Plant(name, description, price);
                        medicineChest.AddPlant(plant);

                        Console.WriteLine($"\n{plant.ToString()} успешно добавлено в аптечку!\n");

                        break;

                    case 2:
                        List<Plant> plantsToRemove = medicineChest.GetPlants();

                        if (plantsToRemove.Count == 0)
                        {
                            Console.WriteLine("Аптечка пуста, нет растений для удаления.\n");
                            break;
                        }

                        Console.WriteLine("Выберите растение для удаления:");

                        for (int i = 0; i < plantsToRemove.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {plantsToRemove[i].ToString()}");
                        }

                        int deleteIndex;
                        while (!int.TryParse(Console.ReadLine(), out deleteIndex) || deleteIndex < 1 || deleteIndex > plantsToRemove.Count)
                        {
                            Console.WriteLine("Ошибка ввода. Повторите попытку.");
                        }

                        try
                        {
                            medicineChest.RemovePlant(plantsToRemove[deleteIndex - 1]);
                            Console.WriteLine($"\n{plantsToRemove[deleteIndex - 1].ToString()} успешно удалено из аптечки!\n");
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine($"Ошибка: растения под номером {deleteIndex} не существует в аптечке!\n");
                        }

                        break;

                    case 3:
                        Console.WriteLine("Лекарственные растения в аптечке:");
                        medicineChest.PrintPlants();
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