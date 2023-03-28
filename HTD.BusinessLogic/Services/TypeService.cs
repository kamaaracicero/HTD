using HTD.BusinessLogic.ServiceResults;
using HTD.DataAccess.DbContexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


namespace HTD.BusinessLogic.Services
{
    internal class TypeService : Service, IService<DataEntities.Type>
    {
        public const string NotFoundExceptionMessage = "Type not found!";

        public TypeService(string connectionString)
            : base(connectionString)
        {
        }

        public async Task<ServiceResult> Delete(DataEntities.Type entity)
        {
            ServiceResult result = new ServiceResult();
            using (MainDbContext dbContext = new MainDbContext(ConnectionString))
            {
                try
                {
                    dbContext.Types.Remove(entity);

                    await dbContext.SaveChangesAsync();
                    result.Successfully = true;
                }
                catch (Exception ex)
                {
                    AppendErrorToResult(result, this, ex.Message);
                }

                return result;
            }
        }

        public async Task<ServiceResult<int>> Insert(DataEntities.Type entity)
        {
            ServiceResult<int> result = new ServiceResult<int>();
            using (MainDbContext dbContext = new MainDbContext(ConnectionString))
            {
                try
                {
                    dbContext.Types.Add(entity);

                    await dbContext.SaveChangesAsync();
                    result.Value = entity.Id;
                    result.Successfully = true;
                }
                catch (Exception ex)
                {
                    AppendErrorToResult(result, this, ex.Message);
                }

                return result;
            }
        }

        public async Task<ServiceResult<IList<DataEntities.Type>>> Select()
        {
            ServiceResult<IList<DataEntities.Type>> result = new ServiceResult<IList<DataEntities.Type>>();
            using (MainDbContext dbContext = new MainDbContext(ConnectionString))
            {
                try
                {
                    result.Value = await dbContext.Types.Select(a => a).ToListAsync();
                    result.Successfully = true;
                }
                catch (Exception ex)
                {
                    AppendErrorToResult(result, this, ex.Message);
                }

                return result;
            }
        }

        public async Task<ServiceResult> Update(DataEntities.Type entity)
        {
            ServiceResult result = new ServiceResult();
            using (MainDbContext dbContext = new MainDbContext(ConnectionString))
            {
                try
                {
                    var update = await dbContext.Types.FirstOrDefaultAsync(a => a.Id == entity.Id);
                    if (update != null)
                    {
                        update.Update(entity);
                        await dbContext.SaveChangesAsync();
                        result.Successfully = true;
                    }
                    else
                    {
                        AppendErrorToResult(result, this, NotFoundExceptionMessage);
                    }
                }
                catch (Exception ex)
                {
                    AppendErrorToResult(result, this, ex.Message);
                }

                return result;
            }
        }
    }
}
