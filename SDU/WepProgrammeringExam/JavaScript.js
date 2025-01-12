/* Challenge 1: Dynamic Counter*/

let btnText = document.getElementById("buttonCounterTxt").innerHTML;

var number;
function IncrementNumber()
{
    number++;
    btnText.innerHTML= number;
}

/* Challenge 2: Input Validation*/

function validateForm() 
{
    const name = document.getElementById("name").value;
    const password = document.getElementById("password").value;
    let isValid = true;

    if(name == ""){
        return false;
    }
    else if(password.length < 8){
        return false
    }
    return isValid;
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