﻿using Aplicacion_CursosJD.BusinessLogic.Services;
using Aplicacion_CursosJD.Entities.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_CursosJD.DataAccess.Repository
{
    public class RolRepository
    {
        public IEnumerable<tbRoles> List()
        {
            const string sql = " Acce.sp_Roles_listar";

            List<tbRoles> result = new List<tbRoles>();

            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                result = db.Query<tbRoles>(sql, commandType: CommandType.Text).ToList();

                return result;
            }

        }





        public int Insert(tbRoles item)
        {
            const string sql = "Acce.sp_Roles_insertar";



            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Roles_Descripcion", item.Rol_Descripcion);
                parametro.Add("@Roles_UsuarioCreacion ", item.Rol_UsuarioCreacion);
                parametro.Add("@Roles_FechaCreacion", item.Rol_FechaCreacion);
                parametro.Add("@ID", DbType.Int32, direction: ParameterDirection.Output);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                int id = parametro.Get<int>("@ID");
                //string mensaje = (result == 1) ? "Exito" : "Error";
                return id;

                //return new RequestStatus { CodeStatus = result, MessageStatus = mensaje }+  id;
            }

        }







        public RequestStatus Insertpan(tbPantallasPorRoles item)
        {
            const string sql = "Acce.sp_PantallasRoles_insertar";



            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Panta_Id", item.Pan_Id);
                parametro.Add("@Roles_Id", item.Rol_Id);
                parametro.Add("@Papro_UsuarioCreacion ", item.Ppr_UsuarioCreacion);
                parametro.Add("@Papro_FechaCreacion", item.Ppr_FechaCreacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }

        }

        public IEnumerable<tbRoles> List(int id)
        {
            const string sql = "[Acce].[sp_PantallasPorRol_listar2]";

            List<tbRoles> result = new List<tbRoles>();

            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                result = db.Query<tbRoles>(sql, commandType: CommandType.Text).ToList();

                return result;
            }


        }

        public IEnumerable<tbRoles> ListPXR()
        {
            const string sql = "[Acce].[sp_PantallasPorRol_listar2]";

            List<tbRoles> result = new List<tbRoles>();

            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                result = db.Query<tbRoles>(sql, commandType: CommandType.Text).ToList();

                return result;
            }


        }

        public tbRoles Details(int id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Delete(int Roles_Id)
        {
            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Roles_Id", Roles_Id);

                var result = db.QueryFirst(ScriptsBaseDeDatos.Rol_Eliminar, parameter, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result.Resultado, MessageStatus = (result.Resultado == 1) ? "Exito" : "Error" };
            }
        }
        public IEnumerable<tbPantallasPorRoles> ObtenerRol(int Roles_Id)
        {
            string sql = ScriptsBaseDeDatos.Rol_Obtener;

            List<tbPantallasPorRoles> result = new List<tbPantallasPorRoles>();

            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                var parameters = new { Roles_Id = Roles_Id };
                result = db.Query<tbPantallasPorRoles>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }


        public RequestStatus EliminarPantallaPorRol(int PaRo_Id)
        {
            string sql = ScriptsBaseDeDatos.Papro_Eliminar;
            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Papro_Id", PaRo_Id);

                var result = db.Execute(
                    sql, parametro,
                    commandType: CommandType.StoredProcedure
                );

                string mensaje = (result == 1) ? "exito" : "error";

                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            };
        }


        public IEnumerable<tbPantallasPorRoles> BuscarPantallasPorRol(int Rol_Id)
        {
            string sql = ScriptsBaseDeDatos.Papro_Buscar;

            List<tbPantallasPorRoles> result = new List<tbPantallasPorRoles>();

            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                var parameters = new { Roles_Id = Rol_Id };
                result = db.Query<tbPantallasPorRoles>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }


        public IEnumerable<tbRoles> findObtenerId(string Rol, int usuario_creacion, DateTime fecha_creacion)
        {
            string sql = ScriptsBaseDeDatos.Rol_ObtenerId;

            List<tbRoles> result = new List<tbRoles>();

            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                var parameters = new { Rol, usuario_creacion, fecha_creacion };
                result = db.Query<tbRoles>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }


        public RequestStatus Delete(tbRoles item)
        {
            throw new NotImplementedException();
        }


        public tbRoles find(int? id)
        {
            throw new NotImplementedException();
        }



        public RequestStatus Update(tbRoles item)
        {

            string sql = ScriptsBaseDeDatos.Roles_Actualizar;

            using (var db = new SqlConnection(Aplicacion_CursosJD.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Roles_Id", item.Rol_Id);
                parameter.Add("@Roles_Descripcion", item.Rol_Descripcion);
                parameter.Add("@Roles_UsuarioModificacion", item.Rol_UsuarioModificacion);
                parameter.Add("@Roles_FechaModificacion", item.Rol_FechaModificacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);

                string mensaje = (result > 0) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            }




        }
    }
}
