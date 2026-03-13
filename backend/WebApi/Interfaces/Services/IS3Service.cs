namespace WebApi.Interfaces.Services;

public interface IS3Service
{
    Task<Stream> GetFileStreamAsync(string objectName);
    Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType);
    Task DeleteFileAsync(string objectName);

}