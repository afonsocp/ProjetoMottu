using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Reserva
{
    [Key]
    [Column("ID_RESERVA")]
    public int ID_Reserva { get; set; }
    
    [Column("DATA_RESERVA")]
    public DateTime Data_Reserva { get; set; }
    
    [Column("DATA_DEVOLUCAO")]
    public DateTime Data_Devolucao { get; set; }
    
    [Column("ID_USUARIO")]
    [ForeignKey("Usuario")]
    public int ID_Usuario { get; set; }
    
    [Column("ID_MOTO")]
    [ForeignKey("Moto")]
    public int ID_Moto { get; set; }
    
    public virtual Usuario? Usuario { get; set; }
    public virtual Moto? Moto { get; set; }
}