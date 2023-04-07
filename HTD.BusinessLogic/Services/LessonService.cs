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
    internal class LessonService : Service, IService<Lesson>
    {
        public const string NotFoundExceptionMessage = "Lesson not found!";

        public LessonService(string connectionString)
            : base(connectionString)
        {
        }

        public async Task<ServiceResult> Delete(Lesson entity)
        {
            ServiceResult result = new ServiceResult();
            using (MainDbContext dbContext = new MainDbContext(ConnectionString))
            {
                try
                {
                    var tempEntity = dbContext.Lessons.First(e => e.Id == entity.Id);
                    dbContext.Lessons.Remove(tempEntity);

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

        public async Task<ServiceResult<int>> Insert(Lesson entity)
        {
            ServiceResult<int> result = new ServiceResult<int>();
            using (MainDbContext dbContext = new MainDbContext(ConnectionString))
            {
                try
                {
                    dbContext.Lessons.Add(entity);

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

        public async Task<ServiceResult<IList<Lesson>>> Select()
        {
            ServiceResult<IList<Lesson>> result = new ServiceResult<IList<Lesson>>();
            using (MainDbContext dbContext = new MainDbContext(ConnectionString))
            {
                try
                {
                    result.Value = await dbContext.Lessons.Select(a => a).ToListAsync();
                    result.Successfully = true;
                }
                catch (Exception ex)
                {
                    AppendErrorToResult(result, this, ex.Message);
                }

                return result;
            }
        }

        public async Task<ServiceResult> Update(Lesson entity)
        {
            ServiceResult result = new ServiceResult();
            using (MainDbContext dbContext = new MainDbContext(ConnectionString))
            {
                try
                {
                    var update = await dbContext.Lessons.FirstOrDefaultAsync(a => a.Id == entity.Id);
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
