using Web.DataAccess.Models;

namespace Web.Bussiness.DTO
{
    public class ClassDetailDTO
    {
        public int ClassDetailId { get; set; }
        public int ClassId { get; set; }
        public int UserId { get; set; }

        public virtual ClassDTO Class { get; set; } = null!;
        public virtual UserDTO ClassNavigation { get; set; } = null!;
    }
}
