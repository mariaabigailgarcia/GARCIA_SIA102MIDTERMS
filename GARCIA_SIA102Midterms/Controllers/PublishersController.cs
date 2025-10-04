using Microsoft.AspNetCore.Mvc;
using GARCIA_SIA102Midterms.DTOs;
using GARCIA_SIA102Midterms.Models;
using GARCIA_SIA102Midterms.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace GARCIA_SIA102Midterms.Controllers
{
    public class PublishersController : Controller
    {
        private readonly IPublisherRepository _repo;

        public PublishersController(IPublisherRepository repo)
        {
            _repo = repo;
        }

        // GET: Publishers
        public async Task<IActionResult> Index()
        {
            var publishers = await _repo.GetAllAsync();

            var dtoList = publishers.Select(p => new PublisherReadDto
            {
                PubId = p.PubId,
                PubName = p.PubName,
                City = p.City,
                State = p.State,
                Country = p.Country,
                PrInfo = p.PubInfo?.PrInfo,
                EmployeeCount = p.Employees.Count,
                TitleCount = p.Titles.Count
            }).ToList();

            return View(dtoList);
        }

        // GET: Publishers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publishers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PublisherCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                var publisher = new Publisher
                {
                    PubId = Guid.NewGuid().ToString(),
                    PubName = dto.PubName,
                    City = dto.City,
                    State = dto.State,
                    Country = dto.Country,
                    PubInfo = new PubInfo { PrInfo = dto.PrInfo }
                };

                await _repo.AddAsync(publisher);
                TempData["SuccessMessage"] = "Publisher created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        // GET: Publishers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();

            var publisher = await _repo.GetByIdAsync(id);
            if (publisher == null) return NotFound();

            var dto = new PublisherUpdateDto
            {
                PubId = publisher.PubId,
                PubName = publisher.PubName,
                City = publisher.City,
                State = publisher.State,
                Country = publisher.Country,
                PrInfo = publisher.PubInfo?.PrInfo
            };

            return View(dto);
        }

        // POST: Publishers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, PublisherUpdateDto dto)
        {
            if (id != dto.PubId) return NotFound();

            if (ModelState.IsValid)
            {
                var publisher = await _repo.GetByIdAsync(id);
                if (publisher == null) return NotFound();

                publisher.PubName = dto.PubName;
                publisher.City = dto.City;
                publisher.State = dto.State;
                publisher.Country = dto.Country;

                if (publisher.PubInfo == null) publisher.PubInfo = new PubInfo();
                publisher.PubInfo.PrInfo = dto.PrInfo;

                await _repo.UpdateAsync(publisher);

                TempData["SuccessMessage"] = "Publisher updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        // GET: Publishers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();

            var publisher = await _repo.GetByIdAsync(id);
            if (publisher == null) return NotFound();

            var dto = new PublisherReadDto
            {
                PubId = publisher.PubId,
                PubName = publisher.PubName,
                City = publisher.City,
                State = publisher.State,
                Country = publisher.Country,
                PrInfo = publisher.PubInfo?.PrInfo
            };

            return View(dto);
        }

        // POST: Publishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string PubId)
        {
            await _repo.DeleteAsync(PubId);
            TempData["SuccessMessage"] = "Publisher deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
