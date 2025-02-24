using ConsoleApp1.BLL;
using ConsoleApp1.ENTITY;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int secim;
            do
            {
                menu();
                Console.Write("Seçiminiz, 0-Çıkış");
                 secim = Convert.ToInt32(Console.ReadLine());
                switch (secim)
                {
                    case 1:
                        kitapEkle();
                        break;
                    case 2:
                        kitapSil();
                        break;
                    case 3:
                        kitapGuncelle();
                        break;
                    case 4:
                        kitapAra();
                        break;
                    case 5:
                        kitapListele();
                        break;

                } 
            } while (secim != 0);

            Console.ReadKey();
        }

        static void kitapEkle()
        {
            EKITAP kitap = new EKITAP();
            Console.WriteLine("Eklenecek kitabn bilgileri:");
            Console.WriteLine("Kitap Adı");
            kitap.kitapAdi = Console.ReadLine();
            Console.WriteLine("Sayfa Sayısı");
            kitap.sayfaSayisi = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Yazar ID");
            kitap.yazarID = Convert.ToInt32(Console.ReadLine());
            int i = BLLKITAP.insert(kitap);
            if (i > 0)
            {
                Console.WriteLine("Kayıt eklendi");
                Console.Clear();
                kitapListele();
            }
            else
                Console.WriteLine("Hata oluştu");
        }

        static void kitapSil()
        {
            Console.Write("Silinecek kitap ID girin");
            int id = Convert.ToInt32(Console.ReadLine());
            int i = BLLKITAP.delete(id);

            if (i > 0)
            {
                Console.WriteLine("Kayıt silindi");
                Console.Clear();
                kitapListele();
            }
            else
                Console.WriteLine("Hata oluştu");
        }

        static void kitapGuncelle()
        {
            EKITAP kitap = new EKITAP();
            Console.WriteLine("Guncelleme kitabın bilgileri:");
            Console.WriteLine("Kitap Adı");
            kitap.kitapAdi = Console.ReadLine();
            Console.WriteLine("Sayfa Sayısı");
            kitap.sayfaSayisi = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Yazar ID");
            kitap.yazarID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kitap ID");
            kitap.ID = Convert.ToInt32(Console.ReadLine());
            int i = BLLKITAP.update(kitap);

            if (i > 0)
            {
                Console.WriteLine("Kayıt Guncellendi");
                Console.Clear();
                kitapListele();
            }
            else
                Console.WriteLine("Hata oluştu");
        }
        static void kitapAra()
        {
            Console.Write("Aranacak kitap ID girin");
            int id = Convert.ToInt32(Console.ReadLine());
            EKITAP kt = BLLKITAP.selectbyID(id);
            string veri = String.Format("{0,-5} {1,-20} {2, -13} {3, -10} {4, -10}",
            "ID", "KitapAdı", "Sayfa Sayisi", "yazar ID", "eklenme Tarihi");
            Console.WriteLine(veri);
            EKITAPYAZAR temp = new EKITAPYAZAR();
            temp.ID = kt.ID;
            temp.kitapAdi = kt.kitapAdi;
            temp.sayfaSayisi = kt.sayfaSayisi;
            temp.eklenmeTarihi = kt.eklenmeTarihi;
            KitapYaz(temp);
        }

        static void KitapYaz(EKITAPYAZAR item)
        {
            string veri = String.Format("{0,-5} {1,-20} {2, -15} {3, -15} {4, -15} {5, -15} {6, -15}",
            item.ID, item.kitapAdi, item.sayfaSayisi, item.eklenmeTarihi, item.yazarID, item.yazarAdi, item.yazarSoyadi);
            Console.WriteLine($"{veri}");
        }

        static void kitapListele()
        {
            List<EKITAPYAZAR> liste = BLLKITAP.selectAll();
            string veri = String.Format("{0,-5} {1,-20} {2, -15} {3, -15} {4, -15} {5, -15} {6, -15}",
            "ID", "KitapAdı", "Sayfa Sayisi", "eklenme Tarihi", "yazar ID", "yazar Adı", "yazar Soyadı");
            Console.WriteLine(veri);
            foreach (EKITAPYAZAR item in liste)
            {
                KitapYaz(item);
            }
        }

        static void menu()
        {

            string text = "1- Kitap Ekle\n";
            text += "2- Kitap Sil\n";
            text += "3- Kitap Guncelle\n";
            text += "4- Kitap Ara\n";
            text += "5- Kitap Listesi\n";
            text += "6- Yazar Ekle\n";
            text += "7- Yazar Sil\n";
            text += "8- Yazar Guncelle\n";
            text += "9- Yazar Ara\n";
            text += "10- Yazar Listesi\n";
            Console.WriteLine(text);

            kitapListele();
        }
    }
}
