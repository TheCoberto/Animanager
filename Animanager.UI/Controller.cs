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
                        ReadById();
                        break;
                    case 4:
                        Update();
                        break;
                    case 5:
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
            Console.WriteLine("3. Read By ID");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");

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
                Console.WriteLine(animal.Id + ". " + animal.Name);
                Console.WriteLine();
            }

            if (animals.Count == 0)
            {
                Console.WriteLine("There are currently no animals to display.");
            }

            Console.WriteLine("Enter any key to continue.");
            Console.ReadLine();
        }

        private void ReadById()
        {
            Console.WriteLine("Enter the ID for the animal.");

            int.TryParse(Console.ReadLine(), out var id);

            Console.Clear();

            var animal = repo.ReadById(id);

            if (animal != null)
            {
                Console.WriteLine(animal.Name);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("There is no existing animal with ID: " + id);
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