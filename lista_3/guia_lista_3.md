# Guia de Estudos e Referência — Lista 3

Este guia reúne todos os conceitos, sintaxes e exemplos práticos necessários para resolver os **7 exercícios** da [lista_3.md](file:///home/BRENO/Documents/Unifesp/POO/lista_3/lista_3.md) sobre **Classes, Encapsulamento, Herança, Polimorfismo e Sobrecarga de Operadores**.

---

## 1. Classes, Modificadores de Acesso e Encapsulamento (Exercícios 1 e 2)

### Modificadores de Acesso
Determinam quem pode enxergar ou alterar um atributo ou método:
* `private`: Apenas a **própria classe** tem acesso (usado para proteger os atributos).
* `protected`: A própria classe **e suas classes filhas (herdeiras)** têm acesso (pedido no Exercício 2a para o atributo `n`).
* `public`: Qualquer código externo pode acessar (usado nos construtores, *getters* e *setters*).

### Getters, Setters e Validação
Na Lista 3, o professor pede explicitamente métodos de acesso e configuração (ex: `get_n()`, `set_n(...)`).

```csharp
public class Pessoa
{
    private string nome;
    private int idade;

    public Pessoa(string nome, int idade)
    {
        set_nome(nome);
        set_idade(idade);
    }

    public string get_nome() => this.nome;
    public void set_nome(string nome) => this.nome = nome;

    public int get_idade() => this.idade;
    public void set_idade(int idade)
    {
        if (idade > 0)
            this.idade = idade;
        else
            Console.WriteLine("Idade inválida! Deve ser positiva.");
    }
}
```

### Sobrecarga de Construtores (Exercício 2a)
Uma classe pode ter **mais de um construtor** desde que recebam parâmetros de tipos diferentes (ex: um recebe `int` e outro recebe `string` literal):

```csharp
public class Numero_Natural
{
    protected int n;

    // Construtor 1: recebe inteiro
    public Numero_Natural(int n)
    {
        set_n(n);
    }

    // Construtor 2: recebe literal (string) e converte para inteiro
    public Numero_Natural(string nLiteral)
    {
        int valorConvertido = int.Parse(nLiteral);
        set_n(valorConvertido);
    }

    public virtual void set_n(int valor)
    {
        if (valor >= 0) // ou > 0 conforme enunciado
            this.n = valor;
    }

    public int get_n() => this.n;
}
```

---

## 2. Herança e Polimorfismo (`virtual` e `override`) (Exercícios 1, 2 e 7)

### Herança (`:` e `: base(...)`)
Para que `Aluno` herde de `Pessoa`, usamos `class Aluno : Pessoa`. O construtor da classe filha deve repassar os dados para o construtor da classe mãe usando `: base(...)`.

### Polimorfismo de Sobrescrita (`virtual` e `override`)
Em C#, para que uma classe filha possa sobrescrever um método da classe mãe:
1. Na **classe mãe**, o método deve ser marcado com a palavra-chave **`virtual`**.
2. Na **classe filha**, o método deve ser marcado com a palavra-chave **`override`**.

```csharp
public class Pessoa
{
    // ... atributos e getters/setters ...

    // 1. Marcar como 'virtual' na superclasse
    public virtual void exibir_dados()
    {
        Console.WriteLine($"Nome: {get_nome()}, Idade: {get_idade()}");
    }
}

public class Aluno : Pessoa
{
    private double nota;

    // Repassa nome e idade para o construtor de Pessoa via base(nome, idade)
    public Aluno(string nome, int idade, double nota) : base(nome, idade)
    {
        set_nota(nota);
    }

    public double get_nota() => this.nota;
    public void set_nota(double nota)
    {
        if (nota >= 0 && nota <= 10)
            this.nota = nota;
    }

    // 2. Marcar como 'override' na subclasse
    public override void exibir_dados()
    {
        Console.WriteLine($"Nome: {get_nome()}, Idade: {get_idade()}, Nota: {this.nota}");
    }
}
```

### Composição de Objetos (Exercício 2c)
Quando um atributo de uma classe é um objeto de outra classe (ex: `numerador` e `denominador` são do tipo `Numero_Inteiro`), lembre-se de validar se o objeto não é `null` e se o valor interno dele (`denominador.get_n()`) não é `0`!

---

## 3. Sobrecarga de Operadores (`operator`) (Exercícios 3 e 4)

Em C#, você pode ensinar uma classe a usar operadores matemáticos e relacionais (`+`, `==`, `!=`, `>`, `<`) usando `public static <TipoRetorno> operator <Simbolo>(...)`.

> **Regra de Ouro do C#:** Os operadores andam **em pares**!
> * Se você sobrecarregar `==`, o compilador **obriga** você a sobrecarregar `!=` também.
> * Se você sobrecarregar `>`, o compilador **obriga** você a sobrecarregar `<` também.

### Exemplo na Classe `Numero_Racional` (Exercício 3)
Duas frações $\frac{a_1}{b_1}$ e $\frac{a_2}{b_2}$ são matematicamente iguais se $a_1 \cdot b_2 == a_2 \cdot b_1$:

```csharp
public class Numero_Racional
{
    private Numero_Inteiro numerador;
    private Numero_Inteiro denominador;

    // ... construtores, getters, setters e método show() ...

    // Sobrecarga da Soma (+)
    public static Numero_Racional operator +(Numero_Racional r1, Numero_Racional r2)
    {
        int a1 = r1.numerador.get_n();
        int b1 = r1.denominador.get_n();
        int a2 = r2.numerador.get_n();
        int b2 = r2.denominador.get_n();

        int novoNum = (a1 * b2) + (a2 * b1);
        int novoDen = b1 * b2;

        return new Numero_Racional(new Numero_Inteiro(novoNum), new Numero_Inteiro(novoDen));
    }

    // Sobrecarga da Igualdade (==) e Diferença (!=)
    public static bool operator ==(Numero_Racional r1, Numero_Racional r2)
    {
        if (ReferenceEquals(r1, r2)) return true;
        if (r1 is null || r2 is null) return false;

        return r1.numerador.get_n() * r2.denominador.get_n() ==
               r2.numerador.get_n() * r1.denominador.get_n();
    }

    public static bool operator !=(Numero_Racional r1, Numero_Racional r2)
    {
        return !(r1 == r2); // Reaproveita a lógica do ==
    }
}
```

### Exemplo de `<` e `>` na Classe `Carta` (Exercício 4)
```csharp
public static bool operator >(Carta c1, Carta c2) => c1.get_peso() > c2.get_peso();
public static bool operator <(Carta c1, Carta c2) => c1.get_peso() < c2.get_peso();
public static bool operator ==(Carta c1, Carta c2) => c1.get_peso() == c2.get_peso();
public static bool operator !=(Carta c1, Carta c2) => !(c1 == c2);
```

---

## 4. Algoritmos de Baralho e Truco (Exercícios 5, 6 e 7)

### Validar Valores em uma Lista Permitida (Exercício 4)
Para garantir que `valor` pertence a `["A", "2", ..., "K"]`, você pode usar uma lista ou array estático e o método `.Contains()`:

```csharp
private static readonly List<string> ValoresPermitidos = new List<string> 
    { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

public void set_valor(string v)
{
    if (ValoresPermitidos.Contains(v))
        this.valor = v;
}
```

### Embaralhar uma `List<Carta>` (Algoritmo de Fisher-Yates — Exercício 5)
Para aleatorizar os índices de uma lista `cartas` no método `embaralha()`:

```csharp
public void embaralha()
{
    Random rand = new Random();
    for (int i = cartas.Count - 1; i > 0; i--)
    {
        int j = rand.Next(0, i + 1); // Sorteia índice entre 0 e i
        (cartas[i], cartas[j]) = (cartas[j], cartas[i]); // Troca as cartas de lugar
    }
}
```

### Retirar uma Carta Aleatória (Exercício 5)
```csharp
public Carta retira_carta_aleatoria()
{
    if (cartas.Count == 0) return null;

    Random rand = new Random();
    int idx = rand.Next(0, cartas.Count);
    Carta escolhida = cartas[idx];
    cartas.RemoveAt(idx); // Remove do baralho
    return escolhida;     // E retorna a carta
}
```

### Lógica das Manilhas no `Baralho_de_Truco` (Exercício 7)
1. **Ordem de pesos base (0 a 9)**:
   Crie um dicionário ou lista ordenada com a sequência do truco:
   `["4", "5", "6", "7", "Q", "J", "K", "A", "2", "3"]`.
   Observe que o **índice** de cada carta nessa lista (de `0` a `9`) é exatamente o seu **peso inicial**!
2. **Achar o peso das manilhas após o `vira`**:
   * Se o `vira` tem peso $p$ (entre $0$ e $9$), o peso base das cartas que virarão manilhas é:
     $$\text{pesoAlvo} = (p == 9) \ ? \ 0 : p + 1$$
     *(Isto é, `(p + 1) % 10`: se virar o `"3"` de peso 9, o alvo é o `"4"` de peso 0).*
   * Percorra todas as cartas do baralho: aquelas que tiverem `peso == pesoAlvo` são as **manilhas** e devem ter seu peso atualizado de acordo com o naipe:
     * `Ouros` $\rightarrow 10$
     * `Espadas` $\rightarrow 11$
     * `Copas` $\rightarrow 12$
     * `Paus` $\rightarrow 13$
