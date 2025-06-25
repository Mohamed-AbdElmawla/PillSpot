using Microsoft.AspNetCore.RateLimiting;

namespace PillSpot.Presentation.ActionFilters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class RateLimitAttribute : Attribute
    {
        public string Policy { get; }

        public RateLimitAttribute(string policy)
        {
            Policy = policy;
        }
    }
} 