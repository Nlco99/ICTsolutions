using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace ICTsolutions.Models
{
    public class Client
    {
        internal readonly object CreatedBy;

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phonenumber { get; set; }

       
        public List<Project>? projects { get; set; }


    }
}
