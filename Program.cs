using System;

namespace gauss_elimination_method
{
    class Program
    {
        static int order = 0;
        static void Main(string[] args)
        {
            //matriz quadrada
            // X
            double[,] matrizX = new double[0, 0];
            //vetor contendo termos independentes
            // Y
            double[] vectorY = new double[0];
            readMatrixAndVector(out matrizX, out vectorY);
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Matriz informada:");
            printMatrix(matrizX, vectorY);

            elimination(matrizX, vectorY);

            Console.WriteLine("Etapa de Eliminação:");
            printMatrix(matrizX, vectorY);

            Console.WriteLine("Resolução:");
            resolution(matrizX, vectorY);

            Console.ReadLine();
        }
        static void readMatrixAndVector(out double[,] matrizX, out double[] vectorY)
        {
            matrizX = new double[0, 0];
            vectorY = new double[0];
            bool moveon = false;
            while (!moveon)
            {
                Console.WriteLine("Informe a ordem da matriz quadrada:");
                string value = Console.ReadLine();
                if (int.TryParse(value, out int orderValue))
                {
                    if (orderValue < 2 || orderValue > 5)
                    {
                        Console.WriteLine("Programa não validado para ordem informada.");
                    }
                    else
                    {
                        order = orderValue;
                        matrizX = new double[order, order];
                        vectorY = new double[order];
                        moveon = true;
                        for (int i = 0; i < order; i++)
                        {
                            for (int j = 0; j < order; j++)
                            {
                                bool keepgoin = false;
                                while (!keepgoin)
                                {
                                    Console.WriteLine("Informe item a[" + i + ";" + j + "]: ");
                                    string item = Console.ReadLine();
                                    if (double.TryParse(item, out double itemX))
                                    {
                                        keepgoin = true;
                                        matrizX[i, j] = itemX;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Não foi possivel identificar valor a partir do informado.");
                                    }
                                }

                            }
                            bool keepgoing = false;
                            while (!keepgoing)
                            {
                                Console.WriteLine("Informe o termo independente da linha " + i + ": ");
                                string item = Console.ReadLine();
                                if (double.TryParse(item, out double itemY))
                                {
                                    keepgoing = true;
                                    vectorY[i] = itemY;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Não foi possivel identificar valor a partir do informado.");
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Não foi possivel identificar ordem a partir do valor informado.");
                }
            }


        }
        static void elimination(double[,] matrizX, double[] vectorY)
        {
            for (int k = 0; k < order - 1; k++)
            {
                for (int i = k + 1; i < order; i++)
                {
                    double m = matrizX[i, k] / matrizX[k, k];
                    matrizX[i, k] = 0;
                    for (int j = k + 1; j < order; j++)
                    {
                        matrizX[i, j] = matrizX[i, j] - m * matrizX[k, j];
                    }
                    vectorY[i] = vectorY[i] - (m * vectorY[k]);
                }
            }
        }
        static void printMatrix(double[,] matrizX, double[] vectorY)
        {
            for (int i = 0; i < order; i++)//linha
            {
                Console.Write("|");
                for (int j = 0; j < order; j++)//coluna
                {
                    Console.Write(matrizX[i, j].ToString("0.000").PadLeft(12));
                }
                Console.Write("|");
                Console.Write(vectorY[i].ToString("0.000").PadLeft(12));
                Console.Write("|\n");
            }
        }
        static void resolution(double[,] matrizX, double[] vectorY)
        {
            double[] vectorX = new double[order];
            vectorX[order - 1] = vectorY[order - 1] / matrizX[order - 1, order - 1];
            for(int k = order -2; k >= 0; k--)
            {
                double s = 0;
                for(int j = k + 1; j<order; j++)
                {
                    s = s + matrizX[k, j] * vectorX[j];
                }
                vectorX[k] = (vectorY[k] - s) / matrizX[k, k];
            }
            for(int x = 0; x < order; x++)
            {
                Console.WriteLine("X" + x + ": " + vectorX[x]);
            }
        }
    }
}
