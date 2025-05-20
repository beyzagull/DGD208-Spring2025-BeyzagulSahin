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
            OnPetDied?.Invoke(this);
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
        Console.WriteLine($"[{Name}] - Hunger: {Hunger}, Sleep: {Sleep}, Fun: {Fun}");
    }
}
