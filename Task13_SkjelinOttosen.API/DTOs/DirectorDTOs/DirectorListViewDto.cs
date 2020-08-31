using System;


namespace Task13_SkjelinOttosen.API.DTOs.DirectorDTOs
{
    public class DirectorListViewDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
