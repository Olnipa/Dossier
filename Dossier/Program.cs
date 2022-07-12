using System;

namespace sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] fullNameArray = new string[3, 3] { 
                { "Петров", "Михаил", "Евгеньевич" }, 
                { "Васильев", "Евгений", "Иванович" }, 
                { "Дроздов", "Николай", "Петрович" } };
            bool isWorking = true;
            string[] employeePositionArray = new string[3] { "Менеджер", "Сантехник", "Зоолог" };
            int surnameColumnNumber = 0;
            int nameColumnNumber = 1;
            int middleColumnNumber = 2;

            while (isWorking)
            {
                Console.WriteLine("\nВыберите соответствующую цифру на клавиатуре: 1 - Добавить досье. 2 - Вывести все досье. " +
                    "3 - удалить досье. 4 - поиск по фамилии. 5 - выход\n");
                ConsoleKeyInfo choosenMenu = Console.ReadKey(true);

                switch (choosenMenu.Key)
                {
                    case ConsoleKey.D1:
                        string surname = "";
                        string name = "";
                        string middleName = "";
                        string employeePosition = "";

                        surname = ReadText("Введите Фамилию: ");
                        name = ReadText("Введите Имя: ");
                        middleName = ReadText("Введите Отчество: ");
                        employeePosition = ReadText("Введите должность: ");

                        EditArrays(ref fullNameArray, ref employeePositionArray);

                        fullNameArray[fullNameArray.GetLength(0) - 1, surnameColumnNumber] = surname;
                        fullNameArray[fullNameArray.GetLength(0) - 1, nameColumnNumber] = name;
                        fullNameArray[fullNameArray.GetLength(0) - 1, middleColumnNumber] = middleName;
                        employeePositionArray[employeePositionArray.Length - 1] = employeePosition;
                        StyleOfSystemMessage("Данные успешно внесены. Для продолжения нажмите любую клавишу...", ConsoleColor.Green);
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D2:
                        WriteArrays(fullNameArray, employeePositionArray, fullNameArray.GetLength(0));
                        Console.WriteLine("Для продолжения нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D3:
                        string surnameSearchForDelete = ReadText("Укажите Фамилию, чье досье необходимо удалить: ");
                        int indexSurnameForDelete = Search(surnameSearchForDelete, fullNameArray, surnameColumnNumber);
                        EditArrays(ref fullNameArray, ref employeePositionArray, indexSurnameForDelete, -1);
                        break;
                    case ConsoleKey.D4:
                        string surnameSearch = ReadText("Введите фамилию для поиска досье: ");
                        int indexSearchSurname = Search(surnameSearch, fullNameArray, surnameColumnNumber);
                        
                        if (indexSearchSurname >= 0)
                        {
                            WriteArrays(fullNameArray, employeePositionArray, indexSearchSurname + 1, indexSearchSurname, surnameColumnNumber);
                        }
                        else
                        {
                            StyleOfSystemMessage("Такой фамилии не найдено.");
                        }

                        Console.WriteLine("Для продолжения нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D5:
                        isWorking = false;
                        break;
                }
            }
        }
        static void StyleOfSystemMessage(string error, ConsoleColor color = ConsoleColor.Red)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(error);
            Console.ForegroundColor = defaultColor;
        }
        static string ReadText(string text)
        {
            string value = "";

            while (value.Length < 2)
            {
                Console.Write(text);
                value = Console.ReadLine();

                if (value.Length < 2)
                {
                    StyleOfSystemMessage("Пожалуйста, введите данные без сокращений.");
                }
            }

            return value;
        }
        static void EditArrays(ref string[,] arrayName, ref string[] arrayEmployee, int indexForDelete = int.MaxValue, int addLines = 1)
        {
            string[,] tempFullName = new string[arrayName.GetLength(0) + addLines, arrayName.GetLength(1)];
            string[] tempEmployeeArray = new string[arrayEmployee.Length + addLines];

            for (int i = 0; i < arrayName.GetLength(0); i++)
            {
                if (i < indexForDelete)
                {
                    tempEmployeeArray[i] = arrayEmployee[i];
                }
                else
                {
                    tempEmployeeArray[i] = arrayEmployee[i + 1];
                }

                for (int j = 0; j < arrayName.GetLength(1); j++)
                {
                    if (i < indexForDelete)
                    {
                        tempFullName[i, j] = arrayName[i, j];
                    }
                    else
                    {
                        tempFullName[i, j] = arrayName[i + 1, j];
                    }
                }
            }

            arrayName = tempFullName;
            arrayEmployee = tempEmployeeArray;
        }
        static void WriteArrays(string[,] fullName, string[] employeePositionArray, int maxLines, int x = 0, int y = 0)
        {
            for (int i = x; i < maxLines; i++)
            {
                Console.Write(i + 1 + ". ");

                for (int j = y; j < fullName.GetLength(1); j++)
                {
                    Console.Write(fullName[i, j] + " ");
                }

                Console.WriteLine("- " + employeePositionArray[i]);
            }
        }
        static int Search(string value, string[,] fullName, int position)
        {
            int index = -1;

            for (int i = 0; i < fullName.GetLength(0); i++)
            {
                if (fullName[i, position].ToLower() == value.ToLower())
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
    }
}
