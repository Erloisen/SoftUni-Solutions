function sortByTwoCriteria(array) {
    array.sort((a, b) => a.length - b. length || a.localeCompare(b));

    console.log(array.join('\n'));
}

sortByTwoCriteria(['alpha', 'beta', 'gamma']);
sortByTwoCriteria(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);
sortByTwoCriteria(['test', 'Deny', 'omen', 'Default']);