using System.Linq.Expressions;
using Para.Base.Entity;
using Para.Data.Domain;
using Para.Data.GenericRepository;

namespace Para.Data.UnitOfWork;

public interface IUnitOfWork
{
    Task Complete();
    
    IGenericRepository<Customer> CustomerRepository { get; }
    IGenericRepository<CustomerDetail> CustomerDetailRepository { get; }
    IGenericRepository<CustomerAddress> CustomerAddressRepository { get; }
    IGenericRepository<CustomerPhone> CustomerPhoneRepository { get; }

    public  Task<List<TEntity>> Include<TEntity>(params Expression<Func<TEntity, object>>[] includes)
        where TEntity : BaseEntity;

    public Task<List<TEntity>> Where<TEntity>(Expression<Func<TEntity, bool>> predicate) 
        where TEntity : BaseEntity;
}