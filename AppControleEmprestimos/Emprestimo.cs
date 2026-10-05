using System;

public class Emprestimo
{
    private int id;
    private string item;
    private string amigo;
    private string contato;
    private DateTime dataEmprestimo;
    private DateTime dataDevolucaoCombinada;
    private DateTime dataDevolucaoReal;
    private string status;

    public Emprestimo() { }

    public Emprestimo(string item, string amigo, string contato, DateTime dataEmprestimo, DateTime dataDevolucaoCombinada)
    {
        this.item = item;
        this.amigo = amigo;
        this.contato = contato;
        this.dataEmprestimo = dataEmprestimo;
        this.dataDevolucaoCombinada = dataDevolucaoCombinada;
        this.status = "Emprestado";
    }

    public int getId() { return id; }
    public void setId(int id) { this.id = id; }

    public string getItem() { return item; }
    public void setItem(string item) { this.item = item; }

    public string getAmigo() { return amigo; }
    public void setAmigo(string amigo) { this.amigo = amigo; }

    public string getContato() { return contato; }
    public void setContato(string contato) { this.contato = contato; }

    public DateTime getDataEmprestimo() { return dataEmprestimo; }
    public void setDataEmprestimo(DateTime dataEmprestimo) { this.dataEmprestimo = dataEmprestimo; }

    public DateTime getDataDevolucaoCombinada() { return dataDevolucaoCombinada; }
    public void setDataDevolucaoCombinada(DateTime dataDevolucaoCombinada) { this.dataDevolucaoCombinada = dataDevolucaoCombinada; }

    public DateTime getDataDevolucaoReal() { return dataDevolucaoReal; }
    public void setDataDevolucaoReal(DateTime dataDevolucaoReal) { this.dataDevolucaoReal = dataDevolucaoReal; }

    public string getStatus() { return status; }
    public void setStatus(string status) { this.status = status; }
}