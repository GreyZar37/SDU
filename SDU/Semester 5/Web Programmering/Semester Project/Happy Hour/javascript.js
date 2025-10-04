const timeTxt = document.getElementById("time_txt");


const jokeTxt = document.getElementById("joke_txt");
const answerDiv = document.getElementById("answer_container");

const pigImage = document.getElementById("pig_image");

const jokeTimeSeconds = 60;
let jokeUpKeepTimer = 60;

let fullHour = false;

let punchLineJoke;

function setUp(){
    jokeTxt.style.display = "none";
    answerDiv.style.display = "none";
    timeTxt.style.display = "block";

    const audioMusic = new Audio("Sounds/comedy-cartoon.mp3");
    audioMusic.play();
    audioMusic.volume = 0.2;
    audioMusic.loop = true;
}

function updateCountdown() {
    const now = new Date();

    // Next full hour
    const nextHour = new Date(now);
    nextHour.setHours(now.getHours() + 1, 0, 0, 0);

    // Remaining time in seconds
    const diffMs = nextHour - now;
    const diffSec = Math.floor(diffMs / 1000);

    const minutes = Math.floor(diffSec / 60);
    const seconds = diffSec % 60;

    // Display as MM:SS
    timeTxt.textContent = `${String(minutes).padStart(2, "0")}:${String(seconds).padStart(2, "0")}`;
    
    if(diffSec > 60 && !fullHour){
        changePigImage("images/BoredPig.png");
    }
    else if (diffSec < 60 && diffSec > 0 && !fullHour){
        changePigImage("images/SurprisedPig.png");
    }
  
    else{}
    
    if (!fullHour && diffSec <= 0) {
        fullHour = true;
        getJoke();
    }
}


function jokePopUp(){
    if (fullHour) {
        if(jokeUpKeepTimer > 0){
          
            jokeTxt.style.display = "block";
            timeTxt.style.display = "none";

            jokeUpKeepTimer--;
        }
        else{
            fullHour = false;
            jokeUpKeepTimer = jokeTimeSeconds;
            timeTxt.style.display = "block";
            jokeTxt.style.display = "none";
            answerDiv.style.display = "none";

        }
    }
}


const form = document.getElementById("jokeForm")

form.addEventListener("submit", function(event) {
    event.preventDefault();


    const answer = event.target.answer.value;
    submitAnswer(answer, event.target.answer);
});

function submitAnswer(text, punchLineInputField) {
    jokeTxt.innerHTML = punchLineJoke;
    punchLineInputField.value = "";
    answerDiv.style.display = "none";
    changePigImage("images/HappyHourLogo.png");

}


async function getJoke() {
    const res = await fetch("https://v2.jokeapi.dev/joke/Any");
    const data = await res.json();

    let jokeText = "";

    if (data.type === "single") {
        // single joke (just one string)
        jokeText = data.joke;
        answerDiv.style.display = "none";
        changePigImage("images/HappyHourLogo.png");

    } else if (data.type === "twopart") {
        jokeText = data.setup;
        punchLineJoke = data.delivery;
        answerDiv.style.display = "block";
        changePigImage("images/MischievousPig.png");


    } else {
        jokeText = "Oops, couldn't fetch a joke this time!";
    }

   jokeTxt.innerHTML = jokeText;
}

function pigPressed(){
    const audio = new Audio("Sounds/pig-grunt.mp3");
    changePigImage("images/HappyHourLogo.png");
    audio.play();
}

function changePigImage(imageLink){
    pigImage.src = imageLink;
}

setUp();
updateCountdown();
setInterval(updateCountdown, 1000);
setInterval(jokePopUp, 1000);

