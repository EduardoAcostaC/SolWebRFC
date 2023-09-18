using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class N_RFC
    {
        public List<E_RFC> ObtenerTodos()
        {
            D_RFC datos = new D_RFC();
            return datos.ObtenerTodos();
        }

        public string AgregarRFC(E_RFC rfc)
        {
            D_RFC datos = new D_RFC();
            string rfcOk = this.CalcularRFC(rfc);
            rfc.rfc = rfcOk;
            datos.AgregarRFC(rfc);
            return rfcOk;
        }

        public E_RFC ObtenerPorId(int idRFC)
        {
            D_RFC datos = new D_RFC();
            return datos.ObtenerPorID(idRFC);
        }
        public void GuardarEdicion(E_RFC rfc)
        {
            D_RFC datos = new D_RFC();
            datos.GuardarEdicion(rfc);
        }

        public void EliminarRFC(int id)
        {
            D_RFC datos = new D_RFC();
            datos.EliminarRFC(id);
        }
        public List<E_RFC> BuscarRFC(string texto)
        {
            D_RFC datos = new D_RFC();
            return datos.BuscarRFC(texto);
        }

        public int ObtenerCantidad()
        {
            D_RFC datos = new D_RFC();
            return datos.ObtenerCantidad();
        }

        private string ObtenerPrimeraVocal(string palabra)
        {
            string vocales = "aeiouAEIOU";

            foreach (char letra in palabra)
            {
                if (vocales.Contains(letra))
                {
                    return letra.ToString();
                }
            }

            return ""; // Si no se encuentra ninguna vocal, devolvemos una cadena vacía
        }

        // Método auxiliar para encontrar la segunda vocal en una cadena
        private string ObtenerSegundaVocal(string palabra)
        {
            string vocales = "aeiouAEIOU";
            int countVocales = 0;

            foreach (char letra in palabra)
            {
                if (vocales.Contains(letra))
                {
                    countVocales++;
                    if (countVocales == 2)
                    {
                        return letra.ToString();
                    }
                }
            }

            return ""; // Si no se encuentra la segunda vocal, devolvemos una cadena vacía
        }

        private string CalcularRFC(E_RFC obj)
        {
            
                // Regla 1: La letra inicial y la primera vocal interna del primer apellido
                string primeraLetraApellido = obj.apellidoPaterno.Substring(0, 1);
                string primeraVocalApellido = ObtenerPrimeraVocal(obj.apellidoPaterno);

                // Validación para la regla 1
                if (primeraLetraApellido == primeraVocalApellido)
                {
                    primeraVocalApellido = ObtenerSegundaVocal(obj.apellidoPaterno);
                }

                // Regla 2: La letra inicial del segundo apellido
                string letraInicialSegundoApellido = obj.apellidoMaterno.Substring(0, 1);

                // Regla 3: La primera letra del nombre
                string primeraLetraNombre = obj.nombre.Substring(0, 1);
                primeraLetraNombre = this.ValidaÑ(primeraLetraNombre);

                // Regla 4: Fecha de nacimiento en el formato AAMMDD
                string fechaNacimientoRFC = $"{obj.fechaNacimiento.Year % 100:D2}{obj.fechaNacimiento.Month:D2}{obj.fechaNacimiento.Day:D2}";

                // Concatenar los resultados
                string rfc = $"{primeraLetraApellido}{primeraVocalApellido}{letraInicialSegundoApellido}{primeraLetraNombre}{fechaNacimientoRFC}";

                return rfc.ToUpper(); // Convertimos a mayúsculas (el RFC suele estar en mayúsculas)

        }

        private string ValidaÑ(string valor)
        {
            if (valor[0].ToString().ToLower() == "ñ") 
            {
                return "X";
            }
            return valor;
        }
    }

    

}
