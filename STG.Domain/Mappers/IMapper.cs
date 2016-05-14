namespace STG.Domain.Mappers
{
    public interface IMapper
    {
        TTarget Map<TSource, TTarget>(TSource source);
    }
}
