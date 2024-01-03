using System;
using System.Collections.Generic;
using System.Threading;

class Program {
   
  public static void Main() {
    Console.WriteLine(@" 
      █▀ █▀▀ █▀█ █▀▀ █▀▀ █▄░█   █▀ █▀█ █░█ █▄░█ █▀▄
      ▄█ █▄▄ █▀▄ ██▄ ██▄ █░▀█   ▄█ █▄█ █▄█ █░▀█ █▄▀ ");
      Thread.Sleep(2000);
      Console.Clear();
//mudanças
 //Criar conta ou entrar no sistema
   
    
// fim das mundaças
    
    if (Login() == "admin") {
      int op = 0;
      while (op != 99) {
        try
        {
          op = MenuAdmin();
          switch (op) {
          case 1: MusicaInserir(); break;
          case 2: MusicaListar(); break;
          case 3: MusicaListarPlaylist(); break;
          case 4: MusicaAtualizar(); break;
          case 5: MusicaExcluir(); break;
          case 6: PlaylistInserir(); break; 
          case 7: PlaylistListar(); break; 
          case 8: PlaylistAtualizar(); break; 
          case 9: PlaylistExcluir(); break; 
          case 10: UsuarioInserir(); break;
          case 11: UsuarioAtualizar(); break;
          case 12: UsuarioExcluir(); break;
          case 13: UsuarioListar(); break;
          case 14: ArtistaInserir(); break;
          case 15: ArtistaListar(); break;
          case 16: ArtistaAtualizar(); break;
          case 17: ArtistaExcluir(); break;
        
          }
        }
        catch (Exception obj) {
          Console.WriteLine("Deu erro: " + obj.Message);
        }
      }  
      Console.WriteLine("Obrigado por usar o sistema");
    }
    else {
      int op = 0;
      while (op != 99) {
        try
        {
          op = MenuUsuario();
          switch (op) {
          case 1: MusicaListar(); break;
          case 2: MusicaListarPlaylist(); break;
          case 3: PlaylistListar(); break; 
          case 4: PlaylistInserir(); break; 
          case 5: PlaylistAtualizar(); break; 
          case 6: PlaylistExcluir(); break;
            
          }
        }
        catch (Exception obj) {
          Console.WriteLine("Deu erro: " + obj.Message);
        }
      }  
      Console.WriteLine("Obrigado por usar o sistema");
    }
  }
  public static string Login() {
    Console.Clear();
    Console.WriteLine("Deseja criar conta ou entrar no sistema?");
    Console.WriteLine("1 - Criar conta");
    Console.WriteLine("2 - Entrar no sistema");
    int op = int.Parse(Console.ReadLine());
    if (op == 1) {
      Console.WriteLine("Digite seu nome: ");
      string nome = Console.ReadLine();
      Console.WriteLine("Digite seu email: ");
      string emai = Console.ReadLine();
      Console.WriteLine("Digite sua senha: ");
      string senh = Console.ReadLine();
      View.UsuarioInserir(nome, emai, senh);
      Login();
    }
    else if (op == 2) {
      Console.WriteLine("Digite seu email: ");
      string emai = Console.ReadLine();
      Console.WriteLine("Digite sua senha: ");
      string senh = Console.ReadLine();
      if (emai == "admin" && senh == "123456") {
      return "admin";}
      if(View.UsuarioLogar(emai, senh)){
        return "usuario";
  
    }
      else{
        Console.WriteLine("Email ou senha incorretos");}
      Login();
  
    }
    else {
      Console.WriteLine("Opção inválida");
      Login();
      
    }
    return "usuario";
  }
  

  public static int MenuUsuario() {
    Console.WriteLine();
    Console.WriteLine("Menu Musicas");
    Console.WriteLine("01 - Listar");
    Console.WriteLine("02 - Listar por Playlist");
    Console.WriteLine();
    Console.WriteLine("Menu Playlist");
    Console.WriteLine("03 - Listar");
   
    Console.WriteLine("04 - Criar nova Playlist");
    
    Console.WriteLine("05 - Atualizar uma Playlist");
  
    Console.WriteLine("06 - Excluir uma Playlist");
    Console.WriteLine();
    Console.WriteLine("99 - Sair");
    Console.Write("\nOpção: ");
    return int.Parse(Console.ReadLine());
  }

  public static int MenuAdmin() {
    Console.WriteLine();
    Console.WriteLine("Menu Musica");
    Console.WriteLine("01 - Inserir");
    Console.WriteLine("02 - Listar");
    Console.WriteLine("03 - Listar por Playlist");
    Console.WriteLine("04 - Atualizar");
    Console.WriteLine("05 - Excluir");
    Console.WriteLine();
    Console.WriteLine("Menu Playlist");
    Console.WriteLine("06 - Inserir");
    Console.WriteLine("07 - Listar");
    Console.WriteLine("08 - Atualizar");
    Console.WriteLine("09 - Excluir");
    Console.WriteLine();
    Console.WriteLine("Menu Usuarios");
    Console.WriteLine("10 - Inserir");
    Console.WriteLine("11 - Atualizar");
    Console.WriteLine("12 - Excluir");
    Console.WriteLine("13 - Listar");
    Console.WriteLine();
    Console.WriteLine("Menu Artistas");
    Console.WriteLine("10 - Inserir");
    Console.WriteLine("11 - Listar");
    Console.WriteLine("12 - Excluir");
    Console.WriteLine("13 - Exclir");
    Console.WriteLine();
    Console.WriteLine("99 - Sair");
    Console.Write("\nOpção: ");
    return int.Parse(Console.ReadLine());
  }
  public static void MusicaInserir() {
    Console.Clear();
    Console.Write("Informe o nome da musica: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a duração: ");
    double duracao = double.Parse(Console.ReadLine());
    

    foreach (Playlist c in View.PlaylistListar())
     Console.Clear();
    Console.Write("\nInforme o id da Playlist: ");
    int idPlaylist = int.Parse(Console.ReadLine());

    View.MusicaInserir(nome, duracao, idPlaylist);
    Console.WriteLine("Musica cadastrada com sucesso");
    Console.WriteLine("\nPrecione uma tecla para voltar ao menu principal...");
    Console.ReadKey();
    Console.Clear();
  }
  public static void MusicaListar() {
    Console.Clear();
    Console.WriteLine("Cadastro de Musicas");
    foreach (Musica p in View.MusicaListar())
    {
      Playlist c = View.PlaylistListar(p.IdPlaylist);
      Console.WriteLine(p + " - " + c.Nome);
    }
    Console.WriteLine("\nPrecione uma tecla para voltar ao menu principal...");
    Console.ReadKey();
    Console.Clear();
  }
  public static void MusicaListarPlaylist() {
     Console.Clear();
    Console.WriteLine("Cadastro de Musica por Playlist");
    foreach (Playlist c in View.PlaylistListar())
      Console.WriteLine(c);
    Console.Write("\nInforme o id da Playlist: ");
    int idPlaylist = int.Parse(Console.ReadLine());
    foreach (Musica p in View.MusicaListar(idPlaylist))
    {
      Playlist c = View.PlaylistListar(p.IdPlaylist);
      Console.WriteLine(p + " - " + c.Nome);
    }
    Console.WriteLine("\nPrecione uma tecla para voltar ao menu principal...");
    Console.ReadKey();
    Console.Clear();
  }
  public static void MusicaAtualizar() {
     Console.Clear();
    MusicaListar();

    Console.Write("Informe o id da musica a ser atualizada: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome da Musica: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a durção: ");
    double duracao = double.Parse(Console.ReadLine());


    foreach (Playlist c in View.PlaylistListar())
     Console.Clear();
    Console.Write("\nInforme o id da Playlist: ");
    int idPlaylist = int.Parse(Console.ReadLine());

    View.MusicaAtualizar(id, nome, duracao, idPlaylist);
    Console.WriteLine("Musica cadastrada com sucesso");
    Console.WriteLine("\nPrecione uma tecla para voltar ao menu principal...");
    Console.ReadKey();
    Console.Clear();
  }
  
public static void MusicaExcluir() {
   Console.Clear();
  Console.WriteLine("Informe o id da musica");
  int id = int.Parse(Console.ReadLine());
  Musica p = new Musica{ Id = id };
  NMusica np = new NMusica();
  np.Excluir(p);
  Console.WriteLine("Musica excluida com sucesso");
  Console.WriteLine("\nPrecione uma tecla para voltar ao menu principal...");
  Console.ReadKey();
  Console.Clear();
}

  public static void PlaylistInserir() {
     Console.Clear();
    Console.Write("Informe o nome da Playlist: ");
    string nome = Console.ReadLine();
    View.PlaylistInserir(nome);
    Console.WriteLine("Playlist cadastrada com sucesso");
    Console.WriteLine("\nPrecione uma tecla para voltar ao menu principal...");
    Console.ReadKey();
    Console.Clear();
  }
  public static void PlaylistListar() {
     Console.Clear();
    Console.WriteLine("Cadastro de Playlists");
    foreach (Playlist c in View.PlaylistListar()){
      Console.WriteLine(c);}
    Console.WriteLine("\nPrecione uma tecla para voltar ao menu principal...");
    Console.ReadKey();
    Console.Clear();
  }

public static void PlaylistAtualizar() {
   Console.Clear();
   Console.WriteLine("Informe o id da Playlist");
   int id = int.Parse(Console.ReadLine());
  Console.WriteLine("Informe o nome da Playlist");
  string nome = Console.ReadLine(); 
  Playlist c = new Playlist{ Id = id, Nome = nome };
  NPlaylist nc = new NPlaylist();
  nc.Atualizar(c);
  Console.WriteLine("Playlist atualizada com sucesso");
  Console.WriteLine("\nPrecione uma tecla para voltar ao menu principal...");
  Console.ReadKey();
  Console.Clear();
}

  
public static void PlaylistExcluir() {
   Console.Clear();
  Console.WriteLine("Informe o id da Playlist");
   int id = int.Parse(Console.ReadLine());
  Playlist c = new Playlist{ Id = id };
  NPlaylist nc = new NPlaylist();
  nc.Excluir(c);
  Console.WriteLine("Playlist excluida com sucesso");
  Console.WriteLine("\nPrecione uma tecla para voltar ao menu principal...");
  Console.ReadKey();
  Console.Clear();
  }
  public static void UsuarioInserir() {
     Console.Clear();
    Console.Write("Informe o nome do Usuario: ");
    string nome = Console.ReadLine();
    View.UsuarioInserir(nome, nome, nome);
    Console.WriteLine("Usuario cadastrada com sucesso");
    Console.WriteLine("\nPrecione uma tecla para voltar ao menu principal...");
    Console.ReadKey();
    Console.Clear();
  }
  public static void UsuarioListar() {
     Console.Clear();
    Console.WriteLine("Cadastro de Usuarios");  
    foreach(Usuario c in View.UsuarioListar()){
      Console.WriteLine(c);
      
    }
    Console.WriteLine("\nPrecione uma tecla para voltar ao menu principal...");
    Console.ReadKey();
    Console.Clear();
    
    }
  public static void UsuarioAtualizar() {
     Console.Clear();
    Console.Write("Informe o id do Usuario a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome do Usuario: ");
    string nome =Console.ReadLine();
    Usuario c = new Usuario{ Id = id, Nome = nome };
    NUsuario nc = new NUsuario();
    nc.Atualizar(c);
    Console.WriteLine(" Usuario atualizado");
    Console.WriteLine("\nPrecione uma tecla para voltar ao menu principal...");
    Console.ReadKey();
    Console.Clear();
    }
  public static void UsuarioExcluir() {
     Console.Clear();
    Console.Write("Informe o id do Usuario a ser excluido");
    int id = int.Parse(Console.ReadLine());
    Usuario c = new Usuario{ Id = id };
    NUsuario nc = new NUsuario();
    nc.Excluir(c);
    Console.WriteLine("Usuario excluido");
    Console.WriteLine("\nPrecione uma tecla para voltar ao menu principal...");
    Console.ReadKey();
    Console.Clear();
    
  }
  
public static void ArtistaInserir() {
     Console.Clear();
    Console.Write("Informe o nome do Artista: ");
    string nome = Console.ReadLine();
    View.ArtistaInserir(nome);
    Console.WriteLine("Artista cadastrado com sucesso");
  Console.WriteLine("\nPrecione uma tecla para voltar ao menu principal...");
  Console.ReadKey();
  Console.Clear();
}
  public static void ArtistaListar() {
     Console.Clear();
    Console.WriteLine("Cadastro de Artistas");
    foreach(Artista c in View.ArtistaListar()){
       Console.WriteLine(c);
    
  }
    Console.WriteLine("\nPrecione uma tecla para voltar ao menu principal...");
    Console.ReadKey();
    Console.Clear();
    }
  public static void ArtistaAtualizar() {
     Console.Clear();
    Console.Write("Informe o id do Artista a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome do Artista: ");
    string nome =Console.ReadLine();
    Artista c = new Artista{ Id = id, Nome = nome };
    NArtista nc = new NArtista();
    nc.Atualizar(c);
    Console.WriteLine(" Artista atualizado");
    Console.WriteLine("\nPrecione uma tecla para voltar ao menu principal...");
    Console.ReadKey();
    Console.Clear();
    
  }
  public static void ArtistaExcluir() {
     Console.Clear();
    Console.Write("Informe o id do Artista a ser excluido");
    int id = int.Parse(Console.ReadLine());
    Artista c = new Artista{ Id = id };
    NArtista nc = new NArtista();
    nc.Excluir(c);
    Console.WriteLine("Artista excluido");
    Console.WriteLine("\nPrecione uma tecla para voltar ao menu principal...");
    Console.ReadKey();
    Console.Clear();
  }
public static bool IsUserInXML(string email, string senha) {
    NUsuario nu = new NUsuario();
    foreach (Usuario u in nu.Listar()) {
      if (u.Email == email && u.Senha == senha) {
        return true;
      }
    }
    return false;
  }
}


    
