using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using POO3D236.BLL;
using POO3D236.DTO;

namespace POO3D236.UI
{
    public partial class frm_musica : System.Web.UI.Page
    {

        private tblMusicaDTO DTOMusica = new tblMusicaDTO();
        private tblMusicaBLL BLLMusica = new tblMusicaBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                this.ExibirGrid();
            }
        }

        public void ExibirGrid()
        {
            Grid.DataSource = BLLMusica.ListarMusica();
            Grid.DataBind();
        }

        protected void btnConsulta(object sender, EventArgs e)
        {
            try
            {
                DTOMusica.Nome = txt_nome.Text;
                DTOMusica.NomeAutor = txt_nomeAutor.Text;
                DTOMusica.IdGravadora = int.Parse(txt_idGravadora.Text);
                DTOMusica.IdCD = int.Parse(txt_idCD.Text);
                txt_nome.Text = string.Empty;
                txt_nomeAutor.Text = string.Empty;
                txt_idGravadora.Text = string.Empty;
                txt_idCD.Text = string.Empty;
                BLLMusica.InserirMusica(DTOMusica);
                this.ExibirGrid();
            }catch(Exception ex)
            {
                Response.Write($"<script>alert('ERRO: {ex.Message}');</script>");
            }
        }

        protected void DeleteRow(object sender, GridViewDeleteEventArgs args)
        {
            try
            {
                DTOMusica.IdMusica = Convert.ToInt32(args.Values[0]);
                BLLMusica.ExcluirMusica(DTOMusica);
                this.ExibirGrid();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('ERRO: {ex.Message}');</script>");
            }
        }

        protected void EditingRow(object sender, GridViewEditEventArgs args)
        {
            Grid.EditIndex = args.NewEditIndex;
            this.ExibirGrid();
        }

        protected void UpdatingRow(object sender, GridViewUpdateEventArgs args)
        {
            try
            {
                DTOMusica.IdMusica = int.Parse(args.NewValues[0].ToString());
                DTOMusica.Nome = args.NewValues[1].ToString();
                DTOMusica.NomeAutor = args.NewValues[2].ToString();
                DTOMusica.IdGravadora = int.Parse(args.NewValues[3].ToString());
                DTOMusica.IdCD = int.Parse(args.NewValues[4].ToString());
                BLLMusica.AlterarMusica(DTOMusica);
                Grid.EditIndex = -1;
                this.ExibirGrid();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('ERRO: {ex.Message}');</script>");
            }
        }

        protected void CancelEditing(object sender, GridViewCancelEditEventArgs e)
        {
            Grid.EditIndex = -1;
            this.ExibirGrid();
        }
    }
}