using Domain.Enum;
using Domain.Models;
using Repository;

namespace Service
{
    public class ServiceClass : IServiceClass
    {
        private readonly IRepositoryClass _repository;
        public ValueSingleton _valueSingleton;
        public ValueScoped _valueScoped;
        public ValueTransient _valueTransient;

        public ServiceClass(IRepositoryClass repository, ValueSingleton valueSingleton, ValueScoped valueScoped, ValueTransient valueTransient)
        {
            _repository = repository;
            _valueSingleton = valueSingleton;
            _valueScoped = valueScoped;
            _valueTransient = valueTransient;

        }

        public Value SericeMethod(Value value, LifeCycleTypeEnum type)
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
            Console.WriteLine($"Entrada da service, o valor é {_value.ActualValue ?? "nulo" }");
            _value ??= new Value() { ActualValue = "service" };
            value.ActualValue = "Service";
            _value.ActualValue = value.ActualValue;
            Console.WriteLine($"Saída da Service, o valor é {_value?.ActualValue}\n");
            return _repository.RepositoryMethod(value, type);
        }
    }
}
