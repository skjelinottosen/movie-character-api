﻿using System;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.DTOs.CharacterDTOs
{
    // Data transfer object for character
    public class CharacterDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Alias { get; set; }
        public EGender Gender { get; set; }
        public string ImageURL { get; set; }
    }
}
