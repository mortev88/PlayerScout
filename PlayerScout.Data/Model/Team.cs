using System;
using System.Collections.Generic;

namespace PlayerScout.Data.Model
{
    public class Team : IEntity
    {
        public Team()
        {
            
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public Guid CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
