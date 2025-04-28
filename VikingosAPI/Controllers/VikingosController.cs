using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vikingos.Shared;
using VikingosAPI.Models;

namespace VikingosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VikingosController : ControllerBase
    {
        private readonly ValhallaDbContext _dbcontext;

        public VikingosController(ValhallaDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<VikingosDTO>>();
            var listVikingos = new List<VikingosDTO>();
            try
            {
                foreach (var item in await _dbcontext.Vikingos.ToListAsync())
                {
                    listVikingos.Add(new VikingosDTO
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        BatallasGanadas = item.BatallasGanadas,
                        ArmaFavorita = item.ArmaFavorita,
                        NivelHonor  = item.NivelHonor,
                        CausaMuerte = item.CausaMuerte,
                        Fuerza  = item.Fuerza,
                        HabilidadTactica = item.HabilidadTactica,
                        Sabiduria   = item.Sabiduria,

                    });
                
                }
                responseApi.EsCorrecto = true;
                responseApi.Valor = listVikingos;


            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensajes = ex.Message;
            }

            return Ok(responseApi);
        }

        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> Buscar(int id)
        {
            var responseApi = new ResponseAPI<VikingosDTO>();
            var VikingosDTO = new VikingosDTO();
            try
            {
                var dbVikingos = await _dbcontext.Vikingos.FirstOrDefaultAsync(x => x.Id == id);

                if(dbVikingos != null)
                {
                    VikingosDTO.Id = dbVikingos.Id;
                    VikingosDTO.Nombre = dbVikingos.Nombre;
                    VikingosDTO.BatallasGanadas = dbVikingos.BatallasGanadas;
                    VikingosDTO.ArmaFavorita = dbVikingos.ArmaFavorita;
                    VikingosDTO.NivelHonor = dbVikingos.NivelHonor;
                    VikingosDTO.CausaMuerte = dbVikingos.CausaMuerte;
                    VikingosDTO.Fuerza = dbVikingos.Fuerza;
                    VikingosDTO.HabilidadTactica = dbVikingos.HabilidadTactica;
                    VikingosDTO.Sabiduria = dbVikingos.Sabiduria;



                    responseApi.EsCorrecto = true;
                    responseApi.Valor = VikingosDTO;
                }
                else
                {

                    responseApi.EsCorrecto = false;
                    responseApi.Mensajes = "No existe el vikingo";
                }



            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensajes = ex.Message;
            }

            return Ok(responseApi);
        }


        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar(VikingosDTO vikingos)
        {
            var responseApi = new ResponseAPI<int>();
            try
            {
                var dbVikingos = new Vikingo
                {
                    Nombre = vikingos.Nombre,
                    BatallasGanadas = vikingos.BatallasGanadas,
                    ArmaFavorita = vikingos.ArmaFavorita,
                    NivelHonor = vikingos.NivelHonor,
                    CausaMuerte = vikingos.CausaMuerte,
                    Fuerza = vikingos.Fuerza,
                    HabilidadTactica = vikingos.HabilidadTactica,
                    Sabiduria = vikingos.Sabiduria
                };
                
                _dbcontext.Vikingos.Add(dbVikingos);
                await _dbcontext.SaveChangesAsync();

                if(dbVikingos.Id != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbVikingos.Id;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensajes = "No Guardado, Verifica La Informacion";
                }


            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensajes = ex.Message;
            }

            return Ok(responseApi);
        }

        [HttpPut]
        [Route("Editar/{id}")]
        public async Task<IActionResult> Editar(VikingosDTO vikingos, int id)
        {
            var responseApi = new ResponseAPI<int>();
            try
            {
                var dbVikingos = await _dbcontext.Vikingos.FirstOrDefaultAsync(x => x.Id == id);
                if (dbVikingos != null)
                {
                    dbVikingos.Nombre = vikingos.Nombre;
                    dbVikingos.BatallasGanadas = vikingos.BatallasGanadas;
                    dbVikingos.ArmaFavorita = vikingos.ArmaFavorita;
                    dbVikingos.NivelHonor = vikingos.NivelHonor;
                    dbVikingos.CausaMuerte = vikingos.CausaMuerte;
                    dbVikingos.Fuerza = vikingos.Fuerza;
                    dbVikingos.HabilidadTactica = vikingos.HabilidadTactica;
                    dbVikingos.Sabiduria = vikingos.Sabiduria;

                    _dbcontext.Vikingos.Update(dbVikingos);
                    await _dbcontext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbVikingos.Id;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensajes = "Vikingo No Encontrado";
                }


            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensajes = ex.Message;
            }

            return Ok(responseApi);
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var responseApi = new ResponseAPI<int>();
            try
            {
                var dbVikingos = await _dbcontext.Vikingos.FirstOrDefaultAsync(x => x.Id == id);
                if (dbVikingos != null)
                {

                    _dbcontext.Vikingos.Remove(dbVikingos);
                    await _dbcontext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensajes = "Vikingo No Encontrado";
                }


            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensajes = ex.Message;
            }

            return Ok(responseApi);
        }


    }
}
