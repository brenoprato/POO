# Guia de Estudos e Referência — Lista 1

Este guia reúne todos os conceitos, sintaxes e exemplos práticos necessários para resolver os **25 exercícios** da [lista_1.md](file:///home/BRENO/Documents/Unifesp/POO/lista_1/lista_1.md).

---

## 1. Console: Leitura, Escrita e Formatação (Exercícios 1 a 4)

### Escrita e Interpolação de Strings
* `Console.WriteLine("texto")`: Imprime e pula uma linha.
* `Console.Write("texto")`: Imprime na mesma linha (ótimo para pedir entrada ao usuário).
* **Interpolação (`$"..."`)**: Permite inserir variáveis e formatar casas decimais diretamente na string.

```csharp
string nome = "Breno";
double divisao = 10.0 / 3.0;

// :F2 formata o número real com 2 casas decimais
Console.WriteLine($"Olá {nome}, o resultado é {divisao:F2}"); // Saída: Olá Breno, o resultado é 3.33
```

### Leitura e Conversão de Tipos
O `Console.ReadLine()` sempre retorna uma `string`. Para fazer contas, você precisa converter para tipos numéricos (`int`, `double`, `float`):

```csharp
// Conversão direta (lança erro se o usuário digitar letras)
int a = int.Parse(Console.ReadLine());
double b = double.Parse(Console.ReadLine());

// Conversão segura com TryParse (evita travar o programa, ótimo para menus!)
if (int.TryParse(Console.ReadLine(), out int opcao))
{
    Console.WriteLine($"Opção válida: {opcao}");
}
```

### Divisão Inteira vs. Divisão Real (Exercício 2)
Em C#, se você dividir dois `int`, o resultado será truncado (divisão inteira). Para obter a divisão real, faça *cast* de um dos operandos para `double`:

```csharp
int x = 7, y = 2;
int divInteira = x / y;             // Resultado: 3
double divReal = (double)x / y;     // Resultado: 3.5
Console.WriteLine($"{divReal:F2}"); // Resultado: 3.50
```

### Loops e Menus com `do-while` e `switch` (Exercício 3)
```csharp
int opcao;
do
{
    Console.WriteLine("1 - Opção A | 2 - Opção B | 0 - Sair");
    opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case 1:
            Console.WriteLine("Executando A...");
            break;
        case 2:
            Console.WriteLine("Executando B...");
            break;
        case 0:
            Console.WriteLine("Saindo...");
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
} while (opcao != 0);
```

### Ler vários números na mesma linha com `Split` (Exercício 4)
Para ler `"10 20 30 40"` e transformar em um vetor `int[]`:

```csharp
string linha = Console.ReadLine();
// StringSplitOptions.RemoveEmptyEntries evita erros se o usuário digitar espaços duplos
string[] partes = linha.Split(' ', StringSplitOptions.RemoveEmptyEntries);

int[] numeros = new int[partes.Length];
for (int i = 0; i < partes.Length; i++)
{
    numeros[i] = int.Parse(partes[i]);
}
```

---

## 2. Vetores Unidimensionais — Arrays (Exercícios 5 a 7)

Um vetor (`T[]`) tem **tamanho fixo** definido na sua criação.

### Criação e Preenchimento
```csharp
int n = 10;
int[] vec = new int[n]; // Índices vão de 0 até n - 1

for (int i = 0; i < vec.Length; i++)
{
    vec[i] = i * i; // vec[i] = i²
}
```

### Laço `for` vs. `foreach`
* Use `for` quando precisar **alterar** valores no vetor ou saber o **índice `i`** diretamente.
* Use `foreach` para **percorrer/ler** todos os elementos de forma limpa (somente leitura da variável de iteração).

```csharp
// Percorrendo com foreach
int somaImpares = 0;
foreach (int valor in vec)
{
    if (valor % 2 == 0)
        Console.WriteLine($"Par: {valor}");
    else
        somaImpares += valor;
}
```

> **Dica para os Exercícios 6 e 7:** Se precisar saber o índice dentro de um `foreach`, crie uma variável contadora externa (`int idx = 0;`) e incremente (`idx++;`) a cada iteração!

---

## 3. Matrizes 2D, Jagged Arrays e Tempos de Execução (Exercícios 8 a 13)

### Matriz Retangular (`int[,]`) vs. Jagged Array (`int[][]`)

| Característica | Matriz 2D (`int[,]`) | Jagged Array (`int[][]`) |
| :--- | :--- | :--- |
| **Formato** | Grade retangular ($n \times m$ fixo) | Vetor de vetores (cada linha tem seu tamanho) |
| **Declaração** | `int[,] mat = new int[n, m];` | `int[][] jag = new int[n][];` |
| **Acesso** | `mat[i, j]` | `jag[i][j]` |
| **Tamanho** | `mat.GetLength(0)` (linhas), `mat.GetLength(1)` (colunas) | `jag.Length` (linhas), `jag[i].Length` (colunas da linha `i`) |

#### Exemplo de Matriz 2D e Números Aleatórios (`Random`)
```csharp
Random rand = new Random();
int n = 3, m = 4;
int[,] matriz = new int[n, m];

for (int i = 0; i < matriz.GetLength(0); i++) // Percorre linhas
{
    for (int j = 0; j < matriz.GetLength(1); j++) // Percorre colunas
    {
        matriz[i, j] = rand.Next(0, 101); // Sorteia inteiro em [0, 100]
        Console.Write($"{matriz[i, j],4}"); // ,4 alinha em 4 espaços (formato tabela)
    }
    Console.WriteLine();
}
```

#### Exemplo de Jagged Array (Exercício 12)
```csharp
Random rand = new Random();
int n = 4, m = 6;
int[][] jagged = new int[n][];

for (int i = 0; i < n; i++)
{
    int tamanhoLinha = rand.Next(1, m + 1); // Intervalo [1, m]
    jagged[i] = new int[tamanhoLinha];

    for (int j = 0; j < jagged[i].Length; j++)
    {
        jagged[i][j] = rand.Next(0, 101);
    }
    // Transforma a linha inteira em texto separado por vírgula ("1,2,3")
    string linhaCsv = string.Join(",", jagged[i]);
}
```

### Dicas de Algoritmos de Matriz (Exercícios 11 e 13)
* **Matriz Mágica (Ex. 11)**: Uma matriz quadrada $n \times n$ é mágica se a soma de cada linha, a soma de cada coluna, a soma da diagonal principal (`mat[i, i]`) e a soma da diagonal secundária (`mat[i, n - 1 - i]`) forem todas **iguais**.
* **Rotação $90^\circ$ Horária (Ex. 13)**:
  * **Com matriz auxiliar**: `aux[j, n - 1 - i] = mat[i, j];` (Complexidade de Tempo: $O(n^2)$, Espaço: $O(n^2)$).
  * **In-place (sem matriz auxiliar)**: Faça primeiro a **transposta** da matriz (trocando `mat[i, j]` com `mat[j, i]` para $j > i$) e depois **inverta a ordem dos elementos de cada linha** (trocando `mat[i, j]` com `mat[i, n - 1 - j]`). (Tempo: $O(n^2)$, Espaço adicional: $O(1)$).
* **Medir Tempo de Execução (`Stopwatch`)**:
```csharp
using System.Diagnostics;

Stopwatch sw = Stopwatch.StartNew();
// ... código da rotação ...
sw.Stop();
Console.WriteLine($"Tempo: {sw.Elapsed.TotalMilliseconds} ms");
```

---

## 4. Manipulação de Arquivos e Diretórios (`System.IO`) (Exercícios 8 a 17)

Adicione `using System.IO;` no topo do arquivo.

### Criar, Verificar e Listar Pastas
```csharp
// Cria a pasta "dados" se ela não existir (não dá erro se já existir)
Directory.CreateDirectory("dados");

// Retorna um string[] com o caminho de todos os arquivos .txt dentro de "dados"
string[] arquivos = Directory.GetFiles("dados", "*.txt");
```

### Escrever e Ler Arquivos de Texto
```csharp
// Escrever uma string inteira no arquivo (sobrescreve se existir)
File.WriteAllText("dados/valor_1.txt", "42");

// Escrever várias linhas (ex: matriz ou CSV)
string[] linhas = { "1,2,3", "4,5", "6,7,8,9" };
File.WriteAllLines("jagged.csv", linhas);

// Ler todo o texto de um arquivo
string conteudo = File.ReadAllText("dados/valor_1.txt");
int valor = int.Parse(conteudo.Trim());

// Ler todas as linhas como string[]
string[] linhasLidas = File.ReadAllLines("jagged.csv");
```

### Copiar, Mover e Deletar Arquivos (Exercícios 16 e 17)
```csharp
string nomeArquivo = Path.GetFileName(caminho); // Extrai apenas "valor_1.txt" de "dados/valor_1.txt"

// Copiar (o 3º parâmetro 'true' permite sobrescrever caso já exista)
File.Copy("dados/valor_1.txt", "backup/valor_1.txt", true);

// Mover (para a lixeira, por exemplo)
File.Move("dados/valor_1.txt", "lixeira/valor_1.txt", true);

// Deletar permanentemente
File.Delete("lixeira/valor_1.txt");
```

---

## 5. Windows Forms — WinForms (Exercícios 18 a 25)

Nos exercícios 18 a 25, a interface gráfica utiliza controles visuais do **Windows Forms**.

> **Nota sobre Linux / .NET**: O projeto padrão de console (`Microsoft.NET.Sdk`) não inclui WinForms. Para compilar WinForms no .NET moderno, usa-se `<UseWindowsForms>true</UseWindowsForms>` e `<TargetFramework>net10.0-windows</TargetFramework>` (com `<EnableWindowsTargeting>true</EnableWindowsTargeting>` no Linux), ou você pode estruturar a classe do formulário via código em `Program.cs`.

### Principais Controles e Propriedades

| Controle | Propriedade / Método Principal | Exemplo de Uso |
| :--- | :--- | :--- |
| **`TextBox`** | `.Text` (lê ou altera o texto digitado)<br>`.Multiline = true` (múltiplas linhas) | `double n = double.Parse(txtNum1.Text);`<br>`txtTabuada.Text = "1 x 5 = 5\r\n2 x 5 = 10";` |
| **`Label`** | `.Text` (texto exibido na tela) | `lblResultado.Text = $"Soma: {soma}";` |
| **`Button`** | Evento `.Click` (executado ao clicar) | `btnSomar.Click += BtnSomar_Click;` |
| **`ComboBox`** | `.Items.Add(...)` (adiciona item)<br>`.Items.Count` (total de itens)<br>`.SelectedItem` (item escolhido) | `cmbOpcoes.Items.Add("Vermelho");`<br>`string cor = cmbOpcoes.SelectedItem?.ToString();` |

### Exemplo Completo de Formulário em Código (Sem precisar do Designer Visual)
Se você quiser criar e testar um exercício de WinForms diretamente no `Program.cs`:

```csharp
using System;
using System.Windows.Forms;

namespace MyApp
{
    public class FormSoma : Form
    {
        private TextBox txt1 = new TextBox { Top = 20, Left = 20, Width = 100 };
        private TextBox txt2 = new TextBox { Top = 50, Left = 20, Width = 100 };
        private Button btnSomar = new Button { Text = "Somar", Top = 80, Left = 20 };
        private Label lblResultado = new Label { Text = "Resultado:", Top = 120, Left = 20, AutoSize = true };

        public FormSoma()
        {
            this.Text = "Exercício 18";
            // Associa o evento de clique a uma função
            btnSomar.Click += (sender, e) =>
            {
                double v1 = double.Parse(txt1.Text);
                double v2 = double.Parse(txt2.Text);
                lblResultado.Text = $"Resultado: {v1 + v2}";
            };

            // Adiciona os controles na janela
            Controls.Add(txt1);
            Controls.Add(txt2);
            Controls.Add(btnSomar);
            Controls.Add(lblResultado);
        }
    }
}
```

### Dicas Rápidas para os Exercícios de WinForms (18–25)
* **Contar vogais (Ex. 22)**: Converta o texto para minúsculas (` string texto = txtFrase.Text.ToLower(); `) e percorra com `foreach (char c in texto)`. Verifique se `"aeiouáéíóúãõâêô".Contains(c)`.
* **Tabuada em `TextBox` Multiline (Ex. 23)**: Em WinForms, a quebra de linha dentro de um `TextBox` com `Multiline = true` exige `\r\n` (ou `Environment.NewLine`). Você também pode usar `txtResultado.AppendText($"{n} x {i} = {n * i}{Environment.NewLine}");`.
* **Quantidade no `ComboBox` (Ex. 24)**: Após fazer `cmbNomes.Items.Add(txtNome.Text);`, o total de itens cadastrados é obtido com `cmbNomes.Items.Count`.
