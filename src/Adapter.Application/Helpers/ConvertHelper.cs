namespace Adapter.Application.Helpers
{
    public static class ConvertHelper
    {
        public static int ToInt(this string value)
        {
            if (!int.TryParse(value, out var number))
                throw new ArgumentException($"Valor inválido inválido");

            return number;
        }
    }
}