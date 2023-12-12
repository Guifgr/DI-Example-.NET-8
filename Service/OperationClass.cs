using Service.Operation;

namespace Domain.Models
{
    public class OperationClass : IOperationTransient, IOperationScoped, IOperationSingleton
    {
        public OperationClass() 
        {
            OperationId = Guid.NewGuid().ToString();
        }

        public string OperationId { get; set; }
    }
}
