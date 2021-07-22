using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class JogoPoker
    {
        public string primeiraMao, segundaMao;
        public JogoPoker(string primeira, string segunda)
        {
            this.primeiraMao = primeira;
            this.segundaMao = segunda;
        }
        private Dictionary<char, int> cartas = new Dictionary<char, int>()
        {
            {'2', 1}, {'3', 2}, {'4', 3}, {'5', 4}, {'6', 5}, {'7', 6}, {'8', 7}, {'9', 8}, {'T', 9}, {'J', 10}, {'Q', 11}, {'K', 12}, {'A', 13}
        };
        public string RetornarVEncedor()
        {
            int valorP = 0, valorS = 0;

            string[] arrayP = primeiraMao.Split(' ');
            string[] arrayS = segundaMao.Split(' ');

            int[] numeroP = ConverterEmNumero(arrayP);
            int[] numeroS = ConverterEmNumero(arrayS);

            valorP = VerificarMao(arrayP, valorP);
            valorS = VerificarMao(arrayS, valorS);

            valorP += VerificaFlush(valorP, numeroP, arrayP);
            valorS += VerificaFlush(valorS, numeroS, arrayS);


            valorP += RetornaValores(numeroP);
            valorS += RetornaValores(numeroS);

            return valorP > valorS ? "Jogador 1 venceu" : "Jogador 2 venceu";
        }

        private int VerificaFlush(int valor, int[] numero, string[] array)
        {
            if (EhRoyalFlush(array, numero))
                return valor += 1000;

           else if (EhMesmoNaipe(array) && EhSequencia(numero))
                valor += 900;

           else if (EhMesmoNaipe(array))
                valor += 400;

           else if (EhSequencia(numero))
                valor += 300;

            return valor;
        }

        public int RetornaValores(int[] array)
        {
            int valor = 0;

            foreach (var item in array)
                valor += item;

            return valor;
        }

        public bool EhRoyalFlush(string[] arrayS, int[] arrayI)
        {
            return arrayS[0][0] == 'A' && EhSequencia(arrayI) ? true : false;
        }

        public bool EhSequencia(int[] array)
        {
            bool sq = false;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] != array[i - 1] - 1)
                    break;
                else
                    sq = true;
            }
            return sq;
        }
        public bool EhMesmoNaipe(string[] array)
        {
            int cont = 1;
            for (int i = 0; i < 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (i != j && array[i][1] == array[j][1])
                        cont++;
                }

            }
            return cont == 5 ? true : false;

        }
        public int[] ConverterEmNumero(string[] array)
        {
            int[] valor = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
                valor[i] = cartas[array[i][0]];

            return valor;
        }
        public int VerificarMao(string[] array, int valor)
        {
            List<int> listCount = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                int cont = 1;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (i != j && array[i][0] == array[j][0])
                        cont++;

                    switch (cont)
                    {
                        case 4: i = 3; break;
                        case 3: i = 2; break;
                        default:
                            break;
                    }
                }
                listCount.Add(cont);
            }
            foreach (var item in listCount)
            {
                switch (item)
                {
                    case 2: valor += 50; break;
                    case 3: valor += 200; break;
                    case 4: valor += 500; break;
                    case 5: valor += 450; break;
                    default:
                        break;
                }
            }
            return valor;
        }
    }
}
