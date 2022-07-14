using System;

namespace sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fullNameArray = new string[3] { "Петров Михаил Евгеньевич", "Васильев Евгений Иванович", "Дроздов Николай Петрович"};
            bool isWorking = true;
            string[] employeePositionArray = new string[3] { "Менеджер", "Сантехник", "Зоолог" };
            int surnameColumnNumber = 0;
            int nameColumnNumber = 1;
            int middleColumnNumber = 2;

            while (isWorking)
            {
                Console.WriteLine("\nВыберите соответствующую цифру на клавиатуре:\n1 - Добавить досье. 2 - Вывести все досье. " +
                    "3 - Удалить досье. 4 - Поиск досье по фамилии. 5 - Выход\n");
                ConsoleKeyInfo choosenMenu = Console.ReadKey(true);

                switch (choosenMenu.Key)
                {
                    case ConsoleKey.D1:
                        AddDossier(ref fullNameArray, ref employeePositionArray);
                        break;
                    case ConsoleKey.D2:
                        WriteArrays(fullNameArray, employeePositionArray, fullNameArray.Length);
                        break;
                    //case ConsoleKey.D3:
                    //    int decreaseArray = -1;
                    //    int isDelete = 1;
                    //    string surnameSearchForDelete = ReadText("Укажите Фамилию, чье досье необходимо удалить: ");
                    //    int indexSurnameForDelete = Search(surnameSearchForDelete, fullNameArray, surnameColumnNumber);

                    //    if (indexSurnameForDelete >= 0)
                    //    {
                    //        Console.Write("\nВы пытаетесь удалить досье №");
                    //        WriteArrays(fullNameArray, employeePositionArray, indexSurnameForDelete + 1, indexSurnameForDelete, surnameColumnNumber);
                    //        Console.WriteLine("\n1 - Подтвердить удаление. 0 - Отменить удаление.");
                    //        ConsoleKeyInfo choosenConfirmationMenu = Console.ReadKey(true);

                    //        switch (choosenConfirmationMenu.Key)
                    //        {
                    //            case ConsoleKey.D1:
                    //                EditArrays(ref fullNameArray, ref employeePositionArray, indexSurnameForDelete, decreaseArray, isDelete);
                    //                StyleOfSystemMessage("Данные успешно удалены. Для продолжения нажмите любую клавишу...", ConsoleColor.Green);
                    //                Console.ReadKey(true);
                    //                break;
                    //            default:
                    //                StyleOfSystemMessage("Удаление отменено.");
                    //                break;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        StyleOfSystemMessage("Такой фамилии не найдено.");
                    //    }

                    //    break;
                    case ConsoleKey.D4:
                        int indexSearchSurname = Search(fullNameArray);

                        if (indexSearchSurname >= 0)
                        {
                            WriteArrays(fullNameArray, employeePositionArray, indexSearchSurname + 1, indexSearchSurname);
                        }
                        else
                        {
                            StyleOfSystemMessage("Такой фамилии не найдено.");
                        }

                        break;
                    case ConsoleKey.D5:
                        isWorking = false;
                        break;
                    default:
                        int cursorPosition = Console.CursorTop - 4;
                        Console.SetCursorPosition(0, cursorPosition);
                        break;
                }
            }
        }
        static void SearchBySurname(string[] fullNameArray, string[] employeePositionArray, );
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
        static void EditArrays(ref string[] array, int indexForDelete = int.MaxValue, int addLines = 1, int isDelete = 0)
        {
            string[] tempArray = new string[array.Length + addLines];

            for (int i = 0; i < array.GetLength(0) - isDelete; i++)
            {
                if (i < indexForDelete)
                {
                    tempArray[i] = array[i];
                }
                else
                {
                    tempArray[i] = array[i + 1];
                }
            }

            array = tempArray;
        }
        static void WriteArrays(string[] fullName, string[] employeePositionArray, int maxCycles, int x = 0)
        {
            for (int i = x; i < maxCycles; i++)
            {
                Console.Write(i + 1 + ". ");
                Console.Write(fullName[i]);
                Console.WriteLine(" - " + employeePositionArray[i]);
            }
            Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey(true);
        }
        static int Search(string[] fullName, int surnameIndex = 0)
        {
            int index = -1;
            string surnameSearch = ReadText("Введите фамилию для поиска досье: ");
            
            for (int i = 0; i < fullName.Length; i++)
            {
                string[] separateWords = fullName[i].Split(' ');

                if (separateWords[surnameIndex].ToLower() == surnameSearch.ToLower())
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
        static void AddDossier(ref string[] fullNameArray, ref string[] employeePositionArray)
        {
            string fullName = "";
            string employeePosition = "";

            fullName = ReadText("Введите Фамилию, Имя и Отчество последовательно, через пробел: ");
            employeePosition = ReadText("Введите должность: ");
            EditArrays(ref fullNameArray);
            EditArrays(ref employeePositionArray);

            fullNameArray[fullNameArray.Length - 1] = fullName;
            employeePositionArray[employeePositionArray.Length - 1] = employeePosition;
            StyleOfSystemMessage("Данные успешно внесены. Для продолжения нажмите любую клавишу...", ConsoleColor.Green);
            Console.ReadKey(true);
        }
    }
}