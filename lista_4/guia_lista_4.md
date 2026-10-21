# Guia de Estudos e Referência — Lista 4

Este guia reúne todos os conceitos teóricos e práticos de C# necessários para responder e resolver os **4 exercícios** da [lista_4.md](file:///home/BRENO/Documents/Unifesp/POO/lista_4/lista_4.md) sobre **Construtores, Herança, Escopo de Visibilidade, Referências e Vetores de Objetos**.

---

## 1. O Identificador `this` e Sobrecarga de Construtores (Exercício 1)

### O Papel do `this`
A palavra-chave `this` é uma referência à **instância atual** (o próprio objeto que está sendo construído ou manipulado).
* **Por que ele é necessário no construtor?** Quando os parâmetros do construtor têm **exatamente o mesmo nome** dos atributos da classe (ex: parâmetro `int x` e atributo `private int x`), ocorre **sombreamento de variáveis (*shadowing*)**.
* Se você escrever apenas `x = x;`, o C# atribuirá o parâmetro a ele mesmo e o atributo da classe continuará `0`!
* Usando `this.x = x;`, você deixa explícito: *"atribua o valor do parâmetro `x` ao atributo `x` deste objeto (`this.x`)"*.

### Regra de Assinatura na Sobrecarga (*Overloading*)
O Polimorfismo Estático (**Sobrecarga de Construtores ou Métodos**) permite ter vários construtores com o mesmo nome da classe, **desde que suas assinaturas sejam diferentes** (diferente quantidade, tipos ou ordem de parâmetros).

```csharp
// ERRO DE COMPILAÇÃO (CS0111): Ambos têm a assinatura A(int, int, int)!
public A(int x, int y, int z) { ... }
public A(int x, int y, int z) { ... }
```
**Como corrigir?**
* Alterando a assinatura de um dos construtores (ex: adicionando um parâmetro opcional/booleano, mudando a quantidade de parâmetros ou unificando a lógica em um único construtor).

---

## 2. Herança: Visibilidade (`private` vs `protected`) e `: base(...)` (Exercício 2)

Quando uma subclasse `B` herda de uma superclasse `A` (`class B : A`), existem duas regras fundamentais em C#:

### Problema 1: A Chamada Obrigatória ao Construtor da Classe Base
Se a classe mãe `A` define apenas construtores com parâmetros — como `public A(int x, int y, int z)` — o compilador do C# **não gera mais o construtor vazio padrão `A()`**.
* Portanto, toda classe filha `B` é **obrigada** a chamar explicitamente um construtor válido da classe mãe usando `: base(...)`:

```csharp
// ERRADO (se A não tiver construtor sem parâmetros):
public B(int w) { this.w = w; }

// CORRETO: Recebe ou repassa os valores de x, y, z para a classe mãe A
public B(int x, int y, int z, int w) : base(x, y, z)
{
    this.w = w;
    MostraValores();
}
```

### Problema 2: Acesso a Atributos `private` da Superclasse
Mesmo que `B` herde de `A`, um atributo `private int x;` declarado em `A` **não é visível diretamente dentro de `B`**! Tentar acessar `this.x` dentro de `B` gera erro de compilação (`'A.x' is inaccessible due to its protection level`).
* `y` (`protected`) e `z` (`public`) funcionam normalmente em `B`.
* **Como corrigir o acesso a `x`?**
  1. Criando um método público ou protegido de acesso (*getter*) na classe `A`, como `public int GetX() => this.x;`, e chamando `GetX()` em `B`; **ou**
  2. Mudando o modificador de `x` na classe `A` de `private` para `protected`.

---

## 3. Impressão de Objetos, Operadores, Variáveis Não Inicializadas e Exceções (Exercício 3)

Ao analisar objetos de uma classe `Q` (frações) dentro do `Main`, preste atenção a 5 comportamentos do C#:

### 1. O que acontece em `Console.WriteLine(q1)`?
* Ele **NÃO** calcula a divisão real (`0.5`) sozinho!
* Quando passamos um objeto para `Console.WriteLine`, o C# chama o método `.ToString()` daquele objeto. Se a classe `Q` não sobrescreveu `public override string ToString()`, ele imprime apenas o **nome do tipo da classe** (ex: `MeuNamespace.Q`).

