function cookingANumber (inputNum, first, second, third, fourth, fifth) {
    let number = Number(inputNum);
    let operations = [first, second, third, fourth, fifth];

    for (let index = 0; index < operations.length; index++) {
        
        let currentOperation = operations[index];
        switch (currentOperation) {
            case 'chop':
                number /= 2;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break;
            case 'spice':
                number += 1;
                break;
            case 'bake':
                number *= 3;
                break;
            case 'fillet':
                number -= number * 0.2;
                break;
        }

        console.log(number);
    }
}

cookingANumber('32', 'chop', 'chop', 'chop', 'chop', 'chop');
cookingANumber('9', 'dice', 'spice', 'chop', 'bake', 'fillet');