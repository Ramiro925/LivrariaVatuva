using System.ComponentModel;

namespace Livraria.Enums
{
    public enum LivroClassif
    {
        [Description ("Ruim")]
        Ruim = 1,
        [Description("Normal")]
        Normal = 2,
        [Description("Gostei")]
        Gostei = 3,
        [Description("Bom")]
        Bom = 4,
        [Description("Maravilhoso")]
        Maravilhoso = 5,
    }
}
