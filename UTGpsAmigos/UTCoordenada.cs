using System;
using System.Text;
using System.Collections.Generic;
using GpsAmigos.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UTGpsAmigos
{
	/// <summary>
	/// Descrição resumida para UnitTest2
	/// </summary>
	[TestClass]
	public class UTCoordenada
	{
		Coordenada coord  = new Coordenada(5,4);
		Coordenada coord2 = new Coordenada(3, 4);
		Coordenada coord3 = new Coordenada(5, 4);
		[TestMethod]
		public void UTEqualTrue()
		{
			Assert.AreEqual(true, coord.Equals(coord3));

		}

		[TestMethod]
		public void UTEqualFalse()
		{
			Assert.AreEqual(false,coord.Equals(coord2));
			
		}

		[TestMethod]
		public void UTCalcularDistancia()
		{
			Assert.AreEqual(2, coord.CalcularDistancia(coord2));
		}
	}
}
