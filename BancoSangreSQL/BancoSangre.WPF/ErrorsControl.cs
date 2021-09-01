using BancoSangre.Domain.Models;
using BancoSangre.Domain.Services;
using BancoSangre.EntityFramework;
using BancoSangre.EntityFramework.Services;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace BancoSangre.WPF
{
    public class ErrorsControl
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNac { get; set; }

        public string Donantefk { get; set; }
        public DateTime Fecha { get; set; }
        public string Cantidad { get; set; }

        IDataServiceDonantes<Donante> donanteService = new DonanteDataService<Donante>(new BancoSangreDbContextFactory());
        IDataServiceDonaciones<Donacion> donacionService = new DonacionDataService<Donacion>(new BancoSangreDbContextFactory());

        public ErrorsControl (string dni, string nombre, string telf, DateTime fechaNac)
        {
            Dni = dni;
            Nombre = nombre;
            Telefono = telf;
            FechaNac = fechaNac;
        }

        public ErrorsControl (string donantefk, DateTime fecha, string cantidad)
        {
            Donantefk = donantefk;
            Fecha = fecha;
            Cantidad = cantidad;
        }

        public bool validarCamposDonante()
        {

            if (!validarConRegex(@"^((([A-Za-z])\d{8})|(\d{8}([A-Za-z])))$", Dni))
            {
                MessageBox.Show("El campo 'DNI' no es válido");
                return false;
            }
            if (!validarConRegex(@"([A-Z,Á,É,Í,Ó,Ú,Ñ,a-z,á,é,í,ó,ú,ñ]+\s*)+$", Nombre))
            {
                MessageBox.Show("El campo 'Nombre' no es válido");
                return false;
            }
            if (!validarConRegex(@"^6[0-9]{8}$", Telefono))
            {
                MessageBox.Show("El campo 'Teléfono' no es válido");
                return false;
            }
            if (FechaNac > DateTime.UtcNow.AddMonths(-216) || FechaNac < DateTime.UtcNow.AddMonths(-840))
            {
                MessageBox.Show("El campo 'Fecha de nacimiento' no es válido");
                return false;
            }

            return true;
        }

        public bool validarCamposDonacion()
        {

            if (!validarConRegex(@"^((([A-Za-z])\d{8})|(\d{8}([A-Za-z])))$", Donantefk))
            {
                MessageBox.Show("El campo 'Donante' no es válido");
                return false;
            }
            if (Fecha.Year < 2015 || Fecha > DateTime.UtcNow)
            {
                MessageBox.Show("El campo 'Fecha' no es válido");
                return false;
            }
            if (!isNumeric(Cantidad) || int.Parse(Cantidad) > 450)
            {
                MessageBox.Show("El campo 'Cantidad' no es válido");
                return false;
            }

            return true;
        }

        public bool donanteExiste (string dniDon)
        {
            Donante donante = donanteService.GetDonante(dniDon);
            if (donante == null)
            {
                return false;
            }
            return true;
        }

        private bool validarConRegex(string pattern, string contenido)
        {
            Regex r = new Regex(pattern);

            if ((r.IsMatch(contenido)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool isNumeric(string strNum)
        {
            if (strNum != null)
            {
                try
                {
                    int.Parse(strNum);
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
