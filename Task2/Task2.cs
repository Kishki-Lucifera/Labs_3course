using System;

namespace Task2
{
    abstract class GameEntity
    {
        public virtual void Move()
        {
            Console.WriteLine("Entity is moving.");
        }
    }

    abstract class Character : GameEntity
    {
        public int Health { get; set; }
        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
            Console.WriteLine($"Took {damage} damage. Health left: {Health}");
        }
    }

    class TalkableCharacter : Character
    {
        public string Name { get; set; }
        public void Talk()
        {
            Console.WriteLine($"{Name} says: Hello!");
        }

        public override void Move()
        {
            Console.WriteLine($"{Name} is moving.");
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            Console.WriteLine($"{Name} took {damage} damage. Health left: {Health}");
        }
    }

    class AttackingCharacter : Character
    {
        public void Attack()
        {
            Console.WriteLine("Attacks for 10 damage!");
        }

        public override void Move()
        {
            Console.WriteLine("Entity is moving."); // Для Zombie без имени
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            Console.WriteLine($"Zombie took {damage} damage. Health left: {Health}");
        }
    }

    class Player : TalkableCharacter
    {
        // Дублирование Attack, т.к. нельзя наследовать от обоих Talkable и Attacking
        public void Attack()
        {
            Console.WriteLine($"{Name} attacks for 10 damage!");
        }
    }

    class Loader : TalkableCharacter
    {
        // Нет Attack, как требуется
    }

    class Zombie : AttackingCharacter
    {
        // Нет Name и Talk, как требуется
        public override void Move()
        {
            Console.WriteLine("Zombie is moving.");
        }

        public void Attack()
        {
            Console.WriteLine("Zombie attacks for 10 damage!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создание и демонстрация Player
            Player player = new Player
            {
                Name = "Hero",
                Health = 100
            };
            Console.WriteLine("Player actions:");
            player.Move();
            player.Talk();
            player.Attack();
            player.TakeDamage(10);

            // Создание и демонстрация Loader
            Loader loader = new Loader
            {
                Name = "Bob the Loader",
                Health = 0 // Хотя HasHealth=false подразумевается, но класс имеет Health
            };
            Console.WriteLine("\nLoader actions:");
            loader.Move();
            loader.Talk();
            // Нет Attack - не вызываем
            loader.TakeDamage(10); // Но Health=0, демонстрируем

            // Создание и демонстрация Zombie
            Zombie zombie = new Zombie
            {
                Health = 50
            };
            Console.WriteLine("\nZombie actions:");
            zombie.Move();
            // Нет Talk - не вызываем
            zombie.Attack();
            zombie.TakeDamage(10);

            Console.ReadLine(); // Чтобы консоль не закрывалась сразу
        }
    }
}
