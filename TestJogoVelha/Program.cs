/* 
Grupo:
 —  Eduardo Lopes Barros dos Santos - RA: 2025105015
 —  Guilherme de Lima Ficagna - RA: 2025105145
 —  Cleberson Cesar Bueno dos Santos - RA: 2025105040
*/

// Importações do código
using Spectre.Console;
using System.Threading;
using System.Linq;

String[,] matriz = new String[3, 3]; // Matriz que ira ser o tabuleiro com as cordenadas

// Númerando a Matriz
int n = 0;
for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
{
    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
    {
        matriz[l, c] = Convert.ToString(n += 1);
    }
}

Dictionary<string, int> ranking = new Dictionary<string, int>()
{
    {"X", 0},
    {"O", 0},
    {"Bot", 0 },
    {"Velha", 0}
};

Dictionary<string, Color> coresJogadores = new()
{
    {"X", Color.Red},
    {"O", Color.Blue},
    {"Bot", Color.Yellow},
    {"Velha", Color.Grey}
};

Random random = new();


void MostrarRanking(Dictionary<string, int> ranking, bool noMenu = false)
{
    if (!noMenu) Console.Clear();

    var chart = new BarChart()
        .Width(60)
        .Label("[green]Ranking de Vitórias[/]");

    foreach (var kvp in ranking)
    {
        if (!coresJogadores.ContainsKey(kvp.Key))
        {
            coresJogadores[kvp.Key] = new Color(
                (byte)random.Next(50, 256),
                (byte)random.Next(50, 256),
                (byte)random.Next(50, 256)
            );
        }

        chart.AddItem(kvp.Key, kvp.Value, coresJogadores[kvp.Key]);
    }

    AnsiConsole.Write(chart);

    if (!noMenu)
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }
}




