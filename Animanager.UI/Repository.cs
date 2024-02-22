using System;
using System.Collections.Generic;
using System.Linq;
using Animanager.Models;

namespace Animanager.UI
{
    public class Repository
    {
        public List<Animal> animals;

        public Repository() 
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

        internal static void Update()
        {
            throw new NotImplementedException();
        }

        internal static void Delete()
        {
            throw new NotImplementedException();
        }
    }
}