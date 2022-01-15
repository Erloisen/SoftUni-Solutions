function largestNum (a, b, c) {
    let result;

    if (a > b) {
        if (a > c) {
            result = a;
        } else {
            result = c;
        }
    } else if (b > c) {
        result = b;
    } else {
        result = c;
    }

    console.log(`The largest number is ${result}.`)
}

largestNum(1, 2, 3);
largestNum(1, 3, 2);
largestNum(2, 1, 3);
largestNum(3, 2, 1);
largestNum(2, 3, 1);