using System;
using System.Collections.Generic;


public class Pet
{
    public string Name { get; private set; }
    public PetType Type { get; private set; }


    public int Hunger { get; private set; }
    public int Sleep { get; private set; }
    public int Fun { get; private set; }


    public bool IsAlive => Hunger > 0 && Sleep > 0 && Fun > 0;


    public bool IsOnAdventure { get; private set; } = false;
    public event Action<Pet> OnPetLeftGame;
    public event Action<Pet> OnPetDied;


    public Pet(string name, PetType type)
    {
        Name = name;
        Type = type;
        Hunger = 50;
        Sleep = 50;
        Fun = 50;
    }


    public void DecreaseStats()
    {
        Hunger = Math.Max(0, Hunger - 1);
        Sleep = Math.Max(0, Sleep - 1);
        Fun = Math.Max(0, Fun - 1);


        if (!IsAlive)
        {
            TriggerLeaveBehavior();
        }
    }


    public void ApplyItem(Item item)
    {
        if (!item.CompatibleWith.Contains(Type))
        {
            Console.WriteLine("This item is not compatible with this pet.");
            return;
        }


        switch (item.AffectedStat)
        {
            case PetStat.Hunger:
                Hunger = Math.Min(100, Hunger + item.EffectAmount);
                break;
            case PetStat.Sleep:
                Sleep = Math.Min(100, Sleep + item.EffectAmount);
                break;
            case PetStat.Fun:
                Fun = Math.Min(100, Fun + item.EffectAmount);
                break;
        }
   
    }


    public void DisplayStats()
    {
        if (IsOnAdventure)
        {
            Console.WriteLine($"[{Name}] is currently exploring distant lands... 🌍");
            return;
        }


        Console.WriteLine($"[{Name}] - Hunger: {Hunger}, Sleep: {Sleep}, Fun: {Fun}");
    }


    private void TriggerLeaveBehavior()
    {
        IsOnAdventure = true;


        Console.WriteLine();
        switch (Type)
        {
            case PetType.Bird:
                Console.WriteLine("Your Northern Swallow Bird spread its wings and flew far away... You couldn't hold onto its freedom-loving soul.");
                break;
            case PetType.Rabbit:
                Console.WriteLine("The turtle retreats into its shell and refuses to come out again. It needs peace now.");
                break;
            case PetType.Cat:
                Console.WriteLine("The dinosaur's lineage has finally gone extinct. A moment of silence for the ancient one...");
                break;
            case PetType.Dog:
                Console.WriteLine("The dragon sets the nearest town ablaze and disappears into the clouds. Its wrath cannot be tamed.");
                break;
            case PetType.Ghost:
                Console.WriteLine("Gulyabani descends upon the village, spreading fear before vanishing into the mist.");
                break;
        }


        OnPetLeftGame?.Invoke(this);
    }
    public void Tick()
    {
        Hunger -= 5;
        if (Hunger < 0) Hunger = 0;

        Fun -= 3;
        if (Fun < 0) Fun = 0;

        Sleep -= 10;
        if (Sleep < 0) Sleep = 0;

      

        if (Hunger == 0 || Fun == 0 || Sleep == 0)
        {
            Die(); 
        }
    }
    public void Die()
    {
        
        OnPetDied?.Invoke(this);
    }

}
