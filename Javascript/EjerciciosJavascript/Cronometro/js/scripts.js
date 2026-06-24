let segudnos = 0;
let minutos = 0;
let horas = 0;
let intervalo = true;
let calculadora = document.getElementById("calculadora");

let start = document.getElementById("Start");
start.addEventListener("click", () => {
    console.log("alskdfjasdf");
    Timer();
})

function Timer(){
    if (intervalo) {
        setInterval(() => {
            segudnos++;
            if (segudnos == 60) {
                segudnos = 0;
                minutos++;
            }else if (minutos == 60) {
                minutos = 0;
                horas++;
            }
            UpdateTime();
        }, 1000);
        intervalo = false;
    }
}   

function UpdateTime(){
    let calc = document.querySelector("#calculadora");
    calc.textContent = `${zeroSeconds(segudnos)} : ${zeroSeconds(minutos)} : ${zeroSeconds(horas)}`;
}


function zeroSeconds(tiempo){
    if (tiempo < 10) {
        return "0"+tiempo;
    }return tiempo;
}
