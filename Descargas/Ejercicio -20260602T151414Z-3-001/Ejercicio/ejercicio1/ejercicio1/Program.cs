using System; // Permite usar Console, string, int, etc.
using System.Drawing; // Permite usar Bitmap y Color para trabajar con imágenes.
using System.Drawing.Imaging; // Permite guardar la imagen con formato BMP.
using System.Text; // Permite usar StringBuilder y Encoding.UTF8.
using System.IO; // Permite usar File.Exists para validar archivos.

class Program // Clase principal del programa.
{
    static void Main() // Método principal donde inicia el programa.
    {
        Console.WriteLine("1. Ocultar mensaje"); // Muestra la opción 1.
        Console.WriteLine("2. Extraer mensaje"); // Muestra la opción 2.
        Console.Write("Opción: "); // Pide al usuario una opción.

        string opcion = Console.ReadLine(); // Lee lo que el usuario escribió.

        if (opcion == "1") // Si el usuario escribe 1...
            OcultarMensaje(); // Llama al método para ocultar el mensaje.
        else if (opcion == "2") // Si el usuario escribe 2...
            ExtraerMensaje(); // Llama al método para extraer el mensaje.
        else // Si escribió otra cosa...
            Console.WriteLine("Opción no válida."); // Muestra error.
    }


    static void OcultarMensaje() // Método encargado de ocultar texto en una imagen.
    {
        Console.Write("Ruta de imagen BMP original: "); // Pide la ruta de la imagen original.
        string rutaOriginal = Console.ReadLine().Trim().Trim('"'); // Lee la ruta y quita espacios/comillas.

        if (!File.Exists(rutaOriginal)) // Verifica si el archivo no existe.
        {
            Console.WriteLine("La imagen original no existe."); // Muestra error.
            return; // Sale del método.
        }

        Console.Write("Mensaje a ocultar: "); // Pide el mensaje.
        string mensaje = Console.ReadLine(); // Guarda el mensaje escrito.

        Console.Write("Ruta de salida BMP: "); // Pide dónde guardar la nueva imagen.
        string rutaSalida = Console.ReadLine().Trim().Trim('"'); // Lee la ruta de salida.

        /* The line `Bitmap imagen = new Bitmap(rutaOriginal);` is creating a new instance of the
        `Bitmap` class in C# by loading an image file specified by the `rutaOriginal` variable. This
        line reads an image file from the specified path and stores it as a `Bitmap` object named
        `imagen`, which can then be used to manipulate the image data, such as accessing pixel
        colors, dimensions, and saving the modified image. */
        Bitmap imagen = new Bitmap(rutaOriginal); // Carga la imagen original en memoria.

        string bitsMensaje = TextoABits(mensaje); // Convierte el mensaje a una cadena de 0 y 1.

        Console.WriteLine("Bits que se van a guardar:"); // Muestra texto informativo.
        Console.WriteLine(bitsMensaje); // Muestra los bits del mensaje.

        int capacidad = imagen.Width * imagen.Height * 3; // Calcula cuántos bits caben en la imagen.

        if (bitsMensaje.Length > capacidad) // Verifica si el mensaje no cabe.
        {
            Console.WriteLine("La imagen es muy pequeña para guardar ese mensaje."); // Muestra error.
            return; // Sale del método.
        }

        int indiceBit = 0; // Indica qué bit del mensaje se está guardando.

        for (int y = 0; y < imagen.Height; y++) // Recorre las filas de la imagen.
        {
            for (int x = 0; x < imagen.Width; x++) // Recorre las columnas de la imagen.
            {
                Color pixel = imagen.GetPixel(x, y); // Obtiene el píxel actual.

                int r = pixel.R; // Guarda el valor rojo.
                int g = pixel.G; // Guarda el valor verde.
                int b = pixel.B; // Guarda el valor azul.

                if (indiceBit < bitsMensaje.Length) // Si todavía hay bits por guardar...
                    r = ModificarColor(r, bitsMensaje[indiceBit++]); // Guarda un bit en el rojo.

                if (indiceBit < bitsMensaje.Length) // Si todavía hay bits por guardar...
                    g = ModificarColor(g, bitsMensaje[indiceBit++]); // Guarda un bit en el verde.

                if (indiceBit < bitsMensaje.Length) // Si todavía hay bits por guardar...
                    b = ModificarColor(b, bitsMensaje[indiceBit++]); // Guarda un bit en el azul.

                imagen.SetPixel(x, y, Color.FromArgb(r, g, b)); // Reemplaza el píxel con los colores modificados.

                if (indiceBit >= bitsMensaje.Length) // Si ya se guardaron todos los bits...
                    break; // Sale del ciclo de columnas.
            }

            if (indiceBit >= bitsMensaje.Length) // Si ya se guardaron todos los bits...
                break; // Sale del ciclo de filas.
        }

        if (!rutaSalida.EndsWith(".bmp")) // Si la ruta no termina en .bmp...
            rutaSalida += ".bmp"; // Le agrega la extensión .bmp.

        imagen.Save(rutaSalida, ImageFormat.Bmp); // Guarda la imagen modificada como BMP.
        imagen.Dispose(); // Libera la imagen de la memoria.

        Console.WriteLine("Mensaje ocultado correctamente."); // Confirma que terminó.
        Console.WriteLine("Imagen guardada en:"); // Muestra texto informativo.
        Console.WriteLine(rutaSalida); // Muestra la ruta donde se guardó.
    }

