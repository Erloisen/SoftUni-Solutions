function circleArea(radius) {
    if (typeof(radius) == 'number') {
        let area = Math.PI * radius ** 2 ;
        console.log(area.toFixed(2));
    } else {
        console.log(`We can not calculate the circle area, because we receive a ${typeof(radius)}.`)
    }
}

circleArea(6);
circleArea("Radius");
circleArea('10');
