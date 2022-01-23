function sortedArray (array) {
    array.sort((a, b) => a - b);
    let startIndex = Math.floor(array.length / 2);
    const newArray = array.slice(startIndex);

    return newArray;
}

console.log(sortedArray([4, 7, 2, 5]));
console.log(sortedArray([3, 19, 14, 7, 2, 19, 6]));