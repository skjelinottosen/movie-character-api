using System;
using System.Collections.Generic;
using Task13_SkjelinOttosen.API.DTOs.CharacterDTOs;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.DTOs.FranchiseDTOs
{
    // Data transfer object for franchise listing all characters
    public class FranchiseAllCharactersDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CharacterListViewDto> Characters { get; set; }
    }
}
