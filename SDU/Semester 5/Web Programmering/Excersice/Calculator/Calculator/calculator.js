let resultDisplay = document.getElementById("result");
let currentFormula = document.getElementById("current_formula");

let firstValue = "";
let secondValue = "";
let result = 0;
let operator = "";
let formula = "";

let data ={
    string : formula = "",
    string : firstValue = "",
    string : secondValue = "",
    int : result = 0,
    string : operator = ""
};

let isSecondValue = false;
let isDoneCalculating = false;

function addNumber(value){

    if(isDoneCalculating){
        clearDisplay();
        isDoneCalculating = false;
    }
    
    if(isSecondValue){
        secondValue += value;
    }
    else
    {
        firstValue += value;
    }
    
    
    updateDisplay();
}

function clearDisplay(){
    firstValue = "";
    secondValue = "";
    result = 0;
    operator = "";
    formula = "";
    resultDisplay.innerHTML = "";

    updateDisplay()
}

function divide(){
    operator = "/";
    isSecondValue = true;
    updateDisplay();
}

function multiply(){
     operator = "*";
     isSecondValue = true;
     updateDisplay();
}
function subtract(){
     operator = "-";
     isSecondValue = true;
     updateDisplay();
}


function addere(){
    operator = "+";
    isSecondValue = true;
    updateDisplay();
}

function equal(){
    result = eval(formula);
    resultDisplay.innerHTML = result;
    isDoneCalculating = true;
    isSecondValue = false;
}

function updateDisplay(){
    
    formula = firstValue + operator + secondValue;
    currentFormula.innerHTML = formula;
}