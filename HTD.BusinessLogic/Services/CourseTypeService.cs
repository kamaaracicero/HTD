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
    internal class CourseTypeService : Service, IService<CourseType>
    {
        public const string NotFoundExceptionMessage = "CourseType not found!";

        public CourseTypeService(string connectionString)
            : base(connectionString)
        {
        }

        public async Task<ServiceResult> Delete(CourseType entity)
        {
            ServiceResult result = new ServiceResult();
            using (MainDbContext dbContext = new MainDbContext(ConnectionString))
            {
                try
                {
                    var tempEntity = dbContext.CourseTypes.First(e => e.Id == entity.Id);
                    dbContext.CourseTypes.Remove(tempEntity);

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

        public async Task<ServiceResult<int>> Insert(CourseType entity)
        {
            ServiceResult<int> result = new ServiceResult<int>();
            using (MainDbContext dbContext = new MainDbContext(ConnectionString))
            {
                try
                {
                    dbContext.CourseTypes.Add(entity);

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

        public async Task<ServiceResult<IList<CourseType>>> Select()
        {
            ServiceResult<IList<CourseType>> result = new ServiceResult<IList<CourseType>>();
            using (MainDbContext dbContext = new MainDbContext(ConnectionString))
            {
                try
                {
                    result.Value = await dbContext.CourseTypes.Select(a => a).ToListAsync();
                    result.Successfully = true;
                }
                catch (Exception ex)
                {
                    AppendErrorToResult(result, this, ex.Message);
                }

                return result;
            }
        }

        public async Task<ServiceResult> Update(CourseType entity)
        {
            ServiceResult result = new ServiceResult();
            using (MainDbContext dbContext = new MainDbContext(ConnectionString))
            {
                try
                {
                    var update = await dbContext.CourseTypes.FirstOrDefaultAsync(a => a.Id == entity.Id);
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
