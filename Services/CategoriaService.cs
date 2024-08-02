using webapi.Models;

namespace webapi.Services;

public class CategoriaService : ICategoriaService
{
    TareasContext context;

    public CategoriaService(TareasContext dbContext)
    {
        context = dbContext;
    }

    public IEnumerable<Categoria> GetCategorias()
    {
        return context.Categorias;
    }

    public async Task SaveCategorias(Categoria categoria)
    {
        context.Add(categoria);
        await context.SaveChangesAsync();
    }

    public async Task UpdateCategorias(Guid id, Categoria categoria)
    {
        var categoriaActual = context.Categorias.Find(id);

        if(categoriaActual != null)
        {
            categoriaActual.Nombre = categoria.Nombre;
            categoriaActual.Descripcion = categoria.Descripcion;
            categoriaActual.Peso = categoria.Peso;
            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteCategorias(Guid id)
    {
        var categoriaActual = context.Categorias.Find(id);

        if(categoriaActual != null)
        {
            context.Remove(categoriaActual);
            await context.SaveChangesAsync();
        }
    }
}

public interface ICategoriaService
{
    IEnumerable<Categoria> GetCategorias();
    Task SaveCategorias(Categoria categoria);
    Task UpdateCategorias(Guid id, Categoria categoria);
    Task DeleteCategorias(Guid id);
}