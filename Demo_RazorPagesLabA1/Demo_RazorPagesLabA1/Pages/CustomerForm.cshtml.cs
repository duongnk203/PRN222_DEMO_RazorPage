using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLabA1.Models;

namespace Demo_RazorPagesLabA1.Pages
{
    public class CustomerFormModel : PageModel
    {
        public string Message { set; get; }

        [BindProperty]
        public Customer customerInfo { set; get; }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = "Information is OK";
                ModelState.Clear();
            }
            else
            {
                Message = "Error on input data.";
            }
        }
    }
}