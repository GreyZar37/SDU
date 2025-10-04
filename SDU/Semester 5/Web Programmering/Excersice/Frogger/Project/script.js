// Get the frog element
const frog = document.getElementById("frog");

// Starting position
let frogX = 350; 
let frogY = 450; 

// Apply initial position
frog.style.left = frogX + "px";
frog.style.top = frogY + "px";

// Step size (how much the frog moves each key press)
const step = 50;

//Stats
let score = 0;
let lives = 3;

// Listen for key presses
document.addEventListener("keydown", (event) => {
    if (event.key === "ArrowUp") {
        frogY -= step;
    } else if (event.key === "ArrowDown") {
        frogY += step;
    } else if (event.key === "ArrowLeft") {
        frogX -= step;
    } else if (event.key === "ArrowRight") {
        frogX += step;
    }

    // Prevent frog from leaving the game box
    if (frogX < 0) frogX = 0;
    if (frogX > 650) frogX = 650; 
    if (frogY < 0){
        frogY = 450;
        document.getElementById("score").innerHTML = "Score: " + ++score;
    } 
    if (frogY > 450) frogY = 450; 

    frog.style.left = frogX + "px";
    frog.style.top = frogY + "px";
});





// === CAR AND LOG MOVEMENT ===
const game = document.querySelector(".game");
const GAME_WIDTH = game.clientWidth;

const cars = [
    { el: document.getElementById("red_car"),    speed: 500, dir:  1 },
    { el: document.getElementById("blue_car"),   speed: 350, dir: -1 },
    { el: document.getElementById("orange_car"), speed: 260, dir:  1 },
];

const logs =[
    {el: document.getElementById("log_small"), speed: 120, dir: 1},
    {el: document.getElementById("log_medium"), speed: 50, dir: 1},
    {el: document.getElementById("log_large"), speed: 100, dir: -1},
]

cars.forEach(c => {
    c.x = parseFloat(getComputedStyle(c.el).left) || 0;
    c.w = c.el.offsetWidth; 
});

logs.forEach(l => {
    l.x = parseFloat(getComputedStyle(l.el).left) || 0;
    l.w = l.el.offsetWidth; 
});

// Animation loop
let last = performance.now();
function tick(now) {
    const dt = (now - last) / 1000; 
    last = now;

    cars.forEach(c => {
        c.x += c.dir * c.speed * dt;

        if (c.dir === 1 && c.x > GAME_WIDTH) c.x = -c.w;
        if (c.dir === -1 && c.x < -c.w)      c.x = GAME_WIDTH;

        c.el.style.left = c.x + "px";
    });


    logs.forEach(l => {
        l.x += l.dir * l.speed * dt;

        if (l.dir === 1 && l.x > GAME_WIDTH) l.x = -l.w;
        if (l.dir === -1 && l.x < -l.w)      l.x = GAME_WIDTH;

        l.el.style.left = l.x + "px";
    });


    // After moving cars, check for collision
    if (checkCollision(frog, cars)) {
        
        frogX = 350;
        frogY = 450;
        frog.style.left = frogX + "px";
        frog.style.top = frogY + "px";
    }
    
    if( checkCollisionLog(frog, logs)){
        
    }


    requestAnimationFrame(tick);
}
requestAnimationFrame(tick);

function checkCollision(frog, cars) {
    const frogRect = frog.getBoundingClientRect();

    for (const c of cars) {
        const carRect = c.el.getBoundingClientRect();


        // Customize shrink values separately
        const frogShrinkX = 6;  // shrink frog left/right
        const frogShrinkY = 10; // shrink frog top/bottom

        const carShrinkX = 12;  // shrink cars left/right
        const carShrinkY = 8;   // shrink cars top/bottom

        const frogLeft   = frogRect.left   + frogShrinkX;
        const frogRight  = frogRect.right  - frogShrinkX;
        const frogTop    = frogRect.top    + frogShrinkY;
        const frogBottom = frogRect.bottom - frogShrinkY;

        const carLeft   = carRect.left   + carShrinkX;
        const carRight  = carRect.right  - carShrinkX;
        const carTop    = carRect.top    + carShrinkY;
        const carBottom = carRect.bottom - carShrinkY;
        
        // Check if rectangles overlap
        if (
            frogLeft  < carRight   &&
            frogRight > carLeft  &&
            frogTop  < carBottom &&
            frogBottom > carTop
        ) {
            document.getElementById("lives").innerHTML = "Lives: " + --lives;
            restart();
            return true; // Collision detected
        }
    }
    return false;
}
function checkCollisionLog(frog, logs) {
    const frogRect = frog.getBoundingClientRect();

    for (const l of logs) {
        const logRect = l.el.getBoundingClientRect();


        // Customize shrink values separately
        const frogShrinkX = 6;  // shrink frog left/right
        const frogShrinkY = 10; // shrink frog top/bottom

        const frogLeft   = frogRect.left   + frogShrinkX;
        const frogRight  = frogRect.right  - frogShrinkX;
        const frogTop    = frogRect.top    + frogShrinkY;
        const frogBottom = frogRect.bottom - frogShrinkY;

        // Check if rectangles overlap
        if (
            frogLeft  < logRect.right   &&
            frogRight > logRect.left  &&
            frogTop  < logRect.bottom &&
            frogBottom > logRect.top   
        ) {
            return true; // Collision detected
        }
    }
    return false;
}

function restart() {
    if(lives < 1){
        alert("Game Over");
        location.reload();
    }
}