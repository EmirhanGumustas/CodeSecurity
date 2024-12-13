using Part.Entity.Concrate;
using Party.Data.Concrate.Repositories;
using Party.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Party.Business.Concrate
{
    public class ParticipantService
    {
        private readonly ParticipantRepositories _repository;

        public ParticipantService(ParticipantRepositories repository)
        {
            _repository = repository;
        }
        public List<ParticipantViewModel> GetAll() 
        {
            List<ParticipantViewModel> x = _repository.GetAll().Select(x=>new ParticipantViewModel
            {
                Age = x.Age,
                Email = x.Email,
                FullName = x.FullName,
                Id = x.Id,
                NumberOfPeople = x.NumberOfPeople,
                Phone = x.Phone
            }).ToList();

            return x;
        }

        public List<ParticipantViewModel> GetAllById(int invtId) 
        {
            List<Participant> participants = _repository.GetAll(invtId);
            List<ParticipantViewModel> participantViewModels = participants.Select(x=>new ParticipantViewModel
            {
                Age= x.Age,
                Email= x.Email,
                FullName = x.FullName,
                Id = x.Id,  
                NumberOfPeople = x.NumberOfPeople,
                Phone = x.Phone
            }).ToList();
            return participantViewModels;
        }

        public void Create(ParticipantViewModel participantViewModel, int invitationId) 
        {
            Participant participant = new()
            {
                Age= participantViewModel.Age,
                Email= participantViewModel.Email,
                FullName= participantViewModel.FullName,
                NumberOfPeople= participantViewModel.NumberOfPeople,
                Phone = participantViewModel.Phone
            };
            _repository.Create(participant); // ekleme işlemi yaptık.
            InvitationParticipant ınvitationParticipant = new()
            {
                InvitationId= invitationId,
                ParticipantId=participant.Id,
            };
            participant.InvitationParticipants=new List<InvitationParticipant>();

           
        }
    }
}
