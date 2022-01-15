function strlen(first, second, third) {
    let totalLength = first.length + second.length + third.length;
    let avgLength = Math.floor(totalLength / 3); 

    console.log(totalLength);
    console.log(avgLength);
}

strlen('chocolate', 'ice cream', 'cake');
strlen('pasta', '5', '22.3');