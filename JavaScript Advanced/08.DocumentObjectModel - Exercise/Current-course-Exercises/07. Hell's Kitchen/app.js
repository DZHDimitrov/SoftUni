function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let inputElement = document.querySelector('#inputs textarea');
      let text = inputElement.value;
      text = text.replace(/[\[,\n]/g, '');
      let array = [];
      let arrElement = '';
      let quoteCounter = 0;
      for (let i = 0; i < text.length; i++) {
         if (quoteCounter == 2) {
            array.push(arrElement);
            arrElement = '';
            quoteCounter = 0;
         }
         if (text[i] == '\x22') {
            quoteCounter++;
            continue;
         }
         arrElement += text[i];
      }
      let objects = [];
      for (let i = 0; i < array.length; i++) {
         let line = array[i].split(' - ');
         let restaurant = {};
         restaurant.name = line[0];
         let workersArray = [];
         let workers = line[1].split(' ');
         workers.forEach((x,i) => {
            if (i % 2 == 0) {
               let worker = {};
               worker.name = workers[i];
               worker.salary = workers[i+1];
               workersArray.push(worker);
            }
         });
         restaurant.workers = workersArray;
         objects.push(restaurant);
      }
      console.log(array);
      let testAverage = objects[0].workers.reduce((acc,el) => acc + Number(el.salary),0) / objects[0].workers.length;
      objects.sort((a,b) => {
         let averageSalaryA = a.workers.reduce((acc,el) => acc + Number(el.salary),0) / a.workers.length;
         let averageSalaryB = b.workers.reduce((acc,el) => acc + Number(el.salary),0) / b.workers.length;
         if (averageSalaryA > averageSalaryB) {
            return -1;
         }
         else if (averageSalaryA < averageSalaryB) {
            return 1;
         }
         else {
            return 0;
         }
      });
      
      let bestSalary = 0;
      let bestRestaurantName = objects[0].name;
      let bestRestaurantAvgSalary = (objects[0].workers.reduce((acc,el) => acc + Number(el.salary),0) / objects[0].workers.length).toFixed(2);
      let bestRestaurantWorkers = objects[0].workers;
      for (let i = 0; i < bestRestaurantWorkers.length; i++) {
         if (Number(bestRestaurantWorkers[i].salary) > bestSalary) {
            bestSalary = Number(bestRestaurantWorkers[i].salary).toFixed(2);
         }
      }
      
      let bestRestaurantElement = document.getElementById('bestRestaurant');
      let lastChild = bestRestaurantElement.lastElementChild;
      lastChild.innerHTML = `Name: ${bestRestaurantName} Average Salary: ${bestRestaurantAvgSalary} Best Salary: ${bestSalary}`;

      let workersElement = document.getElementById('workers');
      let lastWorkerElementChild = workersElement.lastElementChild;
      objects[0].workers.forEach(x=> {
         lastWorkerElementChild.innerHTML += `Name: ${x.name} With Salary: ${x.salary} `;
      })
   }
}