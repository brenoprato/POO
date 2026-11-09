# Lista de Exercícios 5 - Abstrações e Interfaces em C#

**Prof. Dr. Rodrigo Colnago Contreras**  
`contreras@unifesp.br`  
Adaptada em 19/05/2026.

---

## 1. Introdução: Interfaces e Abstrações em Programação Orientada a Objetos

A Programação Orientada a Objetos (POO) fundamenta-se em princípios como abstração, encapsulamento, herança e polimorfismo. Entre esses pilares, a **abstração** desempenha papel central ao permitir a construção de modelos conceituais que representam apenas as características essenciais de um objeto, omitindo detalhes irrelevantes. Em C#, dois mecanismos principais são utilizados para expressar abstrações: **classes abstratas** e **interfaces**. Ambos permitem definir contratos de comportamento, mas apresentam objetivos, restrições e funcionalidades distintas.

### 1.1 Classes Abstratas

Uma **classe abstrata** é uma classe incompleta que não pode ser instanciada diretamente. Seu propósito é servir como modelo para outras classes, definindo uma estrutura comum que poderá (ou deverá) ser completada pelas classes derivadas.

As principais características das classes abstratas incluem:
* podem conter métodos abstratos (sem implementação);
* podem conter métodos concretos (já implementados);
* podem armazenar estado através de atributos e propriedades;
* podem declarar construtores;
* suportam apenas herança simples.

Exemplo de classe abstrata:
```csharp
abstract class Animal {
    public string Nome { get; set; }
    public abstract void EmitirSom();

    public void Dormir() {
        Console.WriteLine($"{Nome} esta dormindo.");
    }
}

class Cachorro : Animal {
    public override void EmitirSom() => Console.WriteLine("Au au!");
}
```
Neste exemplo, `Animal` define tanto um comportamento obrigatório (`EmitirSom`), quanto um comportamento comum que pode ser reutilizado (`Dormir`).

### 1.2 Interfaces

**Interfaces** representam **contratos de comportamento**. Diferentemente das classes abstratas, uma interface não define estado, mas apenas o conjunto de operações que uma classe deve implementar. Em C#, interfaces são amplamente utilizadas para garantir padronização e promover baixo acoplamento entre componentes.

Características fundamentais das interfaces:
* não podem conter campos de instância;
* não fornecem implementação detalhada (exceto métodos *default* em versões recentes);
* seus membros são implicitamente públicos;
* uma classe pode implementar múltiplas interfaces simultaneamente.

Exemplo de interface:
```csharp
public interface IVoavel {
    void Voar();
}

public class Passaro : IVoavel {
    public void Voar() {
        Console.WriteLine("O passaro esta voando.");
    }
}
```

### 1.3 Quando usar cada um?

A escolha entre classe abstrata e interface depende do tipo de abstração desejada:
* **Classe abstrata:** ideal quando existe uma relação clara do tipo “é um(a)” (por exemplo, *Cachorro é um Animal*), e quando se deseja compartilhar código comum entre as subclasses.
* **Interface:** ideal para descrever capacidades ou comportamentos independentes da hierarquia (por exemplo, *algo que pode voar*, *algo que pode ser impresso*), além de permitir múltiplas implementações.

### 1.4 Diferenças Fundamentais

A Tabela 1 apresenta uma comparação entre classes abstratas e interfaces.

| Característica | Classe Abstrata | Interface |
| :--- | :---: | :---: |
| Pode ser instanciada? | Não | Não |
| Pode conter métodos concretos? | Sim | Não (regra geral) |
| Pode conter atributos/estado? | Sim | Não |
| Possui construtor? | Sim | Não |
| Permite herança múltipla? | Não | Sim |
| Ideal para... | Hierarquias e modelos | Contratos e capacidades |

*Tabela 1: Comparação entre classes abstratas e interfaces.*

### 1.5 Ilustração Conceitual

Exemplo de classe abstrata:
```csharp
abstract class Forma {
    public abstract double Area();
}
```

Exemplo de interface:
```csharp
public interface IDesenhavel {
    void Desenhar();
}
```

Combinação de ambos:
```csharp
class Circulo : Forma, IDesenhavel {
    public double Raio { get; set; }
    public override double Area() => Math.PI * Raio * Raio;
    public void Desenhar() => Console.WriteLine("Desenhando circulo...");
}
```

### 1.6 Conclusão

Classes abstratas e interfaces são fundamentais para a construção de sistemas orientados a objetos robustos e extensíveis. Enquanto classes abstratas permitem modelar hierarquias estruturais com compartilhamento de código, interfaces fornecem contratos flexíveis que promovem polimorfismo e baixo acoplamento. A escolha entre uma e outra deve considerar a natureza da abstração desejada e os requisitos arquiteturais do sistema.

---

## Exercícios

**Exercício 1.** Explique com suas próprias palavras:
* **(a)** O que é uma **classe abstrata**?
* **(b)** O que é uma **interface**?
* **(c)** Em quais situações é mais apropriado usar classe abstrata do que interface?

