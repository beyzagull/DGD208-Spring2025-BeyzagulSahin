using System.Collections.Generic;

public class Item
{
    // 🌟 Name of the magical item
    public string Name { get; set; }

    // 🍽️ What kind of item it is (Food or Toy)
    public ItemType Type { get; set; }

    // 🐾 Which pet types can use this item
    public List<PetType> CompatibleWith { get; set; }

    // ❤️ Which stat it boosts (Hunger, Sleep, Fun)
    public PetStat AffectedStat { get; set; }

    // 🎯 How much it affects that stat
    public int EffectAmount { get; set; }

    // ⏳ How long it takes to use this magical item (seconds)
    public float Duration { get; set; }
}
