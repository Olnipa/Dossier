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
                        WriteArray(fullNameArray, employeePositionArray, fullNameArray.Length);
                        break;
                    case ConsoleKey.D3:
                        DeleteDossier(ref fullNameArray, ref employeePositionArray) ;
                        break;
                    case ConsoleKey.D4:
                        SearchBySurname(fullNameArray, employeePositionArray);                       
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
        static void DeleteDossier(ref string[] fullNameArray, ref string[] employeePositionArray)
        {
            int decreaseArray = -1;
            int isDelete = 1;
            int indexSurnameForDelete = SearchIndex(fullNameArray, "Укажите Фамилию, чье досье необходимо удалить: ");

            if (indexSurnameForDelete >= 0)
            {
                Console.Write("\nВы пытаетесь удалить досье №");
                WriteArray(fullNameArray, employeePositionArray, indexSurnameForDelete + 1, indexSurnameForDelete, "\n1 - Подтвердить удаление. 0 - Отменить удаление.");
                ConsoleKeyInfo choosenConfirmationMenu = Console.ReadKey(true);

                switch (choosenConfirmationMenu.Key)
                {
                    case ConsoleKey.D1:
                        EditArrays(ref fullNameArray, indexSurnameForDelete, decreaseArray, isDelete);
                        EditArrays(ref employeePositionArray, indexSurnameForDelete, decreaseArray, isDelete);
                        StyleOfSystemMessage("Данные успешно удалены. Для продолжения нажмите любую клавишу...", ConsoleColor.Green);
                        Console.ReadKey(true);
                        break;
                    default:
                        StyleOfSystemMessage("Удаление отменено.");
                        break;
                }
            }
            else
            {
                StyleOfSystemMessage("Такой фамилии не найдено.");
            }
        }
        static void SearchBySurname(string[] fullNameArray, string[] employeePositionArray)
        {
            int indexSearchSurname = SearchIndex(fullNameArray);

            if (indexSearchSurname >= 0)
            {
                Console.WriteLine();
                WriteArray(fullNameArray, employeePositionArray, indexSearchSurname + 1, indexSearchSurname);
            }
            else
            {
                StyleOfSystemMessage("Такой фамилии не найдено.");
            }
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
        static int SearchIndex(string[] fullName, string text = "Введите фамилию для поиска досье: ", int surnameIndex = 0)
        {
            int index = -1;
            string surnameSearch = ReadText(text);

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
        static void WriteArray(string[] fullName, string[] employeePositionArray, int maxCycles, int x = 0, string text = "\nДля продолжения нажмите любую клавишу...")
        {
            for (int i = x; i < maxCycles; i++)
            {
                Console.Write(i + 1 + ". ");
                Console.Write(fullName[i]);
                Console.WriteLine(" - " + employeePositionArray[i]);
            }
            Console.WriteLine(text);

            if (text == "\nДля продолжения нажмите любую клавишу...")
            {
                Console.ReadKey(true);
            }
         }
    }
}