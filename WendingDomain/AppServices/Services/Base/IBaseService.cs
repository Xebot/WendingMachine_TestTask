using System.Linq;
using WebApi.Contracts.DTO.Base;

namespace AppServices.Services.Base
{
    public interface IBaseService<T> where T : EntityWithTypeIdBaseDto<T>
    {
        IQueryable<T> GetAll();
        T Get();
    }
}
