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
    public partial class frm_gravadora : System.Web.UI.Page
    {

        private tblGravadoraDTO DTOGrav = new tblGravadoraDTO();
        private tblGravadoraBLL BLLGrav = new tblGravadoraBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                this.ExibirGrid();
            }
        }

        public void ExibirGrid()
        {
            Grid.DataSource = BLLGrav.ListarGravadora();
            Grid.DataBind();
        }

        protected void btnConsulta(object sender, EventArgs e)
        {
            try
            {
                DTOGrav.Nome = txt_nome.Text;
                BLLGrav.InserirGravadora(DTOGrav);
                txt_nome.Text = string.Empty;
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
                DTOGrav.IdGravadora = Convert.ToInt32(args.Values[0]);
                BLLGrav.ExcluirGravadora(DTOGrav);
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
                DTOGrav.IdGravadora = int.Parse(args.NewValues[0].ToString());
                DTOGrav.Nome = args.NewValues[1].ToString();
                BLLGrav.AlterarGravadora(DTOGrav);
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