using System;

namespace DIO.Series
{
    class Program
    {
        static SeriesRepositorio repositorio = new SeriesRepositorio();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsusario();

            while(opcaoUsuario.ToUpper() != "X"){
                switch(opcaoUsuario){
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentException("Opção inválida");
                }
            opcaoUsuario = ObterOpcaoUsusario();
            }
        }

        private static void ListarSeries(){
            Console.WriteLine("Listando Séries");
            var lista = repositorio.Lista();

            if(lista.Count == 0){
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach (var serie in lista)
            {
                if(!serie.RetornaExcluido()){
                    Console.WriteLine("#ID {0} : - {1}", serie.retornaId(), serie.retornaTitulo());
                }
            }
        }

        private static void InserirSerie(){
            Console.WriteLine("Inserir nova série ");
            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), 
                                        genero: (Genero)entradaGenero, 
                                        titulo: entradaTitulo, 
                                        ano: entradaAno, 
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
            Console.Write("Serie adicionada com sucesso!");
        }

        private static void AtualizarSerie(){
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie, 
                                        genero: (Genero)entradaGenero, 
                                        titulo: entradaTitulo, 
                                        ano: entradaAno, 
                                        descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizaSerie);
            Console.Write("Serie atualizada com sucesso!"); 
        }

        private static void ExcluirSerie(){
            Console.WriteLine("Digite o id da série que deseja excluir: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie(){
            Console.WriteLine("Digite o id da série que deseja visualizar: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            var serie = repositorio.retornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }


        public static string ObterOpcaoUsusario(){
            Console.WriteLine("");
            Console.WriteLine("Bem vindo! ");
            Console.WriteLine("Digite a opção desejada:");
            Console.WriteLine("1 - Listar series");
            Console.WriteLine("2 - Adicionar serie");
            Console.WriteLine("3 - Atualizar serie");
            Console.WriteLine("4 - Remover serie");
            Console.WriteLine("5 - Visualizar serie");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine("");
            return opcaoUsuario;
        } 


    }
}
