function solve(worker){

    if(worker.handsShaking){
        worker.bloodAlcoholLevel += worker.weight*worker.experience*0.1;
        worker.handsShaking = false;
    }
    return worker;
}

let w = { weight: 80,
    experience: 1,
    bloodAlcoholLevel: 0,
    handsShaking: true };

console.log(solve(w));