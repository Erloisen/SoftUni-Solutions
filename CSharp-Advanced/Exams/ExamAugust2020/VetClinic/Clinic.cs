using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        //Field data – collection that holds added pets
        private List<Pet> data;
        public Clinic(int capacity)
        {
            this.Capacity = capacity;

            this.data = new List<Pet>();
        }

        //•	Getter Count – returns the number of pets.
        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }

        //•	Method Add(Pet pet) – adds an entity to the data if there is an empty cell for the pet.
        public void Add(Pet pet)
        {
            if (this.Capacity > data.Count)
            {
                this.data.Add(pet);
            }
        }

        //•	Method Remove(string name) – removes the pet by given name, if such exists, and returns bool.
        public bool Remove(string name)
        {
            return data.Remove(data.FirstOrDefault(p => p.Name == name));
        }

        //•	Method GetPet(string name, string owner) – returns the pet with the given name and owner or null if no such pet exists.
        public Pet GetPet(string name, string owner)
        {
            return data.Find(p => p.Name == name && p.Owner == owner);
        }

        //•	Method GetOldestPet() – returns the oldest Pet.
        public Pet GetOldestPet()
        {
            return data.OrderByDescending(p => p.Age).FirstOrDefault();
        }

        //•	GetStatistics() – returns a string in the following format:
        public string GetStatistics()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The clinic has the following patients:");
            foreach (var pet in data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
