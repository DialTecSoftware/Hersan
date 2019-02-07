﻿using Hersan.Entidades.CapitalHumano;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

namespace Hersan.CH.Contract
{
    [ServiceContract]
    public interface IHersan_CHumano
    {
        [OperationContract]
        int CHU_Perfiles_Guardar(PerfilesBE obj, DataTable Detalle);
        [OperationContract]
        DataSet CHU_Perfiles_Obtener(int IdDepto, int IdPuesto);
        [OperationContract]
        int CHU_Perfiles_Actualiza(PerfilesBE obj, DataTable Detalle);
        [OperationContract]
        int CHU_Perfiles_Elimina(int IdPerfil, int IdUsuario);
    }
}