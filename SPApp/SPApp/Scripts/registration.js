function validatePassword() {
    var password = document.getElementById("password");
    var confirm_password = document.getElementById("confirm-password");

    if (confirm_password.value == "") {
        confirm_password.setCustomValidity("Polje ne sme biti prazno.");
    }

    if (password.value != confirm_password.value) {
        confirm_password.setCustomValidity("Gesli se ne ujemata.");
        return false;
    } else {
        confirm_password.setCustomValidity('');
        return true;
    }

}