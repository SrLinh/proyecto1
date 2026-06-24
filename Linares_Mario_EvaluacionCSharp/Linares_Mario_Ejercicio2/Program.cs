using System;

class Program
{
    static void Main(string[] args)
    {
        
        bool condicional = true;
        while (condicional)
        {   string? contraseña = Console.ReadLine();
            int largo = contraseña.Length;
            bool Mayus = contraseña.Any(char.IsUpper);
            bool Digit = contraseña.Any(char.IsDigit);
            bool psw = contraseña.Contains("password");
            bool unodostres = contraseña.Contains("123");
            if (largo < 12)
            {
                Console.WriteLine(largo);
                Console.WriteLine("Tiene que tener al menos 12 caracteres");
                continue;
            }else if (Mayus == false)
            {
                Console.WriteLine("Tu contraseña necesita al menos una mayuscula");
                continue;
            }else if (Digit == false)
            {
                Console.WriteLine("Tu contraseña necesita al menos un digito");
                continue;
            }else if (psw == true || unodostres == true)
            {
                Console.WriteLine("Evita que tu contraseña posea 'password' o '123' dentro de ella");
                continue;
            }
            else
            {
                Console.WriteLine("Ingrese nuevamente la contraesña: ");
                string? repetir = Console.ReadLine();
                if (repetir != contraseña)
                {
                    Console.WriteLine("La contraseña que ha puesto no coincide, vuelve a repetirlo");
                    continue;
                }
                Console.WriteLine("Tu contraseña ha sido guardada");
                condicional = false;
            }
        }
        
        
    }
}