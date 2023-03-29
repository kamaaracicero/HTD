using HTD.BusinessLogic.Models;

namespace HTD.BusinessLogic.ModelConverters
{
    public interface IModelConverter<TFrom, TTo>
        where TFrom : IModel
        where TTo : class, new()
    {
        ModelConvertResult<TTo> ConvertModel(TFrom model);
    }
}
