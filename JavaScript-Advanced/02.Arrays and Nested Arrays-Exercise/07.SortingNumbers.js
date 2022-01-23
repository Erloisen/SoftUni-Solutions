function sortingNums(array) {
    const sortedArr = [];
    array.sort((a, b) => a - b);
    
    while(array.length != 0) {
        sortedArr.push(array.shift());
        sortedArr.push(array.pop());
    }

    return sortedArr;
}

console.log(sortingNums([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));