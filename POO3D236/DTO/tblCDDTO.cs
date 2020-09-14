using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace POO3D236.DTO
{
    public class tblCDDTO
    {
        private int idCD;
        private string nomeCD;
        private double precoVenda;
        private DateTime dtLancamento;

        public int IdCD { get => idCD; set => idCD = value; }
        public string NomeCD { get => nomeCD;
            set
            {
                if(value != string.Empty)
                {
                    this.nomeCD = value;
                }
                else
                {
                    throw new Exception("O campo nome cd é obrigatório");
                }
            }
        }
        public double PrecoVenda
        {
            get => precoVenda;
            set
            {
                if(double.TryParse(value.ToString(), out value))
                {
                    this.precoVenda = value;
                }
                else
                {
                    throw new Exception("O campo preço venda é obrigatório");
                }
            }
        }
        public DateTime DtLancamento { get => dtLancamento;
            set
            {
                if(DateTime.TryParse(value.ToString(), out value)){
                    this.dtLancamento = value;
                }
                else
                {
                    throw new Exception("O campo data lançamento é obrigatório");
                }
            }
        }
    }
}