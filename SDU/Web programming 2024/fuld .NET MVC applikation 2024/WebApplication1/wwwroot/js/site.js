// Registration Form Validation
    function validateRegistrationForm() {
    // Username Validation: check if it is not empty
    const username = document.getElementById("username").value;
    if (username == "") {
        alert("Username must not be empty.");
    return false;
    }

    // Password Validation: Check if password contains at least one number, one letter, and one special character, and is at least 8 characters long
    const password = document.getElementById("password").value;
    const passwordRegex = /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8, 20}$/;
    if (!passwordRegex.test(password)) {
        alert("Password must be at least 8 characters long and contain at least one letter, one number, and one special character.");
    return false;
    }

    // Email Validation: Using a simple email RegEx pattern
    const email = document.getElementById("email").value;
    const emailRegex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    if (!emailRegex.test(email)) {
        alert("Please enter a valid email address.");
    return false;
    }

    return true; // If all validations pass
}

    // Login Form Validation
    function validateLoginForm() {
    // Username Validation: check if it is not empty
    const loginUsername = document.getElementById("login-username").value;
    if (loginUsername == "") {
        alert("Username must not be empty.");
    return false;
    }

    // Password Validation: Check if password is not empty
    const loginPassword = document.getElementById("login-password").value;
    if (loginPassword == "") {
        alert("Password must not be empty.");
    return false;
    }

    return true; // If all validations pass
}
