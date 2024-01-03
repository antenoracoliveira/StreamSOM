using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class Usuario : IModelo {
  public int Id { get; set; }
  public string Nome { get; set; }
  public string Email { get; set; }
  public string Senha { get; set; }
  public override string ToString() {
    return $"{Id} - {Nome} ({Email})";
  }
}

class NUsuario : NModelo<Usuario> {
  public NUsuario() : base("Usuario.xml") { }
}

class NUsuario2 {
  private List<Usuario> usuarios = new List<Usuario>();
  public void ToXML() {
    XmlSerializer xml = new XmlSerializer(typeof(List<Usuario>));
    StreamWriter f = new StreamWriter("Usuario.xml");
    xml.Serialize(f, usuarios);
    f.Close();
  }
  public void FromXML() {
    try {
      XmlSerializer xml = new XmlSerializer(typeof(List<Usuario>));
List<Usuario> objetos = new List<Usuario>();
      StreamReader f = new StreamReader("Usuario.xml");
      objetos = (List<Usuario>) xml.Deserialize(f);
      f.Close();
    }
    catch (FileNotFoundException)
    {
    }
  }
  public void Inserir(Usuario u) {
    FromXML();
    int id = 0;
    foreach(Usuario obj in usuarios) 
      if (obj.Id > id) id = obj.Id;
    u.Id = id + 1;
    usuarios.Add(u);
    ToXML();
  }
  public List<Usuario> Listar() {
    FromXML();
    return usuarios;
  }
  public Usuario Listar(int id) {
    FromXML();
    foreach(Usuario obj in usuarios) 
      if (obj.Id == id) return obj;
    return null;
  }
  public void Atualizar(Usuario u) {
    FromXML();
    Usuario obj = Listar(u.Id);
    if (obj != null) {
      usuarios.Remove(obj);
      usuarios.Add(u);
    }
    ToXML();
  }
  public void Excluir(Usuario u) {
    FromXML();
    Usuario obj = Listar(u.Id);
    if (obj != null) usuarios.Remove(obj);
    ToXML();
  }
  //mudei aqui
public static string EntrarNoSistema(string nome, string email, string senha) {
    NUsuario2 nu = new NUsuario2();
    nu.FromXML();
    foreach (Usuario u in nu.usuarios) {
        if (u.Nome == nome && u.Email == email && u.Senha == senha) {
            return "UsuarioLogado";
        }
    }
    return "FalhaNaAutenticacao";
}
}
