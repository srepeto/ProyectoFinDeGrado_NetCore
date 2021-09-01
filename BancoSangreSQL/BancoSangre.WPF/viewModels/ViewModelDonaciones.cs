using BancoSangre.Domain.Models;
using BancoSangre.Domain.Services;
using BancoSangre.EntityFramework;
using BancoSangre.EntityFramework.Services;
using System.Collections.Generic;

namespace BancoSangre.WPF
{
    public class ViewModelDonaciones
    {

        IDataServiceDonaciones<Donacion> donacionesService = new DonacionDataService<Donacion>(new BancoSangreDbContextFactory());

        public List<Donacion> DataDonaciones { get; set; }

        public ViewModelDonaciones()
        {
            DataDonaciones = donacionesService.GetAllDonaciones();
        }

    }
        
}
