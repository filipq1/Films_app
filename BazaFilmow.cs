using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projekt_filmy
{   /// <summary>
   /// Klasa zawierająca kolekcję filmów
  /// </summary>
    [Serializable]
    public class BazaFilmow: IBaza, ICloneable
    {
        /// <summary>
        /// Id bazy filmów
        /// </summary>
        [Key]
        public int Baza2Id { get; set; }
        /// <summary>
        /// Lista ze wszystkimi filmami
        /// </summary>
        public virtual List<Film> Baza { get; set; }
        
        private int ilosc;

        /// <summary>
        /// Ilosc filmów na liście
        /// </summary>
        public int Ilosc
        {
            get
            {
                return ilosc;
            }

            set
            {
                ilosc = value;
            }
        }
        /// <summary>
        /// Konstruktor nieparametryczny inicjalizujący bazę
        /// </summary>
        public BazaFilmow()
        {
            Baza = new List<Film>();
            Ilosc = 0;
        }
        /// <summary>
        /// Metoda dodająca film do bazy
        /// </summary>
        /// <param name="f">Film, który ma być dodany do bazy</param>
        public void Dodaj(Film f)
        {
            if (Baza.Contains(f) == false)
            {
                Baza.Add(f);
                Ilosc++;
            }
            
        }
        /// <summary>
        /// Metoda usuwająca film z bazy
        /// </summary>
        /// <param name="f">Film, który ma zostać usunięty</param>
        public void Usun(Film f)
        {
            Baza.Remove(f);
            Ilosc--;
        }
        /// <summary>
        /// Metoda do zapisu bazy do pliku w postaci XML
        /// </summary>
        /// <param name="plik">Ścieżka zapisu pliku</param>
        public void ZapiszXML(string plik)
        {
            StreamWriter sw = new StreamWriter(plik);                     
            XmlSerializer xs = new XmlSerializer(typeof(BazaFilmow));     
            xs.Serialize(sw, this);
            sw.Close();
        }
        /// <summary>
        /// Metoda do odczytywania bazy z pliku
        /// </summary>
        /// <param name="plik">Scieżka do odczytu pliku</param>
        /// <returns>Odczytana baza filmów</returns>
        public static BazaFilmow OdczytajXML(string plik)
        {
            StreamReader sr = new StreamReader(plik);
            XmlSerializer xs = new XmlSerializer(typeof(BazaFilmow));
            BazaFilmow b = (BazaFilmow)xs.Deserialize(sr);
            sr.Close();
            if (b != null)
                return b;
            else return null;
        }
        /// <summary>
        /// Metoda sortująca bazę danych, na podstawie CompareTo z klasy Film
        /// </summary>
        public void Sortuj()
        {
            Baza.Sort();
        }
        /// <summary>
        /// Metoda do klonowania bazy
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        /// <summary>
        /// Metoda zapisująca daną bazę filmów do bazy danych
        /// </summary>
        public void ZapiszDoBazy()
        {
            using (var db = new Model1())
            {
                
                db.Baza2.Add(this);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Metoda dokonywująca głębokiej kopii bazy
        /// </summary>
        /// <returns>Bazę danych po dokonaniu kopii</returns>
        public BazaFilmow DeepCopy()
        {
            BazaFilmow fklon = (BazaFilmow)Clone();
            fklon.Baza = new List<Film>(Baza);       
            return fklon;
        }

    }
}
