using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElectronicEquipmentsService.Data;

namespace ElectronicEquipmentsService.Controllers
{
    public class ExecutesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExecutesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Executes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Executes.Include(e => e.Employee).Include(e => e.Order);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Executes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var execute = await _context.Executes
                .Include(e => e.Employee)
                .Include(e => e.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (execute == null)
            {
                return NotFound();
            }

            return View(execute);
        }

        // GET: Executes/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
            return View();
        }

        // POST: Executes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderId,EmployeeId,Discription,Warrantly,StatusOfOrder,Price")] Execute execute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(execute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", execute.EmployeeId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", execute.OrderId);
            return View(execute);
        }

        // GET: Executes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var execute = await _context.Executes.FindAsync(id);
            if (execute == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", execute.EmployeeId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", execute.OrderId);
            return View(execute);
        }

        // POST: Executes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,OrderId,EmployeeId,Discription,Warrantly,StatusOfOrder,Price")] Execute execute)
        {
            if (id != execute.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(execute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExecuteExists(execute.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", execute.EmployeeId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", execute.OrderId);
            return View(execute);
        }

        // GET: Executes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var execute = await _context.Executes
                .Include(e => e.Employee)
                .Include(e => e.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (execute == null)
            {
                return NotFound();
            }

            return View(execute);
        }

        // POST: Executes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var execute = await _context.Executes.FindAsync(id);
            _context.Executes.Remove(execute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExecuteExists(string id)
        {
            return _context.Executes.Any(e => e.Id == id);
        }
    }
}
