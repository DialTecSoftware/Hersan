using Hersan.Datos.Catalogos;
using Hersan.Entidades.Catalogos;
using System;
using System.Collections.Generic;

namespace Hersan.Negocio.Catalogos
{
    public class AgentesBP
    {
        public List<AgentesBE> ABC_Agentes_Obtener()
        {
            return new AgentesDA().ABC_Agentes_Obtener();
        }
        public int ABC_Agentes_Guardar(AgentesBE obj)
        {
            return new AgentesDA().ABC_Agentes_Guardar(obj);
        }
        public int ABC_Agentes_Actualizar(AgentesBE obj)
        {
            return new AgentesDA().ABC_Agentes_Actualizar(obj);
        }
        public List<AgentesBE> ABC_Agentes_Combo()
        {
            return new AgentesDA().ABC_Agentes_Combo();
        }
    }
}
