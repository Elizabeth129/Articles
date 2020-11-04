using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces;
using BLL.DTO;
using AutoMapper;
using PL.Models;

namespace PL.Controllers
{
    public class WorksheetController : Controller
    {
        IAnketeService anketeService;
        public WorksheetController(IAnketeService serv)
        {
            anketeService = serv;
        }
        public JsonResult ValidateEmail(string Email)
        {
            IEnumerable<AnketeDTO> anketes = anketeService.GetAllAnketes();

            if (anketes.Select(m => m.Email).ToList().Contains(Email))
            {
                return Json("Form with this email already exist!", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Worksheet
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<GenreDTO> genres = anketeService.GetGenres();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, Genre>()).CreateMapper();
            ViewBag.Genre = mapper.Map<IEnumerable<GenreDTO>, List<Genre>>(genres);
            
            IEnumerable<TimeDTO> times = anketeService.GetTimes();
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<TimeDTO, Time>()).CreateMapper();
            ViewBag.Time = new SelectList(mapper.Map<IEnumerable<TimeDTO>, List<Time>>(times), "Id", "TimeName");

            IEnumerable<AgeDTO> ages = anketeService.GetAges();
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<AgeDTO, Age>()).CreateMapper();
            ViewBag.Age = new SelectList(mapper.Map<IEnumerable<AgeDTO>, List<Age>>(ages), "Id", "AgeName");
            return View();
        }
        [HttpPost]
        public ActionResult Index(Ankete ankete)
        {
            if (ModelState.IsValid)
            {
                List<string> g = new List<string>(Request.Form.GetValues("Genre"));
                var Genres = new List<GenreDTO>();
                IEnumerable<GenreDTO> genres = anketeService.GetGenres();
                foreach (string e in g)
                {
                    if (e != "false")
                    {
                        Genres.Add(anketeService.GetGenres().Where(b => b.GenreName == e).Select(b => b).FirstOrDefault());
                    }
                }
                AnketeDTO ankete1 = new AnketeDTO
                {
                    Id = ankete.Id,
                    Name = ankete.Name,
                    Surname = ankete.Surname,
                    Email = ankete.Email,
                    TimeId = ankete.TimeId,
                    AgeId = ankete.AgeId
                };
                int anketeId =  anketeService.AddAnkete(ankete1, Genres);

                
                var genresId = anketeService.GetAnketeGenres().Where(m => m.AnketeId == anketeId).Select(m => m.GenreId).ToList();
                List<string> genresName = new List<string>();
                foreach (var e in genresId)
                {
                    genresName.Add(anketeService.GetGenres().Where(m => m.Id == e).Select(m => m.GenreName).FirstOrDefault());
                }
                ViewBag.Genres = genresName;
                ViewBag.AgeName = anketeService.GetAges().Where(m => m.Id == ankete.AgeId).Select(m => m.AgeName).FirstOrDefault();
                ViewBag.TimeName = anketeService.GetTimes().Where(m => m.Id == ankete.TimeId).Select(m => m.TimeName).FirstOrDefault();
                return View("Sent", ankete);
            }
            else
            {
                IEnumerable<GenreDTO> genres = anketeService.GetGenres();
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, Genre>()).CreateMapper();
                ViewBag.Genre = mapper.Map<IEnumerable<GenreDTO>, List<Genre>>(genres);

                IEnumerable<TimeDTO> times = anketeService.GetTimes();
                mapper = new MapperConfiguration(cfg => cfg.CreateMap<TimeDTO, Time>()).CreateMapper();
                ViewBag.Time = new SelectList(mapper.Map<IEnumerable<TimeDTO>, List<Time>>(times), "Id", "TimeName");

                IEnumerable<AgeDTO> ages = anketeService.GetAges();
                mapper = new MapperConfiguration(cfg => cfg.CreateMap<AgeDTO, Age>()).CreateMapper();
                ViewBag.Age = new SelectList(mapper.Map<IEnumerable<AgeDTO>, List<Age>>(ages), "Id", "AgeName");
                return View("Index");
            }
        }
    }
}