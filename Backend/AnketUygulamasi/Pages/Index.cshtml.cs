using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AnketUygulamasi.Models;
using AnketUygulamasi.Data;
using AnketUygulamasi.DataStructures;

namespace AnketUygulamasi.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty] public string AdSoyad { get; set; } = string.Empty;
        [BindProperty] public string Secim { get; set; } = string.Empty;
        [BindProperty] public int Yas { get; set; }

        public List<string>? Sorular { get; set; }

        private static List<Vote> Oylar = VeriYonetimi.Yükle();
        private static HashTablosu Hash = new();
        private static OyStack Stack = new();
        private static PriorityQueue Kuyruk = new();
        private static SoruAgaci Agac = new();

        public void OnGet()
        {
            Agac.Olustur();
        }

        public IActionResult OnPost()
        {
            var kullanici = new Kullanici { AdSoyad = AdSoyad, Yas = Yas };
            var oy = new Vote { KullaniciId = kullanici.Id, Kategori = "Spor", Secim = Secim };

            if (!Hash.OyEkle(Secim, kullanici.Id))
            {
                ModelState.AddModelError("", "Bu kullanıcı bu seçeneğe zaten oy verdi.");
                return Page();
            }

            Stack.Ekle(oy);
            Kuyruk.OyEkle(Secim);
            Oylar.Add(oy);
            VeriYonetimi.Kaydet(Oylar);

            Agac.Olustur();
            Sorular = Agac.GetirSorular(Yas);

            return Page();
        }
    }
}
