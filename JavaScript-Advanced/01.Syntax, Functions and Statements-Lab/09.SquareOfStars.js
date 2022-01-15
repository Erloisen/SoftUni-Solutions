function rectangle(size = 5) {
    let line = '';
    for (let r = 0; r < size; r++) {
        for (let c = 0; c < size; c++) {
            line += '* ';
        }

        console.log(line);
        line = '';
    }
}

rectangle(1);
rectangle(2);
rectangle(5);
rectangle();