using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;

namespace RecrutaZero.Infra._Base.Configuracoes
{
    public abstract class ConfiguradorDeSessionFactory<TSessionContext> where TSessionContext : ICurrentSessionContext
    {
        protected Assembly CurrentAssembly;

        public virtual ISessionFactory CriarSessionFactory(ServidorDePublicacao servidorDePublicacao, bool exibirSql = false, bool criarBd = false)
        {
            var nomeStringDeConexao = "SqlServer" + (servidorDePublicacao == ServidorDePublicacao.Producao ? string.Empty : "-" + servidorDePublicacao);

            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey(nomeStringDeConexao)))
                .CurrentSessionContext<TSessionContext>()
                .Mappings(x => x.FluentMappings.AddFromAssembly(CurrentAssembly)
                                   .Conventions.Add(AutoImport.Never())
                                   .Conventions.Add<PrimaryKeyConvention>()
                                   .Conventions.Add<ConvencaoEnum>()
                                   .Conventions.Add<CustomForeignKeyConvention>())
                .ExposeConfiguration(config =>
                                         {
                                             config.SetProperty("command_timeout", "45");
                                             new SchemaExport(config).Drop(exibirSql, criarBd);
                                             new SchemaExport(config).Create(exibirSql, criarBd);
                                         })
                .BuildSessionFactory();
        }
    }
}