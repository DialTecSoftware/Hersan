using Hersan.Entidades.Catalogos;


namespace Hersan.Entidades.CapitalHumano
{
    public class TabuladorBE
    {
        public TabuladorBE()
        {
            Depto = new DepartamentosBE();
            Puesto = new PuestosBE();
            Puntaje = 0;
            Sueldo85 = 0;
            Sueldo90 = 0;
            Sueldo95 = 0;
            SueldoMax = 0;
        }

        public DepartamentosBE Depto { get; set; }
        public PuestosBE Puesto { get; set; }
        public decimal Puntaje { get; set; }
        public decimal Sueldo85 { get; set; }
        public decimal Sueldo90 { get; set; }
        public decimal Sueldo95 { get; set; }
        public decimal SueldoMax { get; set; }

    }
}
