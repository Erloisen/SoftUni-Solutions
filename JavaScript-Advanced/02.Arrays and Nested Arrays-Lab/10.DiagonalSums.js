function sumOfDiagonals(matrix) {
    const lastElement = matrix.length - 1;
    let rightSum = 0;
    let leftSum = 0;

    for (let i = 0; i < matrix.length; i++) {
        rightSum += matrix[i][i];
        leftSum += matrix[i][lastElement - i];
    }

    console.log(`${rightSum} ${leftSum}`);
}

sumOfDiagonals([[20, 40],
                [10, 60]]);
sumOfDiagonals([[3, 5, 17],
                [-1, 7, 14],
                [1, -8, 89]]);