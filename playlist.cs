using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class Playlist : IModelo {
  public int Id { get; set; }
  public string Nome { get; set; }
  public override string ToString() {
    return $"{Id} - {Nome}";
  }
}

class NPlaylist : NModelo<Playlist> {
  public NPlaylist() : base("Playlist.xml") { }
}

class NPlaylist2 {
  private List<Playlist> objetos = new List<Playlist>();
  public void ToXML() {
    XmlSerializer xml = new XmlSerializer(typeof(List<Playlist>));
    StreamWriter f = new StreamWriter("Playlist.xml");
    xml.Serialize(f, objetos);
    f.Close();
  }
  public void FromXML() {
    try {
      XmlSerializer xml = new XmlSerializer(typeof(List<Playlist>));
      StreamReader f = new StreamReader("Playlist.xml");
      objetos = (List<Playlist>) xml.Deserialize(f);
      f.Close();
    }
    catch (FileNotFoundException)
    {
    }
  }
  public void Inserir(Playlist p) {
    FromXML();
    int id = 0;
    foreach(Playlist obj in objetos) 
      if (obj.Id > id) id = obj.Id;
    p.Id = id + 1;
    objetos.Add(p);
    ToXML();
  }
  public List<Playlist> Listar() {
    FromXML();
    return objetos;
  }
  public Playlist Listar(int id) {
    FromXML();
    foreach(Playlist obj in objetos) 
      if (obj.Id == id) return obj;
    return null;
  }
  public void Atualizar(Playlist p) {
    FromXML();
    Playlist obj = Listar(p.Id);
    if (obj != null) {
      objetos.Remove(obj);
      objetos.Add(p);
    }
    ToXML();
  }
  public void Excluir(Playlist p) {
    FromXML();
    Playlist obj = Listar(p.Id);
    if (obj != null) objetos.Remove(obj);
    ToXML();
  }
}