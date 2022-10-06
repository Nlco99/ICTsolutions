using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ICTsolutions.Areas.Identity.Data;
using ICTsolutions.Models;
using ICTsolutions.Enums;

namespace ICTsolutions.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            return View(await _context.projects.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.projects == null)
            {
                return NotFound();
            }

            var project = await _context.projects.Include(p => p.projects)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Client,ProjectManager,amountMembers,Sources,ProgramingLanguage,Payment,Status,Type")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.projects == null)
            {
                return NotFound();
            }

            var project = await _context.projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Client,ProjectManager,amountMembers,Sources,ProgramingLanguage,Payment,Status,Type")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
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
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.projects == null)
            {
                return NotFound();
            }

            var project = await _context.projects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.projects == null)
            {
                return Problem("Entity set 'ApplicationDbContext.projects'  is null.");
            }
            var project = await _context.projects.FindAsync(id);
            if (project != null)
            {
                _context.projects.Remove(project);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        //Filtered projects based on Status
        public async Task<IActionResult> GetAvailableProjects()
        {
            return View("Index", await _context.projects.Where(project => project.Status == StatusEnum.Available).ToListAsync());
        }

        //[HttpPost, ActionName("Join")]
        //public async Task<IActionResult> JoinProject(int id, [Bind("Id,Name,Client,ProjectManager,amountMembers,Sources,ProgramingLanguage,Payment,Status,Type")] Project project)
        //{
        //    if (id == null || _context.projects == null)
        //    {
        //        return NotFound();
        //    }

        //    //var project = await _context.projects.FindAsync(id);
        //    //if (project == null)
        //    //{
        //    //    return NotFound();
        //    //}
        //    return View(project);
        //}



        private bool ProjectExists(int id)
        {
          return _context.projects.Any(e => e.Id == id);
        }
    }
}
