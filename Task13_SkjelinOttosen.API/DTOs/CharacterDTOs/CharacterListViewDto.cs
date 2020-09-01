using System;

namespace Task13_SkjelinOttosen.API.DTOs.CharacterDTOs
{
    // Data transfer object listing the characters. Can be used in a list view
    public class CharacterListViewDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
    }
}
