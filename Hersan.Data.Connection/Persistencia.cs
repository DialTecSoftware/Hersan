using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Hersan.Data.Connection
{
    public class Persistencia
    {
        private string _CadenaConexion = null;
        private string baseConnectionString = null;


        public Persistencia(string connectionString)
        {            
            _CadenaConexion = connectionString;
            baseConnectionString = connectionString;
         
        }

        public int InsertarModificarStoreProcedureSql<T>(string USP, T parametros)
        {
            using (IDbConnection dbConn = new SqlConnection(_CadenaConexion)) {
                var result = dbConn.Execute(USP, parametros, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public int InsertarModificarEliminarUnaVariableSql<T>(string USP, object dynamic)
        {
            using (IDbConnection dbConn = new SqlConnection(_CadenaConexion)) {
                if (dynamic != null) {
                    var result = dbConn.Execute(USP, dynamic, commandType: CommandType.StoredProcedure);
                    return result;
                } else {
                    var result = dbConn.Execute(USP, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
        }

        public T ModelosEntidadesSql<T>(string USP, object dynamic, bool texto = false)
        {
            T result;
            using (IDbConnection db = new SqlConnection(_CadenaConexion)) {
                if (dynamic != null) {
                    if (texto == false) {
                        result = db.Query<T>(USP, dynamic, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    } else {
                        result = db.Query<T>(USP, dynamic, commandType: CommandType.Text).FirstOrDefault();
                    }

                } else {
                    if (texto == false) {
                        result = db.Query<T>(USP, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    } else {
                        result = db.Query<T>(USP, commandType: CommandType.Text).FirstOrDefault();
                    }
                }
            }
            return result;
        }

        public async Task<IEnumerable<T>> IEnumerableSql<T>(string USP, object dynamic)
        {
            using (IDbConnection db = new SqlConnection(_CadenaConexion)) {
                if (dynamic != null) {
                    var results = await db.QueryAsync<T>(USP, dynamic, commandType: CommandType.StoredProcedure);
                    return results;
                } else {
                    var results = await db.QueryAsync<T>(USP, commandType: CommandType.StoredProcedure);
                    return results;
                }
            }
        }

        public async Task<List<T>> List<T>(string USP, object dynamic = null, bool texto = false)
        {
            using (IDbConnection db = new SqlConnection(_CadenaConexion)) {
                if (dynamic != null) {
                    if (texto == false) {
                        var results = await db.QueryAsync<T>(USP, dynamic, commandType: CommandType.StoredProcedure);
                        return results.ToList();
                    } else {
                        var results = await db.QueryAsync<T>(USP, dynamic, commandType: CommandType.Text);
                        return results.ToList();
                    }

                } else {
                    if (texto == false) {
                        var results = await db.QueryAsync<T>(USP, commandType: CommandType.StoredProcedure);
                        return results.ToList();
                    } else {
                        var results = await db.QueryAsync<T>(USP, commandType: CommandType.Text);
                        return results.ToList();
                    }
                }

            }
        }

        public List<T> ListSinAsync<T>(string USP, object dynamic)
        {
            using (IDbConnection db = new SqlConnection(_CadenaConexion)) {
                if (dynamic != null) {
                    var results = db.Query<T>(USP, dynamic, commandType: CommandType.StoredProcedure);
                    return results.ToList();
                } else {
                    var results = db.Query<T>(USP, commandType: CommandType.StoredProcedure);
                    return results.ToList();
                }

            }
        }

        public List<T> ListMultipleSinAsync<T>(string USP, object dynamic, int NTabla = 1)
        {
            using (IDbConnection db = new SqlConnection(_CadenaConexion)) {
                if (dynamic != null) {
                    using (var multi = db.QueryMultiple(USP, dynamic, commandType: CommandType.StoredProcedure)) {
                        List<T> results = null;
                        var invoice2 = multi.Read<object>().First();
                        for (int i = 0; i < NTabla; i++) {
                            results = multi.Read<T>().ToList();
                        }
                        return results.ToList();
                    }
                } else {
                    using (var multi = db.QueryMultiple(USP, commandType: CommandType.StoredProcedure)) {
                        List<T> results = null;
                        var invoice2 = multi.Read<object>().First();
                        for (int i = 0; i < NTabla; i++) {
                            results = multi.Read<T>().ToList();
                        }
                        return results.ToList();
                    }
                }
            }
        }


        //public async Task<List<T>> ListMultiple<T>(string USP, object dynami, int NTabla = 1)
        //{
        //    using (IDbConnection db = new SqlConnection(_CadenaConexion)) {
        //        if (dynami != null) {
        //            using (var multi = db.QueryMultiple(USP, dynami, commandType: CommandType.StoredProcedure)) {
        //                List<T> results = null;
        //                ///Primera Tabla
        //                //var invoice2 = multi.Read<object>().First();
        //                for (int i = 0; i < NTabla + 1; i++) {
        //                    results = multi.Read<T>().ToList();
        //                }
        //                return results.ToList();
        //            }
        //        } else {
        //            using (var multi = db.QueryMultiple(USP, commandType: CommandType.StoredProcedure)) {
        //                List<T> results = null;
        //                var invoice2 = multi.Read<object>().First();
        //                for (int i = 0; i < NTabla; i++) {
        //                    results = multi.Read<T>().ToList();
        //                }
        //                return results.ToList();
        //            }
        //        }
        //    }
        //}


        public async Task<List<T>> ListSql<T>(string USP, object dynamic)
        {
            using (IDbConnection db = new SqlConnection(_CadenaConexion)) {
                if (dynamic != null) {
                    var results = await db.QueryAsync<T>(USP, dynamic, commandType: CommandType.StoredProcedure);
                    return results.ToList();
                } else {
                    var results = await db.QueryAsync<T>(USP, commandType: CommandType.StoredProcedure);
                    return results.ToList();
                }
            }
        }

    }
}
