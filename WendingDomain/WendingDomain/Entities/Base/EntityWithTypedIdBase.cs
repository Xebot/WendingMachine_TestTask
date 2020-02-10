namespace WendingDomain.Entities
{
    public abstract class EntityWithTypedIdBase<TId>
    {
        public virtual TId Id { get; protected set; }
    }
}
