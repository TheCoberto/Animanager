using System;
using System.Collections.Generic;
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
            animals.Add(animal);
        }

        public List<Animal> ReadAll()
        {
            return animals;
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