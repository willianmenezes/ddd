using System.Text.RegularExpressions;

namespace NerdStore.Core.DomainObjects
{
    public class Validacoes
    {
        public static void ValidarSeIgual(object obj1, object obj2, string mensagem)
        {
            if (!obj1.Equals(obj2))
            {
                throw new DomainExeption(mensagem);
            }
        }

        public static void ValidarSeDiferente(object obj1, object obj2, string mensagem)
        {
            if (obj1.Equals(obj2))
            {
                throw new DomainExeption(mensagem);
            }
        }

        public static void ValidarCaracteres(string valor, int maximo, string mensagem)
        {
            var length = valor.Trim().Length;
            if (length > maximo)
            {
                throw new DomainExeption(mensagem);
            }
        }

        public static void ValidarCaracteres(string valor, int minimo, int maximo, string mensagem)
        {
            var length = valor.Trim().Length;
            if (length < minimo || length > maximo)
            {
                throw new DomainExeption(mensagem);
            }
        }

        public static void ValidarExpressao(string pattern, string valor, string mensagem)
        {
            var regex = new Regex(pattern);

            if (!regex.IsMatch(valor))
            {
                throw new DomainExeption(mensagem);
            }
        }

        public static void ValidarSeVazio(string valor, string mensagem)
        {
            if (valor == null || valor.Trim().Length == 0)
            {
                throw new DomainExeption(mensagem);
            }
        }

        public static void ValidarSeNulo(object obj, string mensagem)
        {
            if (obj == null)
            {
                throw new DomainExeption(mensagem);
            }
        }

        public static void ValidarMinimoMaximo(double valor, double minimo, double maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainExeption(mensagem);
            }
        }

        public static void ValidarMinimoMaximo(float valor, float minimo, float maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainExeption(mensagem);
            }
        }

        public static void ValidarMinimoMaximo(int valor, int minimo, int maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainExeption(mensagem);
            }
        }

        public static void ValidarMinimoMaximo(long valor, long minimo, long maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainExeption(mensagem);
            }
        }

        public static void ValidarMinimoMaximo(decimal valor, decimal minimo, decimal maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainExeption(mensagem);
            }
        }

        public static void ValidarSeMenorOuIgualMinimo(long valor, long minimo, string mensagem)
        {
            if (valor <= minimo)
            {
                throw new DomainExeption(mensagem);
            }
        }

        public static void ValidarSeMenorOuIgualMinimo(double valor, double minimo, string mensagem)
        {
            if (valor <= minimo)
            {
                throw new DomainExeption(mensagem);
            }
        }

        public static void ValidarSeMenorOuIgualMinimo(decimal valor, decimal minimo, string mensagem)
        {
            if (valor <= minimo)
            {
                throw new DomainExeption(mensagem);
            }
        }

        public static void ValidarSeMenorOuIgualMinimo(int valor, int minimo, string mensagem)
        {
            if (valor <= minimo)
            {
                throw new DomainExeption(mensagem);
            }
        }

        public static void ValidarSeFalso(bool valor, string mensagem)
        {
            if (valor)
            {
                throw new DomainExeption(mensagem);
            }
        }

        public static void ValidarSeVerdadeiro(bool valor, string mensagem)
        {
            if (!valor)
            {
                throw new DomainExeption(mensagem);
            }
        }
    }
}