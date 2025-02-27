using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record SubCategoryDto
    {
        public CategoryDto CategoryDto { get; init; }
        public string Name { get; init; }
    }
}
