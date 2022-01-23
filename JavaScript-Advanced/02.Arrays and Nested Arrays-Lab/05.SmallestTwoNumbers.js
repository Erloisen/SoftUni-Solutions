function sortedArray (array) {
    array.sort((a, b) => a - b);
    let newArray = array.slice(0, 2);
    
    console.log(newArray.join(' '));
}

sortedArray([30, 15, 50, 5]);
sortedArray([3, 0, 10, 4, 7, 3]);