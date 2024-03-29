﻿

namespace ISCards.Data.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; } 
        public string Position { get; set; }
        public string Organization { get; set; }
        public string Department { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
