using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPrescriptionProductRepository
    {
        Task<IEnumerable<PrescriptionProduct>> GetPrescriptionProductsByPrescriptionIdAsync(Guid prescriptionId, bool trackChanges);
        Task<PrescriptionProduct> GetPrescriptionProductByIdAsync(Guid prescriptionId, Guid productId, bool trackChanges);
        void AddPrescriptionProductsRange(IEnumerable<PrescriptionProduct> prescriptionProducts);
        void CreatePrescriptionProduct(PrescriptionProduct prescriptionProduct);
        void UpdatePrescriptionProduct(PrescriptionProduct prescriptionProduct);
        void DeletePrescriptionProduct(PrescriptionProduct prescriptionProduct);
        void DeletePrescriptionProductsRange(IEnumerable<PrescriptionProduct> prescriptionProducts);
    }
}