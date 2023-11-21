namespace Atividade;

public class Estoque
{
    public List<Produto> Produtos { get; set; } = new();

    public void CadastrarProduto()
    {
        try
        {
            Console.WriteLine("\nCadastro de Novo Produto:");
            Console.Write("Código: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Quantidade: ");
            int quantidade = int.Parse(Console.ReadLine());

            Console.Write("Preço Unitário: ");
            decimal preco = decimal.Parse(Console.ReadLine());

            var produtoExistente = Produtos.FirstOrDefault(p => p.Item.Codigo == codigo);

            if (produtoExistente != null)
                throw new ProdutoException($"\nJá existe um produto com código {codigo} cadastrado.");

            Produto produto = new Produto() { Item = (codigo, nome, quantidade, preco) };

            Produtos.Add(produto);

            Console.WriteLine("\nProduto cadastrado com sucesso!");

            Menu.MenuContinuarCadastro(this);
        }
        catch (FormatException)
        {
            Console.WriteLine("\nErro: Entrada inválida. Por favor, insira um valor válido.");
        }
        catch (ProdutoException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nErro inesperado: {ex.Message}");
        }
    }
    public void BuscarProduto()
    {
        try
        {
            Console.WriteLine("\nBuscar Produto:");
            Console.Write("Código do produto: ");

            int codigoBusca = int.Parse(Console.ReadLine());

            var produto = Produtos.FirstOrDefault(p => p.Item.Codigo == codigoBusca);

            if (produto == null)
                throw new ProdutoException($"\nProduto com código {codigoBusca} não encontrado.");

            Console.WriteLine("\nProduto econtrado: ");
            Console.WriteLine("{0,-15} {1,-20} {2,-10} {3,-10}", "Código", "Nome", "Qtd.", "Valor");
            Console.WriteLine(String.Format("{0,-15} {1,-20} {2,-10} {3,-10:N1}", produto.Item.Codigo, produto.Item.Nome, produto.Item.Quantidade, "R$ " + produto.Item.Preco));
        }
        catch (ProdutoException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }

    public void AtualizarSaldo()
    {
        try
        {
            Console.WriteLine("\nAtualizar saldo de Produto:");
            Console.Write("Código do produto: ");
            int codigoBusca = int.Parse(Console.ReadLine());

            var produto = Produtos.FirstOrDefault(p => p.Item.Codigo == codigoBusca);

            if (produto == null)
                throw new ProdutoException($"\nProduto com código {codigoBusca} não encontrado.");

            var selecao = Menu.MenuSaldo();

            if (selecao == Menu.opcaoEntrada)
                EntradaSaldo(produto);

            else if (selecao == Menu.opcaoSaida)
                SaidaSaldo(produto);

            else
                return;

        }
        catch (ProdutoException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }

    public void EntradaSaldo(Produto produto)
    {
        Console.WriteLine("\nEntrada: " + produto.Item.Nome + " | Saldo atual: " + produto.Item.Quantidade);
        Console.Write("Informe a quantidade que deseja dar entrada: ");
        int quantidade = int.Parse(Console.ReadLine());

        produto = new Produto
        {
            Item = (
                produto.Item.Codigo,
                produto.Item.Nome,
                produto.Item.Quantidade + quantidade,
                produto.Item.Preco
            )
        };

        int index = Produtos.FindIndex(p => p.Item.Codigo == produto.Item.Codigo);
        Produtos[index] = produto;
        Console.WriteLine("\nQuantidade acrescentada com sucesso!");
    }

    public void SaidaSaldo(Produto produto)
    {
        try
        {
            Console.WriteLine("\nSaída: " + produto.Item.Nome + " | Saldo atual: " + produto.Item.Quantidade);
            Console.Write("Informe a quantidade que deseja dar saída: ");
            int quantidade = int.Parse(Console.ReadLine());

            if (quantidade > produto.Item.Quantidade)
                throw new ProdutoException($"\nQuantidade para saída superior ao saldo atual.");

            produto = new Produto
            {
                Item = (
                    produto.Item.Codigo,
                    produto.Item.Nome,
                    produto.Item.Quantidade - quantidade,
                    produto.Item.Preco
                )
            };

            int index = Produtos.FindIndex(p => p.Item.Codigo == produto.Item.Codigo);
            Produtos[index] = produto;
            Console.WriteLine("\nQuantidade retirada com sucesso!");
        }
        catch (ProdutoException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }

    public void ObterTodos()
    {
        Console.WriteLine("");
        Console.WriteLine("{0,-15} {1,-20} {2,-10} {3,-10}", "Código", "Nome", "Qtd.", "Valor");
        foreach (var produto in Produtos.ToList())
        {
            Console.WriteLine(String.Format("{0,-15} {1,-20} {2,-10} {3,-10:N1}", produto.Item.Codigo, produto.Item.Nome, produto.Item.Quantidade, "R$ " + produto.Item.Preco));
        }
    }
    public void ListaProdutoSaldo()
    {
        try
        {
            Console.Write("\nInforme a quantidade limite do saldo que deseja gerar relatório: ");
            int limite = int.Parse(Console.ReadLine());

            var produtos = Produtos.Where(p => p.Item.Quantidade < limite).ToList();

            if (!produtos.Any())
                throw new ProdutoException($"\nNenhum produto encontrado com o saldo abaixo de {limite}");

            Console.WriteLine("");
            Console.WriteLine("{0,-15} {1,-20} {2,-10} {3,-10}", "Código", "Nome", "Qtd.", "Valor");
            foreach (var produto in produtos)
            {
                Console.WriteLine(String.Format("{0,-15} {1,-20} {2,-10} {3,-10:N1}", produto.Item.Codigo, produto.Item.Nome, produto.Item.Quantidade, "R$ " + produto.Item.Preco));
            }
            Console.WriteLine($"\nEsses produtos estão com o saldo abaixo de {limite}");
        }
        catch (ProdutoException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }
    public void ListaProdutoValor()
    {
        try
        {
            Console.WriteLine("\nInforme o intervalo de preços que deseja gerar relatório");
            Console.Write("valor inicial: ");
            decimal valorInicial = decimal.Parse(Console.ReadLine());
            Console.Write("valor final: ");
            decimal valorFinal = decimal.Parse(Console.ReadLine());

            var produtos = Produtos.Where(p => p.Item.Preco >= valorInicial && p.Item.Preco <= valorFinal).ToList();

            if (!produtos.Any())
                throw new ProdutoException($"\nNenhum produto encontrado com o valor entre de R$ {valorInicial} e R$ {valorFinal}");

            Console.WriteLine("");
            Console.WriteLine("{0,-15} {1,-20} {2,-10} {3,-10}", "Código", "Nome", "Qtd.", "Valor");
            foreach (var produto in produtos)
            {
                Console.WriteLine(String.Format("{0,-15} {1,-20} {2,-10} {3,-10:N1}", produto.Item.Codigo, produto.Item.Nome, produto.Item.Quantidade, "R$ " + produto.Item.Preco));
            }
            Console.WriteLine($"\nEsses produtos estão com o valor entre de R$ {valorInicial} e R$ {valorFinal}");
        }
        catch (ProdutoException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

    }
    public void ListaValorEstoque()
    {
        try
        {
            decimal valorEstoque = Produtos.Sum(p => p.Item.Preco * p.Item.Quantidade);

            if (valorEstoque <= 0)
                throw new ProdutoException("\nO estoque está sem saldo.");

            var produtos = Produtos.Select(p => new { Codigo = p.Item.Codigo, Nome = p.Item.Nome, Quantidade = p.Item.Quantidade, Preco = p.Item.Preco, Total = p.Item.Preco * p.Item.Quantidade });

            Console.WriteLine("");
            Console.WriteLine("{0,-15} {1,-20} {2,-10} {3,-10} {4,-10}", "Código", "Nome", "Qtd.", "Valor", "Total");
            foreach (var produto in produtos)
            {
                Console.WriteLine(String.Format("{0,-15} {1,-20} {2,-10} {3,-10} {4,-10:N1}", produto.Codigo, produto.Nome, produto.Quantidade, "R$ " + produto.Preco, "R$ " + produto.Total));
            }
            Console.WriteLine($"\nValor total do estoque R$ {valorEstoque}");
        }
        catch (ProdutoException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }
    class ProdutoException : Exception
    {
        public ProdutoException(string message) : base(message)
        {
        }
    }
}
