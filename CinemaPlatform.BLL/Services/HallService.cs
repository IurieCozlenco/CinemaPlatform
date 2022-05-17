using CinemaPlatform.BLL.Mapper;
using CinemaPlatform.Common.Dtos.Hall;
using CinemaPlatform.Common.Dtos.Place;
using CinemaPlatform.Common.Dtos.Row;
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
    public class HallService
    {
        private readonly IGenericRepository<Hall> _repositoryHall;

        public HallService(IGenericRepository<Hall> repositoryHall)
        {
            _repositoryHall = repositoryHall;
        }
        public async Task<bool> CreateHallAsync(HallCreateDTO hallCreateDTO)
        {
            var state = _repositoryHall.Add(hallCreateDTO.ToEntity());

            await _repositoryHall.SaveChangesAsync();

            return state == EntityState.Added;
        }

        public async Task<IEnumerable<HallDTO>> GetAll()
        {
            var result = await _repositoryHall.GetAllQuery()
                .Include(x => x.Rows)
                .ThenInclude(x => x.Places)
                .ToListAsync();

            var hallDTOs = result.ToDtos();

            return hallDTOs;
        }
    }
}
