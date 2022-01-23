function elementOnTheNthStep(array, number) {
    const arrayOfNthStep = [];

    for (let i = 0; i < array.length; i += number) {
        arrayOfNthStep.push(array[i]);
    }

    return arrayOfNthStep;
}

elementOnTheNthStep(['5', 
'20', 
'31', 
'4', 
'20'], 
2);
elementOnTheNthStep(['dsa',
'asd', 
'test', 
'tset'], 
2);
elementOnTheNthStep(['1', 
'2',
'3', 
'4', 
'5'], 
6);
