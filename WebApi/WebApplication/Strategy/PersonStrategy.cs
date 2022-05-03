#region Utils
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Web.Entities.Data;
using Web.Repository.UnitOfWork;
#endregion

namespace WebApplication.Strategy
{
    public class PersonStrategy : IPersonStrategy
    {
        public async Task AddPerson(TbPersonasFisica model, DatabaseContext _context)
        {
            try
            {
                var Res = new SqlParameter("@ERROR", SqlDbType.Int);
                Res.Direction = ParameterDirection.Output;

                await _context.
                    Database.
                    ExecuteSqlInterpolatedAsync
                    ($@"EXEC sp_AgregarPersonaFisica 
                        @Nombre={model.Nombre},
                        @ApellidoPaterno={model.ApellidoPaterno},
                        @ApellidoMaterno={model.ApellidoMaterno},
                        @RFC={model.Rfc},
                        @FechaNacimiento={model.FechaNacimiento},
                        @UsuarioAgrega={model.UsuarioAgrega}
                        ");                           
            }
            catch(Exception ex)
            {
                var msj = ex.Message;
            }
        }
        public async Task DeletePerson(int Id, DatabaseContext _context)
        {
            try
            {
                var Res = new SqlParameter("@ERROR", SqlDbType.Int);
                Res.Direction = ParameterDirection.Output;

                await _context.
                    Database.
                    ExecuteSqlInterpolatedAsync
                    ($@"EXEC sp_EliminarPersonaFisica 
                        @IdPersonaFisica={Id}
                    ");
            }
            catch (Exception ex)
            {
                var msj = ex.Message;
            }
        }
        public async Task UpdatePerson(TbPersonasFisica model, DatabaseContext _context)
        {
            try
            {
                var Res = new SqlParameter("@ERROR", SqlDbType.Int);
                Res.Direction = ParameterDirection.Output;

                await _context.
                    Database.
                    ExecuteSqlInterpolatedAsync
                    ($@"EXEC sp_ActualizarPersonaFisica 
                        @IdPersonaFisica={model.IdPersonaFisica},
                        @Nombre={model.Nombre},
                        @ApellidoPaterno={model.ApellidoPaterno},
                        @ApellidoMaterno={model.ApellidoMaterno},
                        @RFC={model.Rfc},
                        @FechaNacimiento={model.FechaNacimiento},
                        @UsuarioAgrega={model.UsuarioAgrega}
                        ");
            }
            catch (Exception ex)
            {
                var msj = ex.Message;
            }
        }
        public async Task<TbPersonasFisica> GetPerson(IUnitOfWork _unitOfWork, int PersonId)
        {
            TbPersonasFisica tbPersonasFisica = null;
            
            var query = _unitOfWork
                .TbPersonasFisica
                .GetBy(u => u.IdPersonaFisica == PersonId)
                .Where(w=>w.Activo == true)
                .OrderBy(s=>s.ApellidoMaterno)
                .FirstOrDefault();

            if (query != null)
                tbPersonasFisica = query;

            return tbPersonasFisica;
        }
        public async Task<IEnumerable<TbPersonasFisica>> GetPersons(IUnitOfWork _unitOfWork)
        {
            IEnumerable<TbPersonasFisica> tbPersonasFisicas = null;

            IEnumerable<TbPersonasFisica> query = _unitOfWork.TbPersonasFisica
                .GetBy(w=>w.Activo==true)
                .OrderBy(s=>s.ApellidoPaterno)
                .ToList();

            if(query != null)
                tbPersonasFisicas = query;

            return tbPersonasFisicas;
        }
    }
}