function sameNumbers(input) {
    let inputNumber = input.toString();
    let isSame = true;
    let sumOfDigits = 0;

    for (let index = 0; index < inputNumber.length; index++) {
        
        sumOfDigits += Number(inputNumber[index]);

        if (inputNumber[0] !== inputNumber[index]) {
            isSame = false;
        }
    }

    console.log(isSame);
    console.log(sumOfDigits);
}

sameNumbers(2222222);
sameNumbers(1234);
