function solve() { 
    class Mage {
        constructor (name) {
            this.name = name;
            this.health = 100;
            this.mana = 100;
        }
        cast(spellname) {
            this.mana--;
            console.log(`${this.name} cast ${spellname}`);
        }
    }
    class Fighter {
        constructor (name) {
            this.name = name;
            this.health = 100;
            this.stamina = 100;
        }
        fight() {
            this.stamina--;
            console.log(`${this.name} slashes at the foe!`);
        }
    }
    let obj = {
        mage: function(mageName) {
            return new Mage(mageName);
        },
        fighter: function(fighterName) {
            return new Fighter(fighterName);
        }
    }
    return obj;
}

let create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball")
scorcher.cast("thunder")
scorcher.cast("light")

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight()

console.log(scorcher2.stamina);
console.log(scorcher.mana);