### 2. O que acontece em `Console.WriteLine(q1 + q2)`?
* Objetos de classes criadas pelo programador **não possuem operadores matemáticos (`+`, `-`, `*`, `/`) por padrão**.
* Se a classe `Q` não definir `public static Q operator +(Q a, Q b)`, o código **nem sequer compila** (Erro de compilação: *Operator '+' cannot be applied to operands of type 'Q' and 'Q'*).

### 3. Acessar atributos privados fora da classe
* Se `Numerador` e `Denominador` são `private`, escrever `q1.Numerador` dentro do `Main` (fora da classe `Q`) **causa erro de compilação**.
* O correto, respeitando o encapsulamento, é chamar os *getters*:
  ```csharp
  Console.WriteLine($"{q1.GetNumerador()} / {q1.GetDenominador()}");
  ```

### 4. Declarar uma variável (`Q q3;`) vs. Instanciar um Objeto (`new Q(...)`)
* Escrever apenas `Q q3;` cria apenas uma **variável de referência** (um "ponteiro" vazio/não inicializado) do tipo `Q`, mas **não instancia nenhum objeto na memória** (não há chamada ao `new`).

### 5. Lançamento de Exceções (`throw new Exception(...)`)
* Ao executar `q4 = new Q(1, 0);`, o construtor chama `SetDenominador(0)`, que cai no `else` e executa `throw new Exception(...)`, interrompendo a execução do programa imediatamente com um erro em tempo de execução (*Runtime Exception*).

---

## 4. Vetores de Objetos e `NullReferenceException` (Exercício 4)

Este é um dos conceitos mais importantes de POO em C# e Java!

### O que `Q[] fracoes = new Q[3];` realmente faz na memória?
Em C#, classes são **Tipos de Referência (*Reference Types*)**.
Quando você executa `Q[] fracoes = new Q[3];`:
1. O C# aloca na memória (Heap) apenas um **vetor com 3 espaços para guardar referências (endereços)** para objetos do tipo `Q`.
2. **Nenhum objeto `Q` foi criado ainda!** O construtor `public Q(...)` não foi chamado nenhuma vez.
3. Todas as 3 posições do vetor começam preenchidas com **`null`**:
   ```text
   fracoes[0] ---> null
   fracoes[1] ---> null
   fracoes[2] ---> null
   ```

### Por que `fracoes[0].SetNumerador(1);` falha?
* O código **compila sem erros sintáticos**, mas trava **em tempo de execução (*runtime*)** lançando uma **`NullReferenceException`** (*Object reference not set to an instance of an object*).
* Isso acontece porque `fracoes[0]` (e também `fracoes[2]`) ainda vale `null`. Você está tentando chamar um método (`SetNumerador`) em um objeto que ainda não existe na memória!
* Já `fracoes[1] = new Q(3, 4);` funciona perfeitamente porque usa o operador `new` para instanciar o objeto antes de usá-lo.

### Como Instanciar um Vetor de Objetos Corretamente
Você deve executar um `new Q(...)` para **cada posição** do vetor antes de chamar qualquer método daquela posição:

```csharp
Q[] fracoes = new Q[3]; // 1º Passo: Cria o vetor de 3 referências (todas null)

// 2º Passo: Instancia cada objeto individualmente com 'new'
fracoes[0] = new Q(1, 2);
fracoes[1] = new Q(3, 4);
fracoes[2] = new Q(5, 6);

// Ou, se já quiser modificar depois de instanciar:
// fracoes[0] = new Q(1, 1);
// fracoes[0].SetNumerador(1);
// fracoes[0].SetDenominador(2);
```

### Resumo Conceitual (Para responder à questão 4e)
* **Definir o tamanho do vetor (`new Q[3]`)**: Reserva apenas o espaço contíguo para armazenar as *referências* (ponteiros) da estrutura do vetor, inicializando todas as posições com `null`.
* **Instanciar os objetos (`fracoes[i] = new Q(...)`)**: Aloca a memória real de cada objeto individual, executa o seu construtor para inicializar seus atributos internos e guarda o endereço desse novo objeto na posição `i` do vetor.
