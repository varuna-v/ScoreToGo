namespace STG.Business.Mappers
{
    public interface IModelMapper<TSource, TTarget>
    {
        TTarget Map(TSource source);
        TSource Map(TTarget source);
    }
}
