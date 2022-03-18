function func() {
    var reg = /^([a-zA-Z0-9]{1,})+\@([a-z]{3,})+\.([a-z]{2,3})$/;
    var str = document.getElementById('text-field-input').value;
    
    if(reg.test(str)){
        alert('Ok');
    }
    else {
        alert('Try again my friend');
    }
}