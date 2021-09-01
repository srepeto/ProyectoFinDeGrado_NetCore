using BancoSangre.Domain.Models;
using BancoSangre.Domain.Services;
using BancoSangre.EntityFramework;
using BancoSangre.EntityFramework.Services;
using System.Collections.Generic;

namespace BancoSangre.WPF
{
    public class ViewModelDonantes
    {

        IDataServiceDonantes<Donante> donanteService = new DonanteDataService<Donante>(new BancoSangreDbContextFactory());

        public List<Donante> Data { get; set; }

        public ViewModelDonantes()
        {
            Data = donanteService.GetAllDonantes();
        }

    }
        
}
