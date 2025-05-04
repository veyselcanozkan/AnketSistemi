namespace AnketUygulamasi.DataStructures
{
    public class HashTablosu
    {
        private Dictionary<string, HashSet<string>> _oylar = new();

        public bool OyEkle(string secim, string kullaniciId)
        {
            if (!_oylar.ContainsKey(secim))
                _oylar[secim] = new HashSet<string>();

            if (_oylar[secim].Contains(kullaniciId))
                return false;

            _oylar[secim].Add(kullaniciId);
            return true;
        }
    }
}
