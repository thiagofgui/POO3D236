using POO3D236.DAL;
using POO3D236.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace POO3D236.BLL
{
    public class tblMusicaBLL
    {
        DALMysql daoBanco = new DALMysql();


        public DataTable ListarMusica()
        {
            string sql = string.Format($@"SELECT * from tbl_musica");
            return daoBanco.executarConsulta(sql);
        }
        public DataTable ListarMusica(string condicao)
        {
            string sql = string.Format($@"SELECT * from tbl_musica where " + condicao);
            return daoBanco.executarConsulta(sql);
        }

        public void InserirMusica(tblMusicaDTO dtoMusica)
        {
            string sql = string.Format($@"INSERT into tbl_musica VALUES(NULL, '{dtoMusica.Nome}',
                                                                              '{dtoMusica.NomeAutor}',
                                                                              '{dtoMusica.IdGravadora}',
                                                                              '{dtoMusica.IdCD}');");
            daoBanco.executarComando(sql);
        }

        public void AlterarMusica(tblMusicaDTO dtoMusica)
        {
            string sql = string.Format($@"UPDATE tbl_musica SET nome = '{dtoMusica.Nome}',
                                                                nomeAutor = '{dtoMusica.NomeAutor}',
                                                                idGravadora = '{dtoMusica.IdGravadora}',
                                                                idCD = '{dtoMusica.IdCD}'
                                                            WHERE idMusica = '{dtoMusica.IdMusica}';");
            daoBanco.executarComando(sql);
        }

        public void ExcluirMusica(tblMusicaDTO dtoMusica)
        {
            string sql = string.Format($@"DELETE FROM tbl_musica WHERE idMusica = '{dtoMusica.IdMusica}';");
            daoBanco.executarComando(sql);
        }
    }
}