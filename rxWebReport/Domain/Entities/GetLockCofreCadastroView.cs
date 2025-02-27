using System;

namespace rxWebReport.Domain.Entities
{
    public class GetLockCofreCadastroView
    {
        public long id { get; set; }
        public string id_cofre { get; set; }
        public string nome { get; set; }
        public string serie { get; set; }
        public string tipo { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string tamanho_malote { get; set; }
        public string cod_loja { get; set; }

        //loja
        public long loja_id { get; set; }
        public string loja_cod_loja { get; set; }
        public string loja_cod_cliente { get; set; }
        public string loja_nome { get; set; }
        public string loja_razao_social { get; set; }
        public string loja_cnpj { get; set; }
        public string loja_endereco { get; set; }
        public string loja_complemento { get; set; }
        public string loja_bairro { get; set; }
        public string loja_cidade { get; set; }
        public string loja_uf { get; set; }
        public string loja_CEP { get; set; }
        public Nullable<decimal> loja_latitude { get; set; }
        public Nullable<decimal> loja_longitude { get; set; }
        public string loja_pessoa_contato { get; set; }
        public string loja_email { get; set; }
        public string loja_telefone { get; set; }

        //cliente
        public long cliente_id { get; set; }
        public string cliente_cod_cliente { get; set; }
        public string cliente_nome { get; set; }
        public string cliente_cod_rede { get; set; }
        public string cliente_razao_social { get; set; }
        public string cliente_cnpj { get; set; }
        public string cliente_endereco { get; set; }
        public string cliente_complemento { get; set; }
        public string cliente_bairro { get; set; }
        public string cliente_cidade { get; set; }
        public string cliente_uf { get; set; }
        public string cliente_CEP { get; set; }
        public Nullable<decimal> cliente_latitude { get; set; }
        public Nullable<decimal> cliente_longitude { get; set; }
        public string cliente_pessoa_contato { get; set; }
        public string cliente_email { get; set; }
        public string cliente_telefone { get; set; }

        //rede
        public long rede_id { get; set; }
        public string rede_cod_rede { get; set; }
        public string rede_nome { get; set; }

    }
}