// Começo do menu
while (true)
{
    Console.WriteLine("JOGO DA VELHA EM C#");
    Console.WriteLine();

    //Ranking Somente em Texto (Sem o Gráfico)
    MostrarRanking(ranking, true);


    // Opção de querer jogar ou não
    string scannerMenu;
    Console.Write("Quer jogar ? (1 para sim, 2 para não): ");
    scannerMenu = Console.ReadLine();
    if (scannerMenu == "1")
    {
        // so continua
    }
    else
    {
        Console.WriteLine("Volte sempre!");
        break;
    }

    //Inclusão da opção de escolher o modo de jogo, sendo 1 para Jogador x Jogador e 2 para Jogador x Bot
    Console.Write("Selecione 1 para dois jogadores, e 2 para jogador x Bot: ");
    string op1 = Console.ReadLine();

    //Jogador x Jogador
    if (op1 == "1")
    {
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

            // Nome do jogador vai para o ranking, mas antes é feio uma verificação pra ver se ja não existe
            if (ranking.ContainsKey(primeiroJogador))
            {
                Console.WriteLine($"Bem vindo novamente {primeiroJogador}!");
                MostrarRanking(ranking, true);
            }
            else
            {
                ranking.Add(primeiroJogador, 0);
            }


            // Entrada segundo jogador
            Console.Write("Digite o nome do segundo jogador(O): ");
            scannerNome = Console.ReadLine();
            segundoJogador = scannerNome;

            // Nome do jogador vai para o ranking, mas antes é feio uma verificação pra ver se ja não existe
            if (ranking.ContainsKey(segundoJogador))
            {
                Console.WriteLine($"Bem vindo novamente {segundoJogador}!");
                MostrarRanking(ranking, true);
            }
            else
            {
                ranking.Add(segundoJogador, 0);
            }
        }


        // Método usado para ver de quem é a vez
        int vezJogador = 0;
        // Lógica para voltar ao menu ou continuar jogando
        string scannerDecision;
        bool vencedor = false;
        int contagemRodada = 0;
        while (!vencedor || contagemRodada > 8)
        {
            // Fala de quem é a vez
            if (vezJogador == 0)
            {
                // Printando a matriz com cores
                for (int l = 0; l < matriz.GetLength(0); l++)
                {
                    Console.WriteLine("  ___    ___    ___");
                    for (int c = 0; c < matriz.GetLength(1); c++)
                    {
                        Console.Write(" | ");

                        if (matriz[l, c] == "X")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                            Console.Write("X");
                            Console.ResetColor();
                        }
                        else if (matriz[l, c] == "O")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;  // O em azul
                            Console.Write("O");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(matriz[l, c]); // número normal
                        }

                        Console.Write(" | ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                Console.WriteLine("Vez do Jogador: " + primeiroJogador);
            }
            else
            {
                // Printando a matriz com cores
                for (int l = 0; l < matriz.GetLength(0); l++)
                {
                    Console.WriteLine("  ___    ___    ___");
                    for (int c = 0; c < matriz.GetLength(1); c++)
                    {
                        Console.Write(" | ");

                        if (matriz[l, c] == "X")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                            Console.Write("X");
                            Console.ResetColor();
                        }
                        else if (matriz[l, c] == "O")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;  // O em azul
                            Console.Write("O");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(matriz[l, c]); // número normal
                        }

                        Console.Write(" | ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

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
                if (matriz[0, 0] != "1")
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
                contagemRodada++;
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
                contagemRodada++;
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
                contagemRodada++;
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
                contagemRodada++;
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
                contagemRodada++;
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
                contagemRodada++;
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
                contagemRodada++;
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
                contagemRodada++;
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
                contagemRodada++;
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
                    // Printando a matriz com cores
                    for (int l = 0; l < matriz.GetLength(0); l++)
                    {
                        Console.WriteLine("  ___    ___    ___");
                        for (int c = 0; c < matriz.GetLength(1); c++)
                        {
                            Console.Write(" | ");

                            if (matriz[l, c] == "X")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                Console.Write("X");
                                Console.ResetColor();
                            }
                            else if (matriz[l, c] == "O")
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;  // O em azul
                                Console.Write("O");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(matriz[l, c]); // número normal
                            }

                            Console.Write(" | ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                    // Atualiza pontuação
                    if (primeiroJogador == "X")
                    {
                        ranking["X"] += 1;
                    }
                    else
                    {
                        ranking[primeiroJogador] += 1;
                        ranking["X"] += 1;
                    }



                    // Printa o ranking com os jogadores
                    Console.WriteLine("RANKING");
                    foreach (KeyValuePair<string, int> r in ranking)
                    {
                        Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                    }

                    Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                    string verRanking = Console.ReadLine();

                    if (verRanking == "1")
                    {
                        MostrarRanking(ranking);

                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else
                        // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                    if (verRanking == "2")
                    {
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else
                        // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("O vencedor é o jogador: " + segundoJogador);
                    // Printando a matriz com cores
                    for (int l = 0; l < matriz.GetLength(0); l++)
                    {
                        Console.WriteLine("  ___    ___    ___");
                        for (int c = 0; c < matriz.GetLength(1); c++)
                        {
                            Console.Write(" | ");

                            if (matriz[l, c] == "X")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                Console.Write("X");
                                Console.ResetColor();
                            }
                            else if (matriz[l, c] == "O")
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;  // O em azul
                                Console.Write("O");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(matriz[l, c]); // número normal
                            }

                            Console.Write(" | ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                    // Soma pontuação no ranking
                    if (segundoJogador == "O")
                    {
                        ranking["O"] += 1;
                    }
                    else
                    {
                        ranking[segundoJogador] += 1;
                        ranking["O"] += 1;
                    }

                    // Printa o ranking com os jogadores
                    Console.WriteLine("RANKING");
                    foreach (KeyValuePair<string, int> r in ranking)
                    {
                        Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                    }

                    Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                    string verRanking = Console.ReadLine();

                    if (verRanking == "1")
                    {
                        MostrarRanking(ranking);
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                    if (verRanking == "2")
                    {
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                }

            }

            // Segundo caso da linha(4,5 e 6)
            if (matriz[1, 0] == "X" && matriz[1, 1] == "X" && matriz[1, 2] == "X" || matriz[1, 0] == "O" && matriz[1, 1] == "O" && matriz[1, 2] == "O")
            {
                if (matriz[1, 0] == "X" && matriz[1, 1] == "X" && matriz[1, 2] == "X")
                {
                    Console.WriteLine("O vencedor é o jogador: " + primeiroJogador);
                    // Printando a matriz com cores
                    for (int l = 0; l < matriz.GetLength(0); l++)
                    {
                        Console.WriteLine("  ___    ___    ___");
                        for (int c = 0; c < matriz.GetLength(1); c++)
                        {
                            Console.Write(" | ");

                            if (matriz[l, c] == "X")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                Console.Write("X");
                                Console.ResetColor();
                            }
                            else if (matriz[l, c] == "O")
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;  // O em azul
                                Console.Write("O");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(matriz[l, c]); // número normal
                            }

                            Console.Write(" | ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                    // Atualiza pontuação
                    if (primeiroJogador == "X")
                    {
                        ranking["X"] += 1;
                    }
                    else
                    {
                        ranking[primeiroJogador] += 1;
                        ranking["X"] += 1;
                    }


                    // Printa o ranking com os jogadores
                    Console.WriteLine("RANKING");
                    foreach (KeyValuePair<string, int> r in ranking)
                    {
                        Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                    }

                    Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                    string verRanking = Console.ReadLine();

                    if (verRanking == "1")
                    {
                        MostrarRanking(ranking);

                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else
                        // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                    if (verRanking == "2")
                    {
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else
                        // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("O vencedor é o jogador: " + segundoJogador);
                    // Printando a matriz com cores
                    for (int l = 0; l < matriz.GetLength(0); l++)
                    {
                        Console.WriteLine("  ___    ___    ___");
                        for (int c = 0; c < matriz.GetLength(1); c++)
                        {
                            Console.Write(" | ");

                            if (matriz[l, c] == "X")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                Console.Write("X");
                                Console.ResetColor();
                            }
                            else if (matriz[l, c] == "O")
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;  // O em azul
                                Console.Write("O");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(matriz[l, c]); // número normal
                            }

                            Console.Write(" | ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                    // Soma pontuação no ranking
                    if (segundoJogador == "O")
                    {
                        ranking["O"] += 1;
                    }
                    else
                    {
                        ranking[segundoJogador] += 1;
                        ranking["O"] += 1;
                    }

                    // Printa o ranking com os jogadores
                    Console.WriteLine("RANKING");
                    foreach (KeyValuePair<string, int> r in ranking)
                    {
                        Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                    }

                    Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                    string verRanking = Console.ReadLine();

                    if (verRanking == "1")
                    {
                        MostrarRanking(ranking);
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                    if (verRanking == "2")
                    {
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                }

            }

            // Terceiro caso da linha(7,8 e 9)
            if (matriz[2, 0] == "X" && matriz[2, 1] == "X" && matriz[2, 2] == "X" || matriz[2, 0] == "O" && matriz[2, 1] == "O" && matriz[2, 2] == "O")
            {
                if (matriz[2, 0] == "X" && matriz[2, 1] == "X" && matriz[2, 2] == "X")
                {
                    Console.WriteLine("O vencedor é o jogador: " + primeiroJogador);
                    // Printando a matriz com cores
                    for (int l = 0; l < matriz.GetLength(0); l++)
                    {
                        Console.WriteLine("  ___    ___    ___");
                        for (int c = 0; c < matriz.GetLength(1); c++)
                        {
                            Console.Write(" | ");

                            if (matriz[l, c] == "X")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                Console.Write("X");
                                Console.ResetColor();
                            }
                            else if (matriz[l, c] == "O")
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;  // O em azul
                                Console.Write("O");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(matriz[l, c]); // número normal
                            }

                            Console.Write(" | ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                    // Atualiza pontuação
                    if (primeiroJogador == "X")
                    {
                        ranking["X"] += 1;
                    }
                    else
                    {
                        ranking[primeiroJogador] += 1;
                        ranking["X"] += 1;
                    }


                    // Printa o ranking com os jogadores
                    Console.WriteLine("RANKING");
                    foreach (KeyValuePair<string, int> r in ranking)
                    {
                        Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                    }

                    Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                    string verRanking = Console.ReadLine();

                    if (verRanking == "1")
                    {
                        MostrarRanking(ranking);

                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else
                        // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                    if (verRanking == "2")
                    {
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else
                        // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("O vencedor é o jogador: " + segundoJogador);
                    // Printando a matriz com cores
                    for (int l = 0; l < matriz.GetLength(0); l++)
                    {
                        Console.WriteLine("  ___    ___    ___");
                        for (int c = 0; c < matriz.GetLength(1); c++)
                        {
                            Console.Write(" | ");

                            if (matriz[l, c] == "X")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                Console.Write("X");
                                Console.ResetColor();
                            }
                            else if (matriz[l, c] == "O")
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;  // O em azul
                                Console.Write("O");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(matriz[l, c]); // número normal
                            }

                            Console.Write(" | ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                    // Soma pontuação no ranking
                    if (segundoJogador == "O")
                    {
                        ranking["O"] += 1;
                    }
                    else
                    {
                        ranking[segundoJogador] += 1;
                        ranking["O"] += 1;
                    }

                    // Printa o ranking com os jogadores
                    Console.WriteLine("RANKING");
                    foreach (KeyValuePair<string, int> r in ranking)
                    {
                        Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                    }

                    Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                    string verRanking = Console.ReadLine();

                    if (verRanking == "1")
                    {
                        MostrarRanking(ranking);
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                    if (verRanking == "2")
                    {
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                }
            }

            // Primeiro caso de coluna(1,4 e 7)
            if (matriz[0, 0] == "X" && matriz[1, 0] == "X" && matriz[2, 0] == "X" || matriz[0, 0] == "O" && matriz[1, 0] == "O" && matriz[2, 0] == "O")
            {
                if (matriz[0, 0] == "X" && matriz[1, 0] == "X" && matriz[2, 0] == "X")
                {
                    Console.WriteLine("O vencedor é o jogador: " + primeiroJogador);
                    // Printando a matriz com cores
                    for (int l = 0; l < matriz.GetLength(0); l++)
                    {
                        Console.WriteLine("  ___    ___    ___");
                        for (int c = 0; c < matriz.GetLength(1); c++)
                        {
                            Console.Write(" | ");

                            if (matriz[l, c] == "X")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                Console.Write("X");
                                Console.ResetColor();
                            }
                            else if (matriz[l, c] == "O")
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;  // O em azul
                                Console.Write("O");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(matriz[l, c]); // número normal
                            }

                            Console.Write(" | ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                    // Atualiza pontuação
                    if (primeiroJogador == "X")
                    {
                        ranking["X"] += 1;
                    }
                    else
                    {
                        ranking[primeiroJogador] += 1;
                        ranking["X"] += 1;
                    }


                    // Printa o ranking com os jogadores
                    Console.WriteLine("RANKING");
                    foreach (KeyValuePair<string, int> r in ranking)
                    {
                        Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                    }

                    Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                    string verRanking = Console.ReadLine();

                    if (verRanking == "1")
                    {
                        MostrarRanking(ranking);

                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else
                        // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                    if (verRanking == "2")
                    {
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else
                        // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("O vencedor é o jogador: " + segundoJogador);
                    // Printando a matriz com cores
                    for (int l = 0; l < matriz.GetLength(0); l++)
                    {
                        Console.WriteLine("  ___    ___    ___");
                        for (int c = 0; c < matriz.GetLength(1); c++)
                        {
                            Console.Write(" | ");

                            if (matriz[l, c] == "X")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                Console.Write("X");
                                Console.ResetColor();
                            }
                            else if (matriz[l, c] == "O")
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;  // O em azul
                                Console.Write("O");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(matriz[l, c]); // número normal
                            }

                            Console.Write(" | ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                    // Soma pontuação no ranking
                    if (segundoJogador == "O")
                    {
                        ranking["O"] += 1;
                    }
                    else
                    {
                        ranking[segundoJogador] += 1;
                        ranking["O"] += 1;
                    }

                    // Printa o ranking com os jogadores
                    Console.WriteLine("RANKING");
                    foreach (KeyValuePair<string, int> r in ranking)
                    {
                        Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                    }

                    Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                    string verRanking = Console.ReadLine();

                    if (verRanking == "1")
                    {
                        MostrarRanking(ranking);
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                    if (verRanking == "2")
                    {
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                }
            }

            // Segundo caso de coluna(2,5 e 8)
            if (matriz[0, 1] == "X" && matriz[1, 1] == "X" && matriz[2, 1] == "X" || matriz[0, 1] == "O" && matriz[1, 1] == "O" && matriz[2, 1] == "O")
            {
                if (matriz[0, 1] == "X" && matriz[1, 1] == "X" && matriz[2, 1] == "X")
                {
                    Console.WriteLine("O vencedor é o jogador: " + primeiroJogador);
                    // Printando a matriz com cores
                    for (int l = 0; l < matriz.GetLength(0); l++)
                    {
                        Console.WriteLine("  ___    ___    ___");
                        for (int c = 0; c < matriz.GetLength(1); c++)
                        {
                            Console.Write(" | ");

                            if (matriz[l, c] == "X")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                Console.Write("X");
                                Console.ResetColor();
                            }
                            else if (matriz[l, c] == "O")
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;  // O em azul
                                Console.Write("O");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(matriz[l, c]); // número normal
                            }

                            Console.Write(" | ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                    // Atualiza pontuação
                    if (primeiroJogador == "X")
                    {
                        ranking["X"] += 1;
                    }
                    else
                    {
                        ranking[primeiroJogador] += 1;
                        ranking["X"] += 1;
                    }


                    // Printa o ranking com os jogadores
                    Console.WriteLine("RANKING");
                    foreach (KeyValuePair<string, int> r in ranking)
                    {
                        Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                    }

                    Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                    string verRanking = Console.ReadLine();

                    if (verRanking == "1")
                    {
                        MostrarRanking(ranking);

                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else
                        // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                    if (verRanking == "2")
                    {
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else
                        // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("O vencedor é o jogador: " + segundoJogador);
                    // Printando a matriz com cores
                    for (int l = 0; l < matriz.GetLength(0); l++)
                    {
                        Console.WriteLine("  ___    ___    ___");
                        for (int c = 0; c < matriz.GetLength(1); c++)
                        {
                            Console.Write(" | ");

                            if (matriz[l, c] == "X")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                Console.Write("X");
                                Console.ResetColor();
                            }
                            else if (matriz[l, c] == "O")
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;  // O em azul
                                Console.Write("O");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(matriz[l, c]); // número normal
                            }

                            Console.Write(" | ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                    // Soma pontuação no ranking
                    if (segundoJogador == "O")
                    {
                        ranking["O"] += 1;
                    }
                    else
                    {
                        ranking[segundoJogador] += 1;
                        ranking["O"] += 1;
                    }

                    // Printa o ranking com os jogadores
                    Console.WriteLine("RANKING");
                    foreach (KeyValuePair<string, int> r in ranking)
                    {
                        Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                    }

                    Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                    string verRanking = Console.ReadLine();

                    if (verRanking == "1")
                    {
                        MostrarRanking(ranking);
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                    if (verRanking == "2")
                    {
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                }
            }

            // Terceiro caso de coluna(3,6 e 9)
            if (matriz[0, 2] == "X" && matriz[1, 2] == "X" && matriz[2, 2] == "X" || matriz[0, 2] == "O" && matriz[1, 2] == "O" && matriz[2, 2] == "O")
            {
                if (matriz[0, 2] == "X" && matriz[1, 2] == "X" && matriz[2, 2] == "X")
                {
                    Console.WriteLine("O vencedor é o jogador: " + primeiroJogador);
                    // Printando a matriz com cores
                    for (int l = 0; l < matriz.GetLength(0); l++)
                    {
                        Console.WriteLine("  ___    ___    ___");
                        for (int c = 0; c < matriz.GetLength(1); c++)
                        {
                            Console.Write(" | ");

                            if (matriz[l, c] == "X")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                Console.Write("X");
                                Console.ResetColor();
                            }
                            else if (matriz[l, c] == "O")
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;  // O em azul
                                Console.Write("O");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(matriz[l, c]); // número normal
                            }

                            Console.Write(" | ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                    // Atualiza pontuação
                    if (primeiroJogador == "X")
                    {
                        ranking["X"] += 1;
                    }
                    else
                    {
                        ranking[primeiroJogador] += 1;
                        ranking["X"] += 1;
                    }


                    // Printa o ranking com os jogadores
                    Console.WriteLine("RANKING");
                    foreach (KeyValuePair<string, int> r in ranking)
                    {
                        Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                    }

                    Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                    string verRanking = Console.ReadLine();

                    if (verRanking == "1")
                    {
                        MostrarRanking(ranking);

                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else
                        // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                    if (verRanking == "2")
                    {
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else
                        // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("O vencedor é o jogador: " + segundoJogador);
                    // Printando a matriz com cores
                    for (int l = 0; l < matriz.GetLength(0); l++)
                    {
                        Console.WriteLine("  ___    ___    ___");
                        for (int c = 0; c < matriz.GetLength(1); c++)
                        {
                            Console.Write(" | ");

                            if (matriz[l, c] == "X")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                Console.Write("X");
                                Console.ResetColor();
                            }
                            else if (matriz[l, c] == "O")
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;  // O em azul
                                Console.Write("O");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(matriz[l, c]); // número normal
                            }

                            Console.Write(" | ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                    // Soma pontuação no ranking
                    if (segundoJogador == "O")
                    {
                        ranking["O"] += 1;
                    }
                    else
                    {
                        ranking[segundoJogador] += 1;
                        ranking["O"] += 1;
                    }

                    // Printa o ranking com os jogadores
                    Console.WriteLine("RANKING");
                    foreach (KeyValuePair<string, int> r in ranking)
                    {
                        Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                    }

                    Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                    string verRanking = Console.ReadLine();

                    if (verRanking == "1")
                    {
                        MostrarRanking(ranking);
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                    if (verRanking == "2")
                    {
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }
                }
            }

            // Primeiro caso de diagonal(1,5 e 9)
            if (matriz[0, 0] == "X" && matriz[1, 1] == "X" && matriz[2, 2] == "X" || matriz[0, 0] == "O" && matriz[1, 1] == "O" && matriz[2, 2] == "O")
            {
                if (matriz[0, 0] == "X" && matriz[1, 1] == "X" && matriz[2, 2] == "X")
                {
                    Console.WriteLine("O vencedor é o jogador: " + primeiroJogador);
                    // Printando a matriz com cores
                    for (int l = 0; l < matriz.GetLength(0); l++)
                    {
                        Console.WriteLine("  ___    ___    ___");
                        for (int c = 0; c < matriz.GetLength(1); c++)
                        {
                            Console.Write(" | ");

                            if (matriz[l, c] == "X")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                Console.Write("X");
                                Console.ResetColor();
                            }
                            else if (matriz[l, c] == "O")
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;  // O em azul
                                Console.Write("O");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(matriz[l, c]); // número normal
                            }

                            Console.Write(" | ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                    // Atualiza pontuação
                    if (primeiroJogador == "X")
                    {
                        ranking["X"] += 1;
                    }
                    else
                    {
                        ranking[primeiroJogador] += 1;
                        ranking["X"] += 1;
                    }


                    // Printa o ranking com os jogadores
                    Console.WriteLine("RANKING");
                    foreach (KeyValuePair<string, int> r in ranking)
                    {
                        Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                    }

                    Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                    string verRanking = Console.ReadLine();

                    if (verRanking == "1")
                    {
                        MostrarRanking(ranking);

                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else
                        // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                    if (verRanking == "2")
                    {
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else
                        // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("O vencedor é o jogador: " + segundoJogador);
                    // Printando a matriz com cores
                    for (int l = 0; l < matriz.GetLength(0); l++)
                    {
                        Console.WriteLine("  ___    ___    ___");
                        for (int c = 0; c < matriz.GetLength(1); c++)
                        {
                            Console.Write(" | ");

                            if (matriz[l, c] == "X")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                Console.Write("X");
                                Console.ResetColor();
                            }
                            else if (matriz[l, c] == "O")
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;  // O em azul
                                Console.Write("O");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(matriz[l, c]); // número normal
                            }

                            Console.Write(" | ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                    // Soma pontuação no ranking
                    if (segundoJogador == "O")
                    {
                        ranking["O"] += 1;
                    }
                    else
                    {
                        ranking[segundoJogador] += 1;
                        ranking["O"] += 1;
                    }

                    // Printa o ranking com os jogadores
                    Console.WriteLine("RANKING");
                    foreach (KeyValuePair<string, int> r in ranking)
                    {
                        Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                    }

                    Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                    string verRanking = Console.ReadLine();

                    if (verRanking == "1")
                    {
                        MostrarRanking(ranking);
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                    if (verRanking == "2")
                    {
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }
                }
            }

            // Segundo caso de diagonal(3,5 e 7)
            if (matriz[0, 2] == "X" && matriz[1, 1] == "X" && matriz[2, 0] == "X" || matriz[0, 2] == "O" && matriz[1, 1] == "O" && matriz[2, 0] == "O")
            {
                if (matriz[0, 2] == "X" && matriz[1, 1] == "X" && matriz[2, 0] == "X")
                {
                    Console.WriteLine("O vencedor é o jogador: " + primeiroJogador);
                    // Printando a matriz com cores
                    for (int l = 0; l < matriz.GetLength(0); l++)
                    {
                        Console.WriteLine("  ___    ___    ___");
                        for (int c = 0; c < matriz.GetLength(1); c++)
                        {
                            Console.Write(" | ");

                            if (matriz[l, c] == "X")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                Console.Write("X");
                                Console.ResetColor();
                            }
                            else if (matriz[l, c] == "O")
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;  // O em azul
                                Console.Write("O");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(matriz[l, c]); // número normal
                            }

                            Console.Write(" | ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                    // Atualiza pontuação
                    if (primeiroJogador == "X")
                    {
                        ranking["X"] += 1;
                    }
                    else
                    {
                        ranking[primeiroJogador] += 1;
                        ranking["X"] += 1;
                    }


                    // Printa o ranking com os jogadores
                    Console.WriteLine("RANKING");
                    foreach (KeyValuePair<string, int> r in ranking)
                    {
                        Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                    }

                    Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                    string verRanking = Console.ReadLine();

                    if (verRanking == "1")
                    {
                        MostrarRanking(ranking);

                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else
                        // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                    if (verRanking == "2")
                    {
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else
                        // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("O vencedor é o jogador: " + segundoJogador);
                    // Printando a matriz com cores
                    for (int l = 0; l < matriz.GetLength(0); l++)
                    {
                        Console.WriteLine("  ___    ___    ___");
                        for (int c = 0; c < matriz.GetLength(1); c++)
                        {
                            Console.Write(" | ");

                            if (matriz[l, c] == "X")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                Console.Write("X");
                                Console.ResetColor();
                            }
                            else if (matriz[l, c] == "O")
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;  // O em azul
                                Console.Write("O");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(matriz[l, c]); // número normal
                            }

                            Console.Write(" | ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                    // Soma pontuação no ranking
                    if (segundoJogador == "O")
                    {
                        ranking["O"] += 1;
                    }
                    else
                    {
                        ranking[segundoJogador] += 1;
                        ranking["O"] += 1;
                    }

                    // Printa o ranking com os jogadores
                    Console.WriteLine("RANKING");
                    foreach (KeyValuePair<string, int> r in ranking)
                    {
                        Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                    }

                    Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                    string verRanking = Console.ReadLine();

                    if (verRanking == "1")
                    {
                        MostrarRanking(ranking);
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                    if (verRanking == "2")
                    {
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }
                }
            }

            // Caso de velha
            if (contagemRodada > 8)
            {
                Console.WriteLine("O jogo terminou em velha!");

                // Printando a matriz com cores
                for (int l = 0; l < matriz.GetLength(0); l++)
                {
                    Console.WriteLine("  ___    ___    ___");
                    for (int c = 0; c < matriz.GetLength(1); c++)
                    {
                        Console.Write(" | ");

                        if (matriz[l, c] == "X")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                            Console.Write("X");
                            Console.ResetColor();
                        }
                        else if (matriz[l, c] == "O")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;  // O em azul
                            Console.Write("O");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(matriz[l, c]); // número normal
                        }

                        Console.Write(" | ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                // Soma pontuação no ranking
                ranking["Velha"] += 1;

                // Printa o ranking com os jogadores
                Console.WriteLine("RANKING");
                foreach (KeyValuePair<string, int> r in ranking)
                {
                    Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                }

                Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                string verRanking = Console.ReadLine();

                if (verRanking == "1")
                {
                    MostrarRanking(ranking);
                    // Lógica que pergunta se quer ou não continuar
                    Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                    scannerDecision = Console.ReadLine();

                    if (scannerDecision == "1") // Caso queira
                    {
                        // renumerando a matriz
                        n = 0;
                        for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                        {
                            for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                            {
                                matriz[l, c] = Convert.ToString(n += 1);
                            }
                        }
                        Console.Clear(); // Limpa terminal
                        contagemRodada = 0;
                        vencedor = false;
                        continue;
                    }
                    else // Caso queira voltar ao menu
                    {
                        // renumerando a matriz
                        n = 0;
                        for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                        {
                            for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                            {
                                matriz[l, c] = Convert.ToString(n += 1);
                            }
                        }
                        Console.Clear(); // Limpa terminal
                        contagemRodada = 0;
                        vencedor = true;
                    }
                }

                if (verRanking == "2")
                {
                    // Lógica que pergunta se quer ou não continuar
                    Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                    scannerDecision = Console.ReadLine();

                    if (scannerDecision == "1") // Caso queira
                    {
                        // renumerando a matriz
                        n = 0;
                        for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                        {
                            for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                            {
                                matriz[l, c] = Convert.ToString(n += 1);
                            }
                        }
                        Console.Clear(); // Limpa terminal
                        contagemRodada = 0;
                        vencedor = false;
                        continue;
                    }
                    else // Caso queira voltar ao menu
                    {
                        // renumerando a matriz
                        n = 0;
                        for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                        {
                            for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                            {
                                matriz[l, c] = Convert.ToString(n += 1);
                            }
                        }
                        Console.Clear(); // Limpa terminal
                        contagemRodada = 0;
                        vencedor = true;
                    }
                }
            }
        }
    }

    //Jogador x Bot
    else if (op1 == "2")
    {
        // Começo do jogo de entre Jogador x maquina

        Console.WriteLine("JOGO DA VELHA ENTRE JOGADOR E MAQUINA");

        Console.WriteLine("Digite a dificuldade:");
        Console.Write("Fácil (1) — Difícil (2): ");
        string scannerDificuldade = Console.ReadLine();
        // Modo Facíl
        if (scannerDificuldade == "1")
        {
            //Teste Lógica Bot - PvM

            int[] verificaArrayBot = { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; ;

            List<int> numerosDisponiveis = verificaArrayBot.ToList();
            Random gerador = new Random();
            //Adicionar bool vencedor = false;

            Console.WriteLine("Modo Jogador x Bot");
            String nomeJogador = "";

            if (nomeJogador == "")
            {
                string scannerNome;
                // Entrada primeiro jogador
                Console.Write("Digite o nome do jogador: ");
                scannerNome = Console.ReadLine();
                nomeJogador = scannerNome;

                // Nome do jogador vai para o ranking, mas antes é feio uma verificação pra ver se ja não existe
                if (ranking.ContainsKey(nomeJogador))
                {
                    Console.WriteLine($"Bem vindo novamente {nomeJogador}. Você tem {ranking[nomeJogador]} vitórias");
                    Console.WriteLine();
                }
                else
                {
                    ranking.Add(nomeJogador, 0);
                }
            }
            // Método usado para ver de quem é a vez
            int vezJogador = 0;
            // Lógica para voltar ao menu ou continuar jogando
            string scannerDecision;
            bool vencedor = false;
            int contagemRodada = 0;
            while (!vencedor || contagemRodada > 8)
            {
                // Printando a matriz com cores
                for (int l = 0; l < matriz.GetLength(0); l++)
                {
                    Console.WriteLine("  ___    ___    ___");
                    for (int c = 0; c < matriz.GetLength(1); c++)
                    {
                        Console.Write(" | ");

                        if (matriz[l, c] == "X")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                            Console.Write("X");
                            Console.ResetColor();
                        }
                        else if (matriz[l, c] == "O")
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;  // O em amarelo
                            Console.Write("O");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(matriz[l, c]); // número normal
                        }

                        Console.Write(" | ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");
                Console.WriteLine("Escolha um número de 1 a 9: ");
                String entrada = Console.ReadLine();
                String jogadaDoJogador = entrada;

                if (int.TryParse(entrada, out int userChoose))
                {
                    if (numerosDisponiveis.Contains(userChoose))
                    {
                        numerosDisponiveis.Remove(userChoose);
                        Console.WriteLine("Você escolheu o número: " + userChoose);
                    }
                    else
                    {
                        Console.WriteLine("Número Inválido ou já escolhido!");
                        continue;
                    }
                }

                else
                {
                    Console.WriteLine("Digite apenas números!");
                    continue;
                }

                //Pega o valor gerado do Random e pega o mesmo valor na lista
                int index = gerador.Next(0, numerosDisponiveis.Count);
                //Vez do bot é dada pelos números disponíveis
                int vezBot = 0;
                if (!(numerosDisponiveis.Count == 0))
                {
                    vezBot = numerosDisponiveis[index];
                }
                //Remove o valor da lista
                if (numerosDisponiveis.Count > 0)
                {
                    numerosDisponiveis.RemoveAt(index);
                }
                //Conversão de variavel para melhor uso na função
                String jogadaBot = Convert.ToString(vezBot);

                if (jogadaDoJogador == "1" || jogadaBot == "1")
                {
                    // Verificação da casa no tabuleiro
                    if (matriz[0, 0] != "1")
                    {
                        Console.WriteLine("Você ou o Bot já marcou está casa");
                        continue;
                    }

                    // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
                    if (jogadaDoJogador == "1")
                    {
                        matriz[0, 0] = "X";
                        contagemRodada++;
                    }
                    else if (jogadaBot == "1")
                    {
                        matriz[0, 0] = "O";
                        contagemRodada++;
                    }
                }

                if (jogadaDoJogador == "2" || jogadaBot == "2")
                {
                    // Verificação da casa no tabuleiro
                    if (matriz[0, 1] != "2")
                    {
                        Console.WriteLine("Você ou o Bot já marcou está casa");
                        continue;
                    }

                    // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
                    if (jogadaDoJogador == "2")
                    {
                        matriz[0, 1] = "X";
                        contagemRodada++;
                    }
                    else if (jogadaBot == "2")
                    {
                        matriz[0, 1] = "O";
                        contagemRodada++;
                    }
                }

                if (jogadaDoJogador == "3" || jogadaBot == "3")
                {
                    // Verificação da casa no tabuleiro
                    if (matriz[0, 2] != "3")
                    {
                        Console.WriteLine("Você ou o Bot já marcou está casa");
                        continue;
                    }

                    // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
                    if (jogadaDoJogador == "3")
                    {
                        matriz[0, 2] = "X";
                        contagemRodada++;
                    }
                    else if (jogadaBot == "3")
                    {
                        matriz[0, 2] = "O";
                        contagemRodada++;
                    }
                }

                if (jogadaDoJogador == "4" || jogadaBot == "4")
                {
                    // Verificação da casa no tabuleiro
                    if (matriz[1, 0] != "4")
                    {
                        Console.WriteLine("Você ou o Bot já marcou está casa");
                        continue;
                    }

                    // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
                    if (jogadaDoJogador == "4")
                    {
                        matriz[1, 0] = "X";
                        contagemRodada++;
                    }
                    else if (jogadaBot == "4")
                    {
                        matriz[1, 0] = "O";
                        contagemRodada++;
                    }
                }

                if (jogadaDoJogador == "5" || jogadaBot == "5")
                {
                    // Verificação da casa no tabuleiro
                    if (matriz[1, 1] != "5")
                    {
                        Console.WriteLine("Você ou o Bot já marcou está casa");
                        continue;
                    }

                    // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
                    if (jogadaDoJogador == "5")
                    {
                        matriz[1, 1] = "X";
                        contagemRodada++;
                    }
                    else if (jogadaBot == "5")
                    {
                        matriz[1, 1] = "O";
                        contagemRodada++;
                    }
                }

                if (jogadaDoJogador == "6" || jogadaBot == "6")
                {
                    // Verificação da casa no tabuleiro
                    if (matriz[1, 2] != "6")
                    {
                        Console.WriteLine("Você ou o Bot já marcou está casa");
                        continue;
                    }

                    // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
                    if (jogadaDoJogador == "6")
                    {
                        matriz[1, 2] = "X";
                        contagemRodada++;
                    }
                    else if (jogadaBot == "6")
                    {
                        matriz[1, 2] = "O";
                        contagemRodada++;
                    }
                }

                if (jogadaDoJogador == "7" || jogadaBot == "7")
                {
                    // Verificação da casa no tabuleiro
                    if (matriz[2, 0] != "7")
                    {
                        Console.WriteLine("Você ou o Bot já marcou está casa");
                        continue;
                    }

                    // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
                    if (jogadaDoJogador == "7")
                    {
                        matriz[2, 0] = "X";
                        contagemRodada++;
                    }
                    else if (jogadaBot == "7")
                    {
                        matriz[2, 0] = "O";
                        contagemRodada++;
                    }
                }

                if (jogadaDoJogador == "8" || jogadaBot == "8")
                {
                    // Verificação da casa no tabuleiro
                    if (matriz[2, 1] != "8")
                    {
                        Console.WriteLine("Você ou o Bot já marcou está casa");
                        continue;
                    }

                    // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
                    if (jogadaDoJogador == "8")
                    {
                        matriz[2, 1] = "X";
                        contagemRodada++;
                    }
                    else if (jogadaBot == "8")
                    {
                        matriz[2, 1] = "O";
                        contagemRodada++;
                    }
                }

                if (jogadaDoJogador == "9" || jogadaBot == "9")
                {
                    // Verificação da casa no tabuleiro
                    if (matriz[2, 2] != "9")
                    {
                        Console.WriteLine("Você ou o Bot já marcou está casa");
                        continue;
                    }

                    // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
                    if (jogadaDoJogador == "9")
                    {
                        matriz[2, 2] = "X";
                        contagemRodada++;
                    }
                    else if (jogadaBot == "9")
                    {
                        matriz[2, 2] = "O";
                        contagemRodada++;
                    }
                }

                // Primeiro caso da linha(1, 2 e 3)
                if (matriz[0, 0] == "X" && matriz[0, 1] == "X" && matriz[0, 2] == "X" || matriz[0, 0] == "O" && matriz[0, 1] == "O" && matriz[0, 2] == "O")
                {
                    if (matriz[0, 0] == "X" && matriz[0, 1] == "X" && matriz[0, 2] == "X")
                    {
                        Console.WriteLine("O vencedor é " + nomeJogador + "!");
                        // Printando a matriz com cores
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | ");

                                if (matriz[l, c] == "X")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                    Console.Write("X");
                                    Console.ResetColor();
                                }
                                else if (matriz[l, c] == "O")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;  // O em amarelo
                                    Console.Write("O");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write(matriz[l, c]); // número normal
                                }

                                Console.Write(" | ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        if (nomeJogador == "X")
                        {
                            ranking["X"] += 1;
                        }
                        else
                        {
                            ranking[nomeJogador] += 1;
                            ranking["X"] += 1;
                        }

                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                        string verRanking = Console.ReadLine();

                        if (verRanking == "1")
                        {
                            MostrarRanking(ranking);
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }

                        if (verRanking == "2")
                        {
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("O vencedor é o Bot!");
                        // Printando a matriz com cores
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | ");

                                if (matriz[l, c] == "X")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                    Console.Write("X");
                                    Console.ResetColor();
                                }
                                else if (matriz[l, c] == "O")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;  // O em amarelo
                                    Console.Write("O");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write(matriz[l, c]); // número normal
                                }

                                Console.Write(" | ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        ranking["Bot"] += 1;
                        ranking["O"] += 1;


                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                        string verRanking = Console.ReadLine();

                        if (verRanking == "1")
                        {
                            MostrarRanking(ranking);
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }

                        if (verRanking == "2")
                        {
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }
                    }

                }
                // Segundo caso da linha(4, 5 e 6)
                if (matriz[1, 0] == "X" && matriz[1, 1] == "X" && matriz[1, 2] == "X" || matriz[1, 0] == "O" && matriz[1, 1] == "O" && matriz[1, 2] == "O")
                {
                    if (matriz[1, 0] == "X" && matriz[1, 1] == "X" && matriz[1, 2] == "X")
                    {
                        Console.WriteLine("O vencedor é " + nomeJogador + "!");
                        // Printando a matriz com cores
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | ");

                                if (matriz[l, c] == "X")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                    Console.Write("X");
                                    Console.ResetColor();
                                }
                                else if (matriz[l, c] == "O")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;  // O em amarelo
                                    Console.Write("O");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write(matriz[l, c]); // número normal
                                }

                                Console.Write(" | ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        if (nomeJogador == "X")
                        {
                            ranking["X"] += 1;
                        }
                        else
                        {
                            ranking[nomeJogador] += 1;
                            ranking["X"] += 1;
                        }

                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                        string verRanking = Console.ReadLine();

                        if (verRanking == "1")
                        {
                            MostrarRanking(ranking);
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }

                        if (verRanking == "2")
                        {
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("O vencedor é o Bot!");
                        // Printando a matriz com cores
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | ");

                                if (matriz[l, c] == "X")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                    Console.Write("X");
                                    Console.ResetColor();
                                }
                                else if (matriz[l, c] == "O")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;  // O em amarelo
                                    Console.Write("O");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write(matriz[l, c]); // número normal
                                }

                                Console.Write(" | ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        ranking["Bot"] += 1;
                        ranking["O"] += 1;


                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                        string verRanking = Console.ReadLine();

                        if (verRanking == "1")
                        {
                            MostrarRanking(ranking);
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }

                        if (verRanking == "2")
                        {
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }
                    }
                }
                // Terceiro caso da linha(7, 8 e 9)
                if (matriz[2, 0] == "X" && matriz[2, 1] == "X" && matriz[2, 2] == "X" || matriz[2, 0] == "O" && matriz[2, 1] == "O" && matriz[2, 2] == "O")
                {
                    if (matriz[2, 0] == "X" && matriz[2, 1] == "X" && matriz[2, 2] == "X")
                    {
                        Console.WriteLine("O vencedor é " + nomeJogador + "!");
                        // Printando a matriz com cores
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | ");

                                if (matriz[l, c] == "X")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                    Console.Write("X");
                                    Console.ResetColor();
                                }
                                else if (matriz[l, c] == "O")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;  // O em amarelo
                                    Console.Write("O");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write(matriz[l, c]); // número normal
                                }

                                Console.Write(" | ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        if (nomeJogador == "X")
                        {
                            ranking["X"] += 1;
                        }
                        else
                        {
                            ranking[nomeJogador] += 1;
                            ranking["X"] += 1;
                        }

                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                        string verRanking = Console.ReadLine();

                        if (verRanking == "1")
                        {
                            MostrarRanking(ranking);
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }

                        if (verRanking == "2")
                        {
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("O vencedor é o Bot!");
                        // Printando a matriz com cores
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | ");

                                if (matriz[l, c] == "X")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                    Console.Write("X");
                                    Console.ResetColor();
                                }
                                else if (matriz[l, c] == "O")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;  // O em amarelo
                                    Console.Write("O");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write(matriz[l, c]); // número normal
                                }

                                Console.Write(" | ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        ranking["Bot"] += 1;
                        ranking["O"] += 1;


                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                        string verRanking = Console.ReadLine();

                        if (verRanking == "1")
                        {
                            MostrarRanking(ranking);
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }

                        if (verRanking == "2")
                        {
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }
                    }
                }
                // Primeiro caso da coluna(1, 4 e 7)
                if (matriz[0, 0] == "X" && matriz[1, 0] == "X" && matriz[2, 0] == "X" || matriz[0, 0] == "O" && matriz[1, 0] == "O" && matriz[2, 0] == "O")
                {
                    if (matriz[0, 0] == "X" && matriz[1, 0] == "X" && matriz[2, 0] == "X")
                    {
                        Console.WriteLine("O vencedor é " + nomeJogador + "!");
                        // Printando a matriz com cores
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | ");

                                if (matriz[l, c] == "X")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                    Console.Write("X");
                                    Console.ResetColor();
                                }
                                else if (matriz[l, c] == "O")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;  // O em amarelo
                                    Console.Write("O");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write(matriz[l, c]); // número normal
                                }

                                Console.Write(" | ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        if (nomeJogador == "X")
                        {
                            ranking["X"] += 1;
                        }
                        else
                        {
                            ranking[nomeJogador] += 1;
                            ranking["X"] += 1;
                        }

                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                        string verRanking = Console.ReadLine();

                        if (verRanking == "1")
                        {
                            MostrarRanking(ranking);
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }

                        if (verRanking == "2")
                        {
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("O vencedor é o Bot!");
                        // Printando a matriz com cores
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | ");

                                if (matriz[l, c] == "X")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                    Console.Write("X");
                                    Console.ResetColor();
                                }
                                else if (matriz[l, c] == "O")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;  // O em amarelo
                                    Console.Write("O");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write(matriz[l, c]); // número normal
                                }

                                Console.Write(" | ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        ranking["Bot"] += 1;
                        ranking["O"] += 1;


                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                        string verRanking = Console.ReadLine();

                        if (verRanking == "1")
                        {
                            MostrarRanking(ranking);
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }

                        if (verRanking == "2")
                        {
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }
                    }
                }
                // Segundo caso da coluna(2, 5 e 8)
                if (matriz[0, 1] == "X" && matriz[1, 1] == "X" && matriz[2, 1] == "X" || matriz[0, 1] == "O" && matriz[1, 1] == "O" && matriz[2, 1] == "O")
                {
                    if (matriz[0, 1] == "X" && matriz[1, 1] == "X" && matriz[2, 1] == "X")
                    {
                        Console.WriteLine("O vencedor é " + nomeJogador + "!");
                        // Printando a matriz com cores
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | ");

                                if (matriz[l, c] == "X")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                    Console.Write("X");
                                    Console.ResetColor();
                                }
                                else if (matriz[l, c] == "O")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;  // O em amarelo
                                    Console.Write("O");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write(matriz[l, c]); // número normal
                                }

                                Console.Write(" | ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        if (nomeJogador == "X")
                        {
                            ranking["X"] += 1;
                        }
                        else
                        {
                            ranking[nomeJogador] += 1;
                            ranking["X"] += 1;
                        }

                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                        string verRanking = Console.ReadLine();

                        if (verRanking == "1")
                        {
                            MostrarRanking(ranking);
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }

                        if (verRanking == "2")
                        {
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("O vencedor é o Bot!");
                        // Printando a matriz com cores
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | ");

                                if (matriz[l, c] == "X")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                    Console.Write("X");
                                    Console.ResetColor();
                                }
                                else if (matriz[l, c] == "O")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;  // O em amarelo
                                    Console.Write("O");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write(matriz[l, c]); // número normal
                                }

                                Console.Write(" | ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        ranking["Bot"] += 1;
                        ranking["O"] += 1;


                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                        string verRanking = Console.ReadLine();

                        if (verRanking == "1")
                        {
                            MostrarRanking(ranking);
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }

                        if (verRanking == "2")
                        {
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }
                    }
                }
                // Terceiro caso da coluna(3, 6 e 9)
                if (matriz[0, 2] == "X" && matriz[1, 2] == "X" && matriz[2, 2] == "X" || matriz[0, 2] == "O" && matriz[1, 2] == "O" && matriz[2, 2] == "O")
                {
                    if (matriz[0, 2] == "X" && matriz[1, 2] == "X" && matriz[2, 2] == "X")
                    {
                        Console.WriteLine("O vencedor é " + nomeJogador + "!");
                        // Printando a matriz com cores
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | ");

                                if (matriz[l, c] == "X")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                    Console.Write("X");
                                    Console.ResetColor();
                                }
                                else if (matriz[l, c] == "O")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;  // O em amarelo
                                    Console.Write("O");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write(matriz[l, c]); // número normal
                                }

                                Console.Write(" | ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        if (nomeJogador == "X")
                        {
                            ranking["X"] += 1;
                        }
                        else
                        {
                            ranking[nomeJogador] += 1;
                            ranking["X"] += 1;
                        }

                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                        string verRanking = Console.ReadLine();

                        if (verRanking == "1")
                        {
                            MostrarRanking(ranking);
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }

                        if (verRanking == "2")
                        {
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("O vencedor é o Bot!");
                        // Printando a matriz com cores
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | ");

                                if (matriz[l, c] == "X")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                    Console.Write("X");
                                    Console.ResetColor();
                                }
                                else if (matriz[l, c] == "O")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;  // O em amarelo
                                    Console.Write("O");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write(matriz[l, c]); // número normal
                                }

                                Console.Write(" | ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        ranking["Bot"] += 1;
                        ranking["O"] += 1;


                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                        string verRanking = Console.ReadLine();

                        if (verRanking == "1")
                        {
                            MostrarRanking(ranking);
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }

                        if (verRanking == "2")
                        {
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }
                    }
                }
                // Primeiro caso da diagonal(1, 5 e 9)
                if (matriz[0, 0] == "X" && matriz[1, 1] == "X" && matriz[2, 2] == "X" || matriz[0, 0] == "O" && matriz[1, 1] == "O" && matriz[2, 2] == "O")
                {
                    if (matriz[0, 0] == "X" && matriz[1, 1] == "X" && matriz[2, 2] == "X")
                    {
                        Console.WriteLine("O vencedor é " + nomeJogador + "!");
                        // Printando a matriz com cores
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | ");

                                if (matriz[l, c] == "X")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                    Console.Write("X");
                                    Console.ResetColor();
                                }
                                else if (matriz[l, c] == "O")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;  // O em amarelo
                                    Console.Write("O");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write(matriz[l, c]); // número normal
                                }

                                Console.Write(" | ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        if (nomeJogador == "X")
                        {
                            ranking["X"] += 1;
                        }
                        else
                        {
                            ranking[nomeJogador] += 1;
                            ranking["X"] += 1;
                        }

                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                        string verRanking = Console.ReadLine();

                        if (verRanking == "1")
                        {
                            MostrarRanking(ranking);
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }

                        if (verRanking == "2")
                        {
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("O vencedor é o Bot!");
                        // Printando a matriz com cores
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | ");

                                if (matriz[l, c] == "X")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                    Console.Write("X");
                                    Console.ResetColor();
                                }
                                else if (matriz[l, c] == "O")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;  // O em amarelo
                                    Console.Write("O");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write(matriz[l, c]); // número normal
                                }

                                Console.Write(" | ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        ranking["Bot"] += 1;
                        ranking["O"] += 1;


                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                        string verRanking = Console.ReadLine();

                        if (verRanking == "1")
                        {
                            MostrarRanking(ranking);
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }

                        if (verRanking == "2")
                        {
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }
                    }
                }
                // Segundo caso da diagonal(3, 5 e 7)
                if (matriz[0, 2] == "X" && matriz[1, 1] == "X" && matriz[2, 0] == "X" || matriz[0, 2] == "O" && matriz[1, 1] == "O" && matriz[2, 0] == "O")
                {
                    if (matriz[0, 2] == "X" && matriz[1, 1] == "X" && matriz[2, 0] == "X")
                    {
                        Console.WriteLine("O vencedor é " + nomeJogador + "!");
                        // Printando a matriz com cores
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | ");

                                if (matriz[l, c] == "X")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                    Console.Write("X");
                                    Console.ResetColor();
                                }
                                else if (matriz[l, c] == "O")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;  // O em amarelo
                                    Console.Write("O");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write(matriz[l, c]); // número normal
                                }

                                Console.Write(" | ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        if (nomeJogador == "X")
                        {
                            ranking["X"] += 1;
                        }
                        else
                        {
                            ranking[nomeJogador] += 1;
                            ranking["X"] += 1;
                        }

                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                        string verRanking = Console.ReadLine();

                        if (verRanking == "1")
                        {
                            MostrarRanking(ranking);
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }

                        if (verRanking == "2")
                        {
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("O vencedor é o Bot!");
                        // Printando a matriz com cores
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | ");

                                if (matriz[l, c] == "X")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                    Console.Write("X");
                                    Console.ResetColor();
                                }
                                else if (matriz[l, c] == "O")
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;  // O em amarelo
                                    Console.Write("O");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write(matriz[l, c]); // número normal
                                }

                                Console.Write(" | ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        ranking["Bot"] += 1;
                        ranking["O"] += 1;


                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                        string verRanking = Console.ReadLine();

                        if (verRanking == "1")
                        {
                            MostrarRanking(ranking);
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }

                        if (verRanking == "2")
                        {
                            // Lógica que pergunta se quer ou não continuar
                            Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                            scannerDecision = Console.ReadLine();

                            if (scannerDecision == "1") // Caso queira
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                //Resetar a lista (reiniciar game)
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = false;
                                continue;
                            }
                            else // Caso queira voltar ao menu
                            {
                                // renumerando a matriz
                                n = 0;
                                for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                                {
                                    for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                    {
                                        matriz[l, c] = Convert.ToString(n += 1);
                                    }
                                }
                                numerosDisponiveis = verificaArrayBot.ToList();
                                Console.Clear(); // Limpa terminal
                                contagemRodada = 0;
                                vencedor = true;
                            }
                        }
                    }
                }
                // Caso de velha
                if (contagemRodada > 8)
                {
                    Console.WriteLine("O jogo terminou em velha!");
                    // Printando a matriz com cores
                    for (int l = 0; l < matriz.GetLength(0); l++)
                    {
                        Console.WriteLine("  ___    ___    ___");
                        for (int c = 0; c < matriz.GetLength(1); c++)
                        {
                            Console.Write(" | ");

                            if (matriz[l, c] == "X")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;   // X em vermelho
                                Console.Write("X");
                                Console.ResetColor();
                            }
                            else if (matriz[l, c] == "O")
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;  // O em amarelo
                                Console.Write("O");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(matriz[l, c]); // número normal
                            }

                            Console.Write(" | ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                    // Soma pontuação no ranking
                    ranking["Velha"] += 1;

                    // Printa o ranking com os jogadores
                    Console.WriteLine("RANKING");
                    foreach (KeyValuePair<string, int> r in ranking)
                    {
                        Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                    }

                    Console.WriteLine("Deseja mostrar o Ranking Gráfico? Sim(1) Não(2)");
                    string verRanking = Console.ReadLine();

                    if (verRanking == "1")
                    {
                        MostrarRanking(ranking);
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            //Resetar a lista (reiniciar game)
                            numerosDisponiveis = verificaArrayBot.ToList();
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            numerosDisponiveis = verificaArrayBot.ToList();
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                    if (verRanking == "2")
                    {
                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            //Resetar a lista (reiniciar game)
                            numerosDisponiveis = verificaArrayBot.ToList();
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            numerosDisponiveis = verificaArrayBot.ToList();
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }
                }
                Console.WriteLine("Número escolhido pelo Bot: " + vezBot);
                Console.WriteLine("Números restantes: " + string.Join(", ", numerosDisponiveis));
                Console.WriteLine();
            }
        }
        // Modo difícil
        else
        {
            Console.WriteLine("test");
            //Teste Lógica Bot - PvM

            int[] verificaArrayBot = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            List<int> numerosDisponiveis = verificaArrayBot.ToList();
            Random gerador = new Random();
            //Adicionar bool vencedor = false;

            Console.WriteLine("Modo Jogador x Bot");
            String nomeJogador = "";

            if (nomeJogador == "")
            {
                string scannerNome;
                // Entrada primeiro jogador
                Console.Write("Digite o nome do jogador: ");
                scannerNome = Console.ReadLine();
                nomeJogador = scannerNome;

                // Nome do jogador vai para o ranking, mas antes é feio uma verificação pra ver se ja não existe
                if (ranking.ContainsKey(nomeJogador))
                {
                    Console.WriteLine($"Bem vindo novamente {nomeJogador}. Você tem {ranking[nomeJogador]} vitórias");
                    Console.WriteLine();
                }
                else
                {
                    ranking.Add(nomeJogador, 0);
                }
            }
            // Método usado para ver de quem é a vez
            int vezJogador = 0;
            // Lógica para voltar ao menu ou continuar jogando
            string scannerDecision;
            bool vencedor = false;
            int contagemRodada = 0;
            while (!vencedor || contagemRodada > 8)
            {
                // Printando a matriz
                for (int l = 0; l < matriz.GetLength(0); l++)
                {
                    Console.WriteLine("  ___    ___    ___");
                    for (int c = 0; c < matriz.GetLength(1); c++)
                    {
                        Console.Write(" | " + matriz[l, c] + " | ");
                        //Thread.Sleep(50); // só para efeito visual
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                int verificacao = 0; // verificação para não bugar a jogada do jogador
                Console.WriteLine("Escolha um número de 1 a 9: ");
                String entrada = Console.ReadLine();
                String jogadaDoJogador = entrada;

                if (int.TryParse(entrada, out int userChoose))
                {
                    if (numerosDisponiveis.Contains(userChoose))
                    {
                        numerosDisponiveis.Remove(userChoose);
                        Console.WriteLine("Você escolheu o número: " + userChoose);
                    }
                    else
                    {
                        Console.WriteLine("Número Inválido ou já escolhido!");
                        continue;
                    }
                }

                else
                {
                    Console.WriteLine("Digite apenas números!");
                    continue;
                }

                int vezBot = 0;
                int[] numBot = { 0, 0 };
                // Repete a jogada do bot 2x
                for (int i = 0; i < 2; i++)
                {
                    //Pega o valor gerado do Random e pega o mesmo valor na lista
                    int index = gerador.Next(0, numerosDisponiveis.Count);
                    //Vez do bot é dada pelos números disponíveis
                    vezBot = 0;
                    if (!(numerosDisponiveis.Count == 0))
                    {
                        vezBot = numerosDisponiveis[index];
                        numBot[i] = vezBot;
                    }
                    //Remove o valor da lista
                    if (numerosDisponiveis.Count > 0)
                    {
                        numerosDisponiveis.RemoveAt(index);
                    }
                    //Conversão de variavel para melhor uso na função
                    String jogadaBot = Convert.ToString(vezBot);

                    // verificação para não bugar
                    if (verificacao == 0)
                    {

                    }
                    else
                    {
                        jogadaDoJogador = "0";
                    }

                    if (jogadaDoJogador == "1" || jogadaBot == "1")
                    {
                        // Verificação da casa no tabuleiro
                        if (matriz[0, 0] != "1")
                        {
                            Console.WriteLine("Você ou o Bot já marcou está casa");
                            continue;
                        }

                        // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
                        if (jogadaDoJogador == "1")
                        {
                            matriz[0, 0] = "X";
                            contagemRodada++;
                        }
                        if (jogadaBot == "1")
                        {
                            matriz[0, 0] = "O";
                            contagemRodada++;
                        }
                    }

                    if (jogadaDoJogador == "2" || jogadaBot == "2")
                    {
                        // Verificação da casa no tabuleiro
                        if (matriz[0, 1] != "2")
                        {
                            Console.WriteLine("Você ou o Bot já marcou está casa");
                            continue;
                        }

                        // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
                        if (jogadaDoJogador == "2")
                        {
                            matriz[0, 1] = "X";
                            contagemRodada++;
                        }
                        if (jogadaBot == "2")
                        {
                            matriz[0, 1] = "O";
                            contagemRodada++;
                        }
                    }

                    if (jogadaDoJogador == "3" || jogadaBot == "3")
                    {
                        // Verificação da casa no tabuleiro
                        if (matriz[0, 2] != "3")
                        {
                            Console.WriteLine("Você ou o Bot já marcou está casa");
                            continue;
                        }

                        // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
                        if (jogadaDoJogador == "3")
                        {
                            matriz[0, 2] = "X";
                            contagemRodada++;
                        }
                        if (jogadaBot == "3")
                        {
                            matriz[0, 2] = "O";
                            contagemRodada++;
                        }
                    }

                    if (jogadaDoJogador == "4" || jogadaBot == "4")
                    {
                        // Verificação da casa no tabuleiro
                        if (matriz[1, 0] != "4")
                        {
                            Console.WriteLine("Você ou o Bot já marcou está casa");
                            continue;
                        }

                        // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
                        if (jogadaDoJogador == "4")
                        {
                            matriz[1, 0] = "X";
                            contagemRodada++;
                        }
                        if (jogadaBot == "4")
                        {
                            matriz[1, 0] = "O";
                            contagemRodada++;
                        }
                    }

                    if (jogadaDoJogador == "5" || jogadaBot == "5")
                    {
                        // Verificação da casa no tabuleiro
                        if (matriz[1, 1] != "5")
                        {
                            Console.WriteLine("Você ou o Bot já marcou está casa");
                            continue;
                        }

                        // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
                        if (jogadaDoJogador == "5")
                        {
                            matriz[1, 1] = "X";
                            contagemRodada++;
                        }
                        if (jogadaBot == "5")
                        {
                            matriz[1, 1] = "O";
                            contagemRodada++;
                        }
                    }

                    if (jogadaDoJogador == "6" || jogadaBot == "6")
                    {
                        // Verificação da casa no tabuleiro
                        if (matriz[1, 2] != "6")
                        {
                            Console.WriteLine("Você ou o Bot já marcou está casa");
                            continue;
                        }

                        // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
                        if (jogadaDoJogador == "6")
                        {
                            matriz[1, 2] = "X";
                            contagemRodada++;
                        }
                        if (jogadaBot == "6")
                        {
                            matriz[1, 2] = "O";
                            contagemRodada++;
                        }
                    }

                    if (jogadaDoJogador == "7" || jogadaBot == "7")
                    {
                        // Verificação da casa no tabuleiro
                        if (matriz[2, 0] != "7")
                        {
                            Console.WriteLine("Você ou o Bot já marcou está casa");
                            continue;
                        }

                        // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
                        if (jogadaDoJogador == "7")
                        {
                            matriz[2, 0] = "X";
                            contagemRodada++;
                        }
                        if (jogadaBot == "7")
                        {
                            matriz[2, 0] = "O";
                            contagemRodada++;
                        }
                    }

                    if (jogadaDoJogador == "8" || jogadaBot == "8")
                    {
                        // Verificação da casa no tabuleiro
                        if (matriz[2, 1] != "8")
                        {
                            Console.WriteLine("Você ou o Bot já marcou está casa");
                            continue;
                        }

                        // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
                        if (jogadaDoJogador == "8")
                        {
                            matriz[2, 1] = "X";
                            contagemRodada++;
                        }
                        if (jogadaBot == "8")
                        {
                            matriz[2, 1] = "O";
                            contagemRodada++;
                        }
                    }

                    if (jogadaDoJogador == "9" || jogadaBot == "9")
                    {
                        // Verificação da casa no tabuleiro
                        if (matriz[2, 2] != "9")
                        {
                            Console.WriteLine("Você ou o Bot já marcou está casa");
                            continue;
                        }

                        // Método usado para ver de quem é a vez. Baseado na variavel vezJogador.
                        if (jogadaDoJogador == "9")
                        {
                            matriz[2, 2] = "X";
                            contagemRodada++;
                        }
                        if (jogadaBot == "9")
                        {
                            matriz[2, 2] = "O";
                            contagemRodada++;
                        }
                    }

                    verificacao = 1;  // incremento na verificação
                }
                // Primeiro caso da linha(1, 2 e 3)
                if (matriz[0, 0] == "X" && matriz[0, 1] == "X" && matriz[0, 2] == "X" || matriz[0, 0] == "O" && matriz[0, 1] == "O" && matriz[0, 2] == "O")
                {
                    if (matriz[0, 0] == "X" && matriz[0, 1] == "X" && matriz[0, 2] == "X")
                    {
                        Console.WriteLine("O vencedor é " + nomeJogador + "!");
                        // Printando a matriz
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | " + matriz[l, c] + " | ");
                                //Thread.Sleep(50); // só para efeito visual
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        if (nomeJogador == "X")
                        {
                            ranking["X"] += 1;
                        }
                        else
                        {
                            ranking[nomeJogador] += 1;
                            ranking["X"] += 1;
                        }

                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            //Resetar a lista (reiniciar game)
                            numerosDisponiveis = verificaArrayBot.ToList();
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else
                        // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("O vencedor é o Bot!");
                        // Printando a matriz
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | " + matriz[l, c] + " | ");
                                //Thread.Sleep(50); // só para efeito visual
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        ranking["Bot"] += 1;
                        ranking["O"] += 1;


                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            //Resetar a lista (reiniciar game)
                            numerosDisponiveis = verificaArrayBot.ToList();
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                }
                // Segundo caso da linha(4, 5 e 6)
                if (matriz[1, 0] == "X" && matriz[1, 1] == "X" && matriz[1, 2] == "X" || matriz[1, 0] == "O" && matriz[1, 1] == "O" && matriz[1, 2] == "O")
                {
                    if (matriz[1, 0] == "X" && matriz[1, 1] == "X" && matriz[1, 2] == "X")
                    {
                        Console.WriteLine("O vencedor é " + nomeJogador + "!");
                        // Printando a matriz
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | " + matriz[l, c] + " | ");
                                //Thread.Sleep(50); // só para efeito visual
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        if (nomeJogador == "X")
                        {
                            ranking["X"] += 1;
                        }
                        else
                        {
                            ranking[nomeJogador] += 1;
                            ranking["X"] += 1;
                        }

                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            //Resetar a lista (reiniciar game)
                            numerosDisponiveis = verificaArrayBot.ToList();
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else
                        // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("O vencedor é o Bot!");
                        // Printando a matriz
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | " + matriz[l, c] + " | ");
                                //Thread.Sleep(50); // só para efeito visual
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        ranking["Bot"] += 1;
                        ranking["O"] += 1;


                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            //Resetar a lista (reiniciar game)
                            numerosDisponiveis = verificaArrayBot.ToList();
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                }
                // Terceiro caso da linha(7, 8 e 9)
                if (matriz[2, 0] == "X" && matriz[2, 1] == "X" && matriz[2, 2] == "X" || matriz[2, 0] == "O" && matriz[2, 1] == "O" && matriz[2, 2] == "O")
                {
                    if (matriz[2, 0] == "X" && matriz[2, 1] == "X" && matriz[2, 2] == "X")
                    {
                        Console.WriteLine("O vencedor é " + nomeJogador + "!");
                        // Printando a matriz
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | " + matriz[l, c] + " | ");
                                //Thread.Sleep(50); // só para efeito visual
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        if (nomeJogador == "X")
                        {
                            ranking["X"] += 1;
                        }
                        else
                        {
                            ranking[nomeJogador] += 1;
                            ranking["X"] += 1;
                        }

                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            //Resetar a lista (reiniciar game)
                            numerosDisponiveis = verificaArrayBot.ToList();
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else
                        // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("O vencedor é o Bot!");
                        // Printando a matriz
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | " + matriz[l, c] + " | ");
                                //Thread.Sleep(50); // só para efeito visual
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        ranking["Bot"] += 1;
                        ranking["O"] += 1;


                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            //Resetar a lista (reiniciar game)
                            numerosDisponiveis = verificaArrayBot.ToList();
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                }
                // Primeiro caso da coluna(1, 4 e 7)
                if (matriz[0, 0] == "X" && matriz[1, 0] == "X" && matriz[2, 0] == "X" || matriz[0, 0] == "O" && matriz[1, 0] == "O" && matriz[2, 0] == "O")
                {
                    if (matriz[0, 0] == "X" && matriz[1, 0] == "X" && matriz[2, 0] == "X")
                    {
                        Console.WriteLine("O vencedor é " + nomeJogador + "!");
                        // Printando a matriz
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | " + matriz[l, c] + " | ");
                                //Thread.Sleep(50); // só para efeito visual
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        if (nomeJogador == "X")
                        {
                            ranking["X"] += 1;
                        }
                        else
                        {
                            ranking[nomeJogador] += 1;
                            ranking["X"] += 1;
                        }

                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            //Resetar a lista (reiniciar game)
                            numerosDisponiveis = verificaArrayBot.ToList();
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else
                        // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("O vencedor é o Bot!");
                        // Printando a matriz
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | " + matriz[l, c] + " | ");
                                //Thread.Sleep(50); // só para efeito visual
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        ranking["Bot"] += 1;
                        ranking["O"] += 1;


                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            //Resetar a lista (reiniciar game)
                            numerosDisponiveis = verificaArrayBot.ToList();
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                }
                // Segundo caso da coluna(2, 5 e 8)
                if (matriz[0, 1] == "X" && matriz[1, 1] == "X" && matriz[2, 1] == "X" || matriz[0, 1] == "O" && matriz[1, 1] == "O" && matriz[2, 1] == "O")
                {
                    if (matriz[0, 1] == "X" && matriz[1, 1] == "X" && matriz[2, 1] == "X")
                    {
                        Console.WriteLine("O vencedor é " + nomeJogador + "!");
                        // Printando a matriz
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | " + matriz[l, c] + " | ");
                                //Thread.Sleep(50); // só para efeito visual
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        if (nomeJogador == "X")
                        {
                            ranking["X"] += 1;
                        }
                        else
                        {
                            ranking[nomeJogador] += 1;
                            ranking["X"] += 1;
                        }

                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            //Resetar a lista (reiniciar game)
                            numerosDisponiveis = verificaArrayBot.ToList();
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else
                        // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("O vencedor é o Bot!");
                        // Printando a matriz
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | " + matriz[l, c] + " | ");
                                //Thread.Sleep(50); // só para efeito visual
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        ranking["Bot"] += 1;
                        ranking["O"] += 1;


                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            //Resetar a lista (reiniciar game)
                            numerosDisponiveis = verificaArrayBot.ToList();
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                }
                // Terceiro caso da coluna(3, 6 e 9)
                if (matriz[0, 2] == "X" && matriz[1, 2] == "X" && matriz[2, 2] == "X" || matriz[0, 2] == "O" && matriz[1, 2] == "O" && matriz[2, 2] == "O")
                {
                    if (matriz[0, 2] == "X" && matriz[1, 2] == "X" && matriz[2, 2] == "X")
                    {
                        Console.WriteLine("O vencedor é " + nomeJogador + "!");
                        // Printando a matriz
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | " + matriz[l, c] + " | ");
                                //Thread.Sleep(50); // só para efeito visual
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        if (nomeJogador == "X")
                        {
                            ranking["X"] += 1;
                        }
                        else
                        {
                            ranking[nomeJogador] += 1;
                            ranking["X"] += 1;
                        }

                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            //Resetar a lista (reiniciar game)
                            numerosDisponiveis = verificaArrayBot.ToList();
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else
                        // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("O vencedor é o Bot!");
                        // Printando a matriz
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | " + matriz[l, c] + " | ");
                                //Thread.Sleep(50); // só para efeito visual
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        ranking["Bot"] += 1;
                        ranking["O"] += 1;


                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            //Resetar a lista (reiniciar game)
                            numerosDisponiveis = verificaArrayBot.ToList();
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                }
                // Primeiro caso da diagonal(1, 5 e 9)
                if (matriz[0, 0] == "X" && matriz[1, 1] == "X" && matriz[2, 2] == "X" || matriz[0, 0] == "O" && matriz[1, 1] == "O" && matriz[2, 2] == "O")
                {
                    if (matriz[0, 0] == "X" && matriz[1, 1] == "X" && matriz[2, 2] == "X")
                    {
                        Console.WriteLine("O vencedor é " + nomeJogador + "!");
                        // Printando a matriz
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | " + matriz[l, c] + " | ");
                                //Thread.Sleep(50); // só para efeito visual
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        if (nomeJogador == "X")
                        {
                            ranking["X"] += 1;
                        }
                        else
                        {
                            ranking[nomeJogador] += 1;
                            ranking["X"] += 1;
                        }

                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            //Resetar a lista (reiniciar game)
                            numerosDisponiveis = verificaArrayBot.ToList();
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else
                        // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("O vencedor é o Bot!");
                        // Printando a matriz
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | " + matriz[l, c] + " | ");
                                //Thread.Sleep(50); // só para efeito visual
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        ranking["Bot"] += 1;
                        ranking["O"] += 1;


                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            //Resetar a lista (reiniciar game)
                            numerosDisponiveis = verificaArrayBot.ToList();
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                }
                // Segundo caso da diagonal(3, 5 e 7)
                if (matriz[0, 2] == "X" && matriz[1, 1] == "X" && matriz[2, 0] == "X" || matriz[0, 2] == "O" && matriz[1, 1] == "O" && matriz[2, 0] == "O")
                {
                    if (matriz[0, 2] == "X" && matriz[1, 1] == "X" && matriz[2, 0] == "X")
                    {
                        Console.WriteLine("O vencedor é " + nomeJogador + "!");
                        // Printando a matriz
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | " + matriz[l, c] + " | ");
                                //Thread.Sleep(50); // só para efeito visual
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        if (nomeJogador == "X")
                        {
                            ranking["X"] += 1;
                        }
                        else
                        {
                            ranking[nomeJogador] += 1;
                            ranking["X"] += 1;
                        }

                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            //Resetar a lista (reiniciar game)
                            numerosDisponiveis = verificaArrayBot.ToList();
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else
                        // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("O vencedor é o Bot!");
                        // Printando a matriz
                        for (int l = 0; l < matriz.GetLength(0); l++)
                        {
                            Console.WriteLine("  ___    ___    ___");
                            for (int c = 0; c < matriz.GetLength(1); c++)
                            {
                                Console.Write(" | " + matriz[l, c] + " | ");
                                //Thread.Sleep(50); // só para efeito visual
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                        // Soma pontuação no ranking
                        ranking["Bot"] += 1;
                        ranking["O"] += 1;


                        // Printa o ranking com os jogadores
                        Console.WriteLine("RANKING");
                        foreach (KeyValuePair<string, int> r in ranking)
                        {
                            Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                        }

                        // Lógica que pergunta se quer ou não continuar
                        Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                        scannerDecision = Console.ReadLine();

                        if (scannerDecision == "1") // Caso queira
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            //Resetar a lista (reiniciar game)
                            numerosDisponiveis = verificaArrayBot.ToList();
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = false;
                            continue;
                        }
                        else // Caso queira voltar ao menu
                        {
                            // renumerando a matriz
                            n = 0;
                            for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                            {
                                for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                                {
                                    matriz[l, c] = Convert.ToString(n += 1);
                                }
                            }
                            Console.Clear(); // Limpa terminal
                            contagemRodada = 0;
                            vencedor = true;
                        }
                    }

                }
                // Caso de velha
                if (contagemRodada > 8)
                {
                    Console.WriteLine("O jogo terminou em velha!");
                    // Printando a matriz
                    for (int l = 0; l < matriz.GetLength(0); l++)
                    {
                        Console.WriteLine("  ___    ___    ___");
                        for (int c = 0; c < matriz.GetLength(1); c++)
                        {
                            Console.Write(" | " + matriz[l, c] + " | ");
                            //Thread.Sleep(50); // só para efeito visual
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("  ¯¯¯    ¯¯¯    ¯¯¯");

                    // Soma pontuação no ranking
                    ranking["Velha"] += 1;

                    // Printa o ranking com os jogadores
                    Console.WriteLine("RANKING");
                    foreach (KeyValuePair<string, int> r in ranking)
                    {
                        Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
                    }

                    Console.Write("Para continuar jogando digite 1, caso não, digite 2 para voltar ao menu: ");
                    scannerDecision = Console.ReadLine();

                    if (scannerDecision == "1") // Caso queira
                    {
                        // renumerando a matriz
                        n = 0;
                        for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                        {
                            for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                            {
                                matriz[l, c] = Convert.ToString(n += 1);
                            }
                        }
                        numerosDisponiveis = verificaArrayBot.ToList();
                        Console.Clear(); // Limpa terminal
                        contagemRodada = 0;
                        vencedor = false;
                        continue;
                    }
                    else // Caso queira voltar ao menu
                    {
                        // renumerando a matriz
                        n = 0;
                        for (int l = 0; l < matriz.GetLength(0); l += 1) // .GetLength(0) pega a Quantidade de Linhas
                        {
                            for (int c = 0; c < matriz.GetLength(1); c += 1) // .GetLength(0) pega a Quantidade de Colunas
                            {
                                matriz[l, c] = Convert.ToString(n += 1);
                            }
                        }
                        numerosDisponiveis = verificaArrayBot.ToList();
                        Console.Clear(); // Limpa terminal
                        contagemRodada = 0;
                        vencedor = true;
                    }
                }
                Console.WriteLine($"Número escolhido pelo Bot: {numBot[0]} e {numBot[1]}");
                Console.WriteLine("Números restantes: " + string.Join(", ", numerosDisponiveis));
                Console.WriteLine();
            }
        }
    }

    else
    {
        Console.WriteLine("Digite um número válido!");
        continue;
    }
}