---

**Exercício 2.** Classifique como Verdadeiro (V) ou Falso (F):
* **( )** Classes abstratas podem ser instanciadas diretamente.
* **( )** Interfaces podem conter atributos (campos).
* **( )** Uma classe pode implementar múltiplas interfaces ao mesmo tempo.
* **( )** Classes abstratas podem conter métodos concretos e abstratos.
* **( )** Interfaces definem apenas contratos de comportamento.
* **( )** Uma interface pode herdar de outra interface.

---

**Exercício 3.** Complete as lacunas:
* **(a)** Métodos abstratos não possuem \_\_\_\_\_\_ e devem ser \_\_\_\_\_\_ nas classes derivadas.
* **(b)** Uma classe abstrata pode conter \_\_\_\_\_ e \_\_\_\_\_.
* **(c)** Interfaces não possuem \_\_\_\_\_ nem \_\_\_\_\_, apenas assinaturas.
* **(d)** Para declarar uma classe como abstrata usamos a palavra-chave \_\_\_\_\_.
* **(e)** Para implementar uma interface usamos a palavra-chave \_\_\_\_\_.

---

**Exercício 4.** Explique, com um exemplo próprio, a diferença entre:
* herdar de uma **classe abstrata**;
* implementar uma **interface**.

---

**Exercício 5.** Analise o trecho de código:

```csharp
abstract class Animal {
    public abstract void Falar();
}

class Cachorro : Animal {
    public override void Falar() => Console.WriteLine("Au au!");
}

interface IAnimal {
    void Comer();
}

class Gato : IAnimal {
    public void Comer() => Console.WriteLine("Gato comendo...");
}
```

Responda:
* **(a)** O que acontece se tentarmos fazer `new Animal()`?
* **(b)** Por que a classe `Cachorro` deve usar `override`?
* **(c)** Por que a classe `Gato` é obrigada a implementar `Comer()`?

---

**Exercício 6.** Implemente um sistema de formas geométricas utilizando os conceitos de **classe abstrata e herança**.

**a)** Crie uma classe abstrata `Forma` contendo:
* um método abstrato `Area()` que retorna um `double`;
* um método concreto `ExibirArea()` que imprime no console o valor retornado por `Area()`.

**b)** Implemente a classe `Quadrado` que herda de `Forma`:
* inclua uma propriedade `Lado` (tipo `double`);
* implemente o método `Area()` retornando `Lado * Lado`.

**c)** Implemente a classe `Circulo` que herda de `Forma`:
* inclua uma propriedade `Raio` (tipo `double`);
* implemente o método `Area()` utilizando a fórmula `Math.PI * Raio * Raio`.

**d)** No método `Main()`:
* crie uma lista (`List<Forma>`) contendo diferentes objetos `Quadrado` e `Circulo`;
* percorra a lista utilizando tipo `Forma` e invoque o método `ExibirArea()` para cada elemento;
* certifique-se de que o programa exiba resultados corretos independentemente do tipo concreto da forma.

Exemplo de método `Main()`:
```csharp
internal class Program
{
    static void Main(string[] args)
    {
        List<Forma> list = new List<Forma>();

        list.Add(new Quadrado(10));
        list.Add(new Circulo(5));
        list.Add(new Quadrado(5));
        list.Add(new Circulo(4));

        foreach (var forma in list) forma.ExibirArea();

        Console.ReadKey();
    }
}
```

---

**Exercício 7.** Implemente um sistema de impressão utilizando o conceito de **interfaces**.

**a)** Crie uma interface `IImprimivel` contendo:
* um método `Imprimir()` (sem parâmetros e sem retorno), responsável por exibir no console informações sobre o objeto.

**b)** Implemente a classe `Relatorio`:
* inclua propriedades literais como `Titulo` e `Conteudo`;
* implemente o método `Imprimir()` exibindo o título e o conteúdo do relatório no console, em formato organizado.

**c)** Implemente a classe `Etiqueta`:
* inclua propriedades como `Codigo` e `Descricao`;
* implemente o método `Imprimir()` exibindo os dados da etiqueta de forma simples, simulando a impressão de um rótulo.

**d)** No método `Main()`:
* crie uma lista (`List<IImprimivel>`) contendo múltiplos objetos `Relatorio` e `Etiqueta`;
* implemente um método `ProcessarImpressao(List<IImprimivel> itens)` que percorra a lista e invoque `Imprimir()` para cada elemento;
* demonstre o uso polimórfico, garantindo que o método seja capaz de imprimir qualquer objeto que implemente `IImprimivel`.

---

**Exercício 8.** Implemente um sistema simples de gestão de funcionários utilizando **classe abstrata, herança, interface e polimorfismo**.

**a)** Crie uma classe abstrata `Funcionario` contendo:
* a propriedade `Nome` (tipo `string`);
* uma propriedade protegida `SalarioBase` (tipo `double`), que representa o salário fixo inicial do funcionário;
* um construtor que receba o nome e o salário base;
* um método abstrato `CalcularSalario()` que retorna `double`.

