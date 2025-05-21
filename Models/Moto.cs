using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Moto
{
    [Key]
    [Column("ID_MOTO")]
    public int ID_Moto { get; set; }
    
    [Column("PLACA")]
    public string Placa { get; set; } = string.Empty;
    
    [Column("MODELO")]
    public string Modelo { get; set; } = string.Empty;
    
    [Column("ANO")]
    public int Ano { get; set; }
    
    [Column("STATUS")]
    public string Status { get; set; } = string.Empty;
    
    [Column("ID_LOCALIZACAO")]
    [ForeignKey("Localizacao")]
    public int ID_Localizacao { get; set; }
    
    public virtual Localizacao? Localizacao { get; set; }
    public virtual ICollection<Manutencao> Manutencoes { get; set; } = new List<Manutencao>();
    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}