﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEDYRE.Core.Models
{
    public class UserRole
    {
        public Guid Id { get; set; }

        public Guid RoleId { get; set; }

        public Role Role { get; set; } = null!;

        public Guid UserId { get; set; }

        public User User { get; set; } = null!;
    }
}
