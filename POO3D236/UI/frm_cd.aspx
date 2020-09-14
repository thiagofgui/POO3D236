<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_cd.aspx.cs" Inherits="POO3D236.UI.frm_cd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="https://fonts.googleapis.com/css2?family=Titillium+Web:ital@1&display=swap" rel="stylesheet"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.14.0/css/all.min.css"/>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <style>
        nav > ul > li > a{
            color: white !important;
        }
    </style>

    <title>CD</title>
</head>
<body>
    <form id="frm_grav" runat="server">
        <nav class="main-header navbar navbar-expand bg-secondary" runat="server">
            <ul class="navbar-nav">
                <li class="nav-item d-none d-inline-block"><a runat="server" href="frm_gravadora.aspx"><i class="fas fa-video"></i><span>Gravadora</span></a></li>
                <li class="pl-2 nav-item d-none d-inline-block"><i class="fas fa-compact-disc"></i><span>CD</span></li>
                <li class="pl-2 nav-item d-none d-inline-block"><a runat="server" href="frm_musica.aspx"><i class="fas fa-music"></i><span>Músicas</span></a></li>
            </ul>
        </nav>

        <div class="container" runat="server">
                <div class="form-group" runat="server">
                    <asp:Label runat="server" Text="Nome" AssociatedControlId="txt_nome"/>
                    <asp:TextBox ID="txt_nome" type="text" runat="server" CssClass="form-control" ></asp:TextBox>
                </div>
                <div class="form-group" runat="server">
                    <asp:Label runat="server" Text="Preço de Venda" AssociatedControlId="txt_precoVenda"/>
                    <asp:TextBox ID="txt_precoVenda" type="text" runat="server" CssClass="form-control" ></asp:TextBox>
                </div>
                <div class="form-group" runat="server">
                    <asp:Label runat="server" Text="Data de Lançamento" AssociatedControlId="txt_dtLancamento"/>
                    <asp:TextBox ID="txt_dtLancamento" type="datetime-local" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            
            <div class="row">
                <div class="col-md pt-3 pb-3">
                    <asp:Button class="btn btn-block btn-success" runat="server" Text="Inserir" OnClick="btnConsulta"/>
                </div>
            </div>
            <div class="row">
                <div class="col-md">
                    <asp:GridView ID="Grid" class="table table-dark table-striped" OnRowDeleting="DeleteRow" OnRowCancelingEdit="CancelEditing" OnRowEditing="EditingRow" OnRowUpdating="UpdatingRow" runat="server">
                        <Columns>
                                <asp:CommandField ButtonType="Link" ShowDeleteButton="True" DeleteText="Deletar" />
                                <asp:CommandField ButtonType="Link" ShowEditButton="True" EditText="Editar" UpdateText="Gravar" CancelText="Cancelar" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
