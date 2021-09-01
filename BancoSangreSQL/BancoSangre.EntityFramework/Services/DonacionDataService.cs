using BancoSangre.Domain.Models;
using BancoSangre.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace BancoSangre.EntityFramework.Services
{
    public class DonacionDataService<T> : IDataServiceDonaciones<Donacion>
    {

        private readonly BancoSangreDbContextFactory _contextFactory;

        public DonacionDataService(BancoSangreDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public Donacion CreateDonacion(Donacion entity)
        {
            using (BancoSangreDbContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<Donacion> createdResult = context.Set<Donacion>().Add(entity);
                context.SaveChanges();

                return createdResult.Entity;
            }
        }

        public bool DeleteDonacion(string id)
        {
            using (BancoSangreDbContext context = _contextFactory.CreateDbContext())
            {
                Donacion entity = context.Set<Donacion>().FirstOrDefault((e) => e.Id == id);
                context.Set<Donacion>().Remove(entity);
                context.SaveChanges();

                return true;
            }
        }

        public List<Donacion> GetAllDonaciones()
        {
            using (BancoSangreDbContext context = _contextFactory.CreateDbContext())
            {
                List<Donacion> listaDonaciones = context.Donaciones.FromSqlRaw("SELECT * FROM bancosangredb.donaciones " +
                    "ORDER BY CAST(Id AS int)").ToList();
                return listaDonaciones;
            }
        }

        public Donacion GetDonacion(string id)
        {
            using (BancoSangreDbContext context = _contextFactory.CreateDbContext())
            {
                Donacion donacion = context.Set<Donacion>().Where(s => s.Id == id).SingleOrDefaultAsync().Result;
                return donacion;
            }
        }

        public List<Donacion> GetDonacionesByDni(string dni)
        {
            using (BancoSangreDbContext context = _contextFactory.CreateDbContext())
            {
                List<Donacion> listaDonaciones = context.Set<Donacion>().Where(s => s.Donantefk == dni).ToList();
                return listaDonaciones;
            }
        }

        public bool UpdateDonacion(string id, Donacion entity)
        {
            using (BancoSangreDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<Donacion>().Update(entity);
                context.SaveChanges();

                return true;
            }
        }

        public int getCantidadSangre (string gs, string rh)
        {

            using (BancoSangreDbContext context = _contextFactory.CreateDbContext())
            {

                int cantidad = 0;

                List<Donacion> result = context.Donaciones.FromSqlRaw("SELECT * FROM bancosangredb.donaciones e " +
                    "JOIN bancosangredb.donantes d ON e.Donantefk=d.Dni AND d.Gruposanguineo LIKE '" + gs + "' " +
                    "AND d.Factorrh LIKE '" + rh + "'").ToList();

                foreach (Donacion donacion in result)
                {
                    cantidad = cantidad + donacion.Cantidad;
                }

                return cantidad;
            }
        }

        public List<Donacion> GetSearchDonaciones(string busqueda)
        {
            using (BancoSangreDbContext context = _contextFactory.CreateDbContext())
            {
                string data = string.Format("%{0}%", busqueda);
                List<Donacion> listaDonaciones = context.Donaciones.FromSqlRaw("SELECT * FROM bancosangredb.donaciones " +
                    "WHERE Id LIKE '" + data + "' OR Donantefk LIKE '" + data + "' OR Fecha LIKE '" + data +
                    "' OR Cantidad LIKE '" + busqueda + "' ORDER BY CAST(Id AS int)").ToList();

                return listaDonaciones;
            }
        }

        public int getUltimoId()
        {
            using (BancoSangreDbContext context = _contextFactory.CreateDbContext())
            {
                List<Donacion> listaDonaciones = context.Donaciones.FromSqlRaw("SELECT * FROM bancosangredb.donaciones " +
                    "ORDER BY CAST(Id AS int)").ToList();
                return int.Parse(listaDonaciones[listaDonaciones.Count - 1].Id);
            }
        }

    }
}
