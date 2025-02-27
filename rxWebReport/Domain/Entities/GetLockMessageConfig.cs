using System.Data.Entity.ModelConfiguration;

namespace rxWebReport.Domain.Entities
{
    public class GetLockMessageConfig : EntityTypeConfiguration<GetLockMessage>
    {
        public GetLockMessageConfig()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
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

            this.Property(t => t.data_type)
                .HasMaxLength(50);

            this.Property(t => t.id_cofre)
                .HasMaxLength(50);

            this.Property(t => t.cod_loja)
                .HasMaxLength(50);

            this.Property(t => t.cod_cliente)
                .HasMaxLength(50);

            this.Property(t => t.cod_rede)
                .HasMaxLength(50);

            this.Property(t => t.user_id)
                .HasMaxLength(50);

            this.Property(t => t.user_name)
                .HasMaxLength(50);

            this.Property(t => t.user_lastname)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("message");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.info_id).HasColumnName("info_id");
            this.Property(t => t.info_ip).HasColumnName("info_ip");
            this.Property(t => t.info_mac).HasColumnName("info_mac");
            this.Property(t => t.info_json).HasColumnName("info_json");
            this.Property(t => t.data_hash).HasColumnName("data_hash");
            this.Property(t => t.data_tmst_begin).HasColumnName("data_tmst_begin");
            this.Property(t => t.data_tmst_end).HasColumnName("data_tmst_end");
            this.Property(t => t.data_user).HasColumnName("data_user");
            this.Property(t => t.data_type).HasColumnName("data_type");
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
            this.Property(t => t.id_cofre).HasColumnName("id_cofre");
            this.Property(t => t.trackLastWriteTime).HasColumnName("trackLastWriteTime");
            this.Property(t => t.trackCreationTime).HasColumnName("trackCreationTime");
            this.Property(t => t.data_tmst_begin_datetime).HasColumnName("data_tmst_begin_datetime");
            this.Property(t => t.data_tmst_end_datetime).HasColumnName("data_tmst_end_datetime");
            this.Property(t => t.cod_loja).HasColumnName("cod_loja");
            this.Property(t => t.cod_cliente).HasColumnName("cod_cliente");
            this.Property(t => t.cod_rede).HasColumnName("cod_rede");
            this.Property(t => t.data_currency_bill).HasColumnName("data_currency_bill");
            this.Property(t => t.data_currency_bill_total).HasColumnName("data_currency_bill_total");
            this.Property(t => t.data_sensor).HasColumnName("data_sensor");
            this.Property(t => t.user_id).HasColumnName("user_id");
            this.Property(t => t.user_name).HasColumnName("user_name");
            this.Property(t => t.user_lastname).HasColumnName("user_lastname");
        }
    }
}
