using Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Models
{
    public class AdminPermission
    {
        [Key, Column(Order = 0)]
        public string AdminID { get; set; }

        [Key, Column(Order = 1)]
        public int PermissionID { get; set; }

        [ForeignKey("AdminID")]
        public virtual User Admin { get; set; }

        [ForeignKey("PermissionID")]
        public virtual Permission Permission { get; set; }
    }
}