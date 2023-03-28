using HTD.BusinessLogic.Models;

namespace HTD.BusinessLogic.ModelConverters
{
    public interface IModelConverter<TFrom, TTo>
        where TFrom : class, IModel
    {
        ModelConvertResult<TTo> ConvertModel(TFrom model);
    }
}
