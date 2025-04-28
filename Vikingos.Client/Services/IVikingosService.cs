using Vikingos.Shared;

namespace Vikingos.Client.Services
{
    public interface IVikingosService
    {
        Task<List<VikingosDTO>> Lista();
        Task<VikingosDTO> Buscar(int id);
        Task<int> Guardar(VikingosDTO vikingo);
        Task<int> Editar(VikingosDTO vikingo);
        Task<bool> Eliminar (int id);

    }
}
