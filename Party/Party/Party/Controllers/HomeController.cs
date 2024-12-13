using Microsoft.AspNetCore.Mvc;
using Party.Business.Concrate;
using Party.Models;
using System.Diagnostics;

namespace Party.Controllers
{
    public class HomeController : Controller
    {
        private readonly InvitationService _invitationService;
        private readonly ParticipantService _participantService;

        public HomeController(InvitationService �nvitationService,ParticipantService participantService)
        {
            _invitationService = �nvitationService;
            _participantService = participantService;
        }

        public IActionResult Index()
        {
            var invitations = _invitationService.GetAll();
            return View(invitations);
        }

        public IActionResult Join()
        {
            return View();
        }

    }
}
