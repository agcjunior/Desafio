namespace Desafio.Comum
{
    public record Error(string code,  string message)
    {
        public static Error None = new Error(string.Empty, string.Empty);
        public static Error NullValue = new Error("Erro.Nulo", "Valor nulo foi informdo");
    }
}
