using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Manutencao
{
    [Key]
    [Column("ID_MANUTENCAO")]
    public int ID_Manutencao { get; set; }
    
    [Column("DATA")]
    public DateTime Data { get; set; }
    
    [Column("DESCRICAO")]
    public string Descricao { get; set; } = string.Empty;
    
    [Column("CUSTO", TypeName = "decimal(10,2)")]
    public decimal Custo { get; set; }
    
    [Column("ID_MOTO")]
    [ForeignKey("Moto")]
    public int ID_Moto { get; set; }
    
    public virtual Moto? Moto { get; set; }
}