function addRemoveElements (inputArray) {
    const array = [1];
    
    for (let i = 1; i < inputArray.length; i++) {
        if(inputArray[i] == 'add') {
            array.push(i + 1);
        } else if (inputArray[i] == 'remove') {
            array.pop();
        }
    }

    array.length == 0 ? console.log('Empty') : console.log(array.join('\n'));
}

addRemoveElements(['add', 
'add', 
'add', 
'add']);
addRemoveElements(['add', 
'add', 
'remove', 
'add', 
'add']);
addRemoveElements(['remove', 
'remove', 
'remove']);