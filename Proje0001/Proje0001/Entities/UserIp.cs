using System.ComponentModel.DataAnnotations.Schema;

namespace Proje0001.Entities
{
    public class UserIp
    {
        public int Id { get; set; }
        public string IpAddress { get; set; }
        public DateTime Created { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
