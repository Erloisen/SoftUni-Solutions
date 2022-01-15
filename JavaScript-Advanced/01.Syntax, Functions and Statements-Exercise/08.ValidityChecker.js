function valideDistance(inputX1, inputY1, inputX2, inputY2) {
    let x1 = Number(inputX1);
    let y1 = Number(inputY1);
    let x2 = Number(inputX2);
    let y2 = Number(inputY2);

    let valid = (x1, y1, x2, y2) => {
       let distance = Math.sqrt(Math.pow((x2 - x1), 2) + Math.pow((y2 - y1), 2));

        let checker = 'invalide';

        if (Number.isInteger(distance)) {
            checker = 'valide';
        }

        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${checker}`);
    }

    valid(x1, y1, 0, 0);
    valid(x2, y2, 0, 0);
    valid(x1, y1, x2, y2);

}

valideDistance(3, 0, 0, 4);
valideDistance(2, 1, 1, 1);