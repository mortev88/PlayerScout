using System;

namespace PlayerScout.Data.Model
{
    public class ShortlistItem : IEntity
    {
        public ShortlistItem()
        {

        }

        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }
        public string Comment { get; set; }

        public Guid ShortlistId { get; set; }
        public Guid PlayerId { get; set; }

        public Shortlist Shortlist { get; set; }
        public Player Player { get; set; }
    }
}
