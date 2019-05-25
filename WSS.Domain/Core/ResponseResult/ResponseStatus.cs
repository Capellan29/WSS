using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace WSS.Domain.Core.ResponseResult
{
    public class ResponseStatus
    {
        public enum StatusCode
        { 
            Success = 1,
            SuccessCreate = 2,
            SuccessUpdate = 3,
            NotFound = 4,
            ErrorMessage = 5,
            ErrorRequest = 6,
            ErrorModelState = 7,
            Timeout = 8 
        }
        public enum StatusMessages
        {
            [Description("El registro fue creado correctamente")]
            SuccessCreateMessage,
            [Description("El registro fue actualizado correctamente")]
            SuccessUpdateMessage,
            [Description("No se han encontrado resultados para la búsqueda")]
            NotFoundMessage,
            [Description("Ha ocurrido un error en la solicitud")]
            ErrorMessage,
            [Description("Se produjo una excepción al procesar su solicitud")]
            ErrorRequest,
            [Description("El estado del formulario no es válido")]
            ErrorModelState,
            [Description("Tiempo de espera agotado")]
            Timeout
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            return value.ToString();
        }


    }
}
