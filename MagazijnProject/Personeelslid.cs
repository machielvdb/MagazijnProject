//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MagazijnProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class Personeelslid
    {
        public int PersoneelslidID { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public System.DateTime DatumInDienst { get; set; }
        public int ToegangID { get; set; }
        public string Wachtwoord { get; set; }
        public Nullable<System.DateTime> LaatsteLogin { get; set; }
        public string VolledigeNaam() => $"{Voornaam} {Achternaam}";
        public override string ToString() => $"{Voornaam} {Achternaam}";
    }
}
