using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Shared.DataTransferObjects;

namespace PillSpot.Presentation.ModelBinders
{
    public class CustomModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(PrescriptionForCreationDto))
            {
                return new BinderTypeModelBinder(typeof(PrescriptionForCreationDtoModelBinder));
            }

            return null!;
        }
    }
}
