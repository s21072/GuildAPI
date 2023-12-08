using GuildAPI.DTOs.Requests;
using GuildAPI.Models;
using GuildAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Services
{
    public class CommissionDBService : ICommissionDBService
    {
        private readonly MyDBContext _context;

        public CommissionDBService(MyDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CreateEmergency(EmergencyCommission emergencyCommission, string creator)
        {
            //podmiana stringa na Enum
            if (!Enum.IsDefined(typeof(Ranks), emergencyCommission.MinRank)) return new BadRequestResult(); //Walidacja czy wartosc w enumie o nazwie {value} istnieje.

            Ranks rank = (Ranks)Enum.Parse(typeof(Ranks), emergencyCommission.MinRank);
            //walidacja czy istnieją, pobranie maxID + 1
            //Console.WriteLine("Enum przeszedł");
            //int teamID = 1; int commID = 1;
            //if (await _context.Teams.AnyAsync()) teamID = await _context.Teams.MaxAsync(p => p.TeamID) + 1;
            //if (await _context.Commissions.AnyAsync()) commID = await _context.Commissions.MaxAsync(p => p.CommissionID) + 1;
            if (!await _context.Adventurers.AnyAsync()) return new BadRequestResult();
            Console.WriteLine("Walidacja istnienia przeszła");
            //Nie sprawdzamy czy istnieje Person, gdyż jeśli nie istnieje CEO i tak nie ma to znaczenia
            if (await _context.CEOs.FirstOrDefaultAsync(o => o.Pesel == creator) == null) return new NotFoundResult();
            //Tworzenie boxa Team i pustej listy Adventurerów i GuildWorkerów do dalszych działań
            var teamBase = new Team(){};
            await _context.AddAsync(teamBase);
            await _context.SaveChangesAsync();

            List<Adventurers> adv = new List<Adventurers>();
            List<GuildWorker> gw = new List<GuildWorker>();

            if(emergencyCommission.Adventurers.Length > 0)
                foreach (string i in emergencyCommission.Adventurers) {
                    Adventurers tmp = await _context.Adventurers.FirstOrDefaultAsync(o => o.Pesel == i);
                    adv.Add(tmp);
                }
            if (emergencyCommission.GuildWorkers.Length > 0)
                foreach (string i in emergencyCommission.GuildWorkers){
                    GuildWorker tmp = await _context.GuildWorkers.FirstOrDefaultAsync(o => o.Pesel == i);
                    gw.Add(tmp);
                }
            Console.WriteLine("Znaleienie CEO i utworzenie obiektu Team przeszło/wysłanie do contextu");
            //walidacja przypadku dla tworzenia zlecenia
            var commission = new Commission();
            //Gdy nie wybieżemy żadnej osoby, domyślnie dodają się wszyscy wolni Adventurers
            if (emergencyCommission.GuildWorkers.Length == 0 && emergencyCommission.Adventurers.Length == 0)
            {
                Console.WriteLine("Nie powinno się włączyć - wszyscy adventurers");
                adv = await _context.Adventurers.Where(p => p.CommissionID == null).ToListAsync();
                foreach (Adventurers adventurers in adv)
                {
                    teamBase.Adventurers.Add(adventurers);
                }
                commission = new Commission()
                {
                    //CommissionID = commID,
                    Title = emergencyCommission.Title,
                    CommissionType = CommissionTypes.EMERGANCY,
                    MinRank = rank,
                    CreateTime = DateTime.Now,
                    AcceptTime = DateTime.Now,
                    Reword = 1000,
                    Pesel = creator,
                    TeamID = teamBase.TeamID,
                    Description = emergencyCommission.Description
                };
            }//Do teamu w GuildWorkers można dodać max 3 osoby
            else if (emergencyCommission.GuildWorkers.Length > 0 && emergencyCommission.Adventurers.Length == 0) {
                Console.WriteLine("Nie powinno się włączyć - tylko guildWorkers");
                if (emergencyCommission.GuildWorkers.Length > 3) return new BadRequestResult();
                foreach(GuildWorker guildWorker in gw)
                {
                    teamBase.GuildWorker.Add(guildWorker);
                    guildWorker.NymberOfCommissionsDone += 1;
                }
                commission = new Commission()
                {
                    //CommissionID = commID,
                    Title = emergencyCommission.Title,
                    CommissionType = CommissionTypes.EMERGANCY,
                    MinRank = rank,
                    CreateTime = DateTime.Now,
                    AcceptTime = DateTime.Now,
                    Reword = 0,
                    Pesel = creator,
                    TeamID = teamBase.TeamID,
                    Description = emergencyCommission.Description
                };
            }// Sami Adventurers
            else if (emergencyCommission.GuildWorkers.Length == 0 && emergencyCommission.Adventurers.Length > 0) {
                foreach (Adventurers adventurers in adv)
                {
                    teamBase.Adventurers.Add(adventurers);
                }
                Console.WriteLine("Dodano adventurerów do listy w Team");
                commission = new Commission()
                {
                    //CommissionID = commID,
                    Title = emergencyCommission.Title,
                    CommissionType = CommissionTypes.EMERGANCY,
                    MinRank = rank,
                    CreateTime = DateTime.Now,
                    AcceptTime = DateTime.Now,
                    Reword = 1000,
                    Pesel = creator,
                    TeamID = teamBase.TeamID,
                    Description = emergencyCommission.Description
                };
                Console.WriteLine("Utworzono obiekt commission");
            }
            else {//Jednocześnie 3 GuildWorkers i Adventurers
                Console.WriteLine("Nie powinno się włączyć - aventurers i guildWorkers");
                if (emergencyCommission.GuildWorkers.Length > 3) return new BadRequestResult();
                foreach (GuildWorker guildWorker in gw)
                {
                    teamBase.GuildWorker.Add(guildWorker);
                    guildWorker.NymberOfCommissionsDone += 1;
                }
                foreach (Adventurers adventurers in adv)
                {
                    teamBase.Adventurers.Add(adventurers);
                }
                commission = new Commission()
                {
                    //CommissionID = commID,
                    Title = emergencyCommission.Title,
                    CommissionType = CommissionTypes.EMERGANCY,
                    MinRank = rank,
                    CreateTime = DateTime.Now,
                    AcceptTime = DateTime.Now,
                    Reword = 1000,
                    Pesel = creator,
                    TeamID = teamBase.TeamID,
                    Description = emergencyCommission.Description
                };
            }

            await _context.AddAsync(commission);
            await _context.SaveChangesAsync();

            //Console.WriteLine("Dodano obiekt commission do contextu");

            if (emergencyCommission.Adventurers.Length > 0)
            {
                foreach (Adventurers i in adv)
                {
                    i.CommissionID = commission.CommissionID;
                    i.TeamID = teamBase.TeamID;
                }
            }
            //Console.WriteLine("Zmieniono status Adventurerom");

            await _context.SaveChangesAsync();

            return new OkResult();
        }
//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!koniec metody przypadku użycia!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(await _context.Commissions.ToListAsync());
        }

        public async Task<IActionResult> Get(int id)
        {
            var commission = await _context.Commissions.FirstOrDefaultAsync(o => o.CommissionID == id);

            if (commission == null) return new NotFoundResult();

            return new OkObjectResult(commission);
        }
    }
}
