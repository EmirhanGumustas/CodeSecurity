using Part.Entity.Concrate;
using Party.Data.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party.Business.Concrate.Repositories
{
    public class InvitationRepositories
    {
        private readonly AppDbContext _appDbContext;

        public InvitationRepositories(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<Invitation> GetAll() 
        {
          var result =  _appDbContext.Invitations.ToList();
            return result;
        }
        public Invitation GetById(int id)
        {
          var result =  _appDbContext.Invitations.First(x => x.Id == id);
            return result;
        }
        public void Create(Invitation ınvitation)
        {
            _appDbContext.Invitations.Add(ınvitation);
            _appDbContext.SaveChanges();
        }
        public void Uptade(Invitation ınvitation)
        {
            _appDbContext.Invitations.Update(ınvitation);
            _appDbContext.SaveChanges();
        }
        public void Delete(Invitation ınvitation)
        {
            _appDbContext.Invitations.Remove(ınvitation);
            _appDbContext.SaveChanges();
        }
    }
}
