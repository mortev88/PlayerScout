using System;
using System.Collections.Generic;

namespace PlayerScout.Data.Model
{
    public class Nationality : IEntity
    {
        public Nationality()
        {

        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
