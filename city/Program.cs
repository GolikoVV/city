using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Запрос количества городов у пользователя
        Console.WriteLine("Введите количество городов:");
        int cityCount = int.Parse(Console.ReadLine());

        // Создание словаря для хранения расстояний между городами
        Dictionary<string, Dictionary<string, int>> distances = new Dictionary<string, Dictionary<string, int>>();

        // Заполнение словаря расстояний
        for (int i = 0; i < cityCount; i++)
        {
            Console.WriteLine($"Введите название города {i + 1}:");
            string city1 = Console.ReadLine();

            Console.WriteLine("Введите количество связанных городов:");
            int connectedCityCount = int.Parse(Console.ReadLine());

            // Создание словаря для хранения расстояний для текущего города
            Dictionary<string, int> cityDistances = new Dictionary<string, int>();

            for (int j = 0; j < connectedCityCount; j++)
            {
                Console.WriteLine($"Введите название связанного города {j + 1}:");
                string city2 = Console.ReadLine();

                Console.WriteLine("Введите расстояние между городами:");
                int distance = int.Parse(Console.ReadLine());

                // Добавление расстояния в словарь для текущего города
                cityDistances[city2] = distance;
            }


            // Добавление словаря расстояний для текущего города в общий словарь
            distances[city1] = cityDistances;
        }

        // Запрос городов, для которых нужно найти минимальное и максимальное расстояние
        Console.WriteLine("Введите название первого города:");
        string cityA = Console.ReadLine();

        Console.WriteLine("Введите название второго города:");
        string cityB = Console.ReadLine();

        // Поиск минимального расстояния между городами
        int minDistance = int.MaxValue;

        // Проверка наличия расстояния в словаре для заданных городов
        if (distances.ContainsKey(cityA) && distances[cityA].ContainsKey(cityB))
        {
            minDistance = distances[cityA][cityB];
        }

        // Поиск максимального расстояния между городами
        int maxDistance = int.MinValue;

        // Проверка наличия расстояния в словаре для заданных городов
        if (distances.ContainsKey(cityA) && distances[cityA].ContainsKey(cityB))
        {
            maxDistance = distances[cityA][cityB];
        }

        // Перебор всех городов и проверка наличия расстояний
        foreach (var city1 in distances.Keys)
        {
            foreach (var city2 in distances[city1].Keys)
            {
                int distance = distances[city1][city2];

                // Обновление минимального расстояния, если текущее расстояние меньше
                if (distance < minDistance)
                {
                    minDistance = distance;
                }

                // Обновление максимального расстояния, если текущее расстояние больше
                if (distance > maxDistance)
                {
                    maxDistance = distance;
                }
            }
        }

        // Вывод результатов
        Console.WriteLine($"Минимальное расстояние между городами {cityA} и {cityB}: {minDistance}");
        Console.WriteLine($"Максимальное расстояние между городами {cityA} и {cityB}: {maxDistance}");
    }
}