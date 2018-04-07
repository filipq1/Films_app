using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_filmy
{  
    /// <summary>
    /// Interfejs z metodami używanymi do dodania i usunięcia Filmu z bazy
    /// </summary>
    public interface IBaza
    {  
        /// <summary>
        /// Metoda dodająca film do bazy
        /// </summary>
        /// <param name="f">Film, który ma być dodany</param>
        void Dodaj(Film f);
        /// <summary>
        /// Metoda usuwająca dany film
        /// </summary>
        /// <param name="f">Film, który ma zostać usunięty</param>
        void Usun(Film f);
    }
}
