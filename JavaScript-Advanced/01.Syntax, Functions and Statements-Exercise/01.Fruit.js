function calculatesMoney(fruit, grams, price) {
    let weight = grams / 1000;
    let result = weight * price;
    console.log(`I need $${result.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruit}.`);
}

calculatesMoney('orange', 2500, 1.80);
calculatesMoney('apple', 1563, 2.35);