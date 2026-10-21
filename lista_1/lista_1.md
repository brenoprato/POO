# Lista de Exercícios 1 - Introdução à C# e ao VSC22/26

**Prof. Dr. Rodrigo Colnago Contreras**  
`contreras@unifesp.br`  
Criada em 11/07/2025 e modificada em 08/09/2026.

---

## Exercícios

### 1 Console: leitura e escrita

**Exercício 1.** Imprima no console seu nome, curso e semestre usando `Console.WriteLine`. Em seguida, leia do teclado (com `Console.ReadLine`) a sua linguagem favorita e mostre: `"Linguagem favorita: <...>"`.

---

**Exercício 2.** Leia dois inteiros do teclado e exiba soma, diferença, produto e quociente (divisão inteira e divisão real formatada com 2 casas).

---

**Exercício 3.** Implemente um menu de console (loop) com as opções `1-Calcular IMC`, `2-Converter Celsius→Fahrenheit`, `0-Sair`. Cada opção deve ler dados, calcular e imprimir o resultado.

---

**Exercício 4.** Leia uma linha com vários números separados por espaço, converta para `int[]` e mostre o maior, o menor e a média.

---

### 2 Vetores (numéricos e strings)

**Exercício 5.** Gere um `int[] vec` de tamanho $N$ com valores tais que $vec[i] = i^2$. Imprima: (a) todos os elementos com `foreach`; (b) apenas os pares; (c) a soma dos ímpares.

---

**Exercício 6.** Leia $M$ nomes (`string[]`). Depois leia um nome alvo e conte, usando `foreach`, quantas ocorrências existem. Mostre também os índices onde aparece.

---

**Exercício 7.** Implemente busca linear em um vetor `int[]` que retorna `-1` se não encontrar. Faça duas versões: com `for` e com `foreach`.

---

### 3 Matrizes (2D) e arquivos

**Exercício 8.** Salve duas matrizes quadradas lidas pelo usuário e cujo número de linhas seja dado pelo usuário em `A.txt` e `B.txt`. Depois, leia, some, mostre o resultado e salve em `C.txt`.

---

**Exercício 9.** Normalize uma matriz de reais $n \times m$ para a faixa $[0, 1]$ usando min–max por coluna ($f_{\text{min-max}}(x) = 2 \left(\frac{x - x_{\min,i}}{x_{\max,i} - x_{\min,i}}\right) - 1$, sendo $x_{\min,i}$ e $x_{\max,i}$ os valores mínimo e máximo, respectivamente, presentes na $i$-ésima coluna da matriz). Salve as matrizes original e normalizada em arquivos `.CSV`.

---

**Exercício 10.** Crie uma matriz $n \times m$ de inteiros com valores aleatórios. Imprima no formato de tabela. Calcule e mostre: (a) soma por linha, (b) soma por coluna, (c) maior elemento e sua posição.

---

**Exercício 11.** Gere uma matriz quadrada $n \times n$ e verifique se é **matriz mágica**. Salve a matriz em `matriz_magica.txt`.

> **Definição de Matriz Mágica (Quadrado Mágico):** Uma matriz quadrada de ordem $n$ é dita mágica quando a soma dos elementos de cada linha, a soma dos elementos de cada coluna, a soma da diagonal principal e a soma da diagonal secundária são todas exatamente iguais.


---

**Exercício 12.** Crie uma *jagged array* do tipo `int[][]` contendo $n$ linhas. O tamanho de cada linha deve ser determinado aleatoriamente no intervalo $[1, m]$.  
Preencha cada posição da *jagged array* com valores inteiros aleatórios no intervalo $[0, 100]$.  
Em seguida, salve os dados no arquivo `jagged.csv`, de modo que cada linha do arquivo corresponda a uma linha da *jagged array*.  
Por exemplo, uma *jagged array*:

```text
1 2 3
4 5
6 7 8 9
```

deve gerar um arquivo CSV no formato:

```csv
1,2,3
4,5
6,7,8,9
```

Ao final, leia o arquivo gerado e verifique se os dados armazenados no arquivo correspondem à *jagged array* original.

