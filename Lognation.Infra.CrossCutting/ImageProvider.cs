using Microsoft.Extensions.FileProviders;
using System.Collections.Generic;
using System.IO;

namespace Lognation.Infra.CrossCutting
{
    public class ImageProvider : IImageProvider
    {
        private PhysicalFileProvider _fileProvider;

        public ImageProvider()
        {
            this._fileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"/projects/personal/Lognation/Images"));
        }

        public string GetBasePath() => this._fileProvider.Root;

        public IFileProvider GetFileProvider() => this._fileProvider;

        public string GetContentType(string content)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(content).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}
