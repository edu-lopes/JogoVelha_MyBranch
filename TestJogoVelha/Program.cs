/* 
Grupo:
 —  Eduardo Lopes Barros dos Santos - RA: 2025105015
 —  Guilherme de Lima Ficagna - RA: 2025105145
 —  Cleberson Cesar Bueno dos Santos - RA: 2025105040
*/

// Importações do código
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

// Lógica - Ranking with dicionary
Dictionary<string, int> ranking = new Dictionary<string, int>() //Key guarda nome. Value guarda vitórias
{
    {"X", 0},
    {"O", 0},
    {"Maquina", 0 },
    {"Velha", 0}
};


// Começo do menu
while (true)
{
    Console.WriteLine("JOGO DA VELHA EM C#");
    Console.WriteLine();

    // Printa o ranking com os jogadores
    Console.WriteLine("RANKING");
    foreach (KeyValuePair<string, int> r in ranking)
    {
        Console.WriteLine($"JOGADOR: {r.Key}     VITÓRIAS: {r.Value}");
    }

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

    //Inclusão da opção de escolher o modo de jogo, sendo 1 para Jogador x Jogador e 2 para Jogador x Máquina
    Console.Write("Selecione 1 para dois jogadores, e 2 para jogador x máquina: ");
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
                Console.WriteLine($"Bem vindo novamente {primeiroJogador}. Você tem {ranking[primeiroJogador]} vitórias");
                Console.WriteLine();
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
                Console.WriteLine($"Bem vindo novamente {segundoJogador}. Você tem {ranking[segundoJogador]} vitórias");
                Console.WriteLine();
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

                Console.WriteLine("Vez do Jogador: " + primeiroJogador);
            }
            else
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

                    // Soma pontuação no ranking
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
                    Console.WriteLine("O vencedor é o jogador: " + segundoJogador);

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

            // Segundo caso da linha(4,5 e 6)
            if (matriz[1, 0] == "X" && matriz[1, 1] == "X" && matriz[1, 2] == "X" || matriz[1, 0] == "O" && matriz[1, 1] == "O" && matriz[1, 2] == "O")
            {
                if (matriz[1, 0] == "X" && matriz[1, 1] == "X" && matriz[1, 2] == "X")
                {
                    Console.WriteLine("O vencedor é o jogador: " + primeiroJogador);

                    // Soma pontuação no ranking
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
                else
                {
                    Console.WriteLine("O vencedor é o jogador: " + segundoJogador);

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

            // Terceiro caso da linha(7,8 e 9)
            if (matriz[2, 0] == "X" && matriz[2, 1] == "X" && matriz[2, 2] == "X" || matriz[2, 0] == "O" && matriz[2, 1] == "O" && matriz[2, 2] == "O")
            {
                if (matriz[2, 0] == "X" && matriz[2, 1] == "X" && matriz[2, 2] == "X")
                {
                    Console.WriteLine("O vencedor é o jogador: " + primeiroJogador);

                    // Soma pontuação no ranking
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
                else
                {
                    Console.WriteLine("O vencedor é o jogador: " + segundoJogador);

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

            // Primeiro caso de coluna(1,4 e 7)
            if (matriz[0, 0] == "X" && matriz[1, 0] == "X" && matriz[2, 0] == "X" || matriz[0, 0] == "O" && matriz[1, 0] == "O" && matriz[2, 0] == "O")
            {
                if (matriz[0, 0] == "X" && matriz[1, 0] == "X" && matriz[2, 0] == "X")
                {
                    Console.WriteLine("O vencedor é o jogador: " + primeiroJogador);

                    // Soma pontuação no ranking
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
                else
                {
                    Console.WriteLine("O vencedor é o jogador: " + segundoJogador);

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

            // Segundo caso de coluna(2,5 e 8)
            if (matriz[0, 1] == "X" && matriz[1, 1] == "X" && matriz[2, 1] == "X" || matriz[0, 1] == "O" && matriz[1, 1] == "O" && matriz[2, 1] == "O")
            {
                if (matriz[0, 1] == "X" && matriz[1, 1] == "X" && matriz[2, 1] == "X")
                {
                    Console.WriteLine("O vencedor é o jogador: " + primeiroJogador);

                    // Soma pontuação no ranking
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
                else
                {
                    Console.WriteLine("O vencedor é o jogador: " + segundoJogador);

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

            // Terceiro caso de coluna(3,6 e 9)
            if (matriz[0, 2] == "X" && matriz[1, 2] == "X" && matriz[2, 2] == "X" || matriz[0, 2] == "O" && matriz[1, 2] == "O" && matriz[2, 2] == "O")
            {
                if (matriz[0, 2] == "X" && matriz[1, 2] == "X" && matriz[2, 2] == "X")
                {
                    Console.WriteLine("O vencedor é o jogador: " + primeiroJogador);

                    // Soma pontuação no ranking
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
                else
                {
                    Console.WriteLine("O vencedor é o jogador: " + segundoJogador);

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

            // Primeiro caso de diagonal(1,5 e 9)
            if (matriz[0, 0] == "X" && matriz[1, 1] == "X" && matriz[2, 2] == "X" || matriz[0, 0] == "O" && matriz[1, 1] == "O" && matriz[2, 2] == "O")
            {
                if (matriz[0, 0] == "X" && matriz[1, 1] == "X" && matriz[2, 2] == "X")
                {
                    Console.WriteLine("O vencedor é o jogador: " + primeiroJogador);

                    // Soma pontuação no ranking
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
                else
                {
                    Console.WriteLine("O vencedor é o jogador: " + segundoJogador);

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

            // Segundo caso de diagonal(3,5 e 7)
            if (matriz[0, 2] == "X" && matriz[1, 1] == "X" && matriz[2, 0] == "X" || matriz[0, 2] == "O" && matriz[1, 1] == "O" && matriz[2, 0] == "O")
            {
                if (matriz[0, 2] == "X" && matriz[1, 1] == "X" && matriz[2, 0] == "X")
                {
                    Console.WriteLine("O vencedor é o jogador: " + primeiroJogador);

                    // Soma pontuação no ranking
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
                else
                {
                    Console.WriteLine("O vencedor é o jogador: " + segundoJogador);

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
                    Console.Clear(); // Limpa terminal
                    contagemRodada = 0;
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

    //Jogador x Máquina 
    else
    {
        // Começo do jogo de entre Jogador x maquina

        Console.WriteLine("JOGO DA VELHA ENTRE JOGADOR E MAQUINA");

        Console.WriteLine("Digite a dificuldade:");
        Console.Write("Fácil (1) — Difícil (2): ");
        string scannerDificuldade = Console.ReadLine();

        if (scannerDificuldade == "1")  //  Dificuldade Fácil
        {
            // Lógica para escolher se vai ser X ou O
            string scannerxOUo;
            Console.Write("Escolha entre ser 'X' ou 'O' (1 para X ou 2 para O): ");
            scannerxOUo = Console.ReadLine();
            if (scannerxOUo == "1")
            {
                scannerxOUo = "X";
            }
            else
            {
                scannerxOUo = "O";
            }

            // Jogador
            String primeiroJogador = "";

            if (primeiroJogador == "")
            {
                string scannerNome;
                // Entrada primeiro jogador
                Console.Write("Digite o nome do jogador: ");
                scannerNome = Console.ReadLine();
                primeiroJogador = scannerNome;

                // Nome do jogador vai para o ranking, mas antes é feio uma verificação pra ver se ja não existe
                if (ranking.ContainsKey(primeiroJogador))
                {
                    Console.WriteLine($"Bem vindo novamente {primeiroJogador}. Você tem {ranking[primeiroJogador]} vitórias");
                    Console.WriteLine();
                }
                else
                {
                    ranking.Add(primeiroJogador, 0);
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
                if (vezJogador == 0 )
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

                    Console.WriteLine("Vez do Jogador: " + primeiroJogador);


                }
                else
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

                    Console.WriteLine("Vez da Máquina");
                }

                // Entrada de dados do jogador para a jogada.
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
                        if (scannerxOUo == "X")
                        {
                            matriz[0, 0] = "X";
                            vezJogador++;
                        }
                        else
                        {
                            matriz[0, 0] = "O";
                            vezJogador++;
                        }
                    }
                    else
                    {
                        if (scannerxOUo == "X")
                        {
                            matriz[0, 0] = "O";
                            vezJogador--;
                        }
                        else
                        {
                            matriz[0, 0] = "X";
                            vezJogador--;
                        }
                    }
                    contagemRodada++;
                }
            }
        }
        else //Modo Dificil
        {

            Console.WriteLine("Em Construção!");

        }

    }
}
