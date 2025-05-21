using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Usuario
{
    [Key]
    [Column("ID_USUARIO")]
    public int ID_Usuario { get; set; }
    
    [Column("NOME")]
    public string Nome { get; set; } = string.Empty;
    
    [Column("EMAIL")]
    public string Email { get; set; } = string.Empty;
    
    [Column("SENHA")]
    public string Senha { get; set; } = string.Empty;
    
    public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}