using Domain.Enum;
using Domain.Models;

namespace Service
{
    public interface IServiceClass
    {
        Value SericeMethod(Value value, LifeCycleTypeEnum type);
    }
}
