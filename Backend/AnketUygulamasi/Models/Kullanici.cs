namespace AnketUygulamasi.Models
{
    public class Kullanici
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string AdSoyad { get; set; } = null!;
        public int Yas { get; set; }
    }
}
