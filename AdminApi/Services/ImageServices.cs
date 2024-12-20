using SixLabors.ImageSharp;
using Microsoft.EntityFrameworkCore;
using AdminApi.Interfaces;

namespace AdminApi.Services
{
    public class ImageServices : IImageServices
    {
        public string CreatePathForBase64Img(string pathFor, string imagebase64)
        {
            byte[] imageBytes = Convert.FromBase64String(imagebase64);
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + ".jpg";
            var filePath = Path.Combine($"wwwroot/images/{pathFor}", uniqueFileName);
            using (var img = Image.Load(imageBytes))
            {
                img.Save(filePath);
            }
            return filePath;
        }

        public async Task<string> CreatePathForImg(string pathFor, IFormFile image)
        {
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
            string filePath = Path.Combine($"wwwroot/images/{pathFor}", uniqueFileName);
            using (var images = Image.Load(image.OpenReadStream()))
            {
                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
                }
                await images.SaveAsJpegAsync(filePath);
            }
            return filePath;
        }

        public bool ProcessImageExtension(IFormFile image)
        {
            var fileExtension = Path.GetExtension(image.FileName).ToLower();
            if (!new[] { ".jpg", ".jpeg", ".png" }.Contains(fileExtension.ToLower())) return false;
            return true;
        }
    }
}