using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaGuardadores;
using TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaMemorizadores;
using TiendaOrdenadores.FabricaComponentes.FabricaProcesadores;
using TiendaOrdenadores.FabricaComponentes;
using TiendaOrdenadoresDB.Models;
using TiendaOrdenadores.BuilderOrdenadores;
using System;
using System.Collections.Generic;

namespace TiendaOrdenadoresDB.Data
{
    public class TiendaOrdenadoresDBContext : DbContext
    {
        private readonly IMapper _mapper;
        public TiendaOrdenadoresDBContext (DbContextOptions<TiendaOrdenadoresDBContext> options, IMapper mapper)
            : base(options)
        {
            _mapper = mapper;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            new DbInitializer(modelBuilder, _mapper).Seed();
        }

        public DbSet<Ordenador> Ordenador { get; set; } = default!;
        public DbSet<OrdenadorComponente> OrdenadorComponente { get; set; } = default!;
        public DbSet<Componente> Componente { get; set; } = default!;
        public DbSet<Pedido> Pedido { get; set; } = default!;
        public DbSet<OrdenadorPedido> OrdenadorPedido { get; set; } = default!;
    }

    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;
        private readonly IMapper _mapper;

        public DbInitializer(ModelBuilder modelBuilder, IMapper mapper)
        {
            this.modelBuilder = modelBuilder;
            _mapper = mapper;
        }

        public void Seed()
        {
            //SeedAllComponentes();
            //SeedOrdenadores();
        }

        private void SeedComponentes<T>(List<T> enumValues) where T : Enum
        {
            IFabricaComponente builderComponente = new FabricaComponente();
            int contador = 1;

            enumValues.ForEach(enumComponente =>
            {
                object? componente;
                if (enumComponente is TipoProcesador)
                    componente = builderComponente.dameComponente((TipoProcesador)(object)enumComponente);
                else if (enumComponente is TipoMemorizador)
                    componente = builderComponente.dameComponente((TipoMemorizador)(object)enumComponente);
                else if (enumComponente is TipoGuardador)
                    componente = builderComponente.dameComponente((TipoGuardador)(object)enumComponente);
                else
                    componente = null;

                if (componente != null)
                {
                    Componente componenteMvc = _mapper.Map<Componente>(componente);
                    componenteMvc.Id = contador;
                    modelBuilder.Entity<Componente>().HasData(componenteMvc);
                    contador++;
                }
            });
        }
        private void SeedAllComponentes()
        {

            List<TipoProcesador> procesadores = new((TipoProcesador[])Enum.GetValues(typeof(TipoProcesador)));
            List<TipoMemorizador> memorizadores = new((TipoMemorizador[])Enum.GetValues(typeof(TipoMemorizador)));
            List<TipoGuardador> guardadores = new((TipoGuardador[])Enum.GetValues(typeof(TipoGuardador)));

            SeedComponentes(procesadores);
            SeedComponentes(memorizadores);
            SeedComponentes(guardadores);


        }

        private void SeedOrdenadores()
        {
            int contador = 1;
            IBuilderOrdenador builder = new BuilderOrdenador();
            var ordenadorMaria =
                builder.dameOrdenador(TipoProcesador._789_XCS, TipoGuardador._789_XX, TipoMemorizador._879_FH);
            if (ordenadorMaria != null)
            {
                Ordenador ordenadorMvc = _mapper.Map<Ordenador>(ordenadorMaria);
                ordenadorMvc.Id = contador;
                ordenadorMvc.NumeroDeSerie = "AAAA";
                ordenadorMvc.Descripcion = "Ordenador de Maria";

                modelBuilder.Entity<Ordenador>().HasData(ordenadorMvc);
                contador++;
            }
        }
    }
}
