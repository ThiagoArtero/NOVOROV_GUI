using Microsoft.EntityFrameworkCore;
using NOVOROV.Models;
using NOVOROV.Models.DropDownLists;

namespace NOVOROV.Context
{
    public class RovDbContext : DbContext
    {
        public RovDbContext(DbContextOptions<RovDbContext> options) : base(options) { }
        public DbSet<Anexo> Anexo { get; set; }
        public DbSet<AcionadoProntoAtendimento> AcionadoProntoAtendimento { get; set; }
        public DbSet<AlarmeRealAcidente> AlarmeRealAcidente { get; set; }
        public DbSet<AnaliseConclusao> AnaliseConclusao { get; set; }
        public DbSet<AreaInterna> AreaInterna { get; set; }
        public DbSet<AreaSaude> AreaSaude { get; set; }
        public DbSet<AreaTratamento> AreaTratamento { get; set; }
        public DbSet<AtendimentoSLA> AtendimentoSLA { get; set; }
        public DbSet<BombeiroCivil> BombeiroCivil { get; set; }
        public DbSet<BombeiroMilitar> BombeiroMilitar { get; set; }
        public DbSet<Cmc> Cmc { get; set; }
        public DbSet<Detentora> Detentora { get; set; }
        public DbSet<Dano> Dano { get; set; }
        public DbSet<EmpresaChamadoSis> EmpresaChamadoSis { get; set; }
        public DbSet<EmpresaProntoAtendimento> EmpresaProntoAtendimento { get; set; }
        public DbSet<EquipamentoSis> EquipamentoSis { get; set; }
        public DbSet<EventoERB> EventoERB { get; set; }
        public DbSet<FornecimentoAcessoFisico> FornecimentoAcessoFisico { get; set; }
        public DbSet<FornecimentoEventoAlarme> FornecimentoEventoAlarme { get; set; }
        public DbSet<FornecimentoImagem> FornecimentoImagem { get; set; }
        public DbSet<Inbox> Inbox { get; set; }
        public DbSet<InformacaoComplementar> InformacaoComplementar { get; set; }
        public DbSet<Local> Local { get; set; }
        public DbSet<Manutencao> Manutencao { get; set; }
        public DbSet<OrgaoPublico> OrgaoPublico { get; set; }
        public DbSet<Placa> Placa { get; set; }
        public DbSet<PlanoDeEmergencia> PlanoDeEmergencia { get; set; }
        public DbSet<Qualificacao> Qualificacao { get; set; }
        public DbSet<RegistroPolicial> RegistroPolicial { get; set; }
        public DbSet<Seguimento> Seguimento { get; set; }
        public DbSet<SistemaFechaduraBluetooth> SistemaFechaduraBluetooth { get; set; }
        public DbSet<SistemaRastreamento> SistemaRastreamento { get; set; }
        public DbSet<SistemaSis> SistemaSis { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<TipoAcesso> TipoAcesso { get; set; }
        public DbSet<TipoOcorrencia> TipoOcorrencia { get; set; }
        public DbSet<TipoSite> TipoSite { get; set; }
        public DbSet<TipoAnexo> TipoAnexo { get; set; }
        public DbSet<Transportadora> Transportadora { get; set; }
        public DbSet<Ocorrencia> Ocorrencia { get; set; }
        public DbSet<Motivo> Motivo { get; set; }
        public DbSet<ApoliceSeguro> ApoliceSeguro { get; set; }
        public DbSet<AlteracaoOcorrencia> AlteracaoOcorrencia { get; set; }
        public DbSet<AtualizacaoOcorrencia> AtualizacaoOcorrencia { get; set; }
        public DbSet<AreaInternaPassivo> AreaInternaPassivo { get; set; }
        public DbSet<EquipamentoPerda> EquipamentoPerda { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Observacao> Observacao { get; set; }
        public DbSet<EmpresaPassivo> EmpresaPassivo { get; set; }
        public DbSet<TipoRessarcimento> TipoRessarcimento { get; set; }
        public DbSet<Recuperacao> Recuperacao { get; set; }
        public DbSet<AuditoriaInfrator> AuditoriaInfrator { get; set; }
        public DbSet<AuditoriaRecuperacao> AuditoriaRecuperacao { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<GestaoQualidade> GestaoQualidade { get; set; }
        public DbSet<GestaoPerda> GestaoPerda { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Perda> Perda { get; set; }
        public DbSet<TipoEquipamento> TipoEquipamento { get; set; }
        public DbSet<Passivo> Passivo { get; set; }
        public DbSet<Biblioteca> Biblioteca { get; set; }
        public DbSet<TipoBiblioteca> TipoBiblioteca { get; set; }
        public DbSet<Site> Site { get; set; }
        public DbSet<AcaoTomada> AcaoTomada { get; set; }
        public DbSet<TipoEnvolvimento> TipoEnvolvimento { get; set; }
        public DbSet<Envolvido> Envolvido { get; set; }
        public DbSet<TipoOcorrenciaTipoSite> TipoOcorrenciaTipoSite { get; set; }
        public DbSet<TipoApoliceSeguro> TipoApoliceSeguro { get; set; }
        public DbSet<Funcionalidade> Funcionalidade { get; set; }
        public DbSet<PerfilFuncionalidade> PerfilFuncionalidade { get; set; }
        public DbSet<UsuarioFuncionalidade> UsuarioFuncionalidade { get; set; }
        public DbSet<StatusSite> StatusSite { get; set; }
        public DbSet<Gestor> Gestor { get; set; }
        public DbSet<Aviso> Aviso { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<LogValor> LogValor { get; set; }
        public DbSet<ModeloRelatorio> ModeloRelatorio { get; set; }
        public DbSet<TipoRelatorio> TipoRelatorio { get; set; }
        public DbSet<Chamado> Chamado { get; set; }
        public DbSet<Atendimento> Atendimento { get; set; }
        public DbSet<StatusAtendimentoChamado> StatusAtendimentoChamado { get; set; }
        public DbSet<StatusChamado> StatusChamado { get; set; }
        public DbSet<AnexosChamado> AnexosChamado { get; set; }
        public DbSet<Espelho> Espelho { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Ocorrencia>()
            //.HasMany<Site>(a => a.Site)
            //.WithOne(b => b.Ocorrencia)
            //.HasForeignKey(b => b.OcorrenciaId)
            //.OnDelete(DeleteBehavior.Restrict)
            //.IsRequired();


            //modelBuilder.Entity<Ocorrencia>()
            //.HasOne<Site>(a => a.Site)
            //.WithMany(b => b.Ocorrencia)
            //.HasForeignKey(b => b.SiteId)
            //.OnDelete(DeleteBehavior.Restrict)
            //.IsRequired();

            //Ocorrência
            modelBuilder.Entity<Cmc>()
            .HasMany<Ocorrencia>(a => a.Ocorrencia)
            .WithOne(b => b.Cmc)
            .HasForeignKey(b => b.CmcId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

            modelBuilder.Entity<Ocorrencia>()
            .HasMany<Anexo>(a => a.Anexo)
            .WithOne(b => b.Ocorrencia)
            .HasForeignKey(b => b.OcorrenciaId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Ocorrencia>()
            .HasMany<Dano>(a => a.Dano)
            .WithOne(b => b.Ocorrencia)
            .HasForeignKey(b => b.OcorrenciaId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Ocorrencia>()
            .HasMany<AuditoriaInfrator>(a => a.AuditoriaInfrator)
            .WithOne(b => b.Ocorrencia)
            .HasForeignKey(b => b.OcorrenciaId)
            .OnDelete(DeleteBehavior.NoAction);

            //Qualificacao
            modelBuilder.Entity<Qualificacao>()
            .HasMany<AuditoriaRecuperacao>(a => a.AuditoriaRecuperacao)
            .WithOne(b => b.Qualificacao)
            .HasForeignKey(b => b.QualificacaoId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Qualificacao>()
            .HasMany<Recuperacao>(a => a.Recuperacao)
            .WithOne(b => b.Qualificacao)
            .HasForeignKey(b => b.QualificacaoId)
            .OnDelete(DeleteBehavior.NoAction);

            //Usuários
            modelBuilder.Entity<Usuario>()
            .HasOne<Cmc>(a => a.Cmc)
            .WithMany(b => b.Usuario)
            .HasForeignKey(b => b.CmcId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

            modelBuilder.Entity<Ocorrencia>()
           .HasOne<Usuario>(a => a.ResponsavelAveriguacao)
           .WithMany(b => b.Ocorrencia)
           .HasForeignKey(b => b.ResponsavelAveriguacaoId)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Usuario>()
            .HasOne<Gestor>(a => a.Gestor)
            .WithMany(b => b.Usuario)
            .HasForeignKey(b => b.GestorId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

            modelBuilder.Entity<Ocorrencia>()
            .Ignore(t => t.UsuarioOperador);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                          .HasMany<UsuarioFuncionalidade>(a => a.UsuarioFuncionalidade)
                          .WithOne(b => b.Usuario)
                          .HasForeignKey(b => b.UsuarioId)
                          .OnDelete(DeleteBehavior.Cascade);

            //Tarefa
            //modelBuilder.Entity<Tarefa>()
            //    .HasOne<Ocorrencia>(a => a.Ocorrencia)
            //    .WithMany(b => b.Tarefas)
            //    .HasForeignKey(b => b.OcorrenciaId)
            //    .OnDelete(DeleteBehavior.NoAction)
            //    .IsRequired();

            //modelBuilder.Entity<Tarefa>()
            //    .Property(o => o.DataCriacao)
            //    .HasDefaultValueSql("GETDATE()");

            //modelBuilder.Entity<Tarefa>()
            //    .Property(o => o.DataInicio)
            //    .HasDefaultValueSql("GETDATE()");

            //modelBuilder.Entity<Tarefa>()
            //   .HasOne<Usuario>(a => a.Demandante)
            //   .WithMany(b => b.TarefasDemandante)
            //   .HasForeignKey(e => e.DemandanteId)
            //   .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Tarefa>()
            //  .HasOne<Usuario>(a => a.Analista)
            //  .WithMany(b => b.TarefasRecebidas)
            //  .HasForeignKey(e => e.AnalistaId)
            //  .OnDelete(DeleteBehavior.NoAction);
        }

    }
}