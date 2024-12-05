using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Proje0001.Entities
{
    public class UserBadWord
    {
        public int Id { get; set; }
        public string Text { get; set; } // yazılan cümle 
        public DateTime Created { get; set; } // kayıt tarihi

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
