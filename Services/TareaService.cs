using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Services;

public class TareaService : ITareaService
{
    TareasContext context;

    public TareaService(TareasContext dbContext)
    {
        context = dbContext;
    }

    public IEnumerable<Tarea> GetTareas()
    {
        return context.Tareas.Include(p=> p.Categorias);
    }

    public async Task SaveTareas(Tarea tarea)
    {
        tarea.CodigoTarea = Guid.NewGuid();
        tarea.FechaCreacion = DateTime.Now;

        await context.AddAsync(tarea);
        await context.SaveChangesAsync();
    }

    public async Task UpdateTareas(Guid id, Tarea tarea)
    {
        var tareaActual = context.Tareas.Find(id);

        if(tareaActual != null)
        {
            tareaActual.CodigoCategoria = tarea.CodigoCategoria;
            tareaActual.Titulo = tarea.Titulo;
            tareaActual.Descripcion = tarea.Descripcion;
            tareaActual.PrioridadTarea = tarea.PrioridadTarea;
            tareaActual.FechaCreacion = tarea.FechaCreacion;
            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteTareas(Guid id)
    {
        var tareaActual = context.Tareas.Find(id);

        if(tareaActual != null)
        {
            context.Remove(tareaActual);
            await context.SaveChangesAsync();
        }
    }
}

public interface ITareaService
{
    IEnumerable<Tarea> GetTareas();
    Task SaveTareas(Tarea tarea);
    Task UpdateTareas(Guid id, Tarea tarea);
    Task DeleteTareas(Guid id);
}