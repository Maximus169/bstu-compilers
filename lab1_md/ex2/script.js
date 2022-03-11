function validateEmail(email) {
   var pattern = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
   //var pattern = /^\w{1,5}@\w+\.\w{3}$/;
   return pattern.test(email);
}

document.querySelector('.submit').onclick = myClick;

function myClick() {

   let email = document.querySelector('.email').value;
   if (validateEmail(email))
      alert('success');
   else
      alert('not successful');
}
