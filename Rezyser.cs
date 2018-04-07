using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_filmy
{
    /// <summary>
    /// Klasa z informacjami na temat reżyserów
    /// </summary>
    [Serializable]
    public class Rezyser
    {
        /// <summary>
        /// Id reżysera przy zapisie do bazy
        /// </summary>
        [Key]
        public int RezyserId { get; set; }
        /// <summary>
        /// Lista filmów wyreżyserowanych przez danego reżysera
        /// </summary>
        public virtual List<Film> Filmy { get; set; }

        private string imie;
        private string nazwisko;
        [Key]
        private DateTime data_ur;
        private string kraj_ur;
        
        /// <summary>
        /// Imię reżysera
        /// </summary>
        public string Imie
        {
            get
            {
                return imie;
            }

            set
            {
                imie = value;
            }
        }
        /// <summary>
        /// Nazwisko reżysera
        /// </summary>
        public string Nazwisko
        {
            get
            {
                return nazwisko;
            }

            set
            {
                nazwisko = value;
            }
        }
        /// <summary>
        /// Kraj urodzenia reżysera
        /// </summary>
        public string Kraj_ur
        {
            get
            {
                return kraj_ur;
            }

            set
            {
                kraj_ur = value;
            }
        }
        /// <summary>
        /// Data urodzenia reżysera
        /// </summary>
        public DateTime Data_ur
        {
            get
            {
                return data_ur;
            }

            set
            {
                data_ur = value;
            }
        }
        /// <summary>
        /// Konstruktor nieparametryczny klasy reżyser
        /// </summary>
        public Rezyser()
        {
            this.Imie = null;
            this.Nazwisko = null;
            this.Data_ur = new DateTime();
            this.Kraj_ur = null;
            this.Filmy = new List<Film>();
        }
        /// <summary>
        /// Konstruktor parametryczny z informacjami o reżyserze
        /// </summary>
        /// <param name="imie"></param>
        /// <param name="nazwisko"></param>
        /// <param name="data_ur"></param>
        /// <param name="kraj_ur"></param>
        public Rezyser(string imie, string nazwisko, string data_ur, string kraj_ur): this()
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.Data_ur = DateTime.Parse(data_ur);
            this.Kraj_ur = kraj_ur;
        }
        /// <summary>
        /// Metoda dodająca film do listy reżyserowanych przez danego reżysera
        /// </summary>
        /// <param name="f">Reżyserowany film</param>
        public void dod_rezyserowane(Film f)
        {
            if (Filmy.Contains(f) == false)
                Filmy.Add(f);
        }
        /// <summary>
        /// Metoda wypisująca informacje o reżyserze
        /// </summary>
        /// <returns>Napis z informacjami o reżyserze</returns>
        public override string ToString()
        {
            return (this.Imie + " " + this.Nazwisko + " " + this.Data_ur.ToShortDateString() + " " + this.Kraj_ur);
        }

    }
}
