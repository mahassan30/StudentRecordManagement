using DomainModels;

namespace Mappers
{
    public static class ClassMapper
    {
        public static WebModels.Models.Class ConvertToWebModel(this DomainModels.Class source)
        {
            return new WebModels.Models.Class
            {
                ClassId = source.ClassId,
                ClassName = source.ClassName,
                ClassLocation = source.ClassRoom
            };
        }

        public static Class ConvertToDomainModel(this WebModels.Models.Class source)
        {
            return new Class
            {
                ClassId = source.ClassId,
                ClassName = source.ClassName,
                ClassRoom = source.ClassLocation,
            };
        }
    }
}
