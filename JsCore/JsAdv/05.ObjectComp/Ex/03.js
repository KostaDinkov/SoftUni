function solve(spec){

    let result = {};
    let engines  = [{power:90,volume:1800},{power:120,volume:2400},{power:200,volume:3500}];

    result.model = spec.model;
    result.engine  = engines.filter(e=>e.power >=spec.power).sort((a,b)=> a.power - b.power)[0];
    result.carriage = {type:spec.carriage,color:spec.color};
    let wheelsize = spec.wheelsize % 2 ===0?spec.wheelsize-1:spec.wheelsize;
    result.wheels = [wheelsize,wheelsize,wheelsize,wheelsize];
    return result

}

let spec = { model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14 };

console.log(solve(spec));
