using System;

abstract class TemplateClasse
{
    public string Nome;
    public string Extends;

    public string Gerar()
    {
        string codigo = "class " + Nome;
        if (Extends != null)
            codigo += " : " + Extends;
        codigo += "\n{\n";
        codigo += GerarMetodos();
        codigo += "}\n";
        return codigo;
    }

    public abstract string GerarMetodos();
}

class GeradorPessoa : TemplateClasse
{
    public override string GerarMetodos()
    {
        return "    public void Falar() { Console.WriteLine(\"Oi\"); }\n";
    }
}

class Program
{
    static void Main()
    {
        GeradorPessoa gerador = new GeradorPessoa();
        gerador.Nome = "Pessoa";
        gerador.Extends = "object";

        Console.WriteLine("Classe gerada:");
        Console.WriteLine(gerador.Gerar());
    }
}
