using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestFeatures
{
    public class CityRequestParameters: RequestParameters
    {
        public CityRequestParameters() => OrderBy = "Name";

    }
}
