using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FileReaderUtility.Models;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using FileReaderUtility;
using Microsoft.AspNetCore.Hosting;

namespace FileReaderUtility.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;

        public HomeController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }


        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");


            if (file.Length > 0)
            {

                //Getting FileName
                var fileName = Path.GetFileName(file.FileName);
                var fileExtension = Path.GetExtension(fileName);

                var filePath = Path.Combine(uploads, file.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                Console.Out.WriteLine("EXTENSION DE FICHIER: "+ fileExtension);
               
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                switch (fileExtension) {
                    case ".txt":
                        ViewBag.Message = ReadFiles.ReadTextFile(filePath);
                        break;
                    case ".xml":
                        ViewBag.Message = ReadFiles.ReadXMLFile(filePath);
                        break;
                    case ".json":
                        ViewBag.Message = ReadFiles.ReadJSONFile(filePath);
                        break;
                    default:
                        ViewBag.Message = "Fichier illisible!";
                        break;
                }


            }
            

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

           //return Ok(new { count = files.Count, size, filePath });

            return View();
        }

    }
}
