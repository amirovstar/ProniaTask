﻿using System;
using P137PRONIA2.Extensions;
using P137PRONIA2.ExtensionServices.Interfaces;

namespace P137PRONIA2.ExtensionServices.Implements;

public class FileService : IFileService
{
    readonly IWebHostEnvironment _env;

    public FileService(IWebHostEnvironment env)
    {
        _env = env;
    }

    public void Delete(string path)
    {
        if (String.IsNullOrEmpty(path) || String.IsNullOrWhiteSpace(path)) throw new
            ArgumentNullException();
        if (!path.StartsWith(_env.WebRootPath))
        {
            path = Path.Combine(_env.WebRootPath, path);
        }
        if (File.Exists(path))
            File.Delete(path);
    }

    public async Task SaveAsync(IFormFile file, string path)
    {
        using FileStream fs = new FileStream(Path.Combine(_env.WebRootPath, path),
        FileMode.Create);
        await file.CopyToAsync(fs);
    }

    private string _renameFile(IFormFile file)
     => Guid.NewGuid() + Path.GetExtension(file.FileName);

    private void _checkDirectory(string path)
    {
        if (!Directory.Exists(Path.Combine(_env.WebRootPath, path)))
        {
            Directory.CreateDirectory(Path.Combine(_env.WebRootPath, path));
        }
    }

    public async Task<string> UploadAsync(IFormFile file, string path,
        string contentType = "image", int mb = 2)
    {
        if (!file.IsSizeValid(mb)) throw new Exception();
        if (!file.IsTypeValid(contentType)) throw new Exception();
        string newFileName = _renameFile(file);
        _checkDirectory(path);
        await SaveAsync(file, Path.Combine(path, newFileName));
        return newFileName;
    }

}
