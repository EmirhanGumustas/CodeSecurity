using Azure.Core;
using Part.Entity.Concrate;
using Party.Business.Concrate.Repositories;
using Party.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party.Business.Concrate
{
    public class InvitationService
    {
        private readonly InvitationRepositories _repo;

        public InvitationService(InvitationRepositories repo)
        {
            _repo = repo;
        }

        public List<InvitationViewModel> GetAll()
        {
            var ınvitations = _repo.GetAll();
            List<InvitationViewModel> ınvitationViewModels = ınvitations.Select(x=>new InvitationViewModel
            {
                EventDate = x.EventDate,
                EventName = x.EventName,
                Id=x.Id,
            }).ToList();
            return ınvitationViewModels;
        }
        public InvitationViewModel GetById(int id)
        {
            var ınvitation = _repo.GetById(id);
            InvitationViewModel ınvitationViewModel = new();

            ınvitationViewModel.Id= ınvitation.Id;
            ınvitationViewModel.EventName=ınvitation.EventName;
            ınvitationViewModel.EventDate=ınvitation.EventDate;
            return ınvitationViewModel;
       
        }
        public void Create(InvitationViewModel ınvitationViewModel)
        {
            Invitation ınvitation = new()
            {
                Id = ınvitationViewModel.Id,
                EventName = ınvitationViewModel.EventName,
                EventDate = ınvitationViewModel.EventDate
            };
            _repo.Create(ınvitation);
        }
        public void Uptade(InvitationViewModel ınvitationVM)
        {
            Invitation ınvit = _repo.GetById(ınvitationVM.Id);
            ınvit.EventDate=ınvitationVM.EventDate;
            ınvit.EventName=ınvitationVM.EventName;
            _repo.Uptade(ınvit);
        }
        public void Delete(int id)
        {
            var xx = _repo.GetById(id);
            _repo.Delete(xx);
        }
    }
}
