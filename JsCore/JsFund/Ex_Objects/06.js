function sysComp(input_arr){
    let systems = new Map();

    //fill systems
    for (let row of input_arr) {
        let [system, component, subComp] = row.split(/ \| /g).filter(x=>x);

        if(!systems.has(system)){
            systems.set(system, new Map(([[component,[]]])));
            systems.get(system).get(component).push(subComp);
        }
        else{
            if(!systems.get(system).has(component)){
                systems.get(system).set(component,[]);
                systems.get(system).get(component).push(subComp);
            }
            else{
                systems.get(system).get(component).push(subComp);
            }
        }
    }


    //sort and print
    let sortedSystems =new Map([...systems.entries()].sort(systemsSort));

    for (let [system, stats] of sortedSystems) {
        console.log(system);
        let statsSorted = new Map([...stats.entries()].sort(compSort));

        for (let [comp, subComps] of statsSorted) {
            console.log(`|||${comp}`)
            for (let subComp of subComps) {
                console.log(`||||||${subComp}`)
            }
        }
    }

    // custom sort functions
    function systemsSort(a,b) {
        if(a[1].size > b[1].size){
            return -1;
        }
        else if(a[1].size === b[1].size){
            return a>b;
        }
        else{
            return 1;

        }
    }
    function compSort(a,b){
        return b[1].length -a[1].length;
    }

}

sysComp(['SULS | Main Site | Home Page' ,
    'SULS | Main Site | Login Page' ,
    'SULS | Main Site | Register Page' ,
    'SULS | Judge Site | Login Page' ,
    'SULS | Judge Site | Submittion Page' ,
    'Lambda | CoreA | A23' ,
    'SULS | Digital Site | Login Page' ,
    'Lambda | CoreB | B24' ,
    'Lambda | CoreA | A24' ,
    'Lambda | CoreA | A25' ,
    'Lambda | CoreC | C4' ,
    'Indice | Session | Default Storage' ,
    'Indice | Session | Default Security']);