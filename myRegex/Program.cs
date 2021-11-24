using System;

namespace odev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sozluk sozluk = Basla();

            int loop = 0;
            while (loop <= 0)
            {
                secenekler();
                int opt = Convert.ToInt32(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        Console.Write("Kaç adet kelime:");
                        int sayi = Convert.ToInt32(Console.ReadLine());
                        string[] kelimeler = sozluk.KelimeTuret(sayi);
                        for (int i = 0; i < kelimeler.Length; i++)
                        {
                            Console.WriteLine("{0}. kelime = {1}", i + 1, kelimeler[i]);
                        }
                        Console.WriteLine("\n");
                        break;
                    case 2:
                        Console.WriteLine("Kelime giriniz:");
                        string kelime = Console.ReadLine();

                        bool kontrol = sozluk.KelimeKontrol(kelime);
                        if (kontrol)
                        {
                            Console.WriteLine("Kelime uyumlu...");
                        }
                        else
                        {
                            Console.WriteLine("Kelime uyumsuz...");
                        }
                        break;
                    case 3:
                        sozluk = Basla();
                        break;
                    case 4:
                        loop++;
                        break;

                }

            }
        }

        private static Sozluk Basla()
        {
            string alfabeText = degerAl("Alfabe");
            string dilText = degerAl("Dil kuralı");
            Sozluk sozluk = new Sozluk(alfabeText, dilText);
            return sozluk;
        }

        static string degerAl(string text)
        {
            Console.WriteLine("{0} giriniz:", text);
            string Text = Console.ReadLine();
            return Text;
        }
        static void secenekler()
        {
            Console.WriteLine("+ + + Yapılacak işlemler  + + +");
            Console.WriteLine("+     1) Kelime üret          +");
            Console.WriteLine("+     2) Kelime kontrol et    +");
            Console.WriteLine("+     3) Yeni alfabe/dil      +");
            Console.WriteLine("+     4) Durdur               +");
            Console.WriteLine("+ + + + + + + + + + + + + + + +");
        }
    }
}
