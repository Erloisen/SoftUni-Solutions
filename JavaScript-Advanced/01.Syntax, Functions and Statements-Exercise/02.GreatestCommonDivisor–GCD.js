function gcd(numberOne, numberTwo) {
    if (numberOne == 0) {
        return numberTwo;
    }

    while (numberTwo != 0) {
        if (numberOne > numberTwo) {
            numberOne = numberOne - numberTwo;
        } else {
            numberTwo = numberTwo - numberOne;
        }
    }

    return numberOne;
}

console.log(gcd(15, 5));
console.log(gcd(2154, 458));