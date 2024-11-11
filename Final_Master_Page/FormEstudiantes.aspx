<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormEstudiantes.aspx.cs" Inherits="Final_Master_Page.FormEstudiantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row g-3">
     <%@ Register TagPrefix="uc" TagName="Spinner"
         Src="~/Controles/Bienvenido.ascx" %>
     <uc:Spinner ID="uc" runat="server" AllowDuplicates="true" />
     <asp:Label ID="lbl_borrar_error" class="alert alert-danger" runat="server"></asp:Label>
     <asp:Label ID="lbl_borrar_exito" class="alert alert-success" runat="server"></asp:Label>
     <div class="row g-3">
         <div class="col">
             <asp:Button ID="btn_crear_estudiante" runat="server" Text="crear estudiante" OnClick="btn_crear_estudiante_Click" CssClass="btn btn-primary" />
         </div>
     </div>
     <div class="col">
         <asp:GridView ID="grid_estudiantes" runat="server" AutoGenerateColumns="False" DataKeyNames="id,nombreUsuario" CssClass="table table-striped" OnRowDeleting="grid_estudiantes_RowDeleting" OnSelectedIndexChanged="grid_estudiantes_SelectedIndexChanged" OnRowUpdating="grid_estudiantes_RowUpdating">
             <Columns>
                 <asp:TemplateField ShowHeader="False">
                     <ItemTemplate>
                         <asp:Button ID="btn_ver_actualizar" runat="server" CausesValidation="False" CommandName="Update" Text="Editar" CssClass="btn btn-primary" />
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField ShowHeader="False">
                     <ItemTemplate>
                         <asp:Button ID="btn_borrar" runat="server" CausesValidation="False" CommandName="Delete" Text="Borrar" CssClass="btn btn-danger" />
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField DataField="id" HeaderText="Codigo" />
                 <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                 <asp:BoundField DataField="apellido" HeaderText="Apellido" />
                 <asp:BoundField DataField="tipoDocId" HeaderText="Tipo Doc" />
                 <asp:BoundField DataField="numeroDoc" HeaderText="Num. Doc" />
                 <asp:BoundField DataField="nombreUsuario" HeaderText="Usuario" />
                 <asp:BoundField DataField="telefono" HeaderText="Telefono" />
                 <asp:BoundField DataField="estado" HeaderText="Estado" />
                 <asp:BoundField DataField="direccion" HeaderText="Direccion" />
                 <asp:BoundField DataField="fechaNacimiento" HeaderText="Fecha Nacimiento" DataFormatString="{0:d}" />
                 <asp:BoundField DataField="cantidadMaterias" HeaderText="Cantidad Materias" />
                 <asp:BoundField DataField="legajo" HeaderText="legajo" />
             </Columns>
         </asp:GridView>
     </div>
 </div>
</asp:Content>
