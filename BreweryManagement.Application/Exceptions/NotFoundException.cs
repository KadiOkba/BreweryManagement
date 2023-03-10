namespace BreweryManagement.Application.Exceptions
{
    public class NotFoundException : Exception
    {

        public NotFoundException(string entity, object value) : base($"{entity} with value {value} not found")
        {

        }
        public NotFoundException(string entity, object value, Exception ex) : base($"{entity} with value {value} not found", ex)
        {

        }

    }
}
