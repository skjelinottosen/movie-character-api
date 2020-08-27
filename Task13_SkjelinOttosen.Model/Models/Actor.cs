using System;
using System.ComponentModel.DataAnnotations;
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
        // Primary key
        [Key]
        public Guid Id { get; set; }
        
        [MaxLength(50)]
        public string FirstName { get; set; }
       
        [MaxLength(50)]
        public string MiddleName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }
       
        public EGender Gender { get; set; }
       
        public DateTime DateOfBirth { get; set; }

        [MaxLength(50)]
        public string BirthPlace { get; set; }
        
        [MaxLength(200)]
        public string Biography { get; set; }
        
        [MaxLength(2048)]
        public string ImageURL { get; set; }
    }
}
