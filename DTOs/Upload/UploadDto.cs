﻿namespace BisleriumBloggers.DTOs.Upload;

public class UploadDto
{
    public string FilePath { get; set; }

    public List<IFormFile> Files { get; set; }
}
