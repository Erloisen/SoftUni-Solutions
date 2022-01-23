function printWithDelimiter(array, string) {
    console.log(array.join(`${string}`));
}

printWithDelimiter(['One', 
'Two', 
'Three', 
'Four', 
'Five'], 
'-');
printWithDelimiter(['How about no?', 
'I',
'will', 
'not', 
'do', 
'it!'], 
'_');