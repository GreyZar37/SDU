/* Challenge 1: Dynamic Counter*/

const upvoteBtn = document.getElementById("upvote_counter_734");
upvoteBtn.addEventListener("click", upvote)

var number;
var hasPressed
function upvote()
{
    if(hasPressed){
        number-= 1;
    }
    else{
        number+=1;
    }
    upvoteCounter.innerHTML= number;
}

/* Challenge 2: Input Validation*/

function validate_password(submission) 
{
    const username = submission.getElementById("username").value;
    const password = submission.getElementById("password").value;
   
    let isValid = true;

    if(username.length < 8 || username.length > 24){
        return false;
    }
    else if(password.length < 8 || username.length > 24){
        return false
    }
    else if(password == username){
        return false;
    }
    return isValid;
}

function validateRegistrationForm(pwd) {

    
    var passwordRegex = /?=.*[A-Z]/;

    if (!passwordRegex.test(password)) {
        alert("Password must have an upper case character");
        return false;

    }
    passwordRegex = /?=.*[a-z]/;
    if (!passwordRegex.test(password)) {
        alert("Password must have lower case Character");
        return false;

    }

    passwordRegex = /[0-9]+/;
    if (!passwordRegex.test(password)) {
    alert("Password must have a number");
    return false;

    }
    passwordRegex = /[^-\s]/;
    if (!passwordRegex.test(password)) {
        alert("Password must not have whitespace");
        return false;
    }
    return true;
}

/* Challenge 3: Show/Hide Content*/

function showOrHide(textToHide){

    var paragraph = document.getElementById(textToHide);
    if (paragraph.style.display === "none") {
        paragraph.style.display = "block";
      } else {
        paragraph.style.display = "none";
      }
}

