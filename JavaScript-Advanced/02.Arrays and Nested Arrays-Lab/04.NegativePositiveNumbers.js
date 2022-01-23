function solve(numbers) {
    const array = [];

    for (const num of numbers) {
        if (num < 0) {
            array.unshift(num);
        } else {
            array.push(num);
        }
    }

    console.log(array.join('\n'));
}

solve([7, -2, 8, 9]);
solve([3, -2, 0, -1]);