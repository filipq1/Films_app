using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projekt_filmy
{ /// <summary>
 ///Klasa zawiera informacje o filmach, przechowywanych w bazie filmów
 /// </summary>
    [Serializable]
    public class Film: IComparable
    {
        /// <summary>
        /// Klucz używany przy zapisie do bazy danych
        /// </summary>
        [Key]
        public int FilmId { get; set; }
        /// <summary>
        /// Odwołanie do klucza bazy
        /// </summary>
        public int Baza2Id { get; set; }
        /// <summary>
        /// Odwołanie do kolekcji filmów w bazie
        /// </summary>
        public virtual BazaFilmow BazaDb { get; set; }
        /// <summary>
        /// Id reżyserującego film
        /// </summary>
        public int RezyserId { get; set; }
        /// <summary>
        /// Odwołanie do reżysera
        /// </summary>
        public virtual Rezyser Rezyser { get; set; }
        /// <summary>
        /// Lista ocen przyznanych filmowi
        /// </summary>
        public List<int> Oceny { get; set; }

        private string nazwa;
        private string gatunek;
        private string rok_produkcji;
        private string kraj_produkcji;
        private float ocena;
        private string opis;
        /// <summary>
        /// Nazwa filmu
        /// </summary>
        public string Nazwa
        {
            get
            {
                return nazwa;
            }

            set
            {
                nazwa = value;
            }
        }
        /// <summary>
        /// Gatunek filmu
        /// </summary>
        public string Gatunek
        {
            get
            {
                return gatunek;
            }

            set
            {
                gatunek = value;
            }
        }
        /// <summary>
        /// Rok produkcji filmu
        /// </summary>
        public string Rok_produkcji
        {
            get
            {
                return rok_produkcji;
            }

            set
            {
                rok_produkcji = value;
            }
        }
        /// <summary>
        /// Kraj produkcji filmu
        /// </summary>
        public string Kraj_produkcji
        {
            get
            {
                return kraj_produkcji;
            }

            set
            {
                kraj_produkcji = value;
            }
        }

        /// <summary>
        /// Ocena filmu, będąca średnią z wszystkich przyznanych mu ocen
        /// </summary>
        public float Ocena
        {
            get
            {
                return ocena;
            }

            set
            {
                ocena = value;
            }
        }
        /// <summary>
        /// Krótki opis filmu
        /// </summary>
        public string Opis
        {
            get
            {
                return opis;
            }

            set
            {
                opis = value;
            }
        }
        /// <summary>
        /// Konstruktor domyślny klasy film
        /// </summary>
        public Film()
        {
            this.Nazwa = null;
            this.Gatunek = null;
            this.Rok_produkcji = null;
            this.Kraj_produkcji = null;
            this.Ocena = 0;
            this.Rezyser = null;
            this.Opis = null;
            this.Oceny = new List<int>();
        }
        /// <summary>
        /// Konstruktor parametryczny klasy film
        /// </summary>
        /// <param name="nazwa"></param>
        /// <param name="gatunek"></param>
        /// <param name="rok_produkcji"></param>
        /// <param name="kraj_produkcji"></param>
        /// <param name="rezyser"></param>
        /// <param name="opis"></param>
        public Film(string nazwa, string gatunek, string rok_produkcji, string kraj_produkcji, Rezyser rezyser, string opis) : this()
        {
            this.Nazwa = nazwa;
            this.Gatunek = gatunek;
            this.Rok_produkcji = rok_produkcji;
            this.Kraj_produkcji = kraj_produkcji;
            this.Rezyser = rezyser;
            this.Opis = opis;
            rezyser.dod_rezyserowane(this);
        }
        public Film(string nazwa)
        {
            this.Nazwa = nazwa;
        }
        /// <summary>
        /// Drugi konstruktor parametryczny klasy film, jednak nie używany w programie
        /// </summary>
        /// <param name="nazwa"></param>
        /// <param name="gatunek"></param>
        /// <param name="rok_produkcji"></param>
        /// <param name="kraj_produkcji"></param>
        /// <param name="rezyser"></param>
        /// <param name="opis"></param>
        /// <param name="ocena"></param>
        public Film(string nazwa, string gatunek, string rok_produkcji, string kraj_produkcji, Rezyser rezyser, string opis, int ocena)
            : this(nazwa, gatunek, rok_produkcji, kraj_produkcji, rezyser, opis)
        {
            this.Ocena = ocena;
        }
        /// <summary>
        /// Metoda dodająca ocenę dla danego filmu
        /// </summary>
        /// <param name="ocena"></param>
        public void Ocen(int ocena)
        {
            this.Oceny.Add(ocena);
            this.Ocena = (float) Oceny.Sum() / (float) Oceny.Count();
        }

        /// <summary>
        /// Metoda służąca do sortowania filmów malejąco na podstawie oceny
        /// </summary>
        /// <param name="s">Film</param>
        /// <returns>Zwraca liczbę dodatnią ujemną lub 0 w zależności od pozycji w sortowaniu</returns>
        public int CompareTo(object s)
        {
            Film f = s as Film;

            if (f != null)
            {
               
               return (this.Ocena.CompareTo(f.Ocena) * (-1));
                
            }
            return 0;
        }
        /// <summary>
        /// Metoda wypisująca wszystkie informacje o danym filmie
        /// </summary>
        /// <returns>Zwraca napis złożony ze wszystkich informacji</returns>
        public string Wypisz_Info()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Tytuł: " + this.nazwa);
            sb.AppendLine("Reżyser: " + this.Rezyser.ToString());
            sb.AppendLine("Gatunek: " + this.Gatunek);
            sb.AppendLine("Rok produkcji: " + this.Rok_produkcji);
            sb.AppendLine("Kraj produkcji: " + this.Kraj_produkcji);
            sb.AppendLine("Ocena: " + this.Ocena.ToString("0.00"));
            sb.AppendLine("Opis: " + this.Opis);
            return sb.ToString();
        }
        /// <summary>
        /// Metoda wypisująca film w listBoxie
        /// </summary>
        /// <returns>Zwraca napis z podstawowymi informacjami o filmie</returns>
        public override string ToString()
        {
            return (this.Nazwa + " " + this.Rok_produkcji + " " + this.Ocena.ToString("0.00"));
        }

    }
}