**b)** Crie a interface `IAvaliavel` contendo:
* o método `AvaliarDesempenho()` (sem parâmetros e sem retorno), responsável por imprimir uma mensagem avaliando o funcionário.

**c)** Implemente a classe `Gerente`:
* herde de `Funcionario` e implemente `IAvaliavel`;
* adicione a propriedade `Bonus` (tipo `double`). O **bônus** representa um valor adicional pago ao gerente devido a responsabilidades de administração e liderança;
* implemente um **construtor que receba `Nome`, `SalarioBase` e `Bonus`** e os inicialize corretamente;
* implemente `CalcularSalario()` retornando:
  $$\text{SalarioTotal} = \text{SalarioBase} + \text{Bonus}$$
* implemente `AvaliarDesempenho()` seguindo os critérios abaixo:
  * se o `Bonus` for maior ou igual a 3000, exiba: `“Desempenho Excelente: liderança acima do esperado.”`;
  * se o `Bonus` estiver entre 1500 e 2999, exiba: `“Desempenho Bom: atingiu as metas de gestão.”`;
  * se o `Bonus` for inferior a 1500, exiba: `“Desempenho Insuficiente: precisa melhorar indicadores de liderança.”`

**d)** Implemente a classe `Vendedor`:
* herde de `Funcionario` e implemente `IAvaliavel`;
* adicione a propriedade `Comissao` (tipo `double`). A **comissão** representa um valor adicional referente às vendas realizadas pelo vendedor;
* implemente um **construtor que receba `Nome`, `SalarioBase` e `Comissao`** e inicialize essas propriedades;
* implemente `CalcularSalario()` retornando:
  $$\text{SalarioTotal} = \text{SalarioBase} + \text{Comissao}$$
* implemente `AvaliarDesempenho()` seguindo os critérios abaixo:
  * se a `Comissao` for maior ou igual a 2000, exiba: `“Desempenho Excelente: vendas excepcionais.”`;
  * se a `Comissao` estiver entre 800 e 1999, exiba: `“Desempenho Bom: metas de vendas atingidas.”`;
  * se a `Comissao` for inferior a 800, exiba: `“Desempenho Insuficiente: metas de vendas não atingidas.”`

**e)** No método `Main()`:
* crie uma lista `List<Funcionario>` contendo instâncias de `Gerente` e `Vendedor`, fornecendo nome, salário base e os valores de bônus ou comissão;
* percorra a lista chamando `CalcularSalario()` para cada funcionário, utilizando polimorfismo;
* crie também uma lista `List<IAvaliavel>` com os mesmos objetos e invoque `AvaliarDesempenho()`;
* exiba para cada funcionário:
  * nome,
  * tipo (`Gerente` ou `Vendedor`),
  * salário total calculado,
  * avaliação de desempenho.

---

**Exercício 9.** Implemente um sistema de transporte utilizando **interface, classe abstrata e polimorfismo**, seguindo as instruções detalhadas abaixo.

**a)** Crie a interface `ITransporte` contendo dois métodos:
* `Ligar()` – método sem retorno que exibe uma mensagem indicando o processo de inicialização do transporte;
* `Mover()` – método sem retorno que descreve como o transporte se desloca.

**b)** Crie a classe abstrata `Veiculo` com:
* a propriedade `Placa` (tipo `string`), representando a identificação;
* um construtor que receba a placa e inicialize a propriedade;
* o método concreto `ExibirInfo()` que exibe no console:
  `“Veículo com placa: [PLACA]”`

**c)** Implemente a classe `Carro`:
* herde de `Veiculo` e implemente `ITransporte`;
* **comportamento específico para `Ligar()`:**
  * exibir: `“Carro ligado: motor acionado.”`
* **comportamento específico para `Mover()`:**
  * exibir: `“Carro em movimento pelas ruas.”`

**d)** Implemente a classe `Bicicleta`:
* herde de `Veiculo` e implemente `ITransporte`;
* **comportamento específico para `Ligar()`:**
  * exibir: `“Bicicleta pronta: não requer ignição.”`
* **comportamento específico para `Mover()`:**
  * exibir: `“Bicicleta pedalando pela ciclovia.”`

**e)** Implemente a classe `Aviao`:
* herde de `Veiculo` e implemente `ITransporte`;
* **comportamento específico para `Ligar()`:**
  * exibir: `“Avião ligado: turbinas ativadas.”`
* **comportamento específico para `Mover()`:**
  * exibir: `“Avião taxiando e decolando na pista.”`

**f)** No método `Main()`:
* crie uma lista `List<ITransporte>` contendo instâncias de `Carro`, `Bicicleta` e `Aviao`;
* para cada item da lista:
  * invoque `Ligar()`;
  * invoque `Mover()`;
  * opcionalmente chame `ExibirInfo()` por meio de *casting* (`as Veiculo`), reforçando o uso de referência comum.
