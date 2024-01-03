using System;
using System.Collections.Generic;

static class View {
  public static void MusicaInserir(string nome, double duracao, int idPlaylist) {
    if (duracao < 0) throw new ArgumentOutOfRangeException("Duração inválida");
    Musica p = new Musica{ Nome = nome, Duracao = duracao,IdPlaylist = idPlaylist }; 
    NMusica np = new NMusica();
    np.Inserir(p);
  }
  public static List<Musica> MusicaListar() {
    NMusica np = new NMusica();
    return np.Listar();
  }
  public static List<Musica> MusicaListar(int idCategoria) {
    NMusica np = new NMusica();
    return np.Listar(new Playlist { Id = idCategoria });
  }
  public static void MusicaAtualizar(int id, string nome, double duracao, int idPlaylist) {
    if (duracao < 0) throw new ArgumentOutOfRangeException("Duração inválida");
     Musica p = new Musica{ Nome = nome, Duracao = duracao,IdPlaylist = idPlaylist };  
    NMusica np = new NMusica();
    np.Atualizar(p);
  }
  public static void MusicaExcluir(int id) {
    Musica p = new Musica{ Id = id };
    NMusica np = new NMusica();
    np.Excluir(p);
  }

  public static void PlaylistInserir(string nome) {
    Playlist c = new Playlist{ Nome = nome }; // Objeto da entidade
    NPlaylist nc = new NPlaylist();           // Objeto da persistência
    nc.Inserir(c);
  }
  public static List<Playlist> PlaylistListar() {
    NPlaylist nc = new NPlaylist();
    return nc.Listar();
  }
  public static Playlist PlaylistListar(int id) {
    NPlaylist nc = new NPlaylist();
    return nc.Listar(id);
  }
  public static void PlaylistAtualizar(int id, string nome) {
    Playlist c = new Playlist{ Id = id, Nome = nome };
    NPlaylist nc = new NPlaylist();
    nc.Atualizar(c);
  }
  public static void PlaylistExcluir(int id) {
    Playlist c = new Playlist{ Id = id };
    NPlaylist nc = new NPlaylist();
    nc.Excluir(c);
  }
//mudançaaaaaaaaaaa
  
public static bool UsuarioLogar(string email, string senha) {
    NUsuario nu = new NUsuario();
    foreach (Usuario u in nu.Listar()) {
        if (u.Email == email && u.Senha == senha) {
            return true;
        }
    }
    return false;
}
public static void UsuarioInserir(string nome, string email, string senha) {
  Usuario u = new Usuario{ Nome = nome, Email = email, Senha = senha };;
  NUsuario nu = new NUsuario();
  nu.Inserir(u);
}
public static List<Usuario> UsuarioListar() {
  NUsuario nu = new NUsuario();
  return nu.Listar();
}
public static void UsuarioAtualizar(int id, string nome) {
  Usuario u = new Usuario{ Id = id, Nome = nome };
  NUsuario nu = new NUsuario();
  nu.Atualizar(u);
}
public static void UsuarioExcluir(int id) {
  Usuario u = new Usuario{ Id = id };
  NUsuario nu = new NUsuario();
  nu.Excluir(u);
}
// mudaça
  
  public static void ArtistaInserir(string nome) {
    Artista a = new Artista{ Nome = nome };
    NArtista na = new NArtista();
    na.Inserir(a);
  }
  public static List<Artista> ArtistaListar() {
    NArtista na = new NArtista();
    return na.Listar();
  }
  public static void ArtistaAtualizar(int id, string nome) {
    Artista a = new Artista{ Id = id, Nome = nome };
    NArtista na = new NArtista();
    na.Atualizar(a);
  }
  public static void ArtistaExcluir(int id) {
    Artista a = new Artista{ Id = id };
    NArtista na = new NArtista();
    na.Excluir(a);
  }
}
