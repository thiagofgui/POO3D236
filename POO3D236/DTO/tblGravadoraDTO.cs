using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POO3D236.DTO
{
    public class tblGravadoraDTO
    {
        private int idGravadora;
        private string nome;

        public int IdGravadora { get => idGravadora; set => idGravadora = value; }
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
    }
}