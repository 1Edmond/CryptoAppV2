﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CryptoAppV2.Custom
{
    public static class MesControls
    {

        public static bool IsModele(this string text)
        {
            bool rep = true;
            if (text.Contains(","))
            {
                var temp = text.Split(',');
                foreach (var item in temp)
                    if (item.Length != 1)
                        rep = false;
            }else
                rep = false;
            return rep;
                
        }

        public static string TransformHistoriqueData(this string entry, string nom, string type, Dictionary<string,string > data) => $"{nom}*{type}*{entry}*{String.Join(",", data.Keys)}:{String.Join("+", data.Values)}";
        
        public static int Getkey(this Dictionary<int ,char> Dictionnaire , char element)
        {
            foreach (KeyValuePair<int,char> item in Dictionnaire)
                if (item.Value == element)
                    return item.Key;
            return -1;
        }

        public static bool IsInModele(this string text,string modeleName)
        {
            text = text.ToUpper();
            var modele = App.UserModeleManager.GetByName(modeleName);
            var rep = true;
            foreach (var car in  text)
                if (!modele.Valeur.ContainsValue(car))
                {
                    rep = false;
                    break;
                }
            return rep;
        }

        public static void MyEntryFocus(this Entry entry, Frame frame)
        {
            entry.Focused += delegate
            {
                frame.BorderColor = Color.FromHex("#178FEB");
            };
            entry.Unfocused += delegate
            {
                frame.BorderColor = Color.White;
            };

        }
        public static void MyEntryFocusPicker(this Picker entry, Frame frame)
        {
            entry.Focused += delegate
            {
                frame.BorderColor = Color.FromHex("#178FEB");
            };
            entry.Unfocused += delegate
            {
                frame.BorderColor = Color.White;
            };

        }
        public static int ProduitRSaList(this List<string> maLise)
        {
            int produit = 1;
            maLise.ForEach(ma =>
            {
                produit *= int.Parse(ma) - 1;
            });
            return produit;
        }
        public static int SommeRSaList(this List<string> maLise)
        {
            int produit = 0;
            maLise.ForEach(ma =>
            {
                produit += int.Parse(ma);
            });
            return produit;
        }
        public static string SubstringString(this string text)
        {
            string result = "";
            Dictionary<int, char> newDic = new Dictionary<int, char>();
            var myTemp = text.ToLower();
            for (int i = 0; i < myTemp.Length; i++)
            {
                if (myTemp[i] >= 'a' && myTemp[i] <= 'z')
                    result += myTemp[i];
            }
            return result;
        }
        public static async Task MyFadeAnnimation(this Page page, Easing easing)
        {
            page.Scale = 0;
            await page.ScaleTo(1, 5000, easing);

        }

#pragma warning disable CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone
        public static async Task MyRotationAnnimation(this Page page)
#pragma warning restore CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone
        {
            page.Scale = 0;
            _ = page.RotateTo(10 * 360, 5000);
            _ = page.ScaleTo(1, 5000);

        }

        public static async Task MyTranslationAnimation(this Page page, Easing easing)
        {
            page.Opacity = 0;
            await page.TranslateTo(500, 0, 250);
            page.Opacity = 1;
            await Task.Delay(0);
            await page.TranslateTo(0, 0, 2500, easing);
        }

        public static bool IsOnlyAphabet(this string texte)
        {
            string temp = texte.ToLower();
            foreach (char car in temp)
                if (car < 'a' || car > 'z')
                    return false;
            return true;
        }

        internal static void MyPickerFocus(Picker codagePicker, Frame codageModeleFrame)
        {
            codagePicker.Focused += delegate
            {
                codageModeleFrame.BorderColor = Color.FromHex("#178FEB");
            };
            codagePicker.Unfocused += delegate
            {
                codageModeleFrame.BorderColor = Color.White;
            };

        }

        public static string SubstringInteger(this string texte) => texte.Contains(",") ? texte.Substring(0, texte.IndexOf(",")) : texte;

        public static bool IsOnlyInteger(this string texte)
        {
            bool result = true;
            try
            {
                int temp = 0;
                var liste = texte.Split(',');
                foreach (var car in liste)
                    temp = int.Parse(car);
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public static bool IsAlphabetOrInteger(this string texte) => texte.IsOnlyAphabet() || texte.IsOnlyInteger() ? true : false;

        public static bool VerfificationCodageFormatBinaire(this string entry)
        {
            foreach (char car in entry)
                if (!car.Equals('0') && !car.Equals('1'))
                    return false;
            return true;
        }

        public static bool SuperSuite(this string texte)
        {
            var result = true;
            var temp = texte.Split(',');
            for (int i = 0; i < temp.Length; i++)
            {
                int somme = 0;
                for (int j = 0; j < i; j++)
                    somme += int.Parse(temp[j]);
                if (somme >= int.Parse(temp[i]))
                    result = false;
            }

            return result;
        }


    }
}
