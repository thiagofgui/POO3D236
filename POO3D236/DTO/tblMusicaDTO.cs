using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POO3D236.DTO
{
    public class tblMusicaDTO
    {
        private int idMusica;
        private string nome, nomeAutor;
        private int idGravadora;
        private int idCD;

        public int IdMusica { get => idMusica; set => idMusica = value; }
        public string Nome { get => nome;
            set
            {
                if(value != string.Empty)
                {
                    nome = value;
                }
                else
                {
                    throw new Exception("O campo nome é obrigatório");
                }
            }
        }
        public string NomeAutor { get => nomeAutor;
            set
            {
                if(value != string.Empty)
                {
                    nomeAutor = value;
                }
                else
                {
                    throw new Exception("O campo nome autor é obrigatório");
                }
            }
        }
        public int IdGravadora { get => idGravadora; set => idGravadora = value; }
        public int IdCD { get => idCD; set => idCD = value; }
    }
}