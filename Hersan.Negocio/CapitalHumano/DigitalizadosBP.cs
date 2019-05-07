using Hersan.Datos;
using Hersan.Entidades.CapitalHumano;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.CapitalHumano
{
  public  class DigitalizadosBP
    {
      
        public DataSet CHU_Digitalizados_Obtener(int IdExp, int NoEmp)
        {
            return new DigitalizadosDA().CHU_Digitalizados_Obtener(IdExp, NoEmp);
        }
        public int CHU_Digitalizados_Guardar(DigitalizadosBE obj, DataTable Detalle)
        {
            return new DigitalizadosDA().CHU_Digitalizados_Guardar(obj, Detalle);
        }
        public int CHU_Digitalizados_Actualiza(DigitalizadosBE obj, DataTable Detalle)
        {
            return new DigitalizadosDA().CHU_Digitalizados_Actualiza(obj, Detalle);
        }
        public int CHU_Digitalizados_Elimina(int IdDocs, int IdUsuario)
        {
            return new DigitalizadosDA().CHU_Digitalizados_Elimina(IdDocs,  IdUsuario);
        }
    }
}
