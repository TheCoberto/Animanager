using Animanager.Models;
using System;

namespace Animanager.UI
{
    public class Controller
    {
        Repository repo;
        public Controller()
        {
            repo = new Repository();
        }

        public void Start()
        {
            while (true)
            {
                DisplayMenu();

                int.TryParse(Console.ReadLine(), out var result);

                switch (result)
                {
                    case 1:
                        Create();
                        break;
                    case 2:
                        ReadAll();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Delete();
                        break;
                    default:
                        break;
                }
            }
        }

        public static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Animanager. Please select from the list of options.");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Read All");
        }

        public void Create()
        {
            Animal animal = new Animal();
            Console.WriteLine("Enter a name for the new animal.");
            animal.Name = Console.ReadLine();
            repo.Create(animal);
        }
        public void ReadAll()
        {
            Console.Clear();
            var animals = repo.ReadAll();

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.Name);
                Console.WriteLine();
            }

            Console.WriteLine("Enter any key to continue.");
            Console.ReadLine();
        }
        public void Update()
        {
            Repository.Update();
        }
        public void Delete()
        {
            Repository.Delete();
        }
    }
}