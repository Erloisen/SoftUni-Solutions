function sortedArray (array) {
    array.sort((a, b) => a.localeCompare(b));
    let counter = 1;
    for (const name of array) {
        console.log(`${counter++}.${name}`);
    }
}

sortedArray(["John", "Bob", "Christina", "Ema"]);