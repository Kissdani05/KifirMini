using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    public partial class UjDiak : Window
    {

        bool uzemMod;
        Felvetelizok felvetelizoAdatai;
        public UjDiak()
        {
            InitializeComponent();
            OMAzonosito.IsReadOnly = false;
        }
        public UjDiak(Felvetelizok ujdiak, bool mod) : this()
        {
            this.felvetelizoAdatai = ujdiak;
            this.DataContext = felvetelizoAdatai;
            this.Title = $"{felvetelizoAdatai.Név} adatainak rögzítése";
            Nev.Text = felvetelizoAdatai.Név;
            this.uzemMod = mod;
            if (this.uzemMod)
            {
                OMAzonosito.IsReadOnly = false;
            }
            else { OMAzonosito.IsReadOnly = true; }


        }


        private void LeaveButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }



        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder errorMessages = new StringBuilder();

            if (string.IsNullOrWhiteSpace(OMAzonosito.Text))
            {
                errorMessages.AppendLine("Üres minden");
            }
            else
            {
                felvetelizoAdatai.Om_azonosito = long.Parse(OMAzonosito.Text);
                if (!long.TryParse(felvetelizoAdatai.Om_azonosito.ToString(), out long omAzonosito) || omAzonosito.ToString().Length != 11)
                {
                    errorMessages.AppendLine("OM azonosito problema: Muszaj 11 karakternek lennie!");
                }

                // Validate Nev
                string trimmedName = Nev.Text.Trim();
                string[] nameParts = trimmedName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (nameParts.Length < 2 || nameParts.Any(part => part[0] != char.ToUpper(part[0])))
                {
                    errorMessages.AppendLine("Név probléma: A névnek legalább két szóból kell állnia, minden szó nagybetűvel kell kezdődjön!");
                }
                else
                {
                    felvetelizoAdatai.Név = string.Join(" ", nameParts);
                }

                // Validate Ertesitesi_cim
                if (string.IsNullOrWhiteSpace(Ertesitescim.Text))
                {
                    errorMessages.AppendLine("Értesítési cím probléma: Az értesítési cím nem lehet üres!");
                }
                else
                {
                    felvetelizoAdatai.Ertesitesi_cim = Ertesitescim.Text;
                }

                // Validate Elerhetoseg_email
                string email = ElerhetosegEmail.Text;
                int atCount = email.Count(c => c == '@');
                int spaceCount = email.Count(c => c == ' ');
                if (email.Length > 40 || atCount != 1 || spaceCount > 1)
                {
                    errorMessages.AppendLine("E-mail cím probléma: Az e-mail cím nem lehet több mint 40 karakter, pontosan egy '@' karaktert kell tartalmaznia, és nem tartalmazhat több mint egy szóközt!");
                }
                else
                {
                    felvetelizoAdatai.Elerhetoseg_email = email;
                }


                // Validate MatekPontszam
                if (!int.TryParse(MatekPontszam.Text, out int matekPont) || matekPont < 0 || matekPont > 50)
                {
                    errorMessages.AppendLine("Matematikapont probléma: A matematikapontszám egy egész szám kell, hogy legyen, 0 és 50 között!");
                }
                else
                {
                    felvetelizoAdatai.Matekpont = matekPont;
                }

                // Validate MagyarPontszam
                if (!int.TryParse(MagyarPontszam.Text, out int irodalomPont) || irodalomPont < 0 || irodalomPont > 50)
                {
                    errorMessages.AppendLine("Irodalompont probléma: Az irodalompontszám egy egész szám kell, hogy legyen, 0 és 50 között!");
                }
                else
                {
                    felvetelizoAdatai.Irodalompont = irodalomPont;
                }

                if (errorMessages.Length > 0)
                {
                    MessageBox.Show(errorMessages.ToString());
                    return;
                }

                Close();
            }

            // Validate OM azonosito



        }


    }
}
