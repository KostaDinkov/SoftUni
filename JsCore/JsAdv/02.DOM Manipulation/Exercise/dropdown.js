function addItem(){
    let value_el = document.getElementById('newItemValue');
    let text_el = document.getElementById('newItemText');

    let op = document.createElement('option');
    op.value= value_el.value;
    op.textContent = text_el.value;

    let menu = document.getElementById('menu');
    menu.appendChild(op);
    value_el.value = '';
    text_el.value = '';

}