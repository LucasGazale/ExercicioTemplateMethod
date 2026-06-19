using System;
using System.Collections.Generic;

class ComparaUltimaLetra : IComparer<string>
{
    public int Compare(string palavra1, string palavra2)
    {
        char ultimaLetra1 = palavra1[palavra1.Length - 1];
        char ultimaLetra2 = palavra2[palavra2.Length - 1];
        return ultimaLetra1.CompareTo(ultimaLetra2);
    }
}

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
        // 16.1
        string[] palavras = { "banana", "uva", "maca", "abacaxi", "kiwi", "pera" };
        Array.Sort(palavras, new ComparaUltimaLetra());

        Console.WriteLine("Palavras ordenadas pela última letra:");
        foreach (string palavra in palavras)
            Console.WriteLine(palavra);

        // 16.2
        GeradorPessoa gerador = new GeradorPessoa();
        gerador.Nome = "Pessoa";
        gerador.Extends = "object";

        Console.WriteLine("\nClasse gerada:");
        Console.WriteLine(gerador.Gerar());
    }
}
