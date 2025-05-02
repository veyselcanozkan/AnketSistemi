using AnketSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;

namespace AnketSistemi.Controllers
{
    public class AnketController : Controller
    {
        private static List<Soru> TumSorular;
        private static Stack<CevapliSoru> Cevaplar = new();
        private static int Index = 0;
        private readonly IMongoCollection<Soru> _soruCollection;

        public AnketController()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("anketDB");
            _soruCollection = database.GetCollection<Soru>("sorular");

            if (TumSorular == null)
            {
                TumSorular = _soruCollection.Find(_ => true).ToList();
            }
        }

        public IActionResult Index1()
        {
            if (Index >= TumSorular.Count)
            {
                return RedirectToAction("Sonuc");
            }

            var aktifSoru = TumSorular[Index];
            return View(aktifSoru);
        }

        [HttpPost]
        public IActionResult Cevapla(string cevap, string islem)
        {
            if (islem == "geri" && Cevaplar.Count > 0)
            {
                Cevaplar.Pop();
                Index = Math.Max(0, Index - 1);
                return RedirectToAction("Index");
            }

            if (!string.IsNullOrWhiteSpace(cevap))
            {
                Cevaplar.Push(new CevapliSoru
                {
                    Soru = TumSorular[Index],
                    Cevap = cevap
                });
                Index++;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Sonuc()
        {
            return View(Cevaplar);
        }
    }
}