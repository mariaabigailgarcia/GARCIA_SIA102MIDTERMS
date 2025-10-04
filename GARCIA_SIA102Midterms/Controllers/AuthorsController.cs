using Microsoft.AspNetCore.Mvc;
using GARCIA_SIA102Midterms.Data;
using GARCIA_SIA102Midterms.DTOs;
using GARCIA_SIA102Midterms.Models;
using GARCIA_SIA102Midterms.Repositories;
using System.Linq;

namespace GARCIA_SIA102Midterms.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorRepository _repo;

        public AuthorsController(IAuthorRepository repo)
        {
            _repo = repo;
        }
        private string GenerateAuthorId()
        {
            // Format like "123-45-6789" (11 chars total, matches pubs)
            var rnd = new Random();
            return $"{rnd.Next(100, 999)}-{rnd.Next(10, 99)}-{rnd.Next(1000, 9999)}";
        }

        // GET: Authors
        public async Task<IActionResult> Index()
        {
            var authors = await _repo.GetAllAsync();

            var dtoList = authors.Select(a => new AuthorReadDto
            {
                AuId = a.AuId,
                AuFname = a.AuFname,
                AuLname = a.AuLname,
                Phone = a.Phone,
                Address = a.Address,
                City = a.City,
                State = a.State,
                Zip = a.Zip,
                Contract = a.Contract
            }).ToList();

            return View(dtoList);
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AuthorCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                var author = new Author
                {
                    AuId = GenerateAuthorId(), // pubs PK is varchar
                    AuFname = string.IsNullOrWhiteSpace(dto.AuFname) ? "Unknown" : dto.AuFname,
                    AuLname = string.IsNullOrWhiteSpace(dto.AuLname) ? "Unknown" : dto.AuLname,
                    Phone = string.IsNullOrWhiteSpace(dto.Phone) ? "(000) 000-0000" : dto.Phone,
                    Address = string.IsNullOrWhiteSpace(dto.Address) ? "N/A" : dto.Address,
                    City = string.IsNullOrWhiteSpace(dto.City) ? "N/A" : dto.City,
                    State = string.IsNullOrWhiteSpace(dto.State) ? "NA" : dto.State,
                    Zip = string.IsNullOrWhiteSpace(dto.Zip) ? "00000" : dto.Zip,
                    Contract = dto.Contract // bool already defaults to false
                };

                await _repo.AddAsync(author);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();

            var author = await _repo.GetByIdAsync(id);
            if (author == null) return NotFound();

            var dto = new AuthorUpdateDto
            {
                AuId = author.AuId,
                AuFname = author.AuFname,
                AuLname = author.AuLname,
                Phone = author.Phone,
                Address = author.Address, 
                City = author.City,
                State = author.State,
                Zip = author.Zip,
                Contract = author.Contract

            };

            return View(dto);
        }

        // POST: Authors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, AuthorUpdateDto dto)
        {
            if (id != dto.AuId) return NotFound();

            if (ModelState.IsValid)
            {
                var author = new Author
                {
                    AuId = dto.AuId,
                    AuFname = string.IsNullOrWhiteSpace(dto.AuFname) ? "Unknown" : dto.AuFname,
                    AuLname = string.IsNullOrWhiteSpace(dto.AuLname) ? "Unknown" : dto.AuLname,
                    Phone = string.IsNullOrWhiteSpace(dto.Phone) ? "(000) 000-0000" : dto.Phone,
                    Address = string.IsNullOrWhiteSpace(dto.Address) ? "N/A" : dto.Address,
                    City = string.IsNullOrWhiteSpace(dto.City) ? "N/A" : dto.City,
                    State = string.IsNullOrWhiteSpace(dto.State) ? "NA" : dto.State,
                    Zip = string.IsNullOrWhiteSpace(dto.Zip) ? "00000" : dto.Zip,
                    Contract = dto.Contract
                };

                await _repo.UpdateAsync(author);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        // GET: Authors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();

            var author = await _repo.GetByIdAsync(id);
            if (author == null) return NotFound();

            // Pass DTO to view
            var dto = new AuthorReadDto
            {
                AuId = author.AuId,
                AuFname = author.AuFname,
                AuLname = author.AuLname,
                City = author.City,
                State = author.State
            };

            return View(dto);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string AuId)
        {
            await _repo.DeleteAsync(AuId);

            // Store success message
            TempData["SuccessMessage"] = "Author deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
