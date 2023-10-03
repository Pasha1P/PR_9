//Погудин Павел
//Практическая работа №9
//В одномерном массиве, вводимом с клавиатуры и состоящем из 15 вещественных элементов,
//вычислить: максимальный элемент массива, заменить его на минимальный;
//сумму элементов массива, расположенных до последнего положительного элемента.

//попробуйте массив:   19 8 2 4 61 -1 0 -2 -2 4 -5 -11 -20 2 -1
//его результат   сумма его элементов 57
//его результат   новый массив  19 8 2 4 -20 -1 0 -2 -2 4 -5 -11 -20 2 -1 

using System;

namespace PR_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Практическая работа №9";

            const int m = 5;
            int i = 0, maxi = 0, n = -1;
            double[] masiv = new double[m];
            double sum = 0, max, min;
            bool err;



            try
            {
                while (true)
                {
                    Console.WriteLine("\t Здраствуйте! ");
                    int stop = 1;

                    while (i < m)                                                     //ввод массива
                    {
                        err = false;
                        Console.Write("Введите " + (i + 1) + " элемент массива: ");

                        try
                        {
                            masiv[i] = Convert.ToDouble(Console.ReadLine());
                        }
                        catch (FormatException fe1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            err = true;
                            Console.WriteLine("возникла ошибка: " + fe1.Message);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        if (!err) i++;
                    }
                    max = masiv[0];                                                   //минимум
                    min = masiv[0];                                                   //максимум
                    for (i = (m - 1); i >= 0; i--)                                    //последний положительный
                    {
                        if (masiv[i] > 0)
                        {
                            n = i - 1;
                            break;
                        }
                    }
                    for (i = n; i >= 0; i--)                                          //сумма
                    {
                        sum += masiv[i];
                    }
                    for (i = (m - 1); i >= 0; i--)                                    //новое значение минимума
                    {
                        if (masiv[i] < min)
                        {
                            min = masiv[i];
                        }
                    }
                    for (i = (m - 1); i >= 0; i--)                                    //новое значение максимума
                    {
                        if (masiv[i] > max)
                        {
                            max = masiv[i];
                            maxi = i;
                        }
                    }
                    masiv[maxi] = min;                                                //меняем максимум на минимум
                    Console.WriteLine("\t. . . ");
                    Console.Write("получился такой массив: ");
                    for (i = 0; i <= m - 1; i++)
                    {
                        Console.Write(masiv[i] + " ");
                    }
                    i = 0;
                    Console.WriteLine("\nсумма элементов, введенного массива, до последнего положительного, равн " + sum);
                    Console.WriteLine("если хотите выйти нажмите 0, если нет другую цифру");
                    stop = Convert.ToInt32(Console.ReadLine());
                    if (stop == 0) break;
                    else
                    {
                        Console.Clear();
                        sum = 0;
                    }
                }
            }
            catch (InvalidCastException ice)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Недопустимое исключение приведения. Ошибка: " + ice.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }            
            catch (ArgumentOutOfRangeException aoore)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Исключение аргумента вне диапазона. Ошибка: " + aoore.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (FormatException fe)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Исключение формата. Ошибка: " + fe.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Что то пошло не так. Ошибка: " + e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.ReadKey();
        }
    }
}
