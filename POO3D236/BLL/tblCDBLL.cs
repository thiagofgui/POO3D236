using POO3D236.DAL;
using POO3D236.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace POO3D236.BLL
{
    public class tblCDBLL
    {
        DALMysql daoBanco = new DALMysql();

        public DataTable ListarCD()
        {
            string sql = string.Format($@"select * from tbl_cd");
            return daoBanco.executarConsulta(sql);
        }

        public DataTable ListarCD(string condicao)
        {
            string sql = string.Format($@"SELECT * FROM tbl_cd where" + condicao);
            return daoBanco.executarConsulta(sql);
        }

        public void InserirCD(tblCDDTO dtoCD)
        {
            string sql = string.Format($@"INSERT INTO tbl_cd VALUES(NULL, '{dtoCD.NomeCD}',
                                                                          '{dtoCD.PrecoVenda}',
                                                                          '{dtoCD.DtLancamento.ToString("yyyy/MM/dd HH:mm:ss")}');");
            daoBanco.executarComando(sql);
        }

        public void AlterarCD(tblCDDTO dtoCD)
        {
            string sql = string.Format($@"UPDATE tbl_cd SET nomeCD = '{dtoCD.NomeCD}',
                                                            precoVenda = '{dtoCD.PrecoVenda}', 
                                                            dtLancamento = '{dtoCD.DtLancamento.ToString("yyyy/MM/dd HH:mm:ss")}' 
                                                        WHERE idCD = '{dtoCD.IdCD}';");
            daoBanco.executarComando(sql);
        }

        public void ExcluirCD(tblCDDTO dtoCD)
        {
            string sql = string.Format($@"DELETE FROM tbl_cd WHERE idCD = '{dtoCD.IdCD}';");
            daoBanco.executarComando(sql);
        }
    }
}