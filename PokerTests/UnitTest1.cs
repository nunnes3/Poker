using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using Poker;

namespace PokerTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void JogadorUmVencedor()
        {
            JogoPoker jogoPoker = new JogoPoker("AD KD QD JD TD", "TD 9D 8D 7D 6D");
            jogoPoker.RetornarVEncedor().Should().Be("Jogador 1 venceu");
        }

        [TestMethod]
        public void JogadorDoisVencedor()
        {
            JogoPoker jogoPoker = new JogoPoker("TD 9D 8D 7D 6D", "AD KD QD JD TD");
            jogoPoker.RetornarVEncedor().Should().Be("Jogador 2 venceu");
        }


        [TestMethod]
        public void VerificaDupla()
        {
            JogoPoker jogoPoker = new JogoPoker("AD AC KD JC 7C", "AD AC KD JC 7C");
            string[] quebrandoValores = jogoPoker.primeiraMao.Split(' ');
            int valor = 0;
            jogoPoker.VerificarMao(quebrandoValores, valor).Should().Be(50);
        }
        [TestMethod]
        public void VerificaSeEhQuadra()
        {
            JogoPoker jogoPoker = new JogoPoker("TD 9C 8D 7C 6C", "AD AC AD AC 7C");
            string[] quebrandoValores = jogoPoker.segundaMao.Split(' ');
            int valor = 0;
            jogoPoker.VerificarMao(quebrandoValores, valor).Should().Be(500);
        }

        [TestMethod]
        public void VerificaSeEhDoisPares()
        {
            JogoPoker jogoPoker = new JogoPoker("TD 9C 8D 7C 6C", "AD AC 2D 2C 7C");
            string[] quebrandoValores = jogoPoker.segundaMao.Split(' ');
            int valor = 0;
            jogoPoker.VerificarMao(quebrandoValores, valor).Should().Be(100);
        }

        [TestMethod]
        public void DeveRetornarMesmoNaipe()
        {
            JogoPoker jogoPoker = new JogoPoker("TD 9D 8D 7D 6D", "AD AC AD AC 7C");
            string[] quebrandoValores = jogoPoker.primeiraMao.Split(' ');

            jogoPoker.EhMesmoNaipe(quebrandoValores).Should().BeTrue();
        }
        [TestMethod]
        public void DeveRetornarNaipesDiferentes()
        {
            JogoPoker jogoPoker = new JogoPoker("TD 9D 8D 7D 6D", "AD AC AD AC 7C");
            string[] quebrandoValores = jogoPoker.segundaMao.Split(' ');

            jogoPoker.EhMesmoNaipe(quebrandoValores).Should().BeFalse();
        }
        [TestMethod]
        public void DeveRetornarSequencia()
        {
            JogoPoker jogoPoker = new JogoPoker("TD 9D 8D 7D 6D", "AD AC AD AC 7C");

            string[] array = jogoPoker.primeiraMao.Split(' ');
            int[] numeroP = jogoPoker.ConverterEmNumero(array);

            jogoPoker.EhSequencia(numeroP).Should().BeTrue();
        }
        [TestMethod]
        public void DeveRetornarNaoEhSequencia()
        {
            JogoPoker jogoPoker = new JogoPoker("3D 9D 8D 7D 6D", "AD AC AD AC 7C");

            string[] array = jogoPoker.primeiraMao.Split(' ');
            int[] numeroP = jogoPoker.ConverterEmNumero(array);

            jogoPoker.EhSequencia(numeroP).Should().BeFalse();
        }
        [TestMethod]
        public void DeveRetornarEhRoyalFlush()
        {
            JogoPoker jogoPoker = new JogoPoker("AD 2D 3D 4D TD", "AD AC AD AC 7C");

            string[] array = jogoPoker.primeiraMao.Split(' ');
            int[] numeroP = jogoPoker.ConverterEmNumero(array);

            jogoPoker.EhRoyalFlush(array, numeroP).Should().BeFalse();
        }
    }
}
