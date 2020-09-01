using System;

namespace Task13_SkjelinOttosen.API.DTOs.FranchiseDTOs
{
    // Data transfer object for default Franchise
    public class FranchiseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
