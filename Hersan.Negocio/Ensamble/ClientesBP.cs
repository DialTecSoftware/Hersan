using Hersan.Datos.Ventas;
using Hersan.Entidades.Ensamble;
using System;
using System.Collections.Generic;
using System.Data;

namespace Hersan.Negocio.Ventas
{
    public class ClientesBP
    {
        public int ABC_Clientes_Guardar(DataSet Tablas, string Entidades, int IdUsuario)
        {
            return new ClientesDA().ABC_Clientes_Guardar(Tablas, Entidades, IdUsuario);
        }
        public int ABC_Clientes_Actualizar(DataSet Tablas, string Entidades, int IdUsuario, bool Estatus)
        {
            return new ClientesDA().ABC_Clientes_Actualizar(Tablas, Entidades, IdUsuario, Estatus);
        }
        public List<ClientesBE> ABC_Clientes_Buscar(ClientesBE Lista, string Entidades)
        {
            return new ClientesDA().ABC_Clientes_Buscar(Lista, Entidades);
        }
        public List<ClientesBE> ABC_Clientes_Obtener(int IdCliente)
        {
            return new ClientesDA().ABC_Clientes_Obtener(IdCliente);
        }
    }
}
