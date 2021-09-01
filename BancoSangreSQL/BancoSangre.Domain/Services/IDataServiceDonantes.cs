using System.Collections.Generic;

namespace BancoSangre.Domain.Services
{
    public interface IDataServiceDonantes<Donante>
    {
        List<Donante> GetAllDonantes();

        Donante GetDonante(string id);

        bool CreateDonante(Donante entity);

        bool UpdateDonante(string id, Donante entity);

        bool DeleteDonante(string id);

        public List<Donante> GetSearchDonantes(string busqueda);

        public List<Donante> GetSearchDonantesGSRH(string busqueda, string signo);

        public int getDonantesRegulares(string gs, string rh);
    }
}
