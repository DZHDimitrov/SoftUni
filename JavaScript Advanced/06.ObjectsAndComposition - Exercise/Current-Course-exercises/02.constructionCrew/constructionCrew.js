class Worker {
    constructor (weight,experience,levelOfHydrated,dizziness) {
        this.weight = weight;
        this.experience = experience;
        this.levelOfHydrated = levelOfHydrated;
        this.dizziness = dizziness;
    }
}

function solve(worker) {

    if (worker.dizziness == true) {
        let hydrate = worker.weight * 0.1 * worker.experience;
        worker.levelOfHydrated += hydrate;
        worker.dizziness = false;
    }

    return worker;
}

let worker = { weight: 95,
    experience: 3,
    levelOfHydrated: 0,
    dizziness: false }
  ;
  
console.log(solve(worker));