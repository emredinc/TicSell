using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otobusBiletSatis
{
    class Program
    {
        static Yolcu[] yolcular = new Yolcu[10];
        static int koltuk = 0;
        static int kayitSayisi = 0;
        static int error = 0;
        static void Main(string[] args)
        {

            Menu();
        }
        static void Menu()
        {

            do
            {
                error = 0;
                Console.Clear();
                Console.WriteLine("çıkmak için=> 1");
                Console.WriteLine("yolcu kayıt=> 2");
                Console.WriteLine("boş koltuk listesi=> 3");
                Console.WriteLine("yolcu listesi=> 4");
                Console.WriteLine("yolcu sil=> 5");
                Console.WriteLine("lütfen şeçiminizi yapınız");
                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1": Environment.Exit(0); break;
                    case "2": YolcuKayit(); break;
                    case "3": BosKoltukListesi(); break;
                    case "4": YolcuListesi(); break;
                    case "5": YolcuSil(); break;
                    default: Console.WriteLine("hatalı işlem"); System.Threading.Thread.Sleep(500); error++; break;

                }









            } while (error != 0);



        }

        private static void YolcuSil()
        {
            if (kayitSayisi != 0)
            {


                Console.WriteLine("silmek istediğiniz yolcunun koltuk numarası");
                int no = int.Parse(Console.ReadLine());
                if (yolcular[no - 1] != null)
                {
                    yolcular[no - 1] = null;

                    Console.WriteLine("yolcu siliniyor");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();

                }
                else
                {
                    Console.WriteLine("seçilen koltuk zaten boş");
                }
            }
            else
            {
                Console.WriteLine("otobus suan boş");
            }
            Console.WriteLine("menüye dönmek için bir tuşa basınız");
            Console.ReadKey();
            Menu();
        }

        private static void YolcuListesi()
        {
            if (kayitSayisi == 0)
            {
                Console.WriteLine("otobus suanda boş");

            }

            for (int i = 0; i < yolcular.Length; i++)
            {
                if (yolcular[i] != null)
                {
                    Console.WriteLine((i + 1) + " koltuk numaralı yolcunun adı: {0}  ,soyadı: {1}", yolcular[i].ad, yolcular[i].soyad);

                }
            }
            Console.WriteLine("menüye dönmek için bir tuşa basınız");
            Console.ReadKey();
            Menu();
        }

        private static void BosKoltukListesi()
        {
            for (int i = 0; i < yolcular.Length; i++)
            {
                if (yolcular[i] != null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine((i + 1) + ":dolu");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine((i + 1) + ":boş");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            Console.WriteLine("menuye dönmek için bir tuşa basınız");
            Console.ReadKey();
            Menu();
        }
        static bool koltukSorgulama(int no)
        {
            if (yolcular[no] != null)
            {
                return true;
            }

            return false;
        }
        private static void YolcuKayit()
        {
            do
            {
                error = 0;
                Console.Clear();
                Console.WriteLine("koltuk numarası giriniz(1-10)");
                koltuk = int.Parse(Console.ReadLine());
                if (koltukSorgulama(koltuk - 1) == false)
                {
                    Console.WriteLine("yolcu adı:");
                    string ad = Console.ReadLine();
                    Console.WriteLine("yolcu soyadı");
                    string soyad = Console.ReadLine();
                    yolcular[koltuk - 1] = new Yolcu(ad, soyad);
                    kayitSayisi++;
                    Console.WriteLine("kayıt yapılıyor...");
                    System.Threading.Thread.Sleep(500);
                    break;
                }
                else
                {
                    Console.WriteLine("bu koltuk dolu");
                    error++;
                }
                Console.WriteLine("tekrar koltuk seçmek için bir tuşa basınız");
                Console.ReadKey();
            } while (error != 0);
            Menu();
        }
    }
}
