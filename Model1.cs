namespace Projekt_filmy
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    /// <summary>
    /// Klasa s³u¿¹ca do zapisu do bazy danych
    /// </summary>
    public class Model1 : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Projekt_filmy.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        /// <summary>
        /// Konstruktor bazy danych
        /// </summary>
        public Model1()
            : base("name=Model1")
        {}
        /// <summary>
        /// Inicjalizacja pierwszej tabeli z bazami filmów
        /// </summary>
        public virtual DbSet<BazaFilmow> Baza2 { get; set; }
        /// <summary>
        /// Inicjalizacja tabeli z filmami w bazie danych
        /// </summary>
        public virtual DbSet<Film> Filmy { get; set; }
        /// <summary>
        /// Inicjalizacja tabeli z re¿yserami w bazie danych
        /// </summary>
        public virtual DbSet<Rezyser> RezyserId { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}