using System;
using System.Collections.Generic;

namespace PlayerScout.Data.Model
{
    public class Player : IEntity
    {
        public Player()
        {

        }

        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public short? Height { get; set; }
        public short? Weight { get; set; }
        public string Position { get; set; }
        public bool IsLeftFooted { get; set; }
        public bool IsRightFooted { get; set; }
        public short Strength { get; set; }
        public short Pace { get; set; }
        public short Stamina { get; set; }
        public short Passing { get; set; }
        public short Shooting { get; set; }
        public short Tackling { get; set; }
        public short Marking { get; set; }
        public short Dribbling { get; set; }
        public short Heading { get; set; }

        public Guid NationalityId { get; set; }
        public Guid TeamId { get; set; }

        public Nationality Nationality { get; set; }
        public Team Team { get; set; }

        public ICollection<ShortlistItem> ShortlistItems { get; set; }
    }
}
