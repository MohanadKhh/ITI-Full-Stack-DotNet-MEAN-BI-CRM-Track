using ECommerce.Common;
using FluentValidation;

namespace ECommerce.BLL
{
    public class ImageManager : IImageManager
    {
        private readonly IValidator<ImageUploadDto> _uploadImageValidator;

        public ImageManager(IValidator<ImageUploadDto> uploadImageValidator)
        {
            _uploadImageValidator = uploadImageValidator;
        }

        public async Task<GeneralResult<ImageUploadResultDto>> UploadAsync(
            ImageUploadDto imageUploadDto,
            string? basePath,
            string? schema,
            string? host
            )
        {
            if (string.IsNullOrWhiteSpace(schema) || string.IsNullOrWhiteSpace(host))
            {
                return GeneralResult<ImageUploadResultDto>.FailedResult("schema or host is missing");
            }

            var validationResult = await _uploadImageValidator.ValidateAsync(imageUploadDto);
            if (!validationResult.IsValid)
            {
                Dictionary<string, List<Error>> errors = validationResult.ToError();
                return GeneralResult<ImageUploadResultDto>.FailedResult(errors);
            }

            //defint image file name with same extension
            var cleanName = Path.GetFileNameWithoutExtension(imageUploadDto.ImageFile.FileName).Replace(" ", "-").ToLower();
            var ext = Path.GetExtension(imageUploadDto.ImageFile.FileName).ToLower();
            var uniqueFileName = $"{cleanName}-{Guid.NewGuid().ToString()}{ext}";

            //define folder path
            string folderPath = Path.Combine(basePath, "Files", "Images");

            //creating folder if not exist
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            //adding image in folder
            using (var stream = new FileStream(Path.Combine(folderPath, uniqueFileName), FileMode.Create))
            {
                await imageUploadDto.ImageFile.CopyToAsync(stream);
            }

            var url = $"{schema}://{host}/Files/Images/{uniqueFileName}";
            var imageUploadResultDto = new ImageUploadResultDto(url);

            return GeneralResult<ImageUploadResultDto>.SuccessedResult(imageUploadResultDto);
        }
    }
}
