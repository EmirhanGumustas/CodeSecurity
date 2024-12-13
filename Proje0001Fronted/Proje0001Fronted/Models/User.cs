namespace Proje0001Fronted.Models
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
        public int LanguageId { get; set; }
    }
}
