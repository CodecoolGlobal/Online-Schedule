using System.ComponentModel.DataAnnotations.Schema;

namespace CodecoolAdvanced.Model;

public class Demo
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long ID { get; set; }
    public DateTime DemoStart { get; set; } = DateTime.Now;
}