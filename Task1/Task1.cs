using System;

namespace Task1
{
    class GameEntity
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public bool CanTalk { get; set; }
        public bool CanAttack { get; set; }
        public bool CanMove { get; set; }
        public bool HasHealth { get; set; }

        public void Move()
        {
            if (CanMove)
                Console.WriteLine($"{Name} is moving.");
            else
                Console.WriteLine($"{Name} can't move.");
        }

        public void Attack()
        {
            if (CanAttack)
                Console.WriteLine($"{Name} attacks for 10 damage!");
            else
                Console.WriteLine($"{Name} can't attack.");
        }

        public void Talk()
        {
            if (CanTalk)
                Console.WriteLine($"{Name} says: Hello!");
            else
                Console.WriteLine($"{Name} can't talk.");
        }

        public void TakeDamage(int damage)
        {
            if (HasHealth)
            {
                Health -= damage;
                if (Health < 0) Health = 0;
                Console.WriteLine($"{Name} took {damage} damage. Health left: {Health}");
            }
            else
                Console.WriteLine($"{Name} has no health to damage.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создание и демонстрация Player
            GameEntity player = new GameEntity
            {
                Name = "Hero",
                Health = 100,
                CanTalk = true,
                CanAttack = true,
                CanMove = true,
                HasHealth = true
            };
            Console.WriteLine("Player actions:");
            player.Move();
            player.Talk();
            player.Attack();
            player.TakeDamage(10);

            // Создание и демонстрация Loader
            GameEntity loader = new GameEntity
            {
                Name = "Bob the Loader",
                Health = 0,
                CanTalk = true,
                CanAttack = false,
                CanMove = true,
                HasHealth = false
            };
            Console.WriteLine("\nLoader actions:");
            loader.Move();
            loader.Talk();
            loader.Attack();
            loader.TakeDamage(10);

            // Создание и демонстрация Zombie
            GameEntity zombie = new GameEntity
            {
                Name = "Zombie",
                Health = 50,
                CanTalk = false,
                CanAttack = true,
                CanMove = true,
                HasHealth = true
            };
            Console.WriteLine("\nZombie actions:");
            zombie.Move();
            zombie.Talk();
            zombie.Attack();
            zombie.TakeDamage(10);

            Console.ReadLine(); // Чтобы консоль не закрывалась сразу
        }
    }
}
