using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Entities;
using BLL.Interfaces;
using BLL.DTO;
using AutoMapper;

namespace BLL.Services
{
    public class AnketeService : IAnketeService
    {
        IUnitOfWork Database { get; set; }

        public AnketeService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public IEnumerable<AnketeDTO> GetAllAnketes()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Ankete, AnketeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Ankete>, List<AnketeDTO>>(Database.Ankete.Get());
        }

        public int AddAnkete(AnketeDTO ankete, List<GenreDTO> genres)
        {
            Ankete a = new Ankete
            {
                Name = ankete.Name,
                Surname = ankete.Surname,
                Email = ankete.Email,
                TimeId = ankete.TimeId,
                AgeId = ankete.AgeId
            };
            Database.Ankete.Add(a);

            foreach (GenreDTO g in genres)
            {
                Database.AnketeGenre.Add(new AnketeGenre { GenreId = g.Id, AnketeId = a.Id });

            }
            return a.Id;
        }
        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<GenreDTO> GetGenres()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Genre, GenreDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Genre>, List<GenreDTO>>(Database.Genre.Get());
        }

        public IEnumerable<AgeDTO> GetAges()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Age, AgeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Age>, List<AgeDTO>>(Database.Age.Get());
        }

        public IEnumerable<TimeDTO> GetTimes()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Time, TimeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Time>, List<TimeDTO>>(Database.Time.Get());
        }

        public IEnumerable<AnketeGenreDTO> GetAnketeGenres()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AnketeGenre, AnketeGenreDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<AnketeGenre>, List<AnketeGenreDTO>>(Database.AnketeGenre.Get());
        }
    }
}
