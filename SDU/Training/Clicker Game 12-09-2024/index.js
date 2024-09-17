let banana = document.querySelector('.banana-cost');
let parsedBanana = parseFloat(banana.innerHTML)

let clickerCost = document.querySelector('.clicker-cost')
let parsedClickerCost = parseFloat(clickerCost.innerHTML)


var timer = window.setInterval(IncrementBananaAuto, 500);

function IncrementBanana(){
    parsedBanana += 1;
    banana.innerHTML = parsedBanana;
    
}

function IncrementBananaAuto(){
    //parsedBanana += ; 
    banana.innerHTML = parsedBanana;
}

function GetBananaPrsFromArray(){
    let totalBananaGain = 0;
    for (let index = 0; index < clickerArray.length; index++) {
        totalBananaGain += clickerArray[i].GetBananaPrS;
    }
    return totalBananaGain;
}

function BuyClicker(){
    if(parsedBanana >=parsedClickerCost){
        parsedBanana-= parsedClickerCost;
        banana.innerHTML = parsedBanana;
        bananaAutoPrS += 1
    }
}

class ClickerArray{
    constructor(){
       this.clickers = [];
    }
    AddClicker(clickerObj){
        this.clickers.push(clickerObj)
    }
    GetClickers(){
        return this.clickers;
    }
}

clickerArray = new ClickerArray()

class Clicker{
    constructor(bananaPrS, upgradeName, upgradeCost){
        this.bananaPrS = bananaPrS;
        this.upgradeName = upgradeName;
        this.upgradeCost = upgradeCost;
        this.amount = 1;
    }
    GetName() {
        return this.upgradeName
    }
    GetPrice(){
        return this.price
    }
    GetBananaPrS(){
        return this.bananaPrS * amount;
    }
}

function CreateClicker(bananaPrS, upgradeName, upgradeCost){
    let monke = new Clicker(bananaPrS, upgradeName, upgradeCost);
    clickerArray.AddClicker(monke);
}


 