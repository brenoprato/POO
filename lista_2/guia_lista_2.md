# Guia de Estudos e Referência — Lista 2

Este guia reúne todos os conceitos, sintaxes e exemplos práticos necessários para resolver os **20 exercícios** da [lista_2.md](file:///home/BRENO/Documents/Unifesp/POO/lista_2/lista_2.md) sobre **Listas (`List<T>`)** e **Dicionários (`Dictionary<TKey, TValue>`)**.

> **Importante:** Sempre inclua `using System.Collections.Generic;` no topo do seu arquivo `.cs` para usar `List` e `Dictionary`.

---

## 1. Fundamentos de `List<T>` (Exercícios 1 a 5)

Diferente de um vetor (`T[]`), a `List<T>` tem **tamanho dinâmico** — cresce e diminui conforme você adiciona ou remove elementos.

### Operações Principais
```csharp
List<int> lista = new List<int>();

// 1. Adicionar ao final
lista.Add(10);
lista.Add(20);

// 2. Acessar ou alterar por índice (0 até lista.Count - 1)
int primeiro = lista[0];
lista[1] = 25;

// 3. Tamanho da lista (Note que é .Count, e não .Length!)
int tamanho = lista.Count;

// 4. Imprimir todos os elementos separados por vírgula rapidamente
Console.WriteLine(string.Join(", ", lista));
```

### Encontrar Maior, Menor, Soma e Média (Exercícios 1, 3 e 9)
Ao procurar o maior e o menor valor em um laço, **nunca inicialize `maior = 0` ou `menor = 0`** (pois a lista pode ter apenas números negativos ou apenas números maiores que zero!). Inicialize sempre com o **primeiro elemento da lista**:

```csharp
double maior = lista[0];
double menor = lista[0];
double soma = 0;

foreach (double x in lista)
{
    if (x > maior) maior = x;
    if (x < menor) menor = x;
    soma += x;
}

double media = soma / lista.Count;
```

### Inverter uma Lista — Lista Espelhada (Exercício 4)
Você pode criar uma lista espelhada percorrendo a original de trás para frente:

```csharp
List<int> espelhada = new List<int>();
for (int i = lista_original.Count - 1; i >= 0; i--)
{
    espelhada.Add(lista_original[i]);
}
```
*(Ou copiando a lista `var espelhada = new List<int>(lista_original);` e chamando `espelhada.Reverse();`).*

---

## 2. Cruzamento e Mutações em Listas (Exercícios 6 e 7)

### Copiar uma Lista sem alterar a Original
Em C#, listas são **tipos de referência**. Se você fizer `List<int> copia = original;`, ambas apontarão para a mesma lista na memória! Para criar uma cópia independente:

```csharp
List<int> copia = new List<int>(original);
```

### Operações de Mutação (Exercício 7)
Supondo $0 \le i < j < \text{Count}$:

1. **Swap (Trocar posições `i` e `j`)**:
```csharp
List<int> listaSwap = new List<int>(c);
// Tupla de desconstrução (ou use uma variável 'int temp')
(listaSwap[i], listaSwap[j]) = (listaSwap[j], listaSwap[i]);
```

2. **Inverse (Inverter a sublista de `i` até `j`)**:
O método `.Reverse(inicio, quantidade)` inverte uma fatia da lista:
```csharp
List<int> listaInverse = new List<int>(c);
int quantidadeElementos = j - i + 1;
listaInverse.Reverse(i, quantidadeElementos);
```
*(Alternativa manual com `while`: usar dois ponteiros `esq = i` e `dir = j`, trocando os elementos enquanto `esq < dir`).*

3. **Insert (Deslocar elemento `j` para a posição `i`)**:
Para mover o elemento que estava em `j` para a posição `i` e empurrar os demais uma casa para a direita (mantendo o mesmo tamanho da lista):
```csharp
List<int> listaInsert = new List<int>(c);
int valorJ = listaInsert[j];
listaInsert.RemoveAt(j);        // Remove da posição j
listaInsert.Insert(i, valorJ);  // Insere na posição i (desloca o antigo i para i+1 automaticamente!)
```

---

## 3. Listas Aninhadas e Tuplas (Exercícios 8, 9 e 10)

### Lista de Listas (`List<List<T>>`)
É o equivalente dinâmico de uma matriz ou *jagged array*.

* **Quando todos os elementos têm o mesmo tipo (Ex. 9 e 10)**: Usa-se `List<List<double>>`.
* **Quando uma lista mistura tipos diferentes, como `string` (nome) e `double` (notas/média) (Ex. 8)**: Usa-se `List<object>` para o aluno, e `List<List<object>>` para a turma!

```csharp
// Exemplo para o Exercício 8
List<List<object>> lista_de_notas_dos_alunos = new List<List<object>>();

List<object> dadosAluno = new List<object>();
dadosAluno.Add("Maria"); // string (nome)
dadosAluno.Add(8.5);     // double (nota 1)
dadosAluno.Add(9.5);     // double (nota 2)
dadosAluno.Add(9.0);     // double (média)

lista_de_notas_dos_alunos.Add(dadosAluno);
```

### Lista de Tuplas (Exercício 10)
Em C#, você pode agrupar dois ou mais valores usando **ValueTuples** `(int, int)` ou `(int positivos, int negativos)`:

```csharp
List<(int positivos, int negativos)> contagem = new List<(int positivos, int negativos)>();

foreach (List<double> sublista in lista_mestra)
{
    int pos = 0, neg = 0;
    foreach (double val in sublista)
    {
        if (val > 0) pos++;
        else if (val < 0) neg++;
    }
    contagem.Add((pos, neg)); // Adiciona a tupla na lista
}

// Acessando os valores da tupla depois:
foreach (var item in contagem)
{
    Console.WriteLine($"Positivos: {item.positivos}, Negativos: {item.negativos}");
}
```

---

## 4. Dicionários (`Dictionary<TKey, TValue>`) (Exercícios 11 a 15)

Um dicionário armazena pares **Chave $\rightarrow$ Valor**. As chaves são únicas (não podem se repetir). Quando os valores podem ser de tipos variados (`string`, `int`, `double`), usamos `Dictionary<string, object>`.

### Criar, Acessar, Modificar, Adicionar e Remover
```csharp
// 1. Criar e inicializar com chaves e valores (Ex. 11)
var ouro = new Dictionary<string, object>
{
    { "Nome", "Ouro" },
    { "Grupo", 11 },
    { "Período", 6 },
    { "Número Atômico", 79 },
    { "Massa Atômica", 197 }
};

// 2. Modificar o valor de uma chave existente (Ex. 12)
ouro["Nome"] = "Au";

// 3. Criar uma nova chave (se a chave não existe, o operador [] a cria automaticamente!) (Ex. 13)
ouro["Estado físico (CNTP)"] = "Sólido";

// 4. Remover uma chave (Ex. 14)
ouro.Remove("Grupo");

// 5. Percorrer todas as chaves e valores de um dicionário
foreach (KeyValuePair<string, object> par in ouro)
{
    Console.WriteLine($"{par.Key}: {par.Value}");
}
```

---

## 5. Manipulando `List<Dictionary<string, object>>` (Exercícios 16 a 20)

Nos últimos 5 exercícios, cada elemento da `List` é um `Dictionary<string, object>`.

### Fazendo *Cast* (Unbox) de `object` (Exercícios 16 a 19)
Como os valores estão guardados como `object`, o C# exige que você converta (*cast*) o valor de volta para `int` ou `string` antes de fazer contas ou comparar tamanhos:

```csharp
foreach (Dictionary<string, object> dict in lista_de_dicionarios)
{
    // Convertendo object para int e string
    int idade = (int)dict["idade"]; // ou Convert.ToInt32(dict["idade"])
    string primeiroNome = (string)dict["primeiro_nome"]; // ou dict["primeiro_nome"].ToString()
    string segundoNome = (string)dict["segundo_nome"];

    // Exemplo Ex. 17: Concatenação, comprimento e tipo
    string nomeCompleto = primeiroNome + " " + segundoNome; // ou primeiroNome + segundoNome
    int comprimento = nomeCompleto.Length;
    Type tipo = nomeCompleto.GetType(); // Retorna System.String

    // Exemplo Ex. 18: Operador ternário para adicionar nova chave
    dict["categoria"] = (primeiroNome == "Maria") ? "Mocinha" : "Vilã";
}
```

### Remover Duplicatas por Par de Chaves (Exercício 20)
Para criar uma nova lista mantendo apenas o primeiro dicionário de cada combinação `(primeiro_nome, segundo_nome)`, você pode usar um `HashSet<(string, string)>` para registrar os pares já vistos (ou verificar na nova lista com um laço):

```csharp
List<Dictionary<string, object>> semDuplicatas = new List<Dictionary<string, object>>();
HashSet<(string, string)> paresVistos = new HashSet<(string, string)>();

foreach (var dict in lista_de_dicionarios)
{
    string pNome = (string)dict["primeiro_nome"];
    string sNome = (string)dict["segundo_nome"];
    var par = (pNome, sNome);

    // .Add() no HashSet retorna 'true' se o par ainda NÃO existia, e 'false' se já existia!
    if (paresVistos.Add(par))
    {
        semDuplicatas.Add(dict);
    }
}
```
