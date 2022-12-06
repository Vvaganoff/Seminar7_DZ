//Задача 50.Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.

//Например, задан массив:

//1 4 7 2

//5 9 2 3

//8 4 2 4

//17->такого числа в массиве нет

Console.Write("Введите размер двухмерного массива: ");
string strArraySize = Console.ReadLine(); //Пользователь вводит два размера: количество строк и столбцов
char[] charSeparators = new char[] { ' ', 'x', '+', '*', 'X', '-', ',', ';' };//Определяем, чем пользователь может отделить размеры
string[] strArrayOfArraySize = strArraySize.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

if (strArrayOfArraySize.Length != 2) //Если пользователь ввёл не два числа, то выдаём ошибку и выходим
{
    Console.WriteLine("У двухмерного массива два размера: количество строк и количество толбцов");
    return;
}
int[] intArraySize = new int[strArrayOfArraySize.Length];             //Преобразуем строковый массив в массив целых
for (int i = 0; i < strArrayOfArraySize.Length; i++)                  //
{
    intArraySize[i] = Convert.ToInt32(strArrayOfArraySize[i]);        //
}
double[,] doubleArray = new double[intArraySize[0], intArraySize[1]];
doubleArray = FillArray(intArraySize);//Заполняем массив

Console.Write("Введите интересующую вас позицию в формате (строка, столбец)");
string strPosition = Console.ReadLine();
string[] strArrayOfPosition = strPosition.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
if (strArrayOfArraySize.Length != 2) //Если пользователь ввёл не два числа, то выдаём ошибку и выходим
{
    Console.WriteLine("У двухмерного массива два размера: количество строк и количество толбцов");
    return;
}
int[] intArrayOfPosition = new int[strArrayOfPosition.Length];             //Преобразуем строковый массив в массив целых
for (int i = 0; i < strArrayOfPosition.Length; i++)                  //
{
    intArrayOfPosition[i] = Convert.ToInt32(strArrayOfPosition[i]);        //
}

PrintArray(doubleArray);

if (intArrayOfPosition[0] > doubleArray.GetUpperBound(0) || intArrayOfPosition[1] > doubleArray.GetUpperBound(1))//Если количество строк
{                                                                                                                //в массиве или количество
    Console.WriteLine($"Элемента с позицией {intArrayOfPosition[0]}, {intArrayOfPosition[1]} в данном массиве нет.");
    return;
}

Console.WriteLine($"Элемент с позицией {intArrayOfPosition[0]}, {intArrayOfPosition[1]} -> {doubleArray[intArrayOfPosition[0], intArrayOfPosition[1]]}.");

double[,] FillArray(int[] intArraySize) //Функция заполняет массив случайными числами. На вход получает массив размеров, возвращает двухмерный массив
{
    var random = new Random();
    var randomInt = new Random();
    double[,] resultArray = new double[intArraySize[0], intArraySize[1]];
    for (int i = 0; i < intArraySize[0]; i++)
    {
        for (int j = 0; j < intArraySize[1]; j++)
        {
            resultArray[i, j] = random.NextDouble() * randomInt.Next(-100, 100);
        }
    }
    return resultArray;
}

void PrintArray(double[,] arr)//Метод выводит массив на экран в формате [.., .., .., ..]
{

    for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
    {
        for (int j = 0; j < arr.GetUpperBound(1) + 1; j++)
        {
            if (i == arr.GetUpperBound(0) && j == arr.GetUpperBound(1))
            {
                Console.Write($"{arr[i, j]}");
            }
            else
            {
                Console.Write($"{arr[i, j]}, ");
            }

        }
        Console.WriteLine("");
    }

}