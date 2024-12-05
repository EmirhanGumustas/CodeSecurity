namespace Proje0001.Entities
{
    public class Language
    {
        public int Id { get; set; }
        public string LanguageCode { get; set; }
        public string PhotoUrl { get; set; }
        public int IsActive { get; set; }
        public string LanguageTextLocal { get; set; } //dilinKendiAdı(Tr=türkçe EN=english)
        public string LanguageTextTurkısh { get; set; } // dilin türkçedeki karşılığı

        public List<User> Users { get; set; } // bir dili birden fazla kullanıcı
    }
}
