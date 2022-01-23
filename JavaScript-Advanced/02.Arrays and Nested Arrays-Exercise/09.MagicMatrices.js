function sumRowsAndCols(matrix) {
    let rowsSum = matrix.map(row => row.reduce((a, b) => a + b));
    let colsSum = matrix.reduce((a, b) => a.map((x, i) => x + b[i]));
    rowsSum.push(...colsSum);
    let result = rowsSum.every((val, i, arr) => val === arr[0]);
    
    console.log(result);
}

sumRowsAndCols([[4, 5, 6],
                [6, 5, 4],
                [5, 5, 5]]);
sumRowsAndCols([[11, 32, 45],
                [21, 0, 1],
                [21, 1, 1]]);
sumRowsAndCols([[1, 0, 0],
                [0, 0, 1],
                [0, 1, 0]]);