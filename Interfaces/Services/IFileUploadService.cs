namespace BisleriumBloggers.Interfaces.Services;

public interface IFileUploadService
{
    string UploadDocument(string uploadedFilePath, IFormFile file);
}
