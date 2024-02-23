using Animanager.Models;
using Animanager.Repository;
using System;

namespace Animanager.UI
{
    public class Controller
    {
        AnimalRepository repo;
        public Controller()
        {
            repo = new AnimalRepository();
        }

        public void Start()
        {
            while (true)
            {
                DisplayMenu();

                int.TryParse(Console.ReadLine(), out var mainMenuSelection);

                switch (mainMenuSelection)
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
            Console.WriteLine();
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Read All");
            Console.WriteLine("3. Read By ID");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
        }

        public void DisplayAnimals()
        {
            Console.Clear();
            var animals = repo.ReadAll();

            foreach (var animal in animals)
            {
                Console.WriteLine("{0}. {1} {2}", animal.Id, animal.Color, animal.Name);
                Console.WriteLine();
            }

            if (animals.Count == 0)
            {
                Console.WriteLine("There are currently no animals to display.");
                Console.WriteLine();
            }

            Console.WriteLine("Enter any key to continue.");
            Console.ReadLine();
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
            DisplayAnimals();
        }

        private void ReadById()
        {
            Console.WriteLine("Enter the ID for the animal.");

            int.TryParse(Console.ReadLine(), out var id);

            Console.Clear();

            Animal animal = repo.ReadById(id);

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
            var animals = repo.ReadAll();
            Animal updatedAnimal = new Animal();
            bool passedValidation = false;

            if (animals.Count == 0)
            {
                Console.WriteLine("There are currently no animals to display.");
            }
            else
            {
                Console.WriteLine("Enter the ID of the animal you want to update.");
                int.TryParse(Console.ReadLine(), out int id);
                var animal = repo.ReadById(id);
                if (animal != null)
                {
                    while (!passedValidation)
                    {
                        Console.WriteLine(animal.Id + ". " + animal.Name);
                        Console.WriteLine();
                        Console.WriteLine("Choose a property to update.");
                        Console.WriteLine();
                        Console.WriteLine("1. Name");
                        Console.WriteLine("2. Color");

                        passedValidation = int.TryParse(Console.ReadLine(), out int updateMenuSelection);
                        switch (updateMenuSelection)
                        {
                            case 1:
                                updatedAnimal = UpdateName(animal);
                                break;
                            case 2:
                                updatedAnimal = UpdateColor(animal);
                                break;
                        }

                        if (updateMenuSelection != 1 && updateMenuSelection != 2)
                        {
                            passedValidation = false;
                        }
                    }

                    repo.Update(updatedAnimal);
                }
            }
        }

        private Animal UpdateName(Animal animal)
        {
            Console.WriteLine("What is the new name?");

            var newName = Console.ReadLine();

            animal.Name = newName;

            return animal;
        }

        private Animal UpdateColor(Animal animal)
        {
            Console.WriteLine("What is the new color?");

            var newColor = Console.ReadLine();

            animal.Color = newColor;

            return animal;
        }

        public void Delete()
        {
            Console.WriteLine("Enter the ID of the animal you want to delete.");
            bool passedValidation = int.TryParse(Console.ReadLine(), out var id);
            var animal = repo.ReadById(id);

            if (animal != null)
                repo.Delete(animal);
        }
    }
}