function daysInMonth(month, year) {
    let result = new Date(year, month, 0).getDate(); 
    return result;
}

console.log(daysInMonth(1, 2012));
console.log(daysInMonth(2, 2021));
console.log(daysInMonth(2, 2020));