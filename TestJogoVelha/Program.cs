// Importações do código
using System.Reflection.Metadata;
using System.Threading;
using System.Linq;

String[,] matriz = new String[3,3]; // Matriz que ira ser o tabuleiro com as cordenadas

// Númerando a Matriz
int n = 0;
for (int l = 0; l < matriz.GetLength(0); l+=1) // .GetLength(0) pega a Quantidade de Linhas
{
    for (int c = 0; c < matriz.GetLength(1); c+=1) // .GetLength(0) pega a Quantidade de Colunas
    {
        matriz[l, c] = Convert.ToString(n += 1);
    }
}
// Começo do jogo de dois jogadores

Console.WriteLine("JOGO DA VELHA ENTRE DOIS JOGADORES");

// Jogador vs Jogador
String primeiroJogador = "";
String segundoJogador = "";

if (primeiroJogador == "" || segundoJogador == "")
{
    string scannerNome;
    // Entrada primeiro jogador
    Console.Write("Digite o nome do primeiro jogador(X): ");
    scannerNome = Console.ReadLine();
    primeiroJogador = scannerNome;
    // Entrada primeiro jogador
    Console.Write("Digite o nome do segundo jogador(O): ");
    scannerNome = Console.ReadLine();
    segundoJogador = scannerNome;
}

// Método usado para ver de quem é a vez
int vezJogador = 0;

while (true)
{
    // Printando a matriz
    for (int l = 0; l < matriz.GetLength(0); l += 1)
    {
        Console.WriteLine("  ___    ___    ___");
        for (int c = 0; c < matriz.GetLength(1); c += 1)
        {
            Console.Write(" | " + matriz[l, c] + " | ");
            Thread.Sleep(100);
        }
        Console.WriteLine();
    }
    Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯  ");
    // Fala de quem é a vez
    if (vezJogador == 0)
    {
        Console.WriteLine("Vez do Jogador: " + primeiroJogador);
    }
    else
    {
        Console.WriteLine("Vez do Jogador: " + segundoJogador);
    }

    // Entrada de dados dos jogadores para a jogada.
    String scannerJogada;
    Console.Write("Digite um número de 1 a 9: ");
    scannerJogada = Console.ReadLine();
    string jogadaDoJogador = scannerJogada; // Jogando scanner dentro da variavel.

    // Teste lógico Para ver onde vai a pessa. Támbem com verificação de número fora dos valores estipulados.

    // verifica se não é número
    if (jogadaDoJogador.Any(char.IsLetter))
    {
        Console.WriteLine("Não é Número.");
        continue;
    }

    // Verifica se está entre 1 e 9 
    int verifica = Convert.ToInt32(jogadaDoJogador);
    if (verifica < 1 || verifica > 9) 
    {
        Console.WriteLine("Número invalido.");
        continue;
    }

    // Coloca a peça no determinado lugar do tabuleiro
    if (jogadaDoJogador == "1")
    {
        // Verificação da casa no tabuleiro
        if (matriz[0,0] != "1")
        {
            Console.WriteLine("Um jogador ja marcou está casa");
            continue;
        }

        // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
        if (vezJogador == 0)
        {
            matriz[0, 0] = "X";
            vezJogador++;
        }
        else
        {
            matriz[0, 0] = "O";
            vezJogador--;
        }
    }
    else if (jogadaDoJogador == "2")
    {
        // Verificação da casa no tabuleiro
        if (matriz[0, 1] != "2")
        {
            Console.WriteLine("Um jogador ja marcou está casa");
            continue;
        }

        // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
        if (vezJogador == 0)
        {
            matriz[0, 1] = "X";
            vezJogador++;
        }
        else
        {
            matriz[0, 1] = "O";
            vezJogador--;
        }
    }
    else if (jogadaDoJogador == "3")
    {
        // Verificação da casa no tabuleiro
        if (matriz[0, 2] != "3")
        {
            Console.WriteLine("Um jogador ja marcou está casa");
            continue;
        }

        // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
        if (vezJogador == 0)
        {
            matriz[0, 2] = "X";
            vezJogador++;
        }
        else
        {
            matriz[0, 2] = "O";
            vezJogador--;
        }
    }
    else if (jogadaDoJogador == "4")
    {
        // Verificação da casa no tabuleiro
        if (matriz[1, 0] != "4")
        {
            Console.WriteLine("Um jogador ja marcou está casa");
            continue;
        }

        // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
        if (vezJogador == 0)
        {
            matriz[1, 0] = "X";
            vezJogador++;
        }
        else
        {
            matriz[1, 0] = "O";
            vezJogador--;
        }
    }
    else if (jogadaDoJogador == "5")
    {
        // Verificação da casa no tabuleiro
        if (matriz[1, 1] != "5")
        {
            Console.WriteLine("Um jogador ja marcou está casa");
            continue;
        }

        // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
        if (vezJogador == 0)
        {
            matriz[1, 1] = "X";
            vezJogador++;
        }
        else
        {
            matriz[1, 1] = "O";
            vezJogador--;
        }
    }
    else if (jogadaDoJogador == "6")
    {
        // Verificação da casa no tabuleiro
        if (matriz[1, 2] != "6")
        {
            Console.WriteLine("Um jogador ja marcou está casa");
            continue;
        }

        // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
        if (vezJogador == 0)
        {
            matriz[1, 2] = "X";
            vezJogador++;
        }
        else
        {
            matriz[1, 2] = "O";
            vezJogador--;
        }
    }
    else if (jogadaDoJogador == "7")
    {
        // Verificação da casa no tabuleiro
        if (matriz[2, 0] != "7")
        {
            Console.WriteLine("Um jogador ja marcou está casa");
            continue;
        }

        // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
        if (vezJogador == 0)
        {
            matriz[2, 0] = "X";
            vezJogador++;
        }
        else
        {
            matriz[2, 0] = "O";
            vezJogador--;
        }
    }
    else if (jogadaDoJogador == "8")
    {
        // Verificação da casa no tabuleiro
        if (matriz[2, 1] != "8")
        {
            Console.WriteLine("Um jogador ja marcou está casa");
            continue;
        }

        // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
        if (vezJogador == 0)
        {
            matriz[2, 1] = "X";
            vezJogador++;
        }
        else
        {
            matriz[2, 1] = "O";
            vezJogador--;
        }
    }
    else
    {
        // Verificação da casa no tabuleiro
        if (matriz[2, 2] != "9")
        {
            Console.WriteLine("Um jogador ja marcou está casa");
            continue;
        }

        // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
        if (vezJogador == 0)
        {
            matriz[2, 2] = "X";
            vezJogador++;
        }
        else
        {
            matriz[2, 2] = "O";
            vezJogador--;
        }
    }

    /*
    Para poder saber se o "jogador X" ou o "jogador O" fez um ponto podemos usar if e else para analisar os 8 posiveis casos de pontuação, sendo eles:

        - Linhas: 3 linhas

        - colunas: 3 colunas

        - Verticais: 2 verticais

    */

    // Primeiro caso da linha(1,2 e 3)
    if (matriz[0, 0] == "X" && matriz[0, 1] == "X" && matriz[0, 2] == "X" || matriz[0, 0] == "O" && matriz[0, 1] == "O" && matriz[0, 2] == "O")
    {
        if (matriz[0, 0] == "X" && matriz[0, 1] == "X" && matriz[0, 2] == "X")
        {
            Console.WriteLine("O vencedor é o jogador: " + primeiroJogador);
        }
        else 
        {
            Console.WriteLine("O vencedor é o jogador: " + segundoJogador);
        }
       
    }
}

//Teste