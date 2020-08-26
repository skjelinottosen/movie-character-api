﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Task13_SkjelinOttosen.Model.Models
{
    public enum EGender
    {
        Male,
        Female
    }

    //Actor plays Movie Character one-to_many 
    public class Actor
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public EGender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BirthPlace { get; set; }
        public string Biography { get; set;  }
        public string ImageURL { get; set; }
    }
}
