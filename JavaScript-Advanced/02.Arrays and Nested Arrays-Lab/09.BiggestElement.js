function biggestElement(matrix) {
    let biggest = Number.MIN_SAFE_INTEGER;
    
    for (let i = 0; i < matrix.length; i++) {
        let currentBig = matrix[i].reduce((a, b) => { return Math.max(a, b) });

        if (biggest < currentBig) {
            biggest = currentBig;
        }
    }

    console.log(biggest);
}

biggestElement([[20, 50, 10],
                [8, 33, 145]]);
biggestElement([[3, 5, 7, 12],
                [-1, 4, 33, 2],
                [8, 3, 0, 4]]);