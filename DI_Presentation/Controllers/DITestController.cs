using Domain.Enum;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Operation;

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

        private readonly IOperationTransient _transientOperation1;
        private readonly IOperationTransient _transientOperation2;

        private readonly IOperationScoped _scopedOperation1;
        private readonly IOperationScoped _scopedOperation2;
        
        private readonly IOperationSingleton _singletonOperation1;
        private readonly IOperationSingleton _singletonOperation2;

        public DITestController(IServiceClass serviceClass,
            ValueSingleton valueSingleton,
            ValueScoped valueScoped,
            ValueTransient valueTransient,
            IOperationTransient transientOperation1,
            IOperationTransient transientOperation2,
            IOperationScoped scopedOperation1,
            IOperationScoped scopedOperation2,
            IOperationSingleton singletonOperation1,
            IOperationSingleton singletonOperation2
            )
        {
            _serviceClass = serviceClass;
            _valueSingleton = valueSingleton;
            _valueScoped = valueScoped;
            _valueTransient = valueTransient;
            _transientOperation1 = transientOperation1;
            _transientOperation2 = transientOperation2;
            _scopedOperation1 = scopedOperation1;
            _scopedOperation2 = scopedOperation2;
            _singletonOperation1 = singletonOperation1;
            _singletonOperation2 = singletonOperation2;
        }

        [HttpGet()]
        public string Index()
        {
            return 
                $"Transient1    : {_transientOperation1.OperationId}\n" +
                $"Transient2    : {_transientOperation2.OperationId}\n" +
                $"Scoped1       : {_scopedOperation1.OperationId}\n" +
                $"Scoped2       : {_scopedOperation2.OperationId}\n" +
                $"Singleton1    : {_singletonOperation1.OperationId}\n" +
                $"Singleton2    : {_singletonOperation2.OperationId}";

        }



        [HttpGet("console")]
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
            return _serviceClass.ServiceMethod(value, type);
        }
    }
}
