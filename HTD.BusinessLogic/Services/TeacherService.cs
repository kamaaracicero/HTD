using HTD.BusinessLogic.ServiceResults;
using HTD.DataAccess.DbContexts;
using HTD.DataEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HTD.BusinessLogic.Services
{
    internal class TeacherService : Service, IService<Teacher>
    {
        public const string NotFoundExceptionMessage = "Teacher not found!";

        public TeacherService(string connectionString)
            : base(connectionString)
        {
        }

        public async Task<ServiceResult> Delete(Teacher entity)
        {
            ServiceResult result = new ServiceResult();
            using (MainDbContext dbContext = new MainDbContext(ConnectionString))
            {
                try
                {
                    dbContext.Teachers.Remove(entity);

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

        public async Task<ServiceResult<int>> Insert(Teacher entity)
        {
            ServiceResult<int> result = new ServiceResult<int>();
            using (MainDbContext dbContext = new MainDbContext(ConnectionString))
            {
                try
                {
                    dbContext.Teachers.Add(entity);

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

        public async Task<ServiceResult<IList<Teacher>>> Select()
        {
            ServiceResult<IList<Teacher>> result = new ServiceResult<IList<Teacher>>();
            using (MainDbContext dbContext = new MainDbContext(ConnectionString))
            {
                try
                {
                    result.Value = await dbContext.Teachers.Select(a => a).ToListAsync();
                    result.Successfully = true;
                }
                catch (Exception ex)
                {
                    AppendErrorToResult(result, this, ex.Message);
                }

                return result;
            }
        }

        public async Task<ServiceResult> Update(Teacher entity)
        {
            ServiceResult result = new ServiceResult();
            using (MainDbContext dbContext = new MainDbContext(ConnectionString))
            {
                try
                {
                    var update = await dbContext.Teachers.FirstOrDefaultAsync(a => a.Id == entity.Id);
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
