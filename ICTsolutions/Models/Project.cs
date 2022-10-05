using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ICTsolutions.Enums;
using ICTsolutions.Areas.Identity.Data;

namespace ICTsolutions.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required, DisplayName("Project name"), StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string ClientName { get; set; } 

        public int? ClientId { get; set; }
        public Client? projects { get; set; }


        [Required]
        public string ProjectManager { get; set; }

        [Required]
        public int amountMembers { get; set; }

        //[Required, DisplayName("Description"), StringLength(100)]
        //public string Description { get; set; }

        //[DataType(DataType.DateTime)]
        //public DateTime StartDate { get; set; }

        //[DataType(DataType.DateTime)]
        //public DateTime EndDate { get; set; }

        [Required]
        public string Sources { get; set; }

        [Required]
        public string ProgramingLanguage { get; set; }

        public PaymentEnum Payment { get; set; }

        public StatusEnum Status { get; set; }

        public TypeEnum Type { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }

        
    }
}
