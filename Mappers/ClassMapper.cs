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
    }
}
