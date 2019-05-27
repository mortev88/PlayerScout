using System;
using System.Collections.Generic;

namespace PlayerScout.Data.Model
{
    public class Country : IEntity
    {
        public Country()
        {

        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}
