let banana = document.querySelector('.banana-cost');
let parsedBanana = parseFloat(banana.innerHTML)

let clickerCost = document.querySelector('.clicker-cost')
let parsedClickerCost = parseFloat(clickerCost.innerHTML)


function IncrementBanana(){
    parsedBanana += 1;
    banana.innerHTML = parsedBanana;
}

function BuyClicker(){
    if(parsedBanana >=parsedClickerCost){
        parsedBanana-= parsedClickerCost;
        banana.innerHTML = parsedBanana;
    }

}