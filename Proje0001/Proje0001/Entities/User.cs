using System.ComponentModel.DataAnnotations.Schema;

namespace Proje0001.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime LastLoginDate { get; set; }
        public int IsActive { get; set; }
        public string DisplayName { get; set; } // oyundaki adı
        public DateTime Created { get; set; } //açılma tarihi
        public string Platform { get; set; } // girilen yer android ıos
        public string PhotoUrl { get; set; }
        public string ApplicationVersiyon { get; set; } // uygulama versiyonu
        public int DiamondCount { get; set; }
        public int GoldCount { get; set; }



        [ForeignKey(nameof(Language))] // bir kullanıcı bir dil kullanabilir
        public int LanguageId { get; set; }
        public Language Language { get; set; }


        public List<UserIp> UserIps { get; set; }

        public UserAbout UserAbout { get; set; }

        public List<UserBadWord> UserBadWords { get; set; }
    }
}