---

**Exercício 13.** Dada uma matriz quadrada $n \times n$ de números inteiros, implemente uma função que realize a rotação da matriz em $90^\circ$ no sentido horário.  
A rotação deve ser implementada de duas formas:

1. utilizando uma matriz auxiliar;
2. realizando a operação **in-place**, sem utilizar uma segunda matriz de tamanho $n \times n$.

Por exemplo, considerando a matriz:

$$
\begin{bmatrix}
1 & 2 & 3 \\
4 & 5 & 6 \\
7 & 8 & 9
\end{bmatrix}
$$

após a rotação de $90^\circ$ no sentido horário, o resultado deve ser:

$$
\begin{bmatrix}
7 & 4 & 1 \\
8 & 5 & 2 \\
9 & 6 & 3
\end{bmatrix}
$$

Teste as duas implementações utilizando diferentes valores de $n$ e compare seus tempos de execução. Apresente os resultados em uma tabela e discuta a complexidade temporal e espacial das duas soluções.

---

### 4 Arquivos: criar, ler, copiar, deletar

**Exercício 14.** Crie $N$ arquivos de texto `valor_#i.txt` em uma pasta `dados/`, com $N$ inteiro sendo dado pelo usuário, cada um contendo um número crescente de $0$ a $N$. Ao final, liste no console os nomes criados.

---

**Exercício 15.** Leia todos os arquivos da pasta `dados/`, some os valores e salve a soma em `dados/soma.txt`.

---

**Exercício 16.** Copie todo o conteúdo de `dados/` para `backup/` (mantendo os nomes). Se o arquivo já existir em `backup/`, sobrescreva.

---

**Exercício 17.** Implemente uma “lixeira” simples: mova todos os arquivos cujo valor $\le 50$ para `lixeira/` e delete todos os com valor $< 10$. Mostre um relatório final.

---

### 5 WinForms

**Exercício 18.** Crie um formulário com dois `TextBox` para o usuário digitar números, um `Button` “Somar” e um `Label` “Resultado:”. Ao clicar no botão, mostrar no `Label` a soma dos dois números.

---

**Exercício 19.** Monte um formulário com três `TextBox`, um `Button` “Calcular” e um `Label`. Ao clicar, mostrar no `Label` qual é o maior número digitado.

---

**Exercício 20.** Faça um formulário com um `ComboBox` contendo as opções “Vermelho”, “Verde” e “Azul”, um `Button` “Aplicar” e um `Label`. Quando o botão for clicado, o texto do `Label` deve mudar para “Você escolheu: `<cor>`”.

---

**Exercício 21.** Crie um formulário com dois `TextBox` para números, um `ComboBox` com as operações “Soma”, “Subtração”, “Multiplicação” e “Divisão”, um `Button` “Calcular” e um `Label`. Ao clicar, mostrar no `Label` o resultado da operação escolhida.

---

**Exercício 22.** Monte um formulário com um `TextBox` para digitar uma palavra ou frase, um `Button` “Contar” e um `Label`. Ao clicar, o programa deve contar quantas vogais (a, e, i, o, u) existem no texto e mostrar no `Label`.

---

**Exercício 23.** Crie um formulário com um `TextBox` para o número, um `Button` “Gerar” e um `TextBox` multiline (configurado com `Multiline=true`) para mostrar o resultado. Ao clicar, o programa deve exibir a tabuada de 1 a 10 para o número digitado.

---

**Exercício 24.** Crie um formulário com um `TextBox` para digitar um nome, um `Button` “Adicionar” e um `ComboBox`. Cada vez que o botão for clicado, o nome digitado deve ser incluído no `ComboBox`. Mostre também em um `Label` a quantidade total de nomes cadastrados.

---

**Exercício 25.** Monte um formulário com três `TextBox` para notas, um `Button` “Calcular média” e um `Label`. Ao clicar, mostrar a média aritmética das notas e também se o aluno está “Aprovado” (média $\ge 6$) ou “Reprovado” (média $< 6$).
