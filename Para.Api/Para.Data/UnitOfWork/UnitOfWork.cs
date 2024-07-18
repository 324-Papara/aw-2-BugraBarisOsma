using System.Linq.Expressions;
using Para.Base.Entity;
using Para.Data.Context;
using Para.Data.Domain;
using Para.Data.GenericRepository;

namespace Para.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ParaSqlDbContext dbContext;
    
    public IGenericRepository<Customer> CustomerRepository { get; }
    public IGenericRepository<CustomerDetail> CustomerDetailRepository { get; }
    public IGenericRepository<CustomerAddress> CustomerAddressRepository { get; }
    public IGenericRepository<CustomerPhone> CustomerPhoneRepository { get; }
    
    

    public UnitOfWork(ParaSqlDbContext dbContext)
    {
        this.dbContext = dbContext;

        CustomerRepository = new GenericRepository<Customer>(this.dbContext);
        CustomerDetailRepository = new GenericRepository<CustomerDetail>(this.dbContext);
        CustomerAddressRepository = new GenericRepository<CustomerAddress>(this.dbContext);
        CustomerPhoneRepository = new GenericRepository<CustomerPhone>(this.dbContext);
    }

    public void Dispose()
    {
        dbContext.Dispose();
    }

    public async Task Complete()
    {
        using (var dbTransaction = await dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                await dbContext.SaveChangesAsync();
                await dbTransaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await dbTransaction.RollbackAsync();
                Console.WriteLine(ex);
                throw; 
            }
        }
    }
    
    // Burada include ve where methodlari bir veya birden cok parametre alacak sekilde , herhangi bir TEntitiy alacak ve birer object donecek sekilde 
    // yazilmistir. 
    public async Task<List<TEntity>> Include<TEntity>(params Expression<Func<TEntity, object>>[] includes) where TEntity : BaseEntity
    {
        return await new GenericRepository<TEntity>(dbContext).Include(includes);
    }

    public async Task<List<TEntity>> Where<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity
    {
        return await new GenericRepository<TEntity>(dbContext).Where(predicate);
    }
}
     
    
    
    
