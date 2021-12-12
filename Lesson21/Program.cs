using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson21
{
    //1.    Имеется пустой участок земли (двумерный массив) и план сада, который необходимо реализовать.
    //Эту задачу выполняют два садовника, которые не хотят встречаться друг с другом.
    //Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо, сделав ряд, он спускается вниз.
    //Второй садовник начинает работу с нижнего правого угла сада и перемещается снизу вверх, сделав ряд, он перемещается влево.
    //Если садовник видит, что участок сада уже выполнен другим садовником, он идет дальше. Садовники должны работать параллельно.
    //Создать многопоточное приложение, моделирующее работу садовников.
    class Program
    {
        
        static int w;
        static  int l;
        static int[,] massivPole;
        static void Main()
        {
            Console.WriteLine("Введите длину сада");
            w = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите ширину сада");
            l = Convert.ToInt32(Console.ReadLine());


            massivPole = new int[w, l];
            //Создаём потоки
            Thread garden1 = new Thread(gardener1);
            Thread garden2 = new Thread(gardener2);
            //Запускаем поток
            garden1.Start();
            garden2.Start();
            //Блокируем вызывающий поток
            garden1.Join();
            garden2.Join();

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    Console.Write(massivPole[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private static void gardener1()
        {
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    if (massivPole[i, j] == 0)
                        massivPole[i, j] = 1;
                    //приостановка потока
                    Thread.Sleep(1);
                }
            }
        }

        private static void gardener2()
        {
            for (int i = l - 1; i > 0; i--)
            {
                for (int j = w - 1; j > 0; j--)
                {
                    if (massivPole[j, i] == 0)
                        massivPole[j, i] = 2;
                    //приостановка потока
                    Thread.Sleep(1);
                }
            }
        }
    }
}
