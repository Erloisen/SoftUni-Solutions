function calculatingDay (year, month, day) {
    let inputDate = `${year}-${month}-${day}`;
    let date = new Date(inputDate);
    date.setDate(date.getDate() - 1);
    
    console.log(`${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`);
}

calculatingDay(2016, 9, 30);
calculatingDay(2016, 10, 1);
calculatingDay(2000, 1, 1);