using HTD.BusinessLogic.ServiceResults;
using HTD.DataEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HTD.BusinessLogic.Services
{
    public interface IService<TEntity>
        where TEntity : class, IDataEntity
    {
        Task<ServiceResult<IList<TEntity>>> Select();

        Task<ServiceResult<int>> Insert(TEntity entity);

        Task<ServiceResult> Update(TEntity entity);

        Task<ServiceResult> Delete(TEntity entity);
    }
}
