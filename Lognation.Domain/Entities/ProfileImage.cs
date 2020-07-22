namespace Lognation.Domain.Entities
{
    public class ProfileImage : Image
    {
        public User User { get; set; }

        public static ProfileImage ToProfileImage(Image image)
        {
            return new ProfileImage()
            {
                ContentType = image.ContentType,
                ImageId = image.ImageId,
                Name = image.Name,
                Url = image.Url
            };
        }
    }
}
