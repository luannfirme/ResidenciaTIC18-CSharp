namespace Atividade;
class Program
{
    static void Main()
    {
        var estoque = new List<(int codigo, string nome, int quantidade, decimal precoUnitario)>();

        cadastrarProduto(estoque);

        Console.WriteLine("Produtos no Estoque:");
        foreach (var produto in estoque)
        {
            Console.WriteLine($"Código: {produto.codigo}, Nome: {produto.nome}, Quantidade: {produto.quantidade}, Preço Unitário: {produto.precoUnitario}");
        }

        BuscarProduto(estoque);
    }

    static void cadastrarProduto(List<(int codigo, string nome, int quantidade, decimal precoUnitario)> estoque)
    {
        try
        {
            Console.WriteLine("Cadastro de Novo Produto:");
            Console.Write("Código: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Quantidade: ");
            int quantidade = int.Parse(Console.ReadLine());

            Console.Write("Preço Unitário: ");
            decimal precoUnitario = decimal.Parse(Console.ReadLine());

            estoque.Add((codigo, nome, quantidade, precoUnitario));

            Console.WriteLine("Produto cadastrado com sucesso!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Entrada inválida. Por favor, insira um valor válido.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }
    static void BuscarProduto(List<(int codigo, string nome, int quantidade, decimal precoUnitario)> estoque)
    {
        try
        {
            Console.WriteLine("Buscar Produto:");
            Console.Write("Código do produto: ");

            int codigoBusca = int.Parse(Console.ReadLine());

            var produto = estoque.FirstOrDefault(p => p.codigo == codigoBusca);

            if(produto.codigo > 0 ) 
                Console.WriteLine($"\nProduto encontrado: \nCódigo: {produto.codigo} - Nome: {produto.nome} - Quantidade: {produto.quantidade} - Preço Unitário: {produto.precoUnitario}");
            else
                throw new ProdutoException($"\nProduto com código {codigoBusca} não encontrado.");

        }
        catch (ProdutoException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void AtualizarSaldo(List<(int codigo, string nome, int quantidade, decimal precoUnitario)> estoque)
    {
        try
        {
            Console.WriteLine("Atualizar saldo de Produto:");
            Console.Write("Código do produto: ");
            int codigoBusca = int.Parse(Console.ReadLine());

            var produto = estoque.FirstOrDefault(p => p.codigo == codigoBusca);

            Console.WriteLine($"\nProduto encontrado: Código: {produto.codigo}, Nome: {produto.nome}, Quantidade: {produto.quantidade}, Preço Unitário: {produto.precoUnitario}");

            throw new ProdutoException($"\nProduto com código {codigoBusca} não encontrado.");
        }
        catch (ProdutoException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }


    class ProdutoException : Exception
    {
        public ProdutoException(string message) : base(message)
        {
        }
    }
}