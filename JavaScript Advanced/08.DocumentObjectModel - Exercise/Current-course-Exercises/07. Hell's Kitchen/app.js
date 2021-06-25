function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let inputTextArea = document.querySelector('#inputs textarea').value;
      let test = Array.from(inputTextArea);
      inputTextArea = Array.from(inputTextArea).filter(x => x !== ']' && x !== '[').join('');
      inputTextArea = inputTextArea.split('"').filter(x => x !== '' && x !== ',\n' && x !== '\n' && x !== ',');

      let mainObj = {};

      inputTextArea.forEach(x => {
         let line = x.split(' - ');

         let restaurantName = line[0];
         let workersLine = line[1].split(', ');

         if (!mainObj[restaurantName]) {
            mainObj[restaurantName] = {};
            mainObj[restaurantName]['workers'] = [];
         }
         workersLine.forEach(y => {
            let workersInfo = y.split(' ');
            let name = workersInfo[0];
            let salary = Number(workersInfo[1]);

            let currentWorker = { name, salary };
            if (mainObj[restaurantName]['workers'].some(x=>x.name == currentWorker.name)) {
               let worker = mainObj[restaurantName]['workers'].find(x=>x.name == currentWorker.name);
               worker.salary = salary;
            }else {
               mainObj[restaurantName]['workers'].push(currentWorker);
            }
         })
      });
      let bestRestaurant = calculateAverageSalary(mainObj);
      let bestRestaurantName = bestRestaurant[0];
      let bestRestaurantAvgSalary = bestRestaurant[1].averageSalary;
      let sortedWorkers = bestRestaurant[1].workers.sort((a,b) => b.salary - a.salary);

      let outputBestRestaurant = document.querySelector('#outputs p');
      outputBestRestaurant.textContent = `Name: ${bestRestaurantName} Average Salary: ${bestRestaurantAvgSalary.toFixed(2)} Best Salary: ${sortedWorkers[0].salary.toFixed(2)}`;

      let outputBestRestaurantWorkers = document.querySelector('#workers p');
      sortedWorkers.forEach(x=> {
         outputBestRestaurantWorkers.textContent += `Name: ${x.name} With Salary: ${x.salary} `;
      })

      
   }
   function calculateAverageSalary(mainObj){
      Object.keys(mainObj).forEach(x=>{
         let currentRestaurant = x;
         let currentWorkers = mainObj[x]['workers'];

         let current = currentWorkers.reduce((acc,{name,salary})  =>{
            acc += salary;
            return acc;
         },0);
         let avgSalary = current / currentWorkers.length
         mainObj[x]['averageSalary'] = Number(avgSalary.toFixed(2));
      })
      let bestRestaurant = Object.entries(mainObj).sort((a,b) => {
         

         if (b[1]['averageSalary'] - a[1]['averageSalary'] !== 0) {
            return b[1]['averageSalary'] - a[1]['averageSalary']
         } else {
            return a[1]['averageSalary'] - b[1]['averageSalary']
         }
      })[0];

      return bestRestaurant;
   }
}