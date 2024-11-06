using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Shared.DataTransferObjects;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PharmacyLocator.OutputFormatter
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
            protected override bool CanWriteType(Type? type)
            {
                if (typeof(PharmacyDto).IsAssignableFrom(type) ||
               typeof(IEnumerable<PharmacyDto>).IsAssignableFrom(type))
                {
                    return base.CanWriteType(type);
                }
                return false;
            }
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();
            if(context.Object is IEnumerable<PharmacyDto>)
            {
                foreach(var pharmacy in (IEnumerable<PharmacyDto>)context.Object)
                {
                    FormatCsv(buffer, pharmacy);
                }
            }
            else
            {
                FormatCsv(buffer, (PharmacyDto)context.Object);
            }
            await response.WriteAsync(buffer.ToString());
        }
        private static void FormatCsv(StringBuilder buffer, PharmacyDto pharmacy)
        {
            buffer.AppendLine($"{pharmacy.PharmacyId},\"{pharmacy.Name}");
        }
    }
}
