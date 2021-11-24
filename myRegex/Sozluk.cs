using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev
{
    public class Sozluk
    {
        Random random = new Random();
        string AlfabeText { get; set; }
        string DilText { get; set; }
        public char[] alfabe;
        public char[] dil;
        public Sozluk(string AlfabeText, string DilText)//Ctor
        {
            this.AlfabeText = AlfabeText;
            this.DilText = DilText;

            alfabe = AlfabeParcala(AlfabeText);
            dil = DilParcala(DilText);
        }
        char[] AlfabeParcala(string text)
        {
            string[] strAlfabe = text.Split(',');
            char[] alfabe = new char[strAlfabe.Length];

            for (int i = 0; i < strAlfabe.Length; i++)
            {
                alfabe[i] = Convert.ToChar(strAlfabe[i]);
            }
            return alfabe;
        }
        char[] DilParcala(string text)
        {
            char[] dizi = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                if (!text[i].Equals(','))
                {
                    dizi[i] = text[i];
                }
            }

            return dizi;
        }
        public void AlfabeYazdir()
        {
            System.Console.WriteLine("------Alfabe------");
            for (int i = 0; i < alfabe.Length; i++)
            {
                System.Console.WriteLine(alfabe[i]);
            }
            System.Console.WriteLine("------------------");
        }

        public string[] KelimeTuret(int sayi)
        {
            string[] kelimeler = new string[sayi];
            int harfIndex = 0;
            bool parantez = false;
            List<char> parantezIci = new List<char>();
            for (int kelimeIndex = 0; kelimeIndex < kelimeler.Length; kelimeIndex++)
            {//3 kelime için
                string kelime = "";
                for (int i = 0; i < dil.Length; i++)
                {
                    for (int Index = 0; Index < alfabe.Length; Index++)
                    {
                        if (dil[i].Equals(alfabe[Index]))
                        {
                            harfIndex = Index;
                            break;
                        }
                    }
                    if (dil[i].Equals('('))
                    {//Parantez
                        parantez = true;
                    }
                    else if (dil[i].Equals(')'))
                    {//Parantez sonu
                        parantez = false;
                        if (i + 1 < dil.Length)
                        {
                            if (dil[i + 1].Equals('*'))
                            {//Parantez yıldız içinn
                                string gelen = ParantezYildizIslem(parantezIci);
                                kelime += gelen;
                            }
                            else
                            {//dil ortası Parantez için
                                string gelen = ParantezIslem(parantezIci);
                                kelime += gelen;
                            }
                        }
                        else
                        {//Dil sonu Parantez için
                            string gelen = ParantezIslem(parantezIci);
                            kelime += gelen;
                        }
                        parantezIci = new List<char>();
                        //Bir dilde birden fazla parantez kullanılabilir.
                    }
                    else if (parantez)
                    {//Parantez başı

                        if (!dil[i].Equals('+'))
                        {//Artı işaretini almaya gerek yok
                            parantezIci.Add(alfabe[harfIndex]);
                        }
                    }
                    else if (!dil[i].Equals('*'))
                    {//dil içindeki harflar için
                        if (i + 1 < dil.Length)
                        {
                            if (dil[i + 1].Equals('*'))
                            {//dil içindeki harflarin yıldız işlemi
                                string gelen = YildizIslem(alfabe[harfIndex]);
                                kelime += gelen;
                            }
                            else
                            {
                                string gelen = alfabe[harfIndex].ToString();
                                kelime += gelen;
                            }
                        }
                        else
                        {//Dil dizisi sonundaki harf için
                            string gelen = alfabe[harfIndex].ToString();
                            kelime += gelen;
                        }
                    }
                }
                kelimeler[kelimeIndex] = kelime;

            }
            return kelimeler;
        }

        private string YildizIslem(char harff)
        {
            string harf = "";
            for (int i = 0; i < random.Next(0, 5); i++)
            {
                harf += harff;
            }
            return harf;
        }

        private string ParantezYildizIslem(List<char> parantezIci)
        {
            string harf = "";
            for (int i = 0; i < random.Next(0, 5); i++)
            {
                harf += parantezIci[random.Next(0, parantezIci.Count)];
            }

            return harf;
        }

        private string ParantezIslem(List<char> parantezIci)
        {
            string harf = "";
            harf += parantezIci[random.Next(0, parantezIci.Count)];

            return harf;
        }

        public bool KelimeKontrol(string kelime)
        {
            char[] kelimeKarakter = kelime.ToCharArray();

            for (int i = 0; i < kelimeKarakter.Length; i++)
            {
                if (i + 1 < kelimeKarakter.Length)
                {
                    if (kelimeKarakter[i].Equals(kelimeKarakter[i + 1]))
                    {

                    }
                }
            }
            return true;
        }
    }
}
