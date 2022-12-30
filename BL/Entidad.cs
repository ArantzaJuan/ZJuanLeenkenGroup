using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Entidad
    {
        public static ML.Result GetAllEntidades()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZjuanLeenkenGroupContext context = new DL.ZjuanLeenkenGroupContext())
                {

                    var empleados = context.EntidadFederativas.FromSqlRaw($"EntidadGetAll").ToList();
                    result.Objects = new List<object>();
                    if (empleados != null)
                    {
                        foreach (var objEmpleado in empleados)
                        {

                            ML.EntidadFederativa entidadfede = new ML.EntidadFederativa();
                            entidadfede.IdEntidadFederativa = objEmpleado.IdEntidadFederativa;
                            entidadfede.Estado = objEmpleado.Estado;
                            
                            result.Objects.Add(entidadfede);

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
    }
}
