using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using E_Commerce.Helper;
using E_Commerce.Interface;
using Microsoft.Extensions.Options;

namespace E_Commerce.Services
{
    public class PhotoService : IPhotoServices
    {
        private readonly Cloudinary _cloudinary;
        public PhotoService(IOptions<CloudinarySettings> options)
        {
            var acc = new Account(options.Value.CloudName, options.Value.ApiKey, options.Value.ApiSecret);
            _cloudinary = new Cloudinary(acc);
        }

        public async Task<ImageUploadResult> AddPhotoAsyn(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);

            }
            return uploadResult;
        }

      

        public async Task<DeletionResult> DeletePhotoAsyn(string publicId)
        {

            var deleteParams = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deleteParams);
            return result;
        }

        
        
    }
}
