function escaping(arr){

    let result = '<ul>\n';
    for (let i = 0; i < arr.length; i++) {
        arr[i] = escapeSpecials(arr[i]);
        result+=`  <li>${arr[i]}</li>\n`
    }
    result+='</ul>';
    console.log(result);


    function escapeSpecials(string){

        string = string. replace(/&/g,'&amp;');
        string = string.replace(/</g,'&lt;');
        string = string.replace(/>/g,'&gt;');

        string = string.replace(/"/g,'&quot;');
        return string;
    }
}

escaping(['<div style=\"color: red;\">Hello, Red!</div>', '<table><tr><td>Cell 1</td><td>Cell 2</td><tr>']);