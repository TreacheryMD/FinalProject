using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalBanking.BLL.Abstract;
using PersonalBanking.PresentationMVC.Models;

namespace PersonalBanking.PresentationMVC.Controllers
{
    public class AdminPersonController : Controller
    {
        private readonly IPersonService _personService;

        public AdminPersonController(IPersonService personService)
        {
            _personService = personService;
        }

        public ActionResult Person()
        {
            var personsDto = _personService.GetPersonsDtos();
            IList<PersonViewModel> personViewModel = new List<PersonViewModel>();
            AutoMapper.Mapper.Map(personsDto, personViewModel);
            return View(personViewModel);
        }
    }
}