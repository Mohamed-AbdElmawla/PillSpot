﻿namespace Entities.Exceptions
{
    public sealed class LocationNotFoundException: NotFoundException
    {
        public LocationNotFoundException(Guid locationID):base($"Location with id: {locationID} was not found"){}
    }
}
