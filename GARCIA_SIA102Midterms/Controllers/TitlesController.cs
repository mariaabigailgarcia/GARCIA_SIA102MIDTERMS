using GARCIA_SIA102Midterms.DTOs;
using GARCIA_SIA102Midterms.Models;
using GARCIA_SIA102Midterms.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GARCIA_SIA102Midterms.Controllers
{
    public class TitlesController : Controller
    {
        private readonly ITitleRepository _titleRepo;
        private readonly IPublisherRepository _publisherRepo;

        public TitlesController(ITitleRepository titleRepo, IPublisherRepository publisherRepo)
        {
            _titleRepo = titleRepo;
            _publisherRepo = publisherRepo;
        }

        // GET: Titles
        public async Task<IActionResult> Index()
        {
            var titles = await _titleRepo.GetAllAsync();
            var dtoList = titles.Select(t => new TitleReadDto
            {
                TitleId = t.TitleId,
                Title = t.Title1,
                Type = t.Type,
                Price = t.Price,
                YtdSales = t.YtdSales,
                PublisherName = t.Pub?.PubName
            }).ToList();

            return View(dtoList);
        }

        // GET: Titles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null) return NotFound();

            var title = await _titleRepo.GetByIdAsync(id);
            if (title == null) return NotFound();

            var dto = new TitleReadDto
            {
                TitleId = title.TitleId,
                Title = title.Title1,
                Type = title.Type,
                Price = title.Price,
                Advance = title.Advance,
                Royalty = title.Royalty,
                YtdSales = title.YtdSales,
                Notes = title.Notes,
                Pubdate = title.Pubdate,
                PublisherName = title.Pub?.PubName,
                Authors = title.Titleauthors.Select(ta => $"{ta.Au.AuFname} {ta.Au.AuLname}").ToList()
            };

            return View(dto);
        }

        // GET: Titles/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Publishers = await _publisherRepo.GetAllAsync(); // for dropdown
            return View();
        }

        // POST: Titles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TitleCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                var title = new Title
                {
                    TitleId = Guid.NewGuid().ToString().Substring(0, 6), // pubs uses 6–8 chars
                    Title1 = dto.Title,
                    Type = dto.Type,
                    PubId = dto.PubId,
                    Price = dto.Price,
                    Advance = dto.Advance,
                    Royalty = dto.Royalty,
                    YtdSales = dto.YtdSales,
                    Notes = dto.Notes,
                    Pubdate = dto.Pubdate
                };

                await _titleRepo.AddAsync(title);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Publishers = await _publisherRepo.GetAllAsync();
            return View(dto);
        }

        // GET: Titles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();

            var title = await _titleRepo.GetByIdAsync(id);
            if (title == null) return NotFound();

            var dto = new TitleUpdateDto
            {
                TitleId = title.TitleId,
                Title = title.Title1,
                Type = title.Type,
                PubId = title.PubId,
                Price = title.Price,
                Advance = title.Advance,
                Royalty = title.Royalty,
                YtdSales = title.YtdSales,
                Notes = title.Notes,
                Pubdate = title.Pubdate
            };

            ViewBag.Publishers = await _publisherRepo.GetAllAsync();
            return View(dto);
        }

        // POST: Titles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, TitleUpdateDto dto)
        {
            if (id != dto.TitleId) return NotFound();

            if (ModelState.IsValid)
            {
                var title = new Title
                {
                    TitleId = dto.TitleId,
                    Title1 = dto.Title,
                    Type = dto.Type,
                    PubId = dto.PubId,
                    Price = dto.Price,
                    Advance = dto.Advance,
                    Royalty = dto.Royalty,
                    YtdSales = dto.YtdSales,
                    Notes = dto.Notes,
                    Pubdate = dto.Pubdate
                };

                await _titleRepo.UpdateAsync(title);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Publishers = await _publisherRepo.GetAllAsync();
            return View(dto);
        }

        // GET: Titles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var title = await _titleRepo.GetByIdAsync(id);
            if (title == null) return NotFound();

            var dto = new TitleReadDto
            {
                TitleId = title.TitleId,
                Title = title.Title1,
                Type = title.Type,
                Price = title.Price,
                YtdSales = title.YtdSales,
                PublisherName = title.Pub?.PubName
            };

            return View(dto);
        }

        // POST: Titles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _titleRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
