namespace AnketUygulamasi.DataStructures
{
    public class Soru
    {
        public string SoruMetni { get; set; } = null!;
        public Func<int, bool> Kosul { get; set; } = _ => true;
        public Soru? Sonraki { get; set; }

        public Soru(string metin, Func<int, bool> kosul)
        {
            SoruMetni = metin;
            Kosul = kosul;
        }
    }

    public class SoruAgaci
    {
        private Soru? _ilk;

        public void Olustur()
        {
            var ehliyet = new Soru("Ehliyetin var mı?", yas => yas >= 18);
            _ilk = ehliyet;
        }

        public List<string> GetirSorular(int yas)
        {
            var sorular = new List<string>();
            var aktif = _ilk;

            while (aktif != null)
            {
                if (aktif.Kosul(yas))
                    sorular.Add(aktif.SoruMetni);

                aktif = aktif.Sonraki;
            }

            return sorular;
        }
    }
}
