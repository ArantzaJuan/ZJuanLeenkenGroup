using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZjuanLeenkenGroupContext context = new DL.ZjuanLeenkenGroupContext())
                {
                    
                    var empleados = context.Empleados.FromSqlRaw($"EmpleadoGetAll").ToList();
                    result.Objects = new List<object>();
                    if (empleados != null)
                    {
                        foreach (var objEmpleado in empleados)
                        {

                           ML.Empleado empleadoobj = new ML.Empleado();
                            empleadoobj.IdEmpleado = objEmpleado.IdEmpleado;
                            empleadoobj.NumeroNomina = objEmpleado.NumeroNomina;
                            empleadoobj.Nombre = objEmpleado.Nombre;
                            empleadoobj.ApellidoPaterno = objEmpleado.ApellidoPaterno;
                            empleadoobj.ApellidoMaterno = objEmpleado.ApellidoMaterno;
                            empleadoobj.EntidadFederativa = new ML.EntidadFederativa();
                            empleadoobj.EntidadFederativa.IdEntidadFederativa = objEmpleado.IdEntidadFederativa.Value;
                            result.Objects.Add(empleadoobj);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar la consulta";

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetById(int IdEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZjuanLeenkenGroupContext context = new DL.ZjuanLeenkenGroupContext())
                {

                    var empleados = context.Empleados.FromSqlRaw($"EmpleadoGetById {IdEmpleado}").AsEnumerable().FirstOrDefault();
                    result.Objects = new List<object>();
                    if (empleados != null)
                    {
                       

                            ML.Empleado empleadoobj = new ML.Empleado();
                            empleadoobj.IdEmpleado = empleados.IdEmpleado;
                            empleadoobj.NumeroNomina = empleados.NumeroNomina;
                            empleadoobj.Nombre = empleados.Nombre;
                            empleadoobj.ApellidoPaterno = empleados.ApellidoPaterno;
                            empleadoobj.ApellidoMaterno = empleados.ApellidoMaterno;

                            empleadoobj.EntidadFederativa = new ML.EntidadFederativa();
                            empleadoobj.EntidadFederativa.IdEntidadFederativa = empleados.IdEntidadFederativa.Value;
                            result.Object = empleadoobj;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar la consulta";

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZjuanLeenkenGroupContext context = new DL.ZjuanLeenkenGroupContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"EmpleadoAdd'{empleado.Nombre}','{empleado.ApellidoPaterno}','{empleado.ApellidoMaterno}',{empleado.EntidadFederativa.IdEntidadFederativa}");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ingreso el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result UpDate(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZjuanLeenkenGroupContext context = new DL.ZjuanLeenkenGroupContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"EmpleadoUpdate'{empleado.Nombre}','{empleado.ApellidoPaterno}','{empleado.ApellidoMaterno}',{empleado.EntidadFederativa.IdEntidadFederativa},{empleado.IdEmpleado}");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ingreso el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Delete(int IdEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZjuanLeenkenGroupContext context = new DL.ZjuanLeenkenGroupContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"EmpleadoDelete {IdEmpleado}");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = !false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

    }
}
