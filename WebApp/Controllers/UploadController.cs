using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    public class UploadController : Controller
    {
        private readonly IHostingEnvironment _environment;

        public UploadController(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        

        [HttpPost]
        [Route("api/upload")]
        public async Task<IActionResult> ImageUpload(IFormFile file)
        {
            // 파일 업로드 할 떄 필요한 것
            // 1. path
            var path = Path.Combine(_environment.WebRootPath, @"images\upload");
            // 2. name
            // 3. extension - jpg, txt 
            var fileFullName = file.FileName.Split('.');
            var fileName = $"{Guid.NewGuid()}.{fileFullName[1]}";
            using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return Ok(new { file = "/images/upload/" + fileName, success = true });

        }
    }
}
