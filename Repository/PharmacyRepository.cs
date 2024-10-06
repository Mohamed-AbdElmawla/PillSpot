using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
namespace Repository
{
    public class PharmacyRepository : RepositoryBase<Pharmacy>, IPharmacyRepository
    {
        public PharmacyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }
        public IEnumerable<Pharmacy> GetAllPharmacies(bool trackChanges)=>FindAll(trackChanges).OrderBy(ph=>ph.Name).ToList();

        public Pharmacy GetPharmacy(int pharmacyId, bool trackChanges) => FindByCondition(ph => ph.Id.Equals(pharmacyId), trackChanges).SingleOrDefault();
    }
}
