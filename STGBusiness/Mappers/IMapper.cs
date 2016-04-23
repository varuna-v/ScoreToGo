namespace STG.Business.Mappers
{
    public interface IMapper
    {
        TTarget Map<TSource, TTarget>(TSource source);
    }
}
