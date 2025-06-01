public static class ItemDatabase
{
    public static List<Item> AllItems = new List<Item>
    {
        // 🌬️ Northern Swallow Bird
        new Item {
            Name = "Feather Seed Mix",
            Type = ItemType.Food,
            CompatibleWith = new List<PetType> { PetType.Bird },
            AffectedStat = PetStat.Hunger,
            EffectAmount = 15,
            Duration = 1.5f
        },
        new Item {
            Name = "Sky Spinner",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Bird },
            AffectedStat = PetStat.Fun,
            EffectAmount = 20,
            Duration = 2.5f
        },
        new Item {
            Name = "Cloud Nest",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Bird },
            AffectedStat = PetStat.Sleep,
            EffectAmount = 30,
            Duration = 3.0f
        },

        // 🐢 Turtle
        new Item {
            Name = "Crunchy Lettuce",
            Type = ItemType.Food,
            CompatibleWith = new List<PetType> { PetType.Rabbit },
            AffectedStat = PetStat.Hunger,
            EffectAmount = 20,
            Duration = 3.0f
        },
        new Item {
            Name = "Shell Brush",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Rabbit },
            AffectedStat = PetStat.Fun,
            EffectAmount = 15,
            Duration = 3.5f
        },
        new Item {
            Name = "Cozy Mud Blanket",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Rabbit },
            AffectedStat = PetStat.Sleep,
            EffectAmount = 25,
            Duration = 4.0f
        },

        // 🐲 Dragon
        new Item {
            Name = "Spicy Ember Treat",
            Type = ItemType.Food,
            CompatibleWith = new List<PetType> { PetType.Dog },
            AffectedStat = PetStat.Hunger,
            EffectAmount = 25,
            Duration = 3.5f
        },
        new Item {
            Name = "Fireball Toy",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Dog },
            AffectedStat = PetStat.Fun,
            EffectAmount = 30,
            Duration = 3.0f
        },
        new Item {
            Name = "Lava Nest",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Dog },
            AffectedStat = PetStat.Sleep,
            EffectAmount = 40,
            Duration = 5.0f
        },

        // 🦖 Dinosaur
        new Item {
            Name = "Jurassic Leaf Snack",
            Type = ItemType.Food,
            CompatibleWith = new List<PetType> { PetType.Cat },
            AffectedStat = PetStat.Hunger,
            EffectAmount = 22,
            Duration = 3.0f
        },
        new Item {
            Name = "Bone Cruncher",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Cat },
            AffectedStat = PetStat.Fun,
            EffectAmount = 18,
            Duration = 2.0f
        },
        new Item {
            Name = "Volcanic Rock Bed",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Cat },
            AffectedStat = PetStat.Sleep,
            EffectAmount = 35,
            Duration = 4.5f
        },

        // 👻 Gulyabani
        new Item {
            Name = "Dark Mist Soup",
            Type = ItemType.Food,
            CompatibleWith = new List<PetType> { PetType.Ghost },
            AffectedStat = PetStat.Hunger,
            EffectAmount = 18,
            Duration = 2.0f
        },
        new Item {
            Name = "Haunted Whistle",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Ghost },
            AffectedStat = PetStat.Fun,
            EffectAmount = 25,
            Duration = 2.5f
        },
        new Item {
            Name = "Eerie Blanket",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Ghost },
            AffectedStat = PetStat.Sleep,
            EffectAmount = 28,
            Duration = 3.5f
        }
    };
}
