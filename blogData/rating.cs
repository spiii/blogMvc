//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace blogData
{
    using System;
    using System.Collections.Generic;
    
    public partial class rating
    {
        public int idRating { get; set; }
        public System.DateTime timestamp { get; set; }
        public int idPost { get; set; }
        public int rate { get; set; }
    
        public virtual post post { get; set; }
    }
}
