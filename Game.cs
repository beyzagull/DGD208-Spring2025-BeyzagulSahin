using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Game
{
    private bool _isRunning;
    private List<Pet> adoptedPets = new List<Pet>();

    public async Task GameLoop()
    {
        Initialize();

        _isRunning = true;
        while (_isRunning)
        {
            string userChoice = GetUserInput();
            await ProcessUserChoice(userChoice);
        }

        Console.WriteLine("✨🌈 Thanks for playing, magical creature whisperer!");
    }

    private void Initialize()
    {
        Console.WriteLine("🐾🌟 Welcome to the ✨ Whimsical Pet Realms ✨");
        Console.WriteLine("🦋 Crafted with cosmic love by: Beyzagul Sahin 🌙\n");
    }

    private string GetUserInput()
    {
        Console.WriteLine("\n🌸 === Main Portal === 🌸");
        Console.WriteLine("1. 🐣 Adopt a mystical pet");
        Console.WriteLine("2. 📊 Peek at their precious stats");
        Console.WriteLine("3. 🍭 Use magical items");
        Console.WriteLine("4. 🧙‍♀️ Who made this?");
        Console.WriteLine("0. 🚪 Exit back to the human world");
        Console.Write("🧁 Choose your path: ");
        return Console.ReadLine();
    }

    private async Task ProcessUserChoice(string choice)
    {
        switch (choice)
        {
            case "1":
                AdoptPet();
                break;

            case "2":
                ViewPetStats();
                break;

            case "3":
                await UseItemOnPet();
                break;

            case "4":
                Console.WriteLine("🧵✨ This world was stitched together by: Beyzagul Sahin");
                break;

            case "0":
                _isRunning = false;
                break;

            default:
                Console.WriteLine("👽 Whoopsie-doopsie! That’s not a valid option. Try again?");
                break;
        }
    }

    private void AdoptPet()
    {
        var magicalCreatures = new List<string>
        {
            "🌬️ Northern Swallow Bird",
            "🐢 Turtle",
            "💧 Water Lizard",
            "🐲 Dragon",
            "🦖 Dinosaur"
        };

        var menu = new Menu<string>("✨ Choose your soul-bonded creature", magicalCreatures, pet => pet);
        string selected = menu.ShowAndGetSelection();

        if (string.IsNullOrEmpty(selected)) return;

        Console.Write("🌟 Name your companion: ");
        string name = Console.ReadLine();

        var pet = new Pet(name, PetType.Dog); // dummy type
        pet.OnPetDied += HandlePetDeath;

        adoptedPets.Add(pet);
        Console.WriteLine($"🎉 {selected} named '{name}' has fluttered into your life!");
    }

    private void ViewPetStats()
    {
        if (adoptedPets.Count == 0)
        {
            Console.WriteLine("😿 No little buddies adopted yet... The realm awaits!");
            return;
        }

        Console.WriteLine("\n🧚 Your current companions:");
        foreach (var pet in adoptedPets)
        {
            pet.DisplayStats();
        }
    }

    private async Task UseItemOnPet()
    {
        if (adoptedPets.Count == 0)
        {
            Console.WriteLine("🪄 You need a pet first to sprinkle magic upon!");
            return;
        }

        var petMenu = new Menu<Pet>("🎯 Choose your beloved pet", adoptedPets, pet => pet.Name);
        var selectedPet = petMenu.ShowAndGetSelection();
        if (selectedPet == null) return;

        var compatibleItems = ItemDatabase.AllItems
            .Where(i => i.CompatibleWith.Contains(selectedPet.Type))
            .ToList();

        var itemMenu = new Menu<Item>("🎁 Pick a magic item", compatibleItems, item => $"{item.Name} (+{item.EffectAmount} {item.AffectedStat})");
        var selectedItem = itemMenu.ShowAndGetSelection();
        if (selectedItem == null) return;

        Console.WriteLine($"⏳ Using {selectedItem.Name} on {selectedPet.Name}... please hold your unicorns...");
        await Task.Delay(TimeSpan.FromSeconds(selectedItem.Duration));

        selectedPet.ApplyItem(selectedItem);
        Console.WriteLine($"💫 Sparkles! {selectedItem.Name} worked wonders on {selectedPet.Name}!");
    }

    private void HandlePetDeath(Pet pet)
    {
        Console.WriteLine($"\n💔 Oh no... {pet.Name} has passed into the stars... 🌠");
        adoptedPets.Remove(pet);
    }
}
