using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Uploads
{
    public class Index : PageModel
    {
        private readonly IWebHostEnvironment _env;

        public Index(IWebHostEnvironment env)
        {
            _env = env;
        }

        public List<string> FileNames { get; set; } = new List<string>();
        public ActionResult OnGet()
        {

            string webRootPath = _env.WebRootPath +"/uploads";
            if (System.IO.Directory.Exists(webRootPath))
            {
                string[] fileEntries = Directory.GetFiles(webRootPath);
                foreach (var fullPathfileName in fileEntries)
                {
                    var fileName = Path.GetFileName(fullPathfileName);
                    var fileExtension = Path.GetExtension(fullPathfileName);
                    if (fileExtension == ".jpg" || fileExtension == ".png" || fileExtension == ".gif")
                    {
                        FileNames.Add(fileName);
                    }
                    
                }
            }
            else
            {
                FileNames.Add("Directory not Found!");
            }

            return Page();

        }
    }
}