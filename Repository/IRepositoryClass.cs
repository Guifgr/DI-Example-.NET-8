using Domain.Enum;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepositoryClass
    {
        Value RepositoryMethod(Value value, LifeCycleTypeEnum type);
    }
}
