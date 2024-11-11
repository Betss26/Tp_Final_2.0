<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Final_Master_Page.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="row g-2">
    <h1>Login</h1>
    <div class="col-md">
        <div class="row g-3">
            <div class="col">
                <asp:Label ID="lbl_mensaje_error" class="alert alert-danger" runat="server"></asp:Label>

                <asp:Label ID="lbl_usuario" runat="server" Text=""></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorusuario" ControlToValidate="txt_usuario"
                    runat="server" ErrorMessage="El nombre de usuario es obligatorio" class="text-danger">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorUsuario"
                    ControlToValidate="txt_usuario"
                    ValidationExpression="^[a-zA-Z]+$"
                    runat="server" ErrorMessage="El nombre debe contener solo letras"
                    class="text-danger" />
                <asp:TextBox ID="txt_usuario" CssClass="form-control" placeholder="Ingrese nombre usuario" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorContrasenia"
                    ControlToValidate="txt_contrasenia"
                    runat="server" ErrorMessage="La contrasenie es obligatoria" class="text-danger">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorContrasenia"
                        ControlToValidate="txt_contrasenia"
                        ValidationExpression="^[^\s]{1,8}$"
                        runat="server" ErrorMessage="La contrasenia debe contener solo letras, números y caracteres especiales hasta 8 carcteres."
                        class="text-danger" />
                </asp:RequiredFieldValidator>
                <asp:Label ID="lbl_contrsenia" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="txt_contrasenia" CssClass="form-control" placeholder="Ingrese contrasenia" runat="server" type="password"></asp:TextBox>
                <div class="col">
                    &nbsp
                    &nbsp
                </div>
                <asp:Button ID="btn_ingresar" runat="server" Text="Ingresar" OnClick="btn_ingresar_Click" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>
</div>
</asp:Content>
