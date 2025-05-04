namespace AnketUygulamasi.DataStructures
{
    public class PriorityQueue
    {
        private Dictionary<string, int> _oylar = new();

        public void OyEkle(string secim)
        {
            if (_oylar.ContainsKey(secim))
                _oylar[secim]++;
            else
                _oylar[secim] = 1;
        }

        public List<KeyValuePair<string, int>> Sirala()
        {
            return _oylar.OrderByDescending(kv => kv.Value).ToList();
        }
    }
}
