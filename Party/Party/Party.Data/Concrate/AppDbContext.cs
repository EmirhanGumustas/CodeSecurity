using Microsoft.EntityFrameworkCore;
using Part.Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party.Data.Concrate
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<InvitationParticipant> InvitationParticipants { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            // veritabanı ile ilgili herşeyi onmodelcreating içine yazabiliriz.
            #region INVITION HASDATA
            List<Invitation> invites = new()
            {
                new Invitation
                {
                    Id = 1,
                    EventDate = new DateTime(2024,12,12),
                    EventName = "Test",

                },
                     new Invitation
                {
                    Id = 2,
                    EventDate = new DateTime(2024,12,12),
                    EventName = "Test1",

                },
            };
            model.Entity<Invitation>().HasData(invites);
            #endregion

            #region PARTICIPANT DATA
            List<Participant> participants = new()
            {
                new Participant
                {
                    Id= 1,
                    Age= 1,
                    Email="sadad@gmail.com",
                    FullName= "TestİSİM",
                    NumberOfPeople= 1,
                    Phone="asşldkasdş"
                },
                    new Participant
                {
                    Id= 2,
                    Age= 2,
                    Email="sadad@gmail.com",
                    FullName= "TestİSİM2",
                    NumberOfPeople= 1,
                    Phone="asşldkasdş2"
                },
                        new Participant
                {
                    Id= 3,
                    Age= 3,
                    Email="sadad@gmail.com",
                    FullName= "TestİSİ4",
                    NumberOfPeople= 3,
                    Phone="asşldkasdş3"
                },
                            new Participant
                {
                    Id= 4,
                    Age= 4,
                    Email="sadad@gmail.com",
                    FullName= "TestİSİM4",
                    NumberOfPeople= 1,
                    Phone="asşldkasdş4"
                },
                                new Participant
                {
                    Id= 5,
                    Age= 5,
                    Email="sadad@gmail.com",
                    FullName= "TestİSİM5",
                    NumberOfPeople= 2,
                    Phone="asşldkasdş5"
                },
                                    new Participant
                {
                    Id= 6,
                    Age= 6,
                    Email="sadad@gmail.com",
                    FullName= "TestİSİM6",
                    NumberOfPeople= 1,
                    Phone="asşldkasdş6"
                },
            };
            model.Entity<Participant>().HasData(participants);
            #endregion

            #region INVITATIONPARTICIPANT HASDATA
            List<InvitationParticipant> ınvitationParticipants = new()
            {

                new() { InvitationId = 1, ParticipantId = 2
                },
                new() { InvitationId = 2, ParticipantId = 4
                },
                new() { InvitationId = 1, ParticipantId = 3
                },
                new() { InvitationId = 2, ParticipantId = 5
                },
                new() { InvitationId = 1, ParticipantId = 6
                },
                new() { InvitationId = 2, ParticipantId = 1
                },
                new() { InvitationId = 1, ParticipantId = 4
                },
                new() { InvitationId = 2, ParticipantId = 3
                },
                new() { InvitationId = 1, ParticipantId = 5
                },
                new() { InvitationId = 2, ParticipantId = 6
                }
            };
            model.Entity<InvitationParticipant>().HasData(ınvitationParticipants);
            #endregion

            #region InvitationConfig
            model.Entity<Invitation>().HasKey(x => x.Id); //primarykey olmasını istedim
            model.Entity<Invitation>().Property(x=>x.Id).ValueGeneratedOnAdd(); // her kayıtta artmasını istedim.

            model.Entity<Invitation>().Property(x => x.EventName)
                                      .IsRequired(true) // boş bırakılmasın.
                                      .HasMaxLength(65); // max 65 karater yazılabilir.

            model.Entity<Invitation>().ToTable("Invitation"); // tablo ismini yaratır
            #endregion

            #region ParticipantConfig
            model.Entity<Participant>().HasKey(x => x.Id); // prımarykey yaptık
            model.Entity<Participant>().Property(x => x.Id).ValueGeneratedOnAdd(); // seçtigimiiz ıd eklendiginde art
            model.Entity<Participant>().Property(x=>x.FullName) // fullname yakaladık.
                                       .IsRequired()// boş bırakılamaz (default == true == not null).
                                       .HasMaxLength(100);// max 100 karakter olsun.
            model.Entity<Participant>().Property(x=>x.Email) // email yakaladık
                                       .HasMaxLength(100); // max karakter sayısı 100
            model.Entity<Participant>().Property(x=>x.Age).IsRequired(false);// null olabilir
            model.Entity<Participant>().Property(x=>x.Phone).IsRequired(false);// null olabilir
            model.Entity<Participant>().Property(x=>x.NumberOfPeople).IsRequired(true); // null olamaz.
            model.Entity<Participant>().ToTable("Participant"); // tablo ismini değiştirdik.

            #endregion

            #region InvitationParticipantConfig
            model.Entity<InvitationParticipant>().HasKey(x => new { x.InvitationId, x.ParticipantId });
            //ID'lerin tekrar etmesini istemiyorum 1 katılımcı noela katılmış. başka zaman aynı katılımcı tekrar noele katılmış tutmasın tekrar etmesin. bu bilgiyi 1 kere tutsun yeterli olacak
            #endregion


            base.OnModelCreating(model);
        }



    }
}