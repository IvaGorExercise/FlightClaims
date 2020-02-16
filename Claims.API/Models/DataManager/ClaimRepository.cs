using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Claims.API.Data;

namespace Claims.API.Models
{
    public class ClaimRepository: IDataRepository<Claim>
    {
        readonly ClaimContext _claimContext;

        public ClaimRepository(ClaimContext context)
        {
            _claimContext = context;
        }

        public IEnumerable<Claim> GetAll()
        {
            return _claimContext.Claim.ToList();
        }

        public Claim Get(long id)
        {
            return _claimContext.Claim.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Claim entity)
        {
             _claimContext.Claim.Add(entity);
             _claimContext.SaveChanges();
        }

        public void Update(Claim employee, Claim entity)
        {
            employee.FirstName = entity.FirstName;
            employee.LastName = entity.LastName;
            employee.Email = entity.Email;
            _claimContext.SaveChanges();
        }

        public void Delete(Claim employee)
        {
            _claimContext.Claim.Remove(employee);
            _claimContext.SaveChanges();
        }
    }
}
