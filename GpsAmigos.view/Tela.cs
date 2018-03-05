using GpsAmigos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpsAmigos.view
{
    public class Tela
    {
        public List<Amigo> ListaDeAmigo = new List<Amigo>();
		protected bool sair = false;
		protected int seq = 1;
		protected string opcao = "0";



        static void Main(string[] args)
        {
            Tela tela = new Tela();
			tela.IniciarPrograma();

        }


		#region Tela Inicial
		public void IniciarPrograma()
		{
			while (!this.sair)
			{
				Console.WriteLine("-----------------------------------------------------------------------------");
				Console.WriteLine("-                                                                           -");
				Console.WriteLine("- 1. Incluir Amigo                                                          -");
				Console.WriteLine("- 2. Listar todos Amigos                                                    -");
				Console.WriteLine("- 3. Listar Amigos Proximos                                                 -");
				Console.WriteLine("- 4. Limpar Tela                                                            -");
				Console.WriteLine("- 5. Sair                                                                   -");
				Console.WriteLine("-                                                                           -");
				Console.WriteLine("-----------------------------------------------------------------------------");

				opcao = Console.ReadLine();
				switch (this.opcao)
				{
					case "1":
						bool Incluido = false;
						do
						{
							Console.WriteLine("Digite o Nome do Amigo e endereco: Ex: João,5,15");
							var linha = Console.ReadLine();
							var dado = linha.Split(',');
							if (dado.Count() == 3 && dado[0]!=null && dado[1] != null && dado[2] != null )
							{
								Console.WriteLine(this.AddAmigo(new Amigo(this.ProximoSeq(), dado[0].ToUpper(), Convert.ToDouble(dado[1]), Convert.ToDouble(dado[2]))));
								Incluido = true;
							}
							else
							{
								Console.Clear();
							}
							
						} while (!Incluido);
						break;
					case "2":
						Console.WriteLine(this.ListarAmigos());
						break;
					case "3":
						bool Mostrar = false;
						do
						{
							Console.WriteLine("Digite o id do Amigo em que está:");
							var idEscolhido = int.Parse(Console.ReadLine());
							if (this.ListaDeAmigo.Exists(x => x.id == idEscolhido))
							{
								Amigo amigoEscolhido = this.ListaDeAmigo.Find(x => x.id == Convert.ToInt32(idEscolhido));
								Console.WriteLine(this.ListarAmigosProximo(amigoEscolhido));
								Mostrar = true;
							}
							else
							{
								Console.WriteLine("Id do Amigo digitado não foi encontrado!");
							}
							
						} while (!Mostrar);
						break;
					case "4":
						Console.WriteLine("");
						Console.Clear();
						break;
					case "5":
						Console.Clear();
						this.sair = true;
						break;
					default:
						break;
				}
			};
		}
		#endregion

		#region Adicionar Amigo   
		public string AddAmigo(Amigo amigo)
        {
			if (!this.ListaDeAmigo.Exists(x => x.coordenada.Equals(new Coordenada(amigo.coordenada.x, amigo.coordenada.y))))
            {
                this.ListaDeAmigo.Add(amigo);
                return "Amigo Cadastrado com sucesso!";
            }
            return "Coordenada já Cadastrada para um Amigo!";
            
        }
		#endregion

		#region Listar Amigos Proximos
		public string ListarAmigosProximo(Amigo AmigoAtual)
        {
            if (this.ListaDeAmigo.Count <= 1)
            {
                return "Sem Amigos proximos! :/";
            }
            
            foreach (var item in ListaDeAmigo)
            {
                item.coordenada.distancia  = AmigoAtual.coordenada.CalcularDistancia(item.coordenada);
            }

			var listOrd = ListaDeAmigo.OrderBy(x => x.coordenada.distancia).Where(s => s.id != AmigoAtual.id).ToList();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(string.Concat(listOrd[i].ToString(), listOrd[i].coordenada.PrintDistancia()));
            }
            return "";
        }
		#endregion

		#region Listar Amigos
		public string ListarAmigos()
        {
            if (this.ListaDeAmigo.Count == 0)
                return "Sem Amigos Cadastrados";
            

            foreach (var item in this.ListaDeAmigo)
            {
                Console.WriteLine(string.Concat(item.ToString(),item.coordenada.ToString()));
            }
            return "";
        }
		#endregion

		public int ProximoSeq()
		{
			return this.seq++;
		}
	}
}
