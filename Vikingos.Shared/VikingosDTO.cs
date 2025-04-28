using System.ComponentModel.DataAnnotations;

namespace Vikingos.Shared

{
    public class VikingosDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int BatallasGanadas { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string ArmaFavorita { get; set; } = null!;
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int NivelHonor { get; set; }

        public string CausaMuerte { get; set; } = null!;
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int Fuerza { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int HabilidadTactica { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int Sabiduria { get; set; }
    }
}
