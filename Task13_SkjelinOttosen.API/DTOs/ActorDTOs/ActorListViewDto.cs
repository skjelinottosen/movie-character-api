using System;

namespace Task13_SkjelinOttosen.API.DTOs.ActorDTOs
{
    // Data transfer object listing the actors. Can be used in a list view
    public class ActorListViewDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
