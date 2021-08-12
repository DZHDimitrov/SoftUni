using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.

        private string name;
        private double health;
        private double armor;
        private double baseArmor;
        private double baseHealth;
        private bool baseArmorIsSet = false;
        private bool baseHealthIsSet = false;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.BaseHealth = health;
            this.BaseArmor = armor;
            this.Name = name;
            this.Health = health;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;

        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                this.name = value;
            }
        }

        public double Health
        {
            get
            {
                return this.health;
            }
            set
            {
                if (value > this.BaseHealth)
                {
                    this.health = BaseHealth;
                }
                else if (value < 0)
                {
                    this.health = 0;
                }
                else
                {
                    this.health = value;
                }
            }
        }

        public double BaseHealth
        {
            get
            {
                return this.baseHealth;
            }
            private set
            {
                if (this.baseHealthIsSet == false)
                {
                    this.baseHealth = value;
                    this.baseHealthIsSet = true;
                }
            }
        }

        public double BaseArmor
        {
            get
            {
                return this.baseArmor;
            }
            private set
            {
                if (this.baseArmorIsSet == false)
                {
                    this.baseArmor = value;
                    this.baseArmorIsSet = true;
                }
            }
        }

        public double Armor
        {
            get
            {
                return this.armor;
            }
            private set
            {
                if (value < 0)
                {
                    this.armor = 0;
                }
                this.armor = value;
            }
        }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; set; }


        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();

            if (this.Armor >= hitPoints)
            {
                this.Armor -= hitPoints;
            }
            else
            {
                this.Health -= Math.Abs(this.Armor);

                this.Armor = 0;

                if (Health <= 0)
                {
                    Health = 0;

                    IsAlive = false;
                }
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
        }
    }
}