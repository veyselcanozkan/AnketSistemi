namespace AnketUygulamasi.Models
{
    public class Soru
    {
        public string SoruMetni { get; set; } = string.Empty;
        public Func<int, bool> Kosul { get; set; } = _ => true;
        public Soru? Sonraki { get; set; }

        public Soru(string metin, Func<int, bool> kosul)
        {
            SoruMetni = metin;
            Kosul = kosul;
        }
    }
}
