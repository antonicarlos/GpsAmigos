using System;
using GpsAmigos.view;
using GpsAmigos.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UTGpsAmigos
{
	[TestClass]
	public class UTTela
	{
		Tela tela = new Tela();

		[TestMethod]
		public void TestListarAmigos()
		{
			Assert.AreEqual("Sem Amigos Cadastrados", tela.ListarAmigos());
			Assert.AreEqual("Amigo Cadastrado com sucesso!", tela.AddAmigo(new Amigo(tela.ProximoSeq(), "Antoni", 3, 7)));
			Assert.AreEqual("", tela.ListarAmigos());
		}

		[TestMethod]
		public void TestAddAmigo()
		{
			Assert.AreEqual("Amigo Cadastrado com sucesso!", tela.AddAmigo(new Amigo(tela.ProximoSeq(), "Antoni", 3, 7)));
			Assert.AreEqual("Coordenada já Cadastrada para um Amigo!",tela.AddAmigo(new Amigo(tela.ProximoSeq(), "Antoni", 3, 7)));
		}

		[TestMethod]
		public void TestListarAmigosProximos()
		{
			Assert.AreEqual("Sem Amigos proximos! :/", tela.ListarAmigosProximo(tela.ListaDeAmigo.Find(x => x.id == 0)));
			Assert.AreEqual("Amigo Cadastrado com sucesso!", tela.AddAmigo(new Amigo(tela.ProximoSeq(), "Antoni", 3, 7)));
			Assert.AreEqual("Amigo Cadastrado com sucesso!", tela.AddAmigo(new Amigo(tela.ProximoSeq(), "Jessica", 7, 7)));
			Assert.AreEqual("Amigo Cadastrado com sucesso!", tela.AddAmigo(new Amigo(tela.ProximoSeq(), "Henri", 4, 9)));
			Assert.AreEqual("Amigo Cadastrado com sucesso!", tela.AddAmigo(new Amigo(tela.ProximoSeq(), "Thamyres", 13, 1)));
			Assert.AreEqual("", tela.ListarAmigosProximo(tela.ListaDeAmigo.Find(x => x.id == 0)));
		}


	}
}
