using System;
using System.Collections.Generic;

/// <summary>
/// A simple console menu to select items.
/// </summary>
public class Menu<T>
{
    private readonly List<T> _items;
    private readonly string _title;
    private readonly Func<T, string> _displaySelector;

    public Menu(string title, List<T> items, Func<T, string> displaySelector)
    {
        _title = title;
        _items = items ?? new List<T>();
        _displaySelector = displaySelector ?? (item => item?.ToString() ?? "");
    }

    public T ShowAndGetSelection()
    {
        if (_items.Count == 0)
        {
            Console.WriteLine($"No options in {_title}. Press any key to continue...");
            Console.ReadKey();
            return default;
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("==================================");
            Console.WriteLine($"   { _title }");
            Console.WriteLine("==================================\n");
        

            for (int i = 0; i < _items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_displaySelector(_items[i])}");
            }

            Console.WriteLine("\n0. Back");
            Console.Write("\nEnter your choice: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int selection))
            {
                if (selection == 0)
                    return default;

                if (selection > 0 && selection <= _items.Count)
                    return _items[selection - 1];
            }

            Console.WriteLine("\nInvalid input. Press any key to try again...");
            Console.ReadKey();
        }
    }
}
