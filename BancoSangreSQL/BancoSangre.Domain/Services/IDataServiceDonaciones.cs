using System.Collections.Generic;

namespace BancoSangre.Domain.Services
{
    public interface IDataServiceDonaciones<Donacion>
    {
        List<Donacion> GetAllDonaciones();

        Donacion GetDonacion(string id);

        List<Donacion> GetDonacionesByDni(string dni);

        Donacion CreateDonacion(Donacion entity);

        bool UpdateDonacion(string id, Donacion entity);

        public int getCantidadSangre(string gs, string rh);

        bool DeleteDonacion(string id);

        public List<Donacion> GetSearchDonaciones(string busqueda);

        public int getUltimoId();
    }
}
