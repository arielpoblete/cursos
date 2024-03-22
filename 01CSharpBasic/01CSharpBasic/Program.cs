// See https://aka.ms/new-console-template for more information
Console.WriteLine("Lets play BlackJack!");

Console.WriteLine("Cuántos créditos quieres?");
int lucas = Convert.ToInt32(Console.ReadLine());
string jugar = "si";
int apostador;


// bucle de muchos juegos
do
{
    Console.WriteLine("Desea un nuevo Juego (si / no)?");
    jugar =  Console.ReadLine();
    if (jugar == "si")
    {
        apostador = 0;
        Console.WriteLine($"Cuánto desea apostar? Su saldo es de {lucas}.");
        int apuesta = Convert.ToInt32(Console.ReadLine());
        Random rnd = new Random();

        // bucle para apostador
        string pedir = "si";
        while (pedir == "si")
        {
            Console.WriteLine($"¿desea una nueva carta (si / no)? Sus cartas suman: {apostador}");
            pedir = Console.ReadLine();
            if (pedir == "si")
            {
                int carta = rnd.Next(1, 10);
                Console.WriteLine($"Salió un {carta}.");
                apostador += carta;
            }
        }

        if (apostador > 21)
        {
            Console.WriteLine($"Perdiste {apuesta}.");
            lucas-= apuesta;
        }
        else
        {
            // bucle para croupier
            int casa = 0;
            while (casa < 16)
            {
                int carta = rnd.Next(1, 10);
                casa += carta;
                Console.WriteLine($"Croupier robó un {carta} y suma {casa}.");
            }
            if (casa > 21)
            {
                Console.WriteLine($"Ganaste {apuesta}.");
                lucas += apuesta;
            }
            else
            {
                Console.WriteLine($"Tu robaste {apostador} y la casa {casa}.");
                if (apostador > casa)
                {
                    Console.WriteLine($"Ganaste {apuesta}.");
                    lucas += apuesta;
                }
                else
                {
                    Console.WriteLine($"Perdiste {apuesta}.");
                    lucas -= apuesta;
                }
            }

        }

    }
} while ((lucas > 0) && (jugar == "si"));
