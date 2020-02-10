
namespace WebApi.Contracts.DTO.Base
{
    public abstract class EntityWithTypeIdBaseDto<TId>
    {
        public virtual TId Id { get; set; }
    }
}
