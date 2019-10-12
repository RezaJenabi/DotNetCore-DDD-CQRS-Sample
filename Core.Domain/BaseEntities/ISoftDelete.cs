using System;

namespace Core.Domain.BaseEntities
{
    public interface ISoftDelete
    {
        bool Deleted { get; set; }
        DateTime DeletedAt { get; set; }
        string DeletedBy { get; set; }
    }
}
