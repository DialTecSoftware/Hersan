﻿using Hersan.Datos.CapitalHumano;
using Hersan.Entidades.CapitalHumano;
using System.Collections.Generic;
using System.Data;

namespace Hersan.Negocio.CapitalHumano
{
    public class PerfilesBP
    {
        public int CHU_Perfiles_Guardar(PerfilesBE obj, DataTable Detalle)
        {
            return new PerfilesDA().CHU_Perfiles_Guardar(obj, Detalle);
        }
        public DataSet CHU_Perfiles_Obtener(int IdDepto, int IdPuesto)
        {
            return new PerfilesDA().CHU_Perfiles_Obtener(IdDepto, IdPuesto);
        }
        public int CHU_Perfiles_Actualiza(PerfilesBE obj, DataTable Detalle)
        {
            return new PerfilesDA().CHU_Perfiles_Actualiza(obj, Detalle);
        }
        public int CHU_Perfiles_Elimina(int IdPerfil, int IdUsuario)
        {
            return new PerfilesDA().CHU_Perfiles_Elimina(IdPerfil, IdUsuario);
        }
    }
}