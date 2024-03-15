internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            object o = null;
            o.ToString();
        }
        catch (Exception exception)
        {
            Console.WriteLine("");
            Console.WriteLine("Erro: " + exception.Message);
            Console.WriteLine("");
        }
    }
}
