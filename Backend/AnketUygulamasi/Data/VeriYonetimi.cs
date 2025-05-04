using System.Text.Json;
using AnketUygulamasi.Models;

namespace AnketUygulamasi.Data
{
    public static class VeriYonetimi
    {
        private static string DosyaYolu => "veriler.json";

        public static List<Vote> Yükle()
        {
            if (!File.Exists(DosyaYolu))
                return new List<Vote>();

            var json = File.ReadAllText(DosyaYolu);
            return JsonSerializer.Deserialize<List<Vote>>(json) ?? new List<Vote>();
        }

        public static void Kaydet(List<Vote> oylar)
        {
            var json = JsonSerializer.Serialize(oylar, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(DosyaYolu, json);
        }
    }
}
