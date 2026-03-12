using Desafio.Comum;

namespace Desafio.Infraestrutura
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
