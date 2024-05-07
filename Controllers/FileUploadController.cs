using BisleriumBloggers.DTOs.Base;
using BisleriumBloggers.DTOs.Upload;
using BisleriumBloggers.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Net;

namespace BisleriumBloggers.Controllers;
[Authorize]
[ApiController]
[Route("api/file-upload")]
public class FileUploadController : Controller
{
    private readonly IFileUploadService _fileUploadService;

    public FileUploadController(IFileUploadService fileUploadService)
    {
        _fileUploadService = fileUploadService;
    }

    [HttpPost]
    public IActionResult UploadFile([FromForm] UploadDto uploads)
    {
        if (!int.TryParse(uploads.FilePath, out int filePathIndex))
        {
            return BadRequest(new ResponseDto<object>()
            {
                Message = "Invalid File Path.",
                StatusCode = HttpStatusCode.BadRequest,
                TotalCount = 0,
                Status = "Bad Request",
                Result = false
            });
        }

        var filePaths = filePathIndex switch
        {
            1 => Constants.FilePath.UsersImagesFilePath,
            2 => Constants.FilePath.BlogsImagesFilePath,
            _ => ""
        };

        if (string.IsNullOrEmpty(filePaths))
        {
            return BadRequest(new ResponseDto<object>()
            {
                Message = "Invalid File Path.",
                StatusCode = HttpStatusCode.BadRequest,
                TotalCount = 0,
                Status = "Bad Request",
                Result = false
            });
        }

        const long maxSize = 3 * 1024 * 1024;

        if (uploads.Files.Any(upload => upload.Length > maxSize))
        {
            return BadRequest(new ResponseDto<object>()
            {
                Message = "Invalid File Size.",
                StatusCode = HttpStatusCode.BadRequest,
                TotalCount = 0,
                Status = "Bad Request",
                Result = false
            });
        }

        var fileNames = uploads.Files.Select(file => _fileUploadService.UploadDocument(filePaths, file)).ToList();

        var response = new ResponseDto<List<string>>()
        {
            Message = "File successfully uploaded.",
            Result = fileNames,
            StatusCode = HttpStatusCode.OK,
            Status = "Success",
            TotalCount = fileNames.Count
        };

        return Ok(response);
    }
}
