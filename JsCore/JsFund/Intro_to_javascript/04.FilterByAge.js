function FilterByAge(thr, name1,age1,name2,age2){

    let person1 = {name:name1, age:age1};
    let person2 = {name:name2, age:age2};

    if(person1.age >=thr){
        console.log(person1);
    }
    if(person2.age >=thr){
        console.log(person2);
    }
}

//result = FilterByAge(16,'Hristofor',99,'Asen',16);
//console.log(result);