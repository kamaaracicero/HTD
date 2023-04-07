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
    internal class CourseService : Service, IService<Course>
    {
        public const string NotFoundExceptionMessage = "Course not found!";

        public CourseService(string connectionString)
            : base(connectionString)
        {
        }

        public async Task<ServiceResult> Delete(Course entity)
        {
            ServiceResult result = new ServiceResult();
            using (MainDbContext dbContext = new MainDbContext(ConnectionString))
            {
                try
                {
                    var tempEntity = dbContext.Courses.First(e => e.Id == entity.Id);
                    dbContext.Courses.Remove(tempEntity);

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

        public async Task<ServiceResult<int>> Insert(Course entity)
        {
            ServiceResult<int> result = new ServiceResult<int>();
            using (MainDbContext dbContext = new MainDbContext(ConnectionString))
            {
                try
                {
                    dbContext.Courses.Add(entity);

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

        public async Task<ServiceResult<IList<Course>>> Select()
        {
            ServiceResult<IList<Course>> result = new ServiceResult<IList<Course>>();
            using (MainDbContext dbContext = new MainDbContext(ConnectionString))
            {
                try
                {
                    result.Value = await dbContext.Courses.Select(a => a).ToListAsync();
                    result.Successfully = true;
                }
                catch (Exception ex)
                {
                    AppendErrorToResult(result, this, ex.Message);
                }

                return result;
            }
        }

        public async Task<ServiceResult> Update(Course entity)
        {
            ServiceResult result = new ServiceResult();
            using (MainDbContext dbContext = new MainDbContext(ConnectionString))
            {
                try
                {
                    var update = await dbContext.Courses.FirstOrDefaultAsync(a => a.Id == entity.Id);
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
