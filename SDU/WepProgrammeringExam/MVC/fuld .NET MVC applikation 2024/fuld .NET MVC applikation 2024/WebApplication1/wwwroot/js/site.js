function validateRegistrationForm() {

    const username = document.getElementById("username").value;
    if (username.length < 3) {
        alert("Username must be longer.");
        return false;
    }

    const password = document.getElementById("password").value;

    if (password.length < 5) {
        alert("Password must be at least 5 characters long.");
        return false;

    }


    var passwordRegex = /[a-zA-Z]+/;

    if (!passwordRegex.test(password)) {
        alert("Password must have a letter");
        return false;

    }
    passwordRegex = /[0-9]+/;
    if (!passwordRegex.test(password)) {
        alert("Password must have a number");
        return false;

    }

    passwordRegex = /[!@#$%^&*]+/;
    if (!passwordRegex.test(password)) {
        alert("Password must have a special character");
        return false;
    }

    
    const email = document.getElementById("email").value;
    const emailRegex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    if (!emailRegex.test(email)) {
        alert("Please enter a valid email address.");
        return false;
    }

    return true;
}

function validateLoginForm() {
    const loginUsername = document.getElementById("login-username").value;
    if (loginUsername == "") {
        alert("Username must not be empty.");
        return false;
    }

    const loginPassword = document.getElementById("login-password").value;
    if (loginPassword == "") {
        alert("Password must not be empty.");
        return false;
    }

    return true;
}

function getDeliveryInfoAjax() {
    const xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            const response = JSON.parse(this.responseText);

            document.getElementById("delivery-time").innerHTML = response.deliveryDays;
            document.getElementById("tracking-number").innerHTML = response.trackingLabel;
        }
    };
    xhttp.open("GET", "/User/GetDeliveryInfo", true);
    xhttp.send();
}

setInterval(getDeliveryInfoAjax, 2000);
