window.addEventListener('load', solution);

function solution() {
  let submitBtn = document.getElementById('submitBTN');
  let personalInformation = {};
  submitBtn.addEventListener('click', submit)

  function submit(e) {
    e.preventDefault();

    let fullName = document.getElementById('fname');
    let email = document.getElementById('email');
    let phone = document.getElementById('phone')
    let address = document.getElementById('address');
    let postalCode = document.getElementById('code');

    if (!fullName.value || !email.value) {
      return;
    }

    let infoPreview = document.getElementById('infoPreview');

    let fullNameLiElement = document.createElement('li');
    fullNameLiElement.textContent = `Full Name: ${fullName.value}`;
    personalInformation['fullName'] = fullName.value;

    let emailLiElement = document.createElement('li');
    emailLiElement.textContent = `Email: ${email.value}`;
    personalInformation['email'] = email.value;

    let phoneLiElement = document.createElement('li');
    phoneLiElement.textContent = `Phone Number: ${phone.value}`;
    personalInformation['phone'] = phone.value;

    let addressLiElement = document.createElement('li');
    addressLiElement.textContent = `Address: ${address.value}`;
    personalInformation['address'] = address.value;

    let codeLiElement = document.createElement('li');
    codeLiElement.textContent = `Postal Code: ${postalCode.value}`;
    personalInformation['postalCode'] = postalCode.value;

    infoPreview.appendChild(fullNameLiElement);
    infoPreview.appendChild(emailLiElement);
    infoPreview.appendChild(phoneLiElement);
    infoPreview.appendChild(addressLiElement);
    infoPreview.appendChild(codeLiElement);

    fullName.value = '';
    email.value = '';
    phone.value = '';
    address.value = '';
    postalCode.value = '';

    e.target.disabled = true;

    let editBtn = document.getElementById('editBTN');
    let continueBtn = document.getElementById('continueBTN');

    editBtn.disabled = false;
    continueBtn.disabled = false;

    editBtn.addEventListener('click',edit)
    continueBtn.addEventListener('click',continueFunc)
  }

  function continueFunc() {
    let blockElement = document.getElementById('block');
    blockElement.innerHTML = '';
    
    let h3Element = document.createElement('h3');
    h3Element.textContent = 'Thank you for your reservation!';

    blockElement.appendChild(h3Element);
  }

  function edit(){
    let fullName = document.getElementById('fname');
    let email = document.getElementById('email');
    let phone = document.getElementById('phone')
    let address = document.getElementById('address');
    let postalCode = document.getElementById('code');

    Object.keys(personalInformation).forEach(x=> {
      if (personalInformation[x]) {
        if (x == 'fullName') {
          fullName.value = personalInformation[x]
        } else if (x == 'email'){
          email.value = personalInformation[x];
        } else if (x == 'phone'){
          phone.value = personalInformation[x];
        } else if (x == 'address') {
          address.value = personalInformation[x];
        } else if (x == 'postalCode') {
          postalCode.value = personalInformation[x];
        }
      }
    });
    let editBtn = document.getElementById('editBTN');
    let continueBtn = document.getElementById('continueBTN');
    editBtn.disabled = true;
    continueBtn.disabled = true;
    submitBtn.disabled = false;
    let infoPreview = document.getElementById('infoPreview');
    infoPreview.innerHTML = '';
  }

}
