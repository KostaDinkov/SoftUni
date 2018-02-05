function box_count(bottles, box_capacity){

    return Math.ceil(bottles / box_capacity);
}

console.log(box_count(5, 10));