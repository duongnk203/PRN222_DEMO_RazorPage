using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageLab.Models;

namespace RazorPageLab.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly FapSystemDbContext _context;

        public IndexModel(FapSystemDbContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get; set; } = default!;
        public string CurrentFilter { get; set; } = string.Empty;

        public int PageIndex { get; set; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage { get; set; }

        public async Task OnGetAsync(string? searchString, int pageIndex = 1)
        {
            PageIndex = pageIndex;
            CurrentFilter = searchString ?? string.Empty;

            var students = from s in _context.Students
                           select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.FullName.Contains(searchString));
            }

            int pageSize = 3;
            Student = await students
                .Skip((PageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            int totalStudents = await students.CountAsync();
            HasNextPage = totalStudents > PageIndex * pageSize;
        }
    }
}
