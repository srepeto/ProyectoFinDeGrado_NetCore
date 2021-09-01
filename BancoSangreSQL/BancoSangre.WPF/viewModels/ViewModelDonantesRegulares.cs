using BancoSangre.Domain.Models;
using BancoSangre.Domain.Services;
using BancoSangre.EntityFramework;
using BancoSangre.EntityFramework.Services;
using System.Collections.Generic;

namespace BancoSangre.WPF.chartModels
{
    class ViewModelDonantesRegulares
    {
        IDataServiceDonantes<Donante> donanteService = new DonanteDataService<Donante>(new BancoSangreDbContextFactory());

        public List<DonantesRegulares> Data { get; set; }

        public ViewModelDonantesRegulares ()
        {
            Data = obtenerDonantesRegulares();
        }

        public List<DonantesRegulares> obtenerDonantesRegulares()
        {
            List<DonantesRegulares> listaDonantesRegulares = new List<DonantesRegulares>()
            {
                new DonantesRegulares
                {
                    A="A", B="B", AB="AB", Cero="0",
                    AcantPos=donanteService.getDonantesRegulares("A", "+"),
                    AcantNeg=donanteService.getDonantesRegulares("A", "-"),
                    BcantPos=donanteService.getDonantesRegulares("B", "+"),
                    BcantNeg=donanteService.getDonantesRegulares("B", "-"),
                    ABcantPos=donanteService.getDonantesRegulares("AB", "+"),
                    ABcantNeg=donanteService.getDonantesRegulares("AB", "-"),
                    CeroCantPos=donanteService.getDonantesRegulares("0", "+"),
                    CeroCantNeg=donanteService.getDonantesRegulares("0", "-"),
                }
            };
            return listaDonantesRegulares;
        }

    }
}
