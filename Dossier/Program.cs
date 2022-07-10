// See https://aka.ms/new-console-template for more information
using System;

namespace sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] fullName = new string[0, 3];
            bool isWorking = true;
            string[] employeePositionArray = new string[0];

            while (isWorking)
            {
                Console.WriteLine("\nВыберите соответствующую цифру на клавиатуре: 1 - Добавить досье. 2 - Вывести все досье. 3 - удалить досье. 4 - поиск по фамилии. 5 - выход\n");
                ConsoleKeyInfo choosenMenu = Console.ReadKey(true);

                switch (choosenMenu.Key)
                {
                    case ConsoleKey.D1:
                        string surname = "";
                        string name = "";
                        string middleName = "";
                        string employeePosition = "";

                        surname = Read("Введите Фамилию: ");
                        name = Read("Введите Имя: ");
                        middleName = Read("Введите Отчество: ");
                        employeePosition = Read("Введите должность: ");

                        string[,] tempFullName = new string[fullName.GetLength(0) + 1, fullName.GetLength(1)];
                        string[] tempEmployeeArray = new string[employeePositionArray.Length + 1];

                        for (int i = 0; i < fullName.GetLength(0); i++)
                        {
                            tempEmployeeArray[i] = employeePositionArray[i];

                            for (int j = 0; j < fullName.GetLength(1); j++)
                            {
                                tempFullName[i, j] = fullName[i, j];
                            }
                        }

                        tempFullName[tempFullName.GetLength(0) - 1, 0] = surname;
                        tempFullName[tempFullName.GetLength(0) - 1, 1] = name;
                        tempFullName[tempFullName.GetLength(0) - 1, 2] = middleName;
                        tempEmployeeArray[tempEmployeeArray.Length - 1] = employeePosition;
                        fullName = tempFullName;
                        employeePositionArray = tempEmployeeArray;

                        break;
                    case ConsoleKey.D2:

                        for (int i = 0; i < fullName.GetLength(0); i++)
                        {
                            Console.Write(i + 1 + ". ");

                            for (int j = 0; j < fullName.GetLength(1); j++)
                            {
                                Console.Write(fullName[i, j] + " ");
                            }
                            Console.WriteLine(" -  " + employeePositionArray[i]);
                        }
                        break;
                    case ConsoleKey.D3:
                        break;
                    case ConsoleKey.D4:
                        break;
                    case ConsoleKey.D5:
                        isWorking = false;
                        break;
                }
            }
        }

        static string Read(string text)
        {
            string value = "";

            while (value.Length < 2)
            {
                Console.Write(text);
                value = Console.ReadLine();

                if (value.Length < 2)
                {
                    ConsoleColor defaultColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Пожалуйста, введите данные без сокращений.");
                    Console.ForegroundColor = defaultColor;
                }
            }
            return value;
        }
    }
}
