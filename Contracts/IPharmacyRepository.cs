using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Contracts
{
    public interface IPharmacyRepository
    {
        IEnumerable<Pharmacy> GetAllPharmacies(bool trackChanges);
        Pharmacy GetPharmacy(int pharmacyId, bool trackChanges);
    }
}

