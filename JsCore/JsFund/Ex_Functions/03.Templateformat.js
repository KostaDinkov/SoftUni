function toXmlTemplate(data_arr){

    let template = '<?xml version="1.0" encoding="UTF-8"?>\n<quiz>\n';
    for (let i = 0; i < data_arr.length-1  ; i+=2) {

        let q = data_arr[i];
        let a = data_arr[i+1];

        template+=`  <question>\n    ${q}\n  </question>\n`;
        template+=`  <answer>\n    ${a}\n  </answer>\n`;
    }
    template+='</quiz>';
    console.log(template);

}

toXmlTemplate(["Dry ice is a frozen form of which gas?",
    "Carbon Dioxide",
    "What is the brightest star in the night sky?",
    "Sirius"]
);