using Domain.Enum;
using Domain.Models;

namespace Repository
{
    public class RepositoryClass : IRepositoryClass
    {
        public ValueSingleton _valueSingleton;
        public ValueScoped _valueScoped;
        public ValueTransient _valueTransient;

        public RepositoryClass(ValueSingleton valueSingleton, ValueScoped valueScoped, ValueTransient valueTransient)
        {
            _valueSingleton = valueSingleton;
            _valueScoped = valueScoped;
            _valueTransient = valueTransient;

        }

        public Value RepositoryMethod(Value value, LifeCycleTypeEnum type)
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
            Console.WriteLine($"Entrada da repository, o valor é {_value?.ActualValue}");
            _value ??= new Value() { ActualValue = "repository" };
            value.ActualValue = "repository";
            _value.ActualValue = value.ActualValue;
            Console.WriteLine($"Saída da repository, o valor é {_value?.ActualValue} \n\n\n");
            return value;
        }
    }
}
