using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileCopyController : ControllerBase
    {
        private readonly string _sourceDirectory = @"\\dev-apps-new\Files";
        private readonly string _destinationDirectory = @"C:\Users\jrrodriguez\Downloads\CEPA";

        [HttpPost("CopyFile")]
        public IActionResult CopyFile([FromQuery] string fileName, string foldername)
        {
            string _sourceDirectory = @"\\dev-apps-new\Files";
            try
            {
                // Use Path.Combine to construct full file paths
                string sourceFilePath = Path.Combine(_sourceDirectory, fileName + ".pdf");
                string destinationFilePath = Path.Combine(_destinationDirectory, fileName + "_" + DateTime.Now.ToString("YYYYmmdd") + ".pdf");

                // Check if the file exists
                if (!System.IO.File.Exists(sourceFilePath))
                {
                    return NotFound("File not found.");
                }

                // Copy the file
                System.IO.File.Copy(sourceFilePath, destinationFilePath, true);

                return Ok("File copied successfully.");
            }
            catch (Exception ex)
            {
                // Handle errors
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}