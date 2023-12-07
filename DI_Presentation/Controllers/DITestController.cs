using Domain.Enum;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace DI_Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DITestController : ControllerBase
    {
        public IServiceClass _serviceClass;
        public ValueSingleton _valueSingleton;
        public ValueScoped _valueScoped;
        public ValueTransient _valueTransient;

        public DITestController(IServiceClass serviceClass, ValueSingleton valueSingleton, ValueScoped valueScoped, ValueTransient valueTransient)
        {
            _serviceClass = serviceClass;
            _valueSingleton = valueSingleton;
            _valueScoped = valueScoped;
            _valueTransient = valueTransient;
        }

        [HttpGet]
        public Value Get([FromQuery] LifeCycleTypeEnum type)
        {
            var _value = new Value();
            switch (type)
            {
                case LifeCycleTypeEnum.Transient:
                    _value = _valueTransient;
                    break;
                case LifeCycleTypeEnum.Scoped:
                    _value = _valueScoped;
                    break;
                case LifeCycleTypeEnum.Singleton:
                    _value = _valueSingleton;
                    break;

            }
            Console.Clear();
            Console.WriteLine($"O tipo do container é {type}");
            Console.WriteLine($"Entrada da controller, o valor é {_value.ActualValue ?? "nulo" }");
            _value ??= new Value() { ActualValue = "controller" };
            var value = new Value() { ActualValue = "controller" };
            _value.ActualValue = value.ActualValue;
            Console.WriteLine($"Saída da controller, o valor é {_value?.ActualValue}\n");
            return _serviceClass.SericeMethod(value, type);
        }
    }
}
