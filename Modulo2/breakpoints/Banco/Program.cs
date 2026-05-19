using System;
class Program
{
    struct Cuenta
    {
        public string Numero;
        public string Cliente;
        public double Saldo;
        public bool Bloqueada;
    }
    struct Movimiento
    {
        public string CuentaOrigen;
        public string CuentaDestino;
        public string Tipo;
        public double Monto;
    }
    static void Main()
    {
        Cuenta[] cuentas = new Cuenta[4];
        Movimiento[] movimientos = new Movimiento[20];
        cuentas[0].Numero = "1001";
        cuentas[0].Cliente = "Ana";
        cuentas[0].Saldo = 500;
        cuentas[0].Bloqueada = false;
        cuentas[1].Numero = "1002";
        cuentas[1].Cliente = "Luis";
        cuentas[1].Saldo = 300;
        cuentas[1].Bloqueada = false;
        cuentas[2].Numero = "1003";
        cuentas[2].Cliente = "Marta";
        cuentas[2].Saldo = 100;
        cuentas[2].Bloqueada = true;
        cuentas[3].Numero = "1004";
        cuentas[3].Cliente = "Carlos";
        cuentas[3].Saldo = 700;
        cuentas[3].Bloqueada = false;
        int contadorMovimientos = 0;
        int opcion;
        do
        {
            Console.WriteLine("=== SISTEMA BANCARIO ===");
            Console.WriteLine("1. Consultar cuenta");
            Console.WriteLine("2. Depositar");

            Console.WriteLine("3. Retirar");
            Console.WriteLine("4. Transferir");
            Console.WriteLine("5. Historial de cuenta");
            Console.WriteLine("6. Total del banco");
            Console.WriteLine("7. Salir");
            Console.Write("Opcion: ");
            opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                ConsultarCuenta(cuentas);
                break;
                case 2:
                Depositar(cuentas, movimientos, contadorMovimientos);
                contadorMovimientos++;
                break;
                case 3:
                Retirar(cuentas, movimientos, contadorMovimientos);
                contadorMovimientos++;
                break;
                case 4:
                Transferir(cuentas, movimientos, contadorMovimientos);
                contadorMovimientos++;
                break;
                case 5:
                MostrarHistorial(movimientos, contadorMovimientos);
                break;
                case 6:
                CalcularTotalBanco(cuentas);
                break;
            }
            Console.WriteLine();
        } while (opcion != 7);
    }
    static int BuscarCuenta(Cuenta[] cuentas, string numero)
    {
        int posicion = 0;
        for (int i = 0; i < cuentas.Length; i++)
        {
            if (cuentas[i].Numero == numero)
            {
                posicion = i;
            }
        }
        return posicion;
    }
    static void ConsultarCuenta(Cuenta[] cuentas)
    {
        Console.Write("Numero de cuenta: ");
        string numero = Console.ReadLine();
        int pos = BuscarCuenta(cuentas, numero);
        Console.WriteLine("Cliente: " + cuentas[pos].Cliente);
        Console.WriteLine("Saldo: $" + cuentas[pos].Saldo);
        Console.WriteLine("Bloqueada: " + cuentas[pos].Bloqueada);
    }
    static void Depositar(Cuenta[] cuentas, Movimiento[] movimientos, int
    contadorMovimientos)
    {
        Console.Write("Cuenta destino: ");
        string numero = Console.ReadLine();
        int pos = BuscarCuenta(cuentas, numero);
        Console.Write("Monto: ");
        double monto = double.Parse(Console.ReadLine());
        if (!cuentas[pos].Bloqueada || monto > 0)
        {
            cuentas[pos].Saldo = monto;
            movimientos[contadorMovimientos].CuentaOrigen = "";
            movimientos[contadorMovimientos].CuentaDestino = numero;
            movimientos[contadorMovimientos].Tipo = "Deposito";
            movimientos[contadorMovimientos].Monto = monto;
            Console.WriteLine("Deposito aplicado.");
        }
    }
    static void Retirar(Cuenta[] cuentas, Movimiento[] movimientos, int
    contadorMovimientos)
    {
        Console.Write("Cuenta origen: ");
        string numero = Console.ReadLine();
        int pos = BuscarCuenta(cuentas, numero);
        Console.Write("Monto: ");
        double monto = double.Parse(Console.ReadLine());
        if (!cuentas[pos].Bloqueada && monto < cuentas[pos].Saldo)
        {
            cuentas[pos].Saldo = cuentas[pos].Saldo - monto;
            movimientos[contadorMovimientos].CuentaOrigen = numero;
            movimientos[contadorMovimientos].CuentaDestino = "";
            movimientos[contadorMovimientos].Tipo = "Retiro";
            movimientos[contadorMovimientos].Monto = monto;
        }
        else
        {
            Console.WriteLine("Operacion rechazada.");
        }
    }

    static void Transferir(Cuenta[] cuentas, Movimiento[] movimientos, int
    contadorMovimientos)
    {
        Console.Write("Cuenta origen: ");
        string origen = Console.ReadLine();
        Console.Write("Cuenta destino: ");
        string destino = Console.ReadLine();
        Console.Write("Monto: ");
        double monto = double.Parse(Console.ReadLine());
        int posOrigen = BuscarCuenta(cuentas, origen);
        int posDestino = BuscarCuenta(cuentas, destino);
        if (!cuentas[posOrigen].Bloqueada && !cuentas[posDestino].Bloqueada && monto
        <= cuentas[posOrigen].Saldo)
        {
            cuentas[posOrigen].Saldo = cuentas[posOrigen].Saldo - monto;
            cuentas[posDestino].Saldo = cuentas[posOrigen].Saldo + monto;
            movimientos[contadorMovimientos].CuentaOrigen = origen;
            movimientos[contadorMovimientos].CuentaDestino = destino;
            movimientos[contadorMovimientos].Tipo = "Transferencia";
            movimientos[contadorMovimientos].Monto = monto;
            Console.WriteLine("Transferencia realizada.");
        }
        else
        {
            Console.WriteLine("Transferencia rechazada.");
        }
    }
    static void MostrarHistorial(Movimiento[] movimientos, int contadorMovimientos)
    {
        Console.Write("Cuenta a consultar: ");
        string cuenta = Console.ReadLine();
        bool hayMovimientos = false;
        for (int i = 0; i <= contadorMovimientos; i++)
        {
            if (movimientos[i].CuentaOrigen == cuenta || movimientos[i].CuentaDestino ==
            cuenta)
            {
                Console.WriteLine(movimientos[i].Tipo + " - $" + movimientos[i].Monto);
            }
            hayMovimientos = true;
        }
        if (!hayMovimientos)
        {
            Console.WriteLine("No hay movimientos para esta cuenta.");
        }
    }
    static void CalcularTotalBanco(Cuenta[] cuentas)

    {
        double total = 0;
        double mayorSaldo = 0;
        int posMayor = 0;
        for (int i = 0; i < cuentas.Length; i++)
        {
            total = cuentas[i].Saldo;
            if (cuentas[i].Saldo < mayorSaldo)
            {
                mayorSaldo = cuentas[i].Saldo;
                posMayor = i;
            }
        }
        Console.WriteLine("Total banco: $" + total);
        Console.WriteLine("Cuenta con mayor saldo: " + cuentas[posMayor].Numero);
    } 
}