﻿using Nelibur.ObjectMapper;

namespace STG.Domain.Mappers
{
    public class Mapper : IMapper
    {
        public TTarget Map<TSource, TTarget>(TSource source)
        {
            TinyMapper.Bind<TSource, TTarget>();
            var target = TinyMapper.Map<TTarget>(source);
            return target;
        }
    }
}
