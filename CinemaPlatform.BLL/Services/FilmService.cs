using CinemaPlatform.BLL.Mapper;
using CinemaPlatform.Common.Dtos.Film;
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
    public class FilmService
    {
        private readonly IGenericRepository<Film> _repositoryFilm;

        public FilmService(IGenericRepository<Film> repositoryFilm)
        {
            _repositoryFilm = repositoryFilm;
        }

        public async Task<bool> CreateFilmAsync(FilmCreateDTO filmCreateDTO)
        {
            var state = _repositoryFilm.Add(filmCreateDTO.ToEntity());

            await _repositoryFilm.SaveChangesAsync();

            return state == EntityState.Added;
        }

        public async Task<IEnumerable<FilmBasicDTO>> GetFilms(DateTime? startDate = null, DateTime? finalDate = null)
        {
            var result = await _repositoryFilm.GetAllQuery()
                .Where(f => f.StartDate >= (startDate ?? DateTime.MinValue) && f.FinalDate <= (finalDate ?? DateTime.MaxValue))
                .Include(f => f.Sessions)
                .ToListAsync();

            var filmSessionBasicDTOs = result.ToDtos();

            return filmSessionBasicDTOs;
        }
    }
}
