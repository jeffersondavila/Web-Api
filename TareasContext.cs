using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi;

public class TareasContext : DbContext
{
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}

    public TareasContext(DbContextOptions<TareasContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Tarea> tareasInit = new List<Tarea>();
        List<Categoria> categoriasInit = new List<Categoria>();

        categoriasInit.Add(new Categoria() {CodigoCategoria = Guid.Parse("ee877ebe-14e2-4ad2-aa4f-bf4b5207657b"),Nombre = "Actividades pendientes",Peso = 1});
        categoriasInit.Add(new Categoria() {CodigoCategoria = Guid.Parse("ee877ebe-14e2-4ad2-aa4f-bf4b52076502"),Nombre = "Actividades activas",Peso = 2});

        tareasInit.Add(new Tarea() {CodigoTarea = Guid.Parse("ee877ebe-14e2-4ad2-aa4f-bf4b52076510"),CodigoCategoria = Guid.Parse("ee877ebe-14e2-4ad2-aa4f-bf4b5207657b"), Titulo = "Pago servicios publico", PrioridadTarea = Prioridad.Media, FechaCreacion = DateTime.Now});
        tareasInit.Add(new Tarea() {CodigoTarea = Guid.Parse("ee877ebe-14e2-4ad2-aa4f-bf4b52076520"),CodigoCategoria = Guid.Parse("ee877ebe-14e2-4ad2-aa4f-bf4b5207657b"), Titulo = "Pago servicios privados", PrioridadTarea = Prioridad.Alta, FechaCreacion = DateTime.Now});
        tareasInit.Add(new Tarea() {CodigoTarea = Guid.Parse("ee877ebe-14e2-4ad2-aa4f-bf4b52076530"),CodigoCategoria = Guid.Parse("ee877ebe-14e2-4ad2-aa4f-bf4b52076502"), Titulo = "Pago U", PrioridadTarea = Prioridad.Alta, FechaCreacion = DateTime.Now});

        modelBuilder.Entity<Categoria>(categoria=>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p=> p.CodigoCategoria);
            categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=> p.Descripcion);
            categoria.Property(p=> p.Peso);

            categoria.HasData(categoriasInit);
        });

        modelBuilder.Entity<Tarea>(tarea=>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p=> p.CodigoTarea);
            tarea.HasOne(p=> p.Categorias).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CodigoCategoria);
            tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p=> p.Descripcion);
            tarea.Property(p=> p.PrioridadTarea);
            tarea.Property(p=> p.FechaCreacion);

            tarea.HasData(tareasInit);
        });
    }
}