using BancoSangre.Domain.Models;
using BancoSangre.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace BancoSangre.EntityFramework.Services
{
    public class DonanteDataService<T> : IDataServiceDonantes<Donante>
    {

        private readonly BancoSangreDbContextFactory _contextFactory;

        public DonanteDataService(BancoSangreDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public bool CreateDonante(Donante entity)
        {
            using (BancoSangreDbContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<Donante> createdResult = context.Set<Donante>().Add(entity);
                context.SaveChanges();

                return true;
            }
        }

        public bool DeleteDonante(string id)
        {
            using (BancoSangreDbContext context = _contextFactory.CreateDbContext())
            {
                Donante entity = context.Set<Donante>().FirstOrDefault((e) => e.Dni == id);
                context.Set<Donante>().Remove(entity);
                context.SaveChanges();

                return true;
            }
        }

        public Donante GetDonante(string id)
        {
            using (BancoSangreDbContext context = _contextFactory.CreateDbContext())
            {
                Donante donante = context.Set<Donante>().Where(s => s.Dni == id).SingleOrDefaultAsync().Result;
                return donante;
            }
        }

        public List<Donante> GetAllDonantes()
        {
            using (BancoSangreDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Donante> entities = context.Set<Donante>().ToList();
                List<Donante> listaDonantes = new List<Donante>();
                foreach (Donante donante in entities)
                {
                    listaDonantes.Add(donante);
                }
                return listaDonantes;
            }
        }

        public bool UpdateDonante(string id, Donante entity)
        {
            using (BancoSangreDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Dni = id;
                context.Set<Donante>().Update(entity);
                context.SaveChanges();

                return true;
            }
        }

        public List<Donante> GetSearchDonantes(string busqueda)
        {
            using (BancoSangreDbContext context = _contextFactory.CreateDbContext())
            {
                List<Donante> listaDonantes;
                if (busqueda.Equals("-") || busqueda.Equals("+"))
                {
                    listaDonantes = context.Donantes.FromSqlRaw("SELECT * FROM bancosangredb.donantes " +
                        "WHERE Factorrh LIKE '" + busqueda + "'").ToList();
                } else
                {
                    string data = string.Format("%{0}%", busqueda);
                    listaDonantes = context.Donantes.FromSqlRaw("SELECT * FROM bancosangredb.donantes " +
                        "WHERE Dni LIKE '" + data + "' OR Nombre LIKE '" + data + "' OR Direccion LIKE '" + data +
                        "' OR Telefono LIKE '" + data + "' OR FechaNacimiento LIKE '" + data + "'OR Gruposanguineo LIKE '" +
                        data + "' OR Factorrh LIKE '" + data + "'").ToList();
                }

                return listaDonantes;
            }
        }

        public List<Donante> GetSearchDonantesGSRH(string busqueda, string signo)
        {

            using (BancoSangreDbContext context = _contextFactory.CreateDbContext())
            {
                if (signo.Equals("+") || signo.Equals("-"))
                {
                    List<Donante> listaDonantes = context.Donantes.FromSqlRaw("SELECT * FROM bancosangredb.donantes " +
                        "WHERE Gruposanguineo LIKE '" + busqueda + "' AND Factorrh LIKE '" + signo + "'").ToList();
                    return listaDonantes;
                } else
                {
                    List<Donante> listaDonantes = context.Donantes.FromSqlRaw("SELECT * FROM bancosangredb.donantes " +
                    "WHERE Gruposanguineo LIKE '" + busqueda + "' OR Factorrh LIKE '" + signo + "'").ToList();
                    return listaDonantes;
                }
            }
        }

        public int getDonantesRegulares(string gs, string rh)
        {

            using (BancoSangreDbContext context = _contextFactory.CreateDbContext())
            {
                int result = context.Donantes.FromSqlRaw("SELECT dc.Donantefk FROM bancosangredb.donaciones dc " +
                    "JOIN bancosangredb.donantes dt ON dc.Donantefk = dt.Dni WHERE dc.Fecha < '2021-05-03' AND " +
                    "dc.Fecha > '2020-01-01' AND dt.Gruposanguineo LIKE '"+ gs +"' AND dt.Factorrh LIKE '"+ rh +"' " +
                    "GROUP BY dc.Donantefk HAVING COUNT(dc.Donantefk) >= 2").Count();

                return result;
            }
        }
    }
}
