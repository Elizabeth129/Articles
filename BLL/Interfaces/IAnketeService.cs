using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IAnketeService
    {
        IEnumerable<AnketeDTO> GetAllAnketes();
        IEnumerable<GenreDTO> GetGenres();
        IEnumerable<AgeDTO> GetAges();
        IEnumerable<TimeDTO> GetTimes();
        IEnumerable<AnketeGenreDTO> GetAnketeGenres();
        int AddAnkete(AnketeDTO ankete, List<GenreDTO> genres);
        void Dispose();
    }
}
