function sumPrevElements(n, k) {
    let array = [1];
    let element;
    
    for (let i = 1; i < n; i++) {
        element = array.slice(-k).reduce((a, b) => a + b);
        array.push(element);
    }

    return array;
}

sumPrevElements(6, 3);
sumPrevElements(8, 2);