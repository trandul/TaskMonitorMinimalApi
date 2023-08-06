﻿using TaskMonitorMinimalApi.Enums;

namespace TaskMonitorMinimalApi.DA.Entities
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AccessLevel AccessLevel { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
