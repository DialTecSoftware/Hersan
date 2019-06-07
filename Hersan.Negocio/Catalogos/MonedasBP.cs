using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;

namespace Hersan.Negocio.Catalogos
{
    public class MonedasBP
    {

        public List<MonedasBE> ABC_Monedas_Obtener()
        {
            return new MonedasDA().ABC_Monedas_Obtener();
        }
        public int ABC_Monedas_Guardar(MonedasBE obj)
        {
            return new MonedasDA().ABC_Monedas_Guardar(obj);
        }
        public int ABC_Monedas_Actualizar(MonedasBE obj)
        {
            return new MonedasDA().ABC_Monedas_Actualizar(obj);
        }
        public List<MonedasBE> ABC_Monedas_Combo()
        {
            return new MonedasDA().ABC_Monedas_Combo();
        }
    }
}
