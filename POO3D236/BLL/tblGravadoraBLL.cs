using Org.BouncyCastle.Security;
using POO3D236.DAL;
using POO3D236.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace POO3D236.BLL
{
    public class tblGravadoraBLL
    {
        DALMysql daoBanco = new DALMysql();

        public DataTable ListarGravadora()
        {
            string sql = string.Format($@"SELECT * from tbl_gravadora");
            return daoBanco.executarConsulta(sql);
        }
        public DataTable ListarGravadora(string condicao)
        {
            string sql = string.Format($@"SELECT * from tbl_gravadora where " + condicao);
            return daoBanco.executarConsulta(sql);
        }

        public void InserirGravadora(tblGravadoraDTO dtoGravadora)
        {
            string sql = string.Format($@"INSERT INTO tbl_gravadora VALUES(NULL, '{dtoGravadora.Nome}');");
            daoBanco.executarComando(sql);
        }

        public void ExcluirGravadora(tblGravadoraDTO dtoGravadora)
        {
            string sql = string.Format($@"DELETE FROM tbl_gravadora WHERE idGravadora = '{dtoGravadora.IdGravadora}';");
            daoBanco.executarComando(sql);
        }

        public void AlterarGravadora(tblGravadoraDTO dtoGravadora)
        {
            string sql = string.Format($@"UPDATE tbl_gravadora SET nome = '{dtoGravadora.Nome}' WHERE idGravadora = '{dtoGravadora.IdGravadora}';");
            daoBanco.executarComando(sql);
        }
    }
}