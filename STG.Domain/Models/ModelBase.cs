using System;

namespace STG.Domain.Models
{
    public abstract class ModelBase
    {
        public Guid UniqueId { get; set; }
        public abstract string IdPrefix { get; }
        public string Id
        {
            get { return $"{IdPrefix}/{UniqueId}"; }
        }
    }
}
