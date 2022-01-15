function convertToUpperCase (input) {
    let newInput = input.match(/[\w]+/g).join(", ");
    
    console.log(newInput.toUpperCase());
}

convertToUpperCase('Hi, how are you?');
convertToUpperCase('hello');
convertToUpperCase('Functions in JS can be nested, i.e. hold other functions');