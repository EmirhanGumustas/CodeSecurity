using System.ComponentModel.DataAnnotations.Schema;

namespace Proje0001.Entities
{
    public class UserAbout
    {
        public int Id { get; set; }
        public string AboutText { get; set; }
        public string InstagramLink { get; set; }
        public string TwitterLink { get; set; }
        public string FacebookLink { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CoverPhotoLink { get; set; }// kapak foto link
        public int ProfileHidden { get; set; }//Profil Gizlimi?

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
