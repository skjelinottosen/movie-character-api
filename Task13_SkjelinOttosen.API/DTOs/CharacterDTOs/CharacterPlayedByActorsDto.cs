﻿using System;
using System.Collections.Generic;
using Task13_SkjelinOttosen.API.DTOs.ActorDTOs;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.DTOs.CharacterDTOs
{
    public class CharacterPlayedByActorsDto 
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public List<ActorListViewDto> Actors { get; set; }
    }
}
