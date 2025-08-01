﻿using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IMedicineService
    {
        Task<(IEnumerable<MedicineDto> medicines, MetaData metaData)> GetAllMedicinesAsync(MedicinesRequestParameters medicinesRequestParameters, bool trackChanges);
        Task<MedicineDto> GetMedicineAsync(Guid productId, bool trackChanges);
        Task<MedicineDto> CreateMedicineAsync(MedicineForCreationDto medicineForCreationDto, bool trackChanges);
        Task DeleteMedicineAsync(Guid productId, bool trackChanges);
        Task UpdateMedicineAsync(Guid productId, MedicineForUpdateDto medicineForUpdateDto, bool trackChanges);
    }
}
