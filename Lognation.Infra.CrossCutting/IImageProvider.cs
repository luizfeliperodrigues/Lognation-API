using Microsoft.Extensions.FileProviders;

namespace Lognation.Infra.CrossCutting
{
    public interface IImageProvider
    {
        string GetBasePath();

        IFileProvider GetFileProvider();

        string GetContentType(string content);
    }
}
