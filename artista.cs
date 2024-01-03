using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class Artista : IModelo {
  public int Id { get; set; }
  public string Nome { get; set; }
  public override string ToString() {
    return $"{Id} - {Nome}";
  }
}

class NArtista : NModelo<Artista> {
  public NArtista() : base("Artista.xml") { }
}

class NArtista2 {
  private List<Artista> objetos = new List<Artista>();
  public void ToXML() {
    XmlSerializer xml = new XmlSerializer(typeof(List<Artista>));
    StreamWriter f = new StreamWriter("Artista.xml");
    xml.Serialize(f, objetos);
    f.Close();
  }
  public void FromXML() {
    try {
      XmlSerializer xml = new XmlSerializer(typeof(List<Artista>));
      StreamReader f = new StreamReader("Artista.xml");
      objetos = (List<Artista>) xml.Deserialize(f);
      f.Close();
    }
    catch (FileNotFoundException)
    {
    }
  }
  public void Inserir(Artista p) {
    FromXML();
    int id = 0;
    foreach(Artista obj in objetos) 
      if (obj.Id > id) id = obj.Id;
    p.Id = id + 1;
    objetos.Add(p);
    ToXML();
  }
  public List<Artista> Listar() {
    FromXML();
    return objetos;
  }
  public Artista Listar(int id) {
    FromXML();
    foreach(Artista obj in objetos) 
      if (obj.Id == id) return obj;
    return null;
  }
  public void Atualizar(Artista p) {
    FromXML();
    Artista obj = Listar(p.Id);
    if (obj != null) {
      objetos.Remove(obj);
      objetos.Add(p);
    }
    ToXML();
  }
  public void Excluir(Artista p) {
    FromXML();
    Artista obj = Listar(p.Id);
    if (obj != null) objetos.Remove(obj);
    ToXML();
  }
}