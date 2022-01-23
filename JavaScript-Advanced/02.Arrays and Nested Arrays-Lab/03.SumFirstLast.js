function sumFirstLast(arrayOfStrings) {
    const first = arrayOfStrings.shift();
    const last = arrayOfStrings.pop();
    const sum = Number(first) + Number(last);
    return sum;
}

console.log(sumFirstLast(['20', '30', '40']));
console.log(sumFirstLast(['5', '10']));