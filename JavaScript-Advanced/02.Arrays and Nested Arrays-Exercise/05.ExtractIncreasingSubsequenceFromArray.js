function nonDecreasingSubset(array) {
    const increasingArray = [array[0]];

    array.reduce(function (previousValue, currentValue) {
        if (currentValue >= increasingArray[increasingArray.length - 1]) {
            increasingArray.push(currentValue);
        }
    });

    return increasingArray;
}

console.log(nonDecreasingSubset([1, 3, 8, 4, 10, 12, 3, 2, 24]));
console.log(nonDecreasingSubset([1, 2, 3, 4]));
console.log(nonDecreasingSubset([20, 3, 2, 15, 6, 1]));
