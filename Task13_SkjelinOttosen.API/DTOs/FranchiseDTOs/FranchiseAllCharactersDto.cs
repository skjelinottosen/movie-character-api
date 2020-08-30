using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.DTOs.FranchiseDTOs
{
    public class FranchiseAllCharactersDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Character> Characters { get; set; }
    }
}
