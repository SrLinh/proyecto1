let visor = document.getElementById("visor");
    let resultado;
    let valor1;
    let valor2;
    let operacion;
    let operador;
    console.log("hola");
    document.querySelectorAll("#buttomValue button").forEach(btn =>{
        btn.addEventListener("click", () => {
            agregarValor(btn.value);
        })
    });

    document.querySelectorAll("#buttonOperations button").forEach(op => {
        op.addEventListener("click", () => {
            agregarValor(op.value);
        })
    });

    document.querySelectorAll("#buttonFeatures button").forEach(ft => {
        ft.addEventListener("click", () => {
           if (ft.value == "=") {
            calcular();
            console.log("boton presionado");
           }else if (ft.value == "CE") {
             CE();
           }else if (ft.value = "Del") {
            Del();
           }
        })
    })

    function agregarValor(valor){
        visor.textContent += valor;
    }
    function calcular(){
        console.log("calculo en progreso");
        let operacion = visor.textContent;
        console.log(visor.textContent)

        if (operacion.includes("+")) operador = "+";
        else if (operacion.includes("-")) operador = "-";
        else if (operacion.includes("*")) operador = "*";
        else if (operacion.includes("/")) operador = "/";

        let partes = operacion.split(operador);
        let hola = "ASDFASDFASDF";
        
        valor1 = parseFloat(partes[0]);
        valor2 = parseFloat(partes[1]);

        console.log(valor1);
        console.log(valor2);

        switch (operador) {
            case "+":
                resultado = valor1 + valor2;
                break;
            case "-":
                resultado = valor1 + valor2;
                break;
            case "*":
                resultado = valor1 + valor2;
                break;
            case "/":
                if (valor1 == 0) {
                    resultado = "Error"
                    break;
                }
                resultado = valor1 + valor2;
                break;
            default:
                break;
        }

        visor.textContent += "\n" + resultado;
    }

    function CE (){
       visor.textContent = ""; 
    }

    function Del(){
        let opTemp = visor.textContent.split("").slice(0,-1).join("");
        console.log(opTemp);
        visor.textContent = opTemp;
        //visor.textContent = opTemp;
        
        
    }