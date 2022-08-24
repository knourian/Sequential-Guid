using System;

namespace SequentialGuid
{
    public interface ISequentialGuid
    {
        Guid GetCurrentGuid();
        Guid Next();
    }
}
