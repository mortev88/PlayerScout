using System;
using System.Collections.Generic;
using System.Text;

namespace PlayerScout.Data.Model
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
