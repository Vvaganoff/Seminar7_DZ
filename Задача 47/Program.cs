//Задача 47.Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.

//m = 3, n = 4.

//0,5 7 -2 -0,2

//1 -3,3 8 -9,9

//8 7,8 -7,1 9

Console.Write("Введите размер двухмерного массива: ");
string strArraySize = Console.ReadLine(); //Пользователь вводит два размера: количество строк и столбцов
char[] charSeparators = new char[] { ' ', 'x', '+', '*', 'X', '-', ',', ';' };//Определяем, чем пользователь может отделить размеры
string[] strArrayOfArraySize = strArraySize.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

if (strArrayOfArraySize.Length != 2) //Если пользователь ввёл не два числа, то выдаём ошибку и выхдим
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
PrintArray(doubleArray);

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