    static void ExtraerMensaje() // Método encargado de leer el mensaje oculto.
    {
        Console.Write("Ruta de imagen BMP modificada: "); // Pide la imagen con mensaje oculto.
        string ruta = Console.ReadLine().Trim().Trim('"'); // Lee la ruta y limpia espacios/comillas.

        if (!File.Exists(ruta)) // Verifica si la imagen no existe.
        {
            Console.WriteLine("La imagen no existe."); // Muestra error.
            return; // Sale del método.
        }

        Bitmap imagen = new Bitmap(ruta); // Carga la imagen modificada.

        StringBuilder bitsExtraidos = new StringBuilder(); // Guarda temporalmente bits leídos.
        StringBuilder mensaje = new StringBuilder(); // Guarda el mensaje reconstruido.

        for (int y = 0; y < imagen.Height; y++) // Recorre las filas.
        {
            for (int x = 0; x < imagen.Width; x++) // Recorre las columnas.
            {
                Color pixel = imagen.GetPixel(x, y); // Obtiene el píxel actual.

                bitsExtraidos.Append(LeerBit(pixel.R)); // Lee el bit oculto en el rojo.
                bitsExtraidos.Append(LeerBit(pixel.G)); // Lee el bit oculto en el verde.
                bitsExtraidos.Append(LeerBit(pixel.B)); // Lee el bit oculto en el azul.

                while (bitsExtraidos.Length >= 8) // Mientras haya al menos 8 bits...
                {
                    string byteTexto = bitsExtraidos.ToString(0, 8); // Toma los primeros 8 bits.
                    bitsExtraidos.Remove(0, 8); // Elimina esos 8 bits ya procesados.

                    int valorDecimal = Convert.ToInt32(byteTexto, 2); // Convierte los 8 bits a número decimal.

                    if (valorDecimal == 0) // Si el byte es 0, significa fin del mensaje.
                    {
                        imagen.Dispose(); // Libera la imagen de memoria.

                        Console.WriteLine("Mensaje extraído:"); // Muestra título.
                        Console.WriteLine(mensaje.ToString()); // Muestra el mensaje leído.
                        return; // Termina el método.
                    }

                    mensaje.Append((char)valorDecimal); // Convierte el número a carácter y lo agrega al mensaje.
                }
            }
        }

        imagen.Dispose(); // Libera la imagen si nunca encontró el terminador.

        Console.WriteLine("No se encontró mensaje."); // Muestra que no encontró final válido.
    }

    static string TextoABits(string texto) // Convierte texto a bits.
    {
        byte[] bytes = Encoding.UTF8.GetBytes(texto + "\0"); // Convierte el texto a bytes y agrega terminador 0.

        StringBuilder bits = new StringBuilder(); // Aquí se guardarán los bits como texto.

        foreach (byte b in bytes) // Recorre cada byte del mensaje.
        {
            bits.Append(Convert.ToString(b, 2).PadLeft(8, '0')); // Convierte cada byte a 8 bits.
        }

        return bits.ToString(); // Devuelve todos los bits juntos.
    }

    static int ModificarColor(int valor, char bit) // Modifica un color para guardar un bit.
    {
        if (bit == '0') // Si el bit que se quiere guardar es 0...
        {
            if (valor % 2 != 0) // Si el color es impar...
                valor--; // Lo vuelve par.
        }
        else // Si el bit que se quiere guardar es 1...
        {
            if (valor % 2 == 0) // Si el color es par...
                valor++; // Lo vuelve impar.
        }

        return valor; // Devuelve el color modificado.
    }

    static char LeerBit(int valor) // Lee el bit oculto en un color.
    {
        if (valor % 2 == 0) // Si el color es par...
            return '0'; // Representa un 0.
        else // Si el color es impar...
            return '1'; // Representa un 1.
    }
}