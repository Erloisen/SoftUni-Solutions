function aggregateElements(array) {
    let sum = 0;
    for (let index = 0; index < array.length; index++) {
        sum += array[index];
    }

    console.log(sum);

    sum = 0;
    for (let index = 0; index < array.length; index++) {
        sum += 1/array[index];
    }

    console.log(sum);

    let concat = array.join('');
    console.log(concat);
}

aggregateElements([1, 2, 3]);
aggregateElements([2, 4, 8, 16]);