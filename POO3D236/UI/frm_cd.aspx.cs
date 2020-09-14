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
    public partial class frm_cd : System.Web.UI.Page
    {

        private tblCDDTO DTOCD = new tblCDDTO();
        private tblCDBLL BLLCD = new tblCDBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                this.ExibirGrid();
            }
        }

        public void ExibirGrid()
        {
            Grid.DataSource = BLLCD.ListarCD();
            Grid.DataBind();
        }

        protected void btnConsulta(object sender, EventArgs e)
        {
            try
            {
                DTOCD.NomeCD = txt_nome.Text;
                DTOCD.PrecoVenda = double.Parse(txt_precoVenda.Text);
                DTOCD.DtLancamento = DateTime.Parse(txt_dtLancamento.Text);
                BLLCD.InserirCD(DTOCD);
                txt_nome.Text = string.Empty;
                txt_precoVenda.Text = string.Empty;
                txt_dtLancamento.Text = DateTime.Now.ToString();
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
                DTOCD.IdCD = Convert.ToInt32(args.Values[0]);
                BLLCD.ExcluirCD(DTOCD);
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
                DTOCD.IdCD = int.Parse(args.NewValues[0].ToString());
                DTOCD.NomeCD = args.NewValues[1].ToString();
                DTOCD.PrecoVenda = double.Parse(args.NewValues[2].ToString());
                DTOCD.DtLancamento = DateTime.Parse(args.NewValues[3].ToString());
                BLLCD.AlterarCD(DTOCD);
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