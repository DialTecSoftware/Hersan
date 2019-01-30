﻿using Hersan.CH.Contract;
using Hersan.Entidades.CapitalHumano;
using Hersan.Negocio.CapitalHumano;
using System.Collections.Generic;
using System.Data;

namespace Hersan.CH.Service
{
    public class Hersan_CHumano : IHersan_CHumano
    {
        public int CHU_Perfiles_Guardar(PerfilesBE obj, DataTable Detalle)
        {
            return new PerfilesBP().CHU_Perfiles_Guardar(obj, Detalle);
        }
        public DataSet CHU_Perfiles_Obtener(int IdDepto, int IdPuesto)
        {
            return new PerfilesBP().CHU_Perfiles_Obtener(IdDepto, IdPuesto);
        }
        public int CHU_Perfiles_Actualiza(PerfilesBE obj, DataTable Detalle)
        {
            return new PerfilesBP().CHU_Perfiles_Actualiza(obj, Detalle);
        }
        public int CHU_Perfiles_Elimina(int IdPerfil, int IdUsuario)
        {
            return new PerfilesBP().CHU_Perfiles_Elimina(IdPerfil, IdUsuario);
        }
    }
}
