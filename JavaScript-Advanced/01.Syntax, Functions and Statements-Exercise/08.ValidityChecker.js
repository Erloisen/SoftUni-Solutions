function valideDistance(inputx1, inputy1, inputx2, inputy2) {
    let x1 = Number(inputx1);
    let y1 = Number(inputy1);
    let x2 = Number(inputx2);
    let y2 = Number(inputy2);

    let firstDistance = Math.sqrt(Math.pow((0 - x1), 2) + Math.pow((0 - y1), 2));

    if (Number.isInteger(firstDistance)) {
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }

    let secondDistance = Math.sqrt(Math.pow(x2, 2) + Math.pow(y2, 2));

    if (Number.isInteger(secondDistance)) {
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    } else {
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }

    let thirdDistance = Math.sqrt(Math.pow((x2 - x1), 2) + Math.pow((y2 - y1), 2));

    if (Number.isInteger(thirdDistance)) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
}

valideDistance(3, 0, 0, 4);
valideDistance(2, 1, 1, 1);