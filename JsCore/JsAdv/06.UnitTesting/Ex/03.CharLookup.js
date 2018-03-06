lookupChar = function(string, index) {
    if (typeof(string) !== 'string' || typeof (index) !== 'number') {
        return undefined;
    }
    if (string.length <= index || index < 0) {
        return "Incorrect index";
    }

    return string.charAt(index);
};


exports.lookupChar = lookupChar;