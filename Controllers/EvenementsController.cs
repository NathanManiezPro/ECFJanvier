using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECFJanvier.Data;
using ECFJanvier.Models;

namespace ECFJanvier.Controllers
{
    public class EvenementsController : Controller
    {


        private readonly ECFJanvierContext _context;

        public EvenementsController(ECFJanvierContext context)
        {
            _context = context;
        }
        // GET: Evenements
        public async Task<IActionResult> Index()
        {
            var evenements = await _context.Evenement.ToListAsync();
            return View(evenements);
        }



        // GET: Evenements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evenement = await _context.Evenement
                .Include(e => e.Participants) 
                .ThenInclude(ep => ep.Participant) 
                .FirstOrDefaultAsync(m => m.Id == id);

            if (evenement == null)
            {
                return NotFound();
            }

            return View(evenement);
        }


        // GET: Evenements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Evenements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titre,Date,Lieu")] Evenement evenement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evenement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(evenement);
        }

        // GET: Evenements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evenement = await _context.Evenement.FindAsync(id);
            if (evenement == null)
            {
                return NotFound();
            }
            return View(evenement);
        }

        // POST: Evenements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titre,Date,Lieu")] Evenement evenement)
        {
            if (id != evenement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evenement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvenementExists(evenement.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(evenement);
        }

        // GET: Evenements/Delete/5
        // GET: Evenements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evenement = await _context.Evenement
                .Include(e => e.Participants) 
                .ThenInclude(ep => ep.Participant)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (evenement == null)
            {
                return NotFound();
            }

            ViewBag.ParticipantCount = evenement.Participants.Count; 

            return View(evenement);
        }


        //Add participant
        public IActionResult AddParticipant(int eventId)
        {
            var evenement = _context.Evenement
                .FirstOrDefault(e => e.Id == eventId);

            if (evenement == null)
            {
                return NotFound();
            }

            // Charger les participants non associés à un événement
            ViewBag.Participants = _context.Participant
                .Where(p => !_context.EvenementParticipant
                    .Any(ep => ep.ParticipantId == p.Id && ep.EvenementId == eventId))
                .ToList();

            return View(evenement);
        }



        [HttpPost]
        public IActionResult AddParticipant(int eventId, int participantId)
        {
            var evenement = _context.Evenement.FirstOrDefault(e => e.Id == eventId);
            var participant = _context.Participant.FirstOrDefault(p => p.Id == participantId);

            if (evenement == null || participant == null)
            {
                return NotFound();
            }

            // Ajouter une relation dans la table de liaison
            var evenementParticipant = new EvenementParticipant
            {
                EvenementId = eventId,
                ParticipantId = participantId
            };

            _context.EvenementParticipant.Add(evenementParticipant);
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = eventId });
        }





        // POST: Evenements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evenement = await _context.Evenement.FindAsync(id);
            if (evenement != null)
            {
                _context.Evenement.Remove(evenement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvenementExists(int id)
        {
            return _context.Evenement.Any(e => e.Id == id);
        }
    }
}
