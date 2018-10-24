using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Data.Connection
{
    public class DataConnection<T> : IDisposable where T : IDbConnection
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly DataConnection<T> dataConnection;

        /// <summary>
        /// 
        /// </summary>
        //public IDbConnection DataConnection => dataConnection.GetGeneric();

        /// <summary>
        /// Cadena de conexión
        /// </summary>
        /// 
        //private string baseConnectionString = CadenaConexion.SqlDbxConexion;

        public DataConnection(string connectionString, string connectionUser = "")
        {
            //if (string.IsNullOrEmpty(connectionString))
            //    connectionString = baseConnectionString;
            dataConnection = new DataConnection<T>(connectionString, connectionUser);
        }

        public void Dispose()
        {
            // If this function is being called the user wants to release the
            // resources. lets call the Dispose which will do this for us.
            Dispose(true);

            // Now since we have done the cleanup already there is nothing left
            // for the Finalizer to do. So lets tell the GC not to call it later.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing == true) {
                //someone want the deterministic release of all resources
                //Let us release all the managed resources
                ReleaseManagedResources();
            } else {
                // Do nothing, no one asked a dispose, the object went out of
                // scope and finalized is called so lets next round of GC 
                // release these resources
            }

            // Release the unmanaged resource in any case as they will not be 
            // released by GC
            ReleaseUnmangedResources();
        }

        /// <summary>
        /// 
        /// </summary>
        ~DataConnection()
        {
            // The object went out of scope and finalized is called
            // Lets call dispose in to release unmanaged resources 
            // the managed resources will anyways be released when GC 
            // runs the next time.
            Dispose(false);
        }

        void ReleaseManagedResources()
        {
            //if (this.dataConnection != null)
            //    this.dataConnection = null;

            //Console.WriteLine("Releasing Managed Resources");
            //if (tr != null)
            //{
            //    tr.Dispose();
            //}
        }

        void ReleaseUnmangedResources()
        {
            Console.WriteLine("Releasing Unmanaged Resources");
        }
    }
}
