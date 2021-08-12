using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private ICollection<Character> characters = new List<Character>();
		private ICollection<Item> items = new List<Item>();
		public WarController()
		{

		}

		public string JoinParty(string[] args)
		{
			string charType = args[0];
			string charName = args[1];
            if (charType != "Warrior" && charType != "Priest")
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, charType));
            }
			Character character = null;
            if (charType == "Warrior")
            {
				character = new Warrior(charName);
            }
            else if (charType == "Priest")
            {
				character = new Priest(charName);

			}
			this.characters.Add(character);
			return $"{string.Format(SuccessMessages.JoinParty,charName)}";
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];
			Item item = null;
            if (itemName != "FirePotion" && itemName != "HealthPotion")
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem,itemName));
            }
            if (itemName == "FirePotion")
            {
				item = new FirePotion();
            }
            else if (itemName == "HealthPotion")
            {
				item = new HealthPotion();
            }
			this.items.Add(item);

			return $"{string.Format(SuccessMessages.AddItemToPool,itemName)}";
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];
			var character = this.characters.FirstOrDefault(x => x.Name == characterName);
            if (character == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            if (this.items.Count == 0)
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }
			var item = this.items.Last();
			this.items.Remove(item);
			character.Bag.AddItem(item);
			return $"{string.Format(SuccessMessages.PickUpItem,characterName,item.GetType().Name)}";
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			var character = this.characters.FirstOrDefault(x => x.Name == characterName);
			if (character == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}
			var test = character.Bag.GetItem(itemName);

			character.UseItem(test);

			return $"{string.Format(SuccessMessages.UsedItem,characterName,itemName)}";

		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();
            foreach (var hero in this.characters.OrderByDescending(x=>x.IsAlive).ThenByDescending(x=>x.Health))
            {
				var isAlive = hero.IsAlive == true ? "Alive" : "Dead";
				sb.AppendLine($"{hero.Name} - HP: {hero.Health}/{hero.BaseHealth}, AP: {hero.Armor}/{hero.BaseArmor}, Status: {isAlive}");
            }

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			StringBuilder sb = new StringBuilder();
			string attackerName = args[0];
			string recieverName = args[1];
			var attacker = this.characters.FirstOrDefault(x => x.Name == attackerName);
			var reciever = this.characters.FirstOrDefault(x => x.Name == recieverName);

			if (attacker == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
			}
            if (reciever == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, recieverName));
			}

            if (attacker is IAttacker)
            {
				IAttacker currentAttacker = attacker as IAttacker;
				currentAttacker.Attack(reciever);
				sb.AppendLine(
					$"{attacker.Name} attacks {reciever.Name} for {attacker.AbilityPoints} hit points!" +
					$" {reciever.Name} has {reciever.Health}/{reciever.BaseHealth} HP and" +
					$" {reciever.Armor}/{reciever.BaseArmor} AP left!");

                if (!reciever.IsAlive)
                {
					sb.AppendLine($"{reciever.Name} is dead!");
                }
				return sb.ToString().TrimEnd();
            }
            else
            {
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
			}
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingRecieverName = args[1];
			StringBuilder sb = new StringBuilder();
			var healer = this.characters.FirstOrDefault(x => x.Name == healerName);
			var healReciever = this.characters.FirstOrDefault(x => x.Name == healingRecieverName);

			if (healer == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
			}
			if (healReciever == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingRecieverName));
			}

            if (healer is IHealer)
            {
				var currentHealer = healer as IHealer;
				currentHealer.Heal(healReciever);

				sb.AppendLine($"{healer.Name} heals {healReciever.Name} for {healer.AbilityPoints}! {healReciever.Name} has {healReciever.Health} health now!");
				return sb.ToString().TrimEnd();
			}
            else
            {
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }
		}
	}
}
