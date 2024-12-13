using Microsoft.EntityFrameworkCore;
using Part.Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party.Data.Concrate.Repositories
{
    public class ParticipantRepositories
    {
        private readonly AppDbContext _appDbContext;

        public ParticipantRepositories(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<Participant> GetAll() 
        {
          List<Participant> participants =  _appDbContext.Participants.ToList();
            return participants;
        }
        public Participant GetById(int id) 
        {
            var participant = _appDbContext.Participants.First(x => x.Id == id);
            return participant;
        }
        public void Create(Participant participant)
        {
            _appDbContext.Participants.Add(participant);
            _appDbContext.SaveChanges();
        }
        public void Update(Participant participant) 
        {
            _appDbContext.Participants.Update(participant);
            _appDbContext.SaveChanges();
        }
        public void Delete(Participant participant) 
        {
            _appDbContext.Participants.Remove(participant);
            _appDbContext.SaveChanges(); 
        }
        public List<Participant> GetAll(int ınvitationId) //İNV ID'YE GÖRE PARTİCİPANT GETİRCEK
        {
            // katılımcıları hangi partide oldugunu görmek istedigimiz için.
            //ççoka çok ilişkilerde ıdleri birbiriyl eşleştirmek için yapılan bir tablo
            var list = _appDbContext.Participants
                                    .Include(x => x.InvitationParticipants)
                                    .ThenInclude(y => y.Invitation) // buraya kadar joinleme işlemi yaptık
                                    .Where(x => x.InvitationParticipants.Any(y => y.InvitationId == ınvitationId)) // gelen verileri çoka çok tabloda ıdlerin eşlenmesini sağladık
                                    .ToList();
            return list;
        }

    }
}
