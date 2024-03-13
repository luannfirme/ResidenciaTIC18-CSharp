namespace Exercicio2
{

    public class Data
    {
        public const int FORMATO_12H = 12;
        public const int FORMATO_24H = 24;

        private readonly int dia;
        private readonly int mes;
        private readonly int ano;
        private readonly int hora;
        private readonly int minuto;
        private readonly int segundo;

        public Data(int dia, int mes, int ano) : this(dia, mes, ano, 0, 0, 0)
        {
        }

        public Data(int dia, int mes, int ano, int hora, int minuto, int segundo)
        {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
            this.hora = hora;
            this.minuto = minuto;
            this.segundo = segundo;
        }

        public int Dia => dia;
        public int Mes => mes;
        public int Ano => ano;
        public int Hora => hora;
        public int Minuto => minuto;
        public int Segundo => segundo;
        public bool CheckHoras => hora != 0 || minuto != 0 || segundo != 0;

        public void Imprimir(int formatoHora)
        {
            string dataFormatada = $"{dia}/{mes}/{ano}";
            if (CheckHoras)
            {
                string horaFormatada;
                if (formatoHora == FORMATO_12H)
                {
                    string periodo = hora < 12 ? "AM" : "PM";
                    int horaFormatadaInt = hora == 0 || hora == 12 ? 12 : hora % 12;
                    horaFormatada = $"{horaFormatadaInt}:{minuto:D2}:{segundo:D2} {periodo}";
                }
                else
                {
                    horaFormatada = $"{hora:D2}:{minuto:D2}:{segundo:D2}";
                }
                dataFormatada += $" {horaFormatada}";
            }
            Console.WriteLine(dataFormatada);
        }
    }
}
