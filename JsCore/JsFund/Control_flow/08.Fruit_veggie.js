function fruit_or_veggie(word){

    let fruits = ['banana', 'apple', 'kiwi', 'cherry', 'lemon', 'grapes', 'peach'];
    let veggies = ['tomato', 'cucumber', 'pepper', 'onion', 'garlic', 'parsley'];
    if (fruits.includes(word)){
        console.log('fruit');
    }
    else if (veggies.includes(word)){
        console.log('vegetable');
    }
    else {
        console.log('unknown');
    }
}

fruit_or_veggie('pizza');