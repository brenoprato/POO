# Guia de Estudos e Referência — Lista 5

Este guia reúne todos os conceitos teóricos, respostas das questões conceituais (Exercícios 1 a 5) e exemplos práticos de sintaxe em C# necessários para resolver os **9 exercícios** da [lista_5.md](file:///home/BRENO/Documents/Unifesp/POO/lista_5/lista_5.md) sobre **Classes Abstratas e Interfaces**.

---

## 1. Classe Abstrata (`abstract class`)

Uma **classe abstrata** serve como um "molde parcial" (superclasse base) para outras classes. Ela **nunca pode ser instanciada diretamente** com `new`.

### Regras Principais:
1. Declarada com `abstract class NomeDaClasse`.
2. **Pode ter estado**: atributos (`private`, `protected`) e propriedades (`{ get; set; }`).
3. **Pode ter construtor**: chamado pelas classes filhas usando `: base(...)`.
4. **Métodos Abstratos (`public abstract ...;`)**: Não têm corpo `{ }` (terminam com `;`). Toda classe filha concreta é **obrigada** a implementá-los usando a palavra-chave **`override`**.
5. **Métodos Concretos**: Têm corpo `{ }` normal e são herdados prontos pelas classes filhas.

### Exemplo Prático (Base para o Exercício 6)
```csharp
public abstract class Forma
{
    // Método abstrato: sem corpo, obriga as filhas a implementarem com 'override'
    public abstract double Area();

    // Método concreto: já tem corpo e chama o método abstrato polimorficamente
    public void ExibirArea()
    {
        Console.WriteLine($"Área: {Area():F2}");
    }
}

public class Quadrado : Forma
{
    public double Lado { get; set; }

    public Quadrado(double lado)
    {
        Lado = lado;
    }

    // Obrigatório usar 'override' para implementar método 'abstract'
    public override double Area()
    {
        return Lado * Lado;
    }
}
```

---

## 2. Interface (`interface`)

Uma **interface** é um **contrato puro de comportamento**. Ela diz *o que* uma classe sabe fazer, sem definir *como* e sem guardar atributos/estado.

