using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace rxWebReport.Domain.Entities
{
    public class GetLockMessageViewConfig : EntityTypeConfiguration<GetLockMessageView>
    {
        public GetLockMessageViewConfig()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id_cofre)
                .HasMaxLength(50);

            this.Property(t => t.cofre_nome)
                .HasMaxLength(50);

            this.Property(t => t.cofre_serie)
                .HasMaxLength(50);

            this.Property(t => t.cofre_tipo)
                .HasMaxLength(50);

            this.Property(t => t.cofre_marca)
                .HasMaxLength(50);

            this.Property(t => t.cofre_modelo)
                .HasMaxLength(50);

            this.Property(t => t.cofre_tamanho_malote)
                .HasMaxLength(50);

            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.info_id)
                .HasMaxLength(50);

            this.Property(t => t.info_ip)
                .HasMaxLength(50);

            this.Property(t => t.info_mac)
                .HasMaxLength(50);

            this.Property(t => t.info_json)
                .HasMaxLength(50);

            this.Property(t => t.data_hash)
                .HasMaxLength(50);

            this.Property(t => t.data_tmst_begin)
                .HasMaxLength(50);

            this.Property(t => t.data_tmst_end)
                .HasMaxLength(50);

            this.Property(t => t.data_user)
                .HasMaxLength(50);

            this.Property(t => t.user_nome)
                .HasMaxLength(50);

            this.Property(t => t.data_type)
                .HasMaxLength(50);

            this.Property(t => t.movimento_nome)
                .HasMaxLength(50);

            this.Property(t => t.movimento_tipo)
                .HasMaxLength(50);

            this.Property(t => t.cod_loja)
                .HasMaxLength(50);

            this.Property(t => t.nome_loja)
                .HasMaxLength(50);

            this.Property(t => t.razao_social_loja)
                .HasMaxLength(50);

            this.Property(t => t.cnpj_loja)
                .HasMaxLength(50);

            this.Property(t => t.endereco_loja)
                .HasMaxLength(60);

            this.Property(t => t.complemento_loja)
                .HasMaxLength(60);

            this.Property(t => t.bairro_loja)
                .HasMaxLength(50);

            this.Property(t => t.cidade_loja)
                .HasMaxLength(50);

            this.Property(t => t.uf_loja)
                .HasMaxLength(20);

            this.Property(t => t.cep_loja)
                .HasMaxLength(10);

            this.Property(t => t.pessoa_contato_loja)
                .HasMaxLength(50);

            this.Property(t => t.email_loja)
                .HasMaxLength(100);

            this.Property(t => t.telefone_loja)
                .HasMaxLength(20);

            this.Property(t => t.cod_cliente)
                .HasMaxLength(50);

            this.Property(t => t.nome_cliente)
                .HasMaxLength(50);

            this.Property(t => t.razao_social_cliente)
                .HasMaxLength(50);

            this.Property(t => t.cnpj_cliente)
                .HasMaxLength(50);

            this.Property(t => t.endereco_cliente)
                .HasMaxLength(60);

            this.Property(t => t.complemento_cliente)
                .HasMaxLength(60);

            this.Property(t => t.bairro_cliente)
                .HasMaxLength(50);

            this.Property(t => t.cidade_cliente)
                .HasMaxLength(50);

            this.Property(t => t.uf_cliente)
                .HasMaxLength(20);

            this.Property(t => t.cep_cliente)
                .HasMaxLength(10);

            this.Property(t => t.pessoa_contato_cliente)
                .HasMaxLength(50);

            this.Property(t => t.email_cliente)
                .HasMaxLength(100);

            this.Property(t => t.telefone_cliente)
                .HasMaxLength(20);

            this.Property(t => t.cod_rede)
                .HasMaxLength(50);

            this.Property(t => t.nome_rede)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("message_view");
            this.Property(t => t.id_cofre).HasColumnName("id_cofre");
            this.Property(t => t.cofre_nome).HasColumnName("cofre_nome");
            this.Property(t => t.cofre_serie).HasColumnName("cofre_serie");
            this.Property(t => t.cofre_tipo).HasColumnName("cofre_tipo");
            this.Property(t => t.cofre_marca).HasColumnName("cofre_marca");
            this.Property(t => t.cofre_modelo).HasColumnName("cofre_modelo");
            this.Property(t => t.cofre_tamanho_malote).HasColumnName("cofre_tamanho_malote");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.info_id).HasColumnName("info_id");
            this.Property(t => t.info_ip).HasColumnName("info_ip");
            this.Property(t => t.info_mac).HasColumnName("info_mac");
            this.Property(t => t.info_json).HasColumnName("info_json");
            this.Property(t => t.data_hash).HasColumnName("data_hash");
            this.Property(t => t.data_tmst_begin).HasColumnName("data_tmst_begin");
            this.Property(t => t.data_tmst_end).HasColumnName("data_tmst_end");
            this.Property(t => t.data_user).HasColumnName("data_user");
            this.Property(t => t.user_nome).HasColumnName("user_nome");
            this.Property(t => t.data_type).HasColumnName("data_type");
            this.Property(t => t.movimento_nome).HasColumnName("movimento_nome");
            this.Property(t => t.movimento_tipo).HasColumnName("movimento_tipo");
            this.Property(t => t.data_currency_total).HasColumnName("data_currency_total");
            this.Property(t => t.data_currency_bill_2).HasColumnName("data_currency_bill_2");
            this.Property(t => t.data_currency_bill_5).HasColumnName("data_currency_bill_5");
            this.Property(t => t.data_currency_bill_10).HasColumnName("data_currency_bill_10");
            this.Property(t => t.data_currency_bill_20).HasColumnName("data_currency_bill_20");
            this.Property(t => t.data_currency_bill_50).HasColumnName("data_currency_bill_50");
            this.Property(t => t.data_currency_bill_100).HasColumnName("data_currency_bill_100");
            this.Property(t => t.data_currency_bill_200).HasColumnName("data_currency_bill_200");
            this.Property(t => t.data_currency_bill_rejected).HasColumnName("data_currency_bill_rejected");
            this.Property(t => t.data_currency_envelope).HasColumnName("data_currency_envelope");
            this.Property(t => t.data_currency_envelope_total).HasColumnName("data_currency_envelope_total");
            this.Property(t => t.cod_loja).HasColumnName("cod_loja");
            this.Property(t => t.nome_loja).HasColumnName("nome_loja");
            this.Property(t => t.razao_social_loja).HasColumnName("razao_social_loja");
            this.Property(t => t.cnpj_loja).HasColumnName("cnpj_loja");
            this.Property(t => t.endereco_loja).HasColumnName("endereco_loja");
            this.Property(t => t.complemento_loja).HasColumnName("complemento_loja");
            this.Property(t => t.bairro_loja).HasColumnName("bairro_loja");
            this.Property(t => t.cidade_loja).HasColumnName("cidade_loja");
            this.Property(t => t.uf_loja).HasColumnName("uf_loja");
            this.Property(t => t.cep_loja).HasColumnName("cep_loja");
            this.Property(t => t.latitude_loja).HasColumnName("latitude_loja");
            this.Property(t => t.longitude_loja).HasColumnName("longitude_loja");
            this.Property(t => t.pessoa_contato_loja).HasColumnName("pessoa_contato_loja");
            this.Property(t => t.email_loja).HasColumnName("email_loja");
            this.Property(t => t.telefone_loja).HasColumnName("telefone_loja");
            this.Property(t => t.cod_cliente).HasColumnName("cod_cliente");
            this.Property(t => t.nome_cliente).HasColumnName("nome_cliente");
            this.Property(t => t.razao_social_cliente).HasColumnName("razao_social_cliente");
            this.Property(t => t.cnpj_cliente).HasColumnName("cnpj_cliente");
            this.Property(t => t.endereco_cliente).HasColumnName("endereco_cliente");
            this.Property(t => t.complemento_cliente).HasColumnName("complemento_cliente");
            this.Property(t => t.bairro_cliente).HasColumnName("bairro_cliente");
            this.Property(t => t.cidade_cliente).HasColumnName("cidade_cliente");
            this.Property(t => t.uf_cliente).HasColumnName("uf_cliente");
            this.Property(t => t.cep_cliente).HasColumnName("cep_cliente");
            this.Property(t => t.latitude_cliente).HasColumnName("latitude_cliente");
            this.Property(t => t.longitude_cliente).HasColumnName("longitude_cliente");
            this.Property(t => t.pessoa_contato_cliente).HasColumnName("pessoa_contato_cliente");
            this.Property(t => t.email_cliente).HasColumnName("email_cliente");
            this.Property(t => t.telefone_cliente).HasColumnName("telefone_cliente");
            this.Property(t => t.cod_rede).HasColumnName("cod_rede");
            this.Property(t => t.nome_rede).HasColumnName("nome_rede");
            this.Property(t => t.trackLastWriteTime).HasColumnName("trackLastWriteTime");
            this.Property(t => t.trackCreationTime).HasColumnName("trackCreationTime");
            this.Property(t => t.data_tmst_begin_datetime).HasColumnName("data_tmst_begin_datetime");
            this.Property(t => t.data_tmst_end_datetime).HasColumnName("data_tmst_end_datetime");
            this.Property(t => t.data_currency_bill).HasColumnName("data_currency_bill");
            this.Property(t => t.data_currency_bill_total).HasColumnName("data_currency_bill_total");
            this.Property(t => t.data_sensor).HasColumnName("data_sensor");
        }
    }
}
