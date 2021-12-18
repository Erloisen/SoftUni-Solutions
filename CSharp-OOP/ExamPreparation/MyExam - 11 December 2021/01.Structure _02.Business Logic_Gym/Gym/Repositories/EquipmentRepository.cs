﻿using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Repositories
{
    class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly List<IEquipment> models;
        public EquipmentRepository()
        {
            this.models = new List<IEquipment>();
        }
        public IReadOnlyCollection<IEquipment> Models => this.models.AsReadOnly();

        public void Add(IEquipment model)
        => this.models.Add(model);

        public IEquipment FindByType(string type)
        => this.models.FirstOrDefault(m => m.GetType().Name == type);

        public bool Remove(IEquipment model)
        => this.models.Remove(model);
    }
}
