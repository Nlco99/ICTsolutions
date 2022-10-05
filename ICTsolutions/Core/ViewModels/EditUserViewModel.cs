using ICTsolutions.Areas.Identity.Data;

namespace ICTsolutions.Core.ViewModels
{
    public class EditUserViewModel
    {
        public ApplicationUser User { get; set; }

        public IEnumerable<ApplicationRole> Roles { get; set; }
    }
}
