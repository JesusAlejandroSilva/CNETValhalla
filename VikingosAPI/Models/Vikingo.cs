using System;
using System.Collections.Generic;

namespace VikingosAPI.Models;

public partial class Vikingo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int BatallasGanadas { get; set; }

    public string ArmaFavorita { get; set; } = null!;

    public int NivelHonor { get; set; }

    public string CausaMuerte { get; set; } = null!;

    public int Fuerza { get; set; }

    public int HabilidadTactica { get; set; }

    public int Sabiduria { get; set; }
}
