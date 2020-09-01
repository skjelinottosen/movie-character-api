using System;

namespace Task13_SkjelinOttosen.API.DTOs.FranchiseDTOs
{
    // Data transfer object listing the franchises. Can be used in a list view
    public class FranchiseListViewDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
