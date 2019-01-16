using System;

namespace Hersan.Entidades.Comun {
    public class GeneralBE 
    {
        public GeneralBE() {
            IdUsuarioCreo = 0;
            FechaCreacion = DateTime.Today;
            IdUsuarioModif = 0;
            FechaModif = DateTime.Today;
            Estatus = true;
        }
        
        public int IdUsuarioCreo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdUsuarioModif { get; set; }
        public DateTime FechaModif { get; set; }
        public bool Estatus { get; set; }
    }
}
