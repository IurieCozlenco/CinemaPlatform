using CinemaPlatform.BLL.Mapper;
using CinemaPlatform.Common.Dtos.Session;
using CinemaPlatform.DAL.Interfaces;
using CinemaPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPlatform.BLL.Services
{
    public class SessionService
    {
        private readonly IGenericRepository<Session> _repositorySession;
        private readonly IGenericRepository<Hall> _repositoryHall;

        public SessionService(IGenericRepository<Session> repositorySession, IGenericRepository<Hall> repositoryHall)
        {
            _repositorySession = repositorySession;
            _repositoryHall = repositoryHall;
        }
        public async Task<bool> CreateSessionAsync(SessionCreateDTO sessionCreateDTO)
        {
            var entity = sessionCreateDTO.ToEntity();

            entity.Hall = await _repositoryHall.GetByIdAsync(entity.HallId)
                .Include(h => h.Rows)
                .ThenInclude(r => r.Places)
                .FirstOrDefaultAsync();

            entity.PlaceStatuses = entity.Hall.Rows.SelectMany(x => x.Places, (rows, place) => new PlaceStatus
            {
                Row = rows,
                Place = place
            }).ToList();

            var state = _repositorySession.Add(entity);

            await _repositorySession.SaveChangesAsync();

            return state == EntityState.Added;
        }

        public async Task<IEnumerable<SessionBasicDTO>> GetSessions()
        {
            var result = await _repositorySession.GetAllQuery()
                .Include(s => s.Film)
                .ToListAsync();

            var sessionBasicDTOs = result.ToSessionBasicDTOs();

            return sessionBasicDTOs;
        }

        public async Task<SessionFullDTO?> GetSessionInfo(int sessionId)
        {
            var result = await _repositorySession.GetByIdAsync(sessionId)
                .Include(s => s.PlaceStatuses)
                .ThenInclude(s => s.Row)
                .ThenInclude(s => s.Places)
                .Include(s => s.Film)
                .FirstOrDefaultAsync();

            var SessionFullDTO = result?.ToSessionFullDTO();

            return SessionFullDTO;
        }
    }
}
