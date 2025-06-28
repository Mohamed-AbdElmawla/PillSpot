using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Utility
{
    public static class DistanceUtility
    {
        private const double EarthRadius = 6371; 

        public static double CalculateDistance(double latitude1, double longitude1, double latitude2, double longitude2)
        {
            // Convert degrees to radians
            var latDistance = ToRadians(latitude2 - latitude1);
            var lonDistance = ToRadians(longitude2 - longitude1);

            // Apply Haversine formula
            var a = Math.Sin(latDistance / 2) * Math.Sin(latDistance / 2) +
                    Math.Cos(ToRadians(latitude1)) * Math.Cos(ToRadians(latitude2)) *
                    Math.Sin(lonDistance / 2) * Math.Sin(lonDistance / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            // Return the distance in kilometers
            return EarthRadius * c;
        }

        private static double ToRadians(double angle) => angle * (Math.PI / 180);
    }
}
