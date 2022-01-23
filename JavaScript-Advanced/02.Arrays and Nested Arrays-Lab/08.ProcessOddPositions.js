const arrayOfOddPositions = (array) => array
        .filter((v, i) => i % 2 == 1)
        .map(x => x * 2)
        .reverse()
        .join(' ');

console.log(arrayOfOddPositions([10, 15, 20, 25]));
console.log(arrayOfOddPositions([3, 0, 10, 4, 7, 3]));