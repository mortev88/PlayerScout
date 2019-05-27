using System;
using System.Collections.Generic;

namespace PlayerScout.Data.Model
{
    public class Shortlist : IEntity
    {
        public Shortlist()
        {

        }

        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<ShortlistItem> ShortlistItems { get; set; }
    }
}
