using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание8
{
    class Program
    {
        public static char ImputVertex()//Ввод вершин
        {
            bool rightValue;
            char value;

            do
            {
                string userImput = Console.ReadLine();
                rightValue = char.TryParse(userImput, out value);
                if (!(char.IsLetter(value))) rightValue = false;
                if (value.ToString() == "0") rightValue = true;
                if (!rightValue) Console.Write(@"Ожидалась буква. Повторите ввод - ");
            }
            while (!rightValue);

            return value;
        }

        public static string ImputEdge(List<char> list)//Ввод ребер
        {
            bool rightValue;
            string value;

            do
            {
                value = Console.ReadLine();
                if ((value.Length != 2) || !(list.Contains(value[0])) || !(list.Contains(value[1])))//Проверка на содержание вершин
                    rightValue = false;
                else rightValue = true;
                if (value == "0") rightValue = true;
                if (!rightValue) Console.Write(@"Ожидалась пара букв. Повторите ввод - ");
            }
            while (!rightValue);

            return value;
        }

        static void Main(string[] args)
        {
            List<char> vertexes = new List<char>();
            List<string> edges = new List<string>();

            Console.WriteLine("Введите список вершин графа (только буквы). Признак конца ввода - 0: ");
            do
            {
                vertexes.Add(ImputVertex());
            }
            while (vertexes.Last().ToString() != "0");

            vertexes.Remove(vertexes.Last());

            Console.WriteLine("Введите список ребер графа (две буквы подряд без пробела) признак конца ввода - 0: ");
            do
            {
                edges.Add(ImputEdge(vertexes));
            }
            while (edges.Last() != "0");

            edges.Remove(edges.Last());

            List<string> result = new List<string>();
            bool exist = false;

            for (int i = 0; i < edges.Count; i++)//Для каждого ребра
            {
                string a = edges[i][0].ToString();
                string b = edges[i][1].ToString();
                
                for (int j = 0; j < result.Count; j++)//В каждом блоке
                {
                    if (result[j].Contains(a) && !(result[j].Contains(b)))//Если ребро связанно и есть новая вершина 
                    {
                        result[j] += b;
                        exist = true;
                    }
                    else if ((result[j].Contains(b) && !(result[j].Contains(a))))
                    {
                        result[j] += a;
                        exist = true;
                    }
                    else if ((result[j].Contains(a)) && (result[j].Contains(b)))//Если ребро связано
                        exist = true;
                    else if (!(result[j].Contains(a) && !(result[j].Contains(b))))//Если ребро не связанно
                        exist = false;
                }

                if (!exist) result.Add(edges[i]);
            }

            exist = false;

            for (int i = 0; i < vertexes.Count; i++)//Проверка на наличие точек
            {
                for (int j = 0; j < result.Count; j++)
                {
                    if (result[j].Contains(vertexes[i]))
                    {
                        exist = true;
                        break;
                    }
                    else exist = false;
                }

                if (!exist) result.Add(vertexes[i].ToString());
            }

                Console.WriteLine("Блоки графа ({0} блока(ов)): ", result.Count);//Вывод рез-ов
            foreach (string x in result)
                Console.WriteLine(x);

            Console.ReadLine();
        }
    }
}
