using CloudinaryDotNet.Actions;

namespace E_Commerce.Interface
{
    public interface IPhotoServices
    {
        Task<ImageUploadResult> AddPhotoAsyn(IFormFile file);
        Task<DeletionResult> DeletePhotoAsyn(string publicId);
    }
}
