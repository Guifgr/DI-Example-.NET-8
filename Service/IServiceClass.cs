using Domain.Enum;
using Domain.Models;

namespace Service
{
    public interface IServiceClass
    {
        Value ServiceMethod(Value value, LifeCycleTypeEnum type);
    }
}
