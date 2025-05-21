using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Localizacao
{
    [Key]
    [Column("ID_LOCALIZACAO")]
    public int ID_Localizacao { get; set; }
    
    [Column("ENDERECO")]
    public string Endereco { get; set; } = string.Empty;
    
    [Column("CEP")]
    public string Cep { get; set; } = string.Empty;
    
    [Column("Cidade")]
    public string Cidade { get; set; } = string.Empty;

    [Column("Estado")]
    public string Estado { get; set; } = string.Empty;
    
    public ICollection<Moto> Motos { get; set; } = new List<Moto>();
}