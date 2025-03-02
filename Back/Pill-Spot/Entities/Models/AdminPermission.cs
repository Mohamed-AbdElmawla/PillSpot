using Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Models
{
    public class AdminPermission
    {
        [Key, Column(Order = 0)]
        public string AdminId { get; set; }

        [Key, Column(Order = 1)]
        public int PermissionId { get; set; }

        [ForeignKey("AdminId")]
        public virtual User Admin { get; set; }

        [ForeignKey("PermissionId")]
        public virtual Permission Permission { get; set; }
    }
}