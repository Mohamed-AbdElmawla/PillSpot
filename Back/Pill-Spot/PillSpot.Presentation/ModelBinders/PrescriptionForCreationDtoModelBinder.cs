using Microsoft.AspNetCore.Mvc.ModelBinding;
using Shared.DataTransferObjects;
using System;

namespace PillSpot.Presentation.ModelBinders
{
    public class PrescriptionForCreationDtoModelBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            var httpRequest = bindingContext.HttpContext.Request;
            var form = await httpRequest.ReadFormAsync();

            var dto = new PrescriptionForCreationDto
            {
                UserId = form["UserId"]
            };

            if (DateTime.TryParse(form["IssueDate"], out var issueDate))
                dto.IssueDate = issueDate;
            if (DateTime.TryParse(form["ExpiryDate"], out var expiryDate))
                dto.ExpiryDate = expiryDate;

            dto.ImageFile = form.Files["ImageFile"];

            var products = new List<PrescriptionProductForCreationDto>();
            var productIndex = 0;
            while (true)
            {
                var productIdKey = $"PrescriptionProducts[{productIndex}].productId";
                var quantityKey = $"PrescriptionProducts[{productIndex}].quantity";
                var dosageKey = $"PrescriptionProducts[{productIndex}].dosage";
                var instructionsKey = $"PrescriptionProducts[{productIndex}].instructions";

                if (string.IsNullOrEmpty(form[productIdKey]))
                    break;

                if (Guid.TryParse(form[productIdKey], out var productId))
                {
                    var product = new PrescriptionProductForCreationDto
                    {
                        ProductId = productId,
                        Quantity = int.TryParse(form[quantityKey], out var quantity) ? quantity : 0,
                        Dosage = form[dosageKey],
                        Instructions = form[instructionsKey]
                    };
                    products.Add(product);
                }
                productIndex++;
            }
            dto.PrescriptionProducts = products.Any() ? products : new List<PrescriptionProductForCreationDto>();

            if (string.IsNullOrEmpty(dto.UserId) || dto.IssueDate == default || dto.ExpiryDate == default || dto.PrescriptionProducts == null)
            {
                bindingContext.ModelState.AddModelError("", "All required fields must be provided.");
                bindingContext.Result = ModelBindingResult.Failed();
                return;
            }

            bindingContext.Result = ModelBindingResult.Success(dto);
        }
    }
}