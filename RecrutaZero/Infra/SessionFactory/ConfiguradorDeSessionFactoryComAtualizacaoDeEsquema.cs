using System;
using System.IO;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;
using RecrutaZero.Infra._Base.Configuracoes;
using Environment = System.Environment;

namespace RecrutaZero.Infra.SessionFactory
{
    public class ConfiguradorDeSessionFactoryComAtualizacaoDeEsquema : ConfiguradorDeSessionFactory<WebSessionContext>
    {
        public ConfiguradorDeSessionFactoryComAtualizacaoDeEsquema()
        {
            CurrentAssembly = Assembly.GetExecutingAssembly();
        }

        public override ISessionFactory CriarSessionFactory(ServidorDePublicacao servidorDePublicacao, bool exibirSql = false, bool criarBd = false)
        {
            var nomeStringDeConexao = "SqlServer" + (servidorDePublicacao == ServidorDePublicacao.Producao ? string.Empty : "-" + servidorDePublicacao);

            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey(nomeStringDeConexao)))
                .Mappings(x => x.FluentMappings.AddFromAssembly(CurrentAssembly)
                                   .Conventions.Add<PrimaryKeyConvention>()
                                   .Conventions.Add<ConvencaoEnum>()
                                   .Conventions.Add<CustomForeignKeyConvention>())
                .ExposeConfiguration(AtualizarEsquema)
                .BuildSessionFactory();
        }

        private void AtualizarEsquema(Configuration cfg)
        {
            ExcluirArquivo();
            (new SchemaUpdate(cfg)).Execute(_atualizarScript, true);
        }

        private static void ExcluirArquivo()
        {
            if (File.Exists(Caminho)) File.Delete(Caminho);
        }

        private static readonly string Caminho = Path.Combine(Environment.CurrentDirectory, "update_script.sql");

        // executada para cada alteração no esquema
        private readonly Action<string> _atualizarScript = sql =>
                                                            {
                                                                using (var arquivo = new FileStream(Caminho, FileMode.Append, FileAccess.Write))
                                                                using (var sw = new StreamWriter(arquivo))
                                                                {
                                                                    sw.Write(sql);
                                                                    sw.Close();
                                                                }
                                                            };
    }
}