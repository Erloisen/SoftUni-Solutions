using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robots : IIdentify
    {
        public Robots(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }

        public string Name { get; set; }
        public string Id { get; set; }
    }
}