### Regras Principais:
1. Declarada com `interface INome` (por convenção em C#, toda interface começa com a letra **`I`** maiúscula: `IImprimivel`, `IAvaliavel`, `ITransporte`).
2. **Não possui atributos (campos) nem construtores**.
3. Contém apenas as **assinaturas** dos métodos (sem corpo `{ }` e sem modificador `public` ou `abstract`).
4. **Implementação na classe**: A classe usa `:` (ex: `class Relatorio : IImprimivel`) e implementa o método como `public`, **SEM usar `override`**!
5. **Múltiplas interfaces**: Uma classe só pode herdar de **1 classe** (abstrata ou concreta), mas pode implementar **várias interfaces** ao mesmo tempo separadas por vírgula.

### Exemplo Prático (Base para o Exercício 7)
```csharp
public interface IImprimivel
{
    void Imprimir(); // Apenas a assinatura
}

public class Etiqueta : IImprimivel
{
    public string Codigo { get; set; }
    public string Descricao { get; set; }

    public Etiqueta(string codigo, string descricao)
    {
        Codigo = codigo;
        Descricao = descricao;
    }

    // Implementa o método da interface com 'public' (SEM override!)
    public void Imprimir()
    {
        Console.WriteLine($"[{Codigo}] {Descricao}");
    }
}
```

---

## 3. Combinando Classe Abstrata + Interface (Exercícios 8 e 9)

Em C#, quando uma classe herda de uma classe abstrata **e** implementa uma interface ao mesmo tempo:
* A **classe mãe (abstrata) vem SEMPRE primeiro** após os dois-pontos `:`, seguida pelas interfaces separadas por vírgula:

```csharp
// Funcionario = classe abstrata (vem primeiro)
// IAvaliavel  = interface (vem depois)
public class Gerente : Funcionario, IAvaliavel
{
    public double Bonus { get; set; }

    // Chama o construtor da classe abstrata mãe via : base(...)
    public Gerente(string nome, double salarioBase, double bonus) 
        : base(nome, salarioBase)
    {
        Bonus = bonus;
    }

    // 1. Veio da classe abstrata Funcionario -> USA override
    public override double CalcularSalario()
    {
        return SalarioBase + Bonus;
    }

    // 2. Veio da interface IAvaliavel -> NÃO usa override
    public void AvaliarDesempenho()
    {
        if (Bonus >= 3000)
            Console.WriteLine("Desempenho Excelente: liderança acima do esperado.");
        else if (Bonus >= 1500)
            Console.WriteLine("Desempenho Bom: atingiu as metas de gestão.");
        else
            Console.WriteLine("Desempenho Insuficiente: precisa melhorar indicadores de liderança.");
    }
}
```

### Polimorfismo com Listas e Casting (`as` / `is`) (Exercícios 8e e 9f)
Mesmo que não possamos fazer `new Forma()` ou `new ITransporte()`, podemos criar **listas tipadas pela classe abstrata ou pela interface** (`List<Forma>`, `List<Funcionario>`, `List<ITransporte>`) e guardar objetos das classes concretas dentro delas!

No **Exercício 9f**, como a lista é `List<ITransporte>`, cada item `t` enxerga apenas `Ligar()` e `Mover()`. Para chamar `ExibirInfo()` (que pertence à classe abstrata `Veiculo`), fazemos o *casting* seguro com `as Veiculo`:

```csharp
List<ITransporte> transportes = new List<ITransporte>();
transportes.Add(new Carro("ABC-1234"));
transportes.Add(new Bicicleta("BIC-0001"));

foreach (ITransporte t in transportes)
{
    t.Ligar();
    t.Mover();

    // Converte a referência ITransporte para Veiculo para acessar ExibirInfo()
    Veiculo v = t as Veiculo;
    if (v != null)
    {
        v.ExibirInfo();
    }
}
```

---

## 4. Gabarito Resumido dos Exercícios Teóricos (Exercícios 1 a 5)

Para facilitar sua revisão para a prova, aqui estão as respostas diretas dos 5 exercícios teóricos da Lista 5:

### Exercício 1 (Conceitos)
* **(a) Classe abstrata:** É uma classe base incompleta que não pode ser instanciada diretamente, servindo de modelo para subclasses. Pode reunir estado (atributos/propriedades), construtores, métodos concretos (reaproveitados) e métodos abstratos (obrigatórios nas subclasses).
* **(b) Interface:** É um contrato puro de comportamento que define apenas assinaturas de métodos que uma classe se compromete a implementar, sem possuir atributos de instância nem construtores.
* **(c) Quando usar classe abstrata em vez de interface:** Quando há uma relação clara de hierarquia do tipo **"é um(a)"** (ex: `Gerente` é um `Funcionario`) e quando desejamos **compartilhar código pronto (métodos concretos) ou estado (atributos/construtores)** entre as classes filhas.

### Exercício 2 (Verdadeiro ou Falso)
* **( F )** Classes abstratas podem ser instanciadas diretamente. *(Não podem ser instanciadas com `new`).*
* **( F )** Interfaces podem conter atributos (campos). *(Interfaces não guardam campos de instância/estado).*
* **( V )** Uma classe pode implementar múltiplas interfaces ao mesmo tempo.
* **( V )** Classes abstratas podem conter métodos concretos e abstratos.
* **( V )** Interfaces definem apenas contratos de comportamento.
* **( V )** Uma interface pode herdar de outra interface.

### Exercício 3 (Preencher Lacunas)
* **(a)** Métodos abstratos não possuem **implementação (ou corpo)** e devem ser **sobrescritos (ou implementados com `override`)** nas classes derivadas.
* **(b)** Uma classe abstrata pode conter **métodos abstratos** e **métodos concretos** *(ou atributos e métodos)*.
* **(c)** Interfaces não possuem **atributos (campos/estado)** nem **construtores (ou implementação)**, apenas assinaturas.
* **(d)** Para declarar uma classe como abstrata usamos a palavra-chave **`abstract`**.
* **(e)** Para implementar uma interface usamos o operador / símbolo **`:` (dois-pontos)** *(nota: em Java usa-se `implements`, mas em C# usa-se `:` tanto para herança quanto para interface)*.

### Exercício 5 (Análise de Código)
* **(a) O que acontece se tentarmos fazer `new Animal()`?** Ocorre um **erro de compilação**, pois `Animal` é uma classe abstrata (`abstract class`) e classes abstratas não podem ser instanciadas diretamente.
* **(b) Por que `Cachorro` deve usar `override`?** Porque na classe abstrata mãe (`Animal`), o método `Falar()` foi declarado como `abstract`, exigindo que a subclasse concreta sobrescreva explicitamente essa assinatura usando `override`.
* **(c) Por que `Gato` é obrigada a implementar `Comer()`?** Porque `Gato` assinou o contrato da interface `IAnimal` (`class Gato : IAnimal`), e toda classe que implementa uma interface é obrigada a fornecer a implementação pública de todos os métodos definidos nela.
