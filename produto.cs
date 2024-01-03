using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class Musica : IModelo {
  public int Id { get; set; }
  public string Nome { get; set; }
  public double Duracao { get; set; }
  public int IdPlaylist { get; set; }
  public override string ToString() {
    return $"{Id} - {Nome}  {Duracao:f2}";
  }
}

class NMusica : NModelo<Musica> {
  public NMusica() : base("Musica.xml") { }
  public List<Musica> Listar(Playlist c) {
    List<Musica> produtos = new List<Musica>();
    foreach(Musica obj in Listar())
      if (obj.IdPlaylist == c.Id) produtos.Add(obj);
    return produtos;
  }
}

class NMusica2 {
  private List<Musica> produtos = new List<Musica>();
  public void ToXML() {
    XmlSerializer xml = new XmlSerializer(typeof(List<Musica>));
    StreamWriter f = new StreamWriter("Musica.xml");
    xml.Serialize(f, produtos);
    f.Close();
  }
  public void FromXML() {
    try {
      XmlSerializer xml = new XmlSerializer(typeof(List<Musica>));
      StreamReader f = new StreamReader("Musica.xml");
      produtos = (List<Musica>) xml.Deserialize(f);
      f.Close();
    }
    catch (FileNotFoundException)
    {
    }
  }
  public void Inserir(Musica p) {
    FromXML();
    int id = 0;
    foreach(Musica obj in produtos) 
      if (obj.Id > id) id = obj.Id;
    p.Id = id + 1;
    produtos.Add(p);
    ToXML();
  }
  public List<Musica> Listar() {
    FromXML();
    return produtos;
  }
  public Musica Listar(int id) {
    FromXML();
    foreach(Musica obj in produtos) 
      if (obj.Id == id) return obj;
    return null;
  }
  public void Atualizar(Musica p) {
    FromXML();
    Musica obj = Listar(p.Id);
    if (obj != null) {
      produtos.Remove(obj);
      produtos.Add(p);
    }
    ToXML();
  }
  public void Excluir(Musica p) {
    FromXML();
    Musica obj = Listar(p.Id);
    if (obj != null) produtos.Remove(obj);
    ToXML();
  }
}