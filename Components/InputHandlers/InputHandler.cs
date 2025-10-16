namespace RPGGame.Components.InputHandlers
{
    static class InputHandler
    {
        static public int SelectOption(string inputLabel, int minOption, int maxOption)
        {
            while(true)
            {
                Console.Write(inputLabel);
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= minOption && choice <= maxOption) return choice;          
                Error("Wpisano nieprawidłowe dane!");
            }
        }
        static public string GetString(string inputLabel)
        {
            string ?input;
            while(true)
            {
                Console.Write(inputLabel);
                input = Console.ReadLine();
                if (input != null && input.Trim() != "") return input;
                else Error("Nieprawidłowe dane!");
            }
        }
        static private void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
