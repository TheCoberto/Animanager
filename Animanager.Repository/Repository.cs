using System;
using System.Collections.Generic;
using System.Linq;
using Animanager.Models;

namespace Animanager.Repository
{
    public class AnimalRepository
    {
        public List<Animal> animals;

        public AnimalRepository() 
        {
            animals = new List<Animal>();
        }

        public void Create(Animal animal)
        {
            animal.Id = animals.Count + 1;
            animals.Add(animal);
        }

        public List<Animal> ReadAll()
        {
            return animals;
        }

        public Animal ReadById(int id)
        {
            return animals.FirstOrDefault(a => a.Id == id);
        }

        public void Update(Animal newAnimal)
        {
            Animal oldAnimal = animals.FirstOrDefault(x => x.Id == newAnimal.Id);
            oldAnimal.Name = newAnimal.Name;
            oldAnimal.Color = newAnimal.Color;
        }

        public void Delete(Animal animal)
        {
            animals.Remove(animal);
        }
    }
}