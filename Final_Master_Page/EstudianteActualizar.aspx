<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstudianteActualizar.aspx.cs" Inherits="Final_Master_Page.EstudianteActualizar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <h1>Actualizar estudiante</h1>
 <div class="row g-2">
     <%@ Register TagPrefix="uc" TagName="Bienvenido"
         Src="~/Controles/Bienvenido.ascx" %>
     <uc:Bienvenido ID="uc" runat="server" AllowDuplicates="true" />
     <asp:Label ID="lbl_mensaje_error" class="alert alert-danger" runat="server"></asp:Label>
     <asp:Label ID="lbl_mensaje_exito" class="alert alert-success" runat="server"></asp:Label>
     <asp:Label ID="lbl_id" class="alert alert-success" runat="server"></asp:Label>
     <div class="col-md">
         <div class="row g-3">
             <div class="col">
                 <asp:Label ID="lbl_nombre" runat="server" Text="nombre"></asp:Label>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombre" runat="server" ErrorMessage="El nombre es obligatorio" ControlToValidate="txt_nombre" class="text-danger"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidatorNombre"
                     ControlToValidate="txt_nombre"
                     ValidationExpression="^[a-zA-Z\s]+$"
                     runat="server" ErrorMessage="El nombre debe contener solo letras y espacios"
                     class="text-danger" />
                 <asp:TextBox ID="txt_nombre" CssClass="form-control" placeholder="Ingrese nombre" runat="server"></asp:TextBox>
             </div>
         </div>
         <div class="row g-3">
             <div class="col">
                 <asp:Label ID="lbl_apellido" runat="server" Text="apellido"></asp:Label>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El apellido es obligatorio" ControlToValidate="txt_pellido" class="text-danger"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidatorApellido"
                     ControlToValidate="txt_pellido"
                     ValidationExpression="^[a-zA-Z\s]+$"
                     runat="server" ErrorMessage="El apellido debe contener solo letras y espacios"
                     class="text-danger" />
                 <asp:TextBox ID="txt_pellido" CssClass="form-control" placeholder="Ingrese apellido" runat="server"></asp:TextBox>
             </div>
         </div>
         <div class="row g-3">
             <div class="col">
                 <asp:Label ID="lbl_edad" runat="server" Text="edad"></asp:Label>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorEdad" runat="server" ErrorMessage="La edad es obligatoria" ControlToValidate="txt_edad" class="text-danger"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidatorEdad"
                     ControlToValidate="txt_edad"
                     ValidationExpression="^\d+$"
                     runat="server" ErrorMessage="Ingrese un número válido"
                     class="text-danger" />
                 <asp:RangeValidator ID="RangeValidator1Edad" ControlToValidate="txt_edad" runat="server"
                     MinimumValue="18"
                     MaximumValue="99"
                     Type="Integer" ErrorMessage="La edad minima es 18 y la máxima 99" class="text-danger"></asp:RangeValidator>
                 <asp:TextBox ID="txt_edad" CssClass="form-control" placeholder="Ingrese edad" runat="server"></asp:TextBox>
             </div>
         </div>
         <div class="row g-3">
             <div class="col">
                 <asp:Label ID="lbl_numDoc" CssClass="col-sm-2 col-form-label" runat="server" Text="Num Doc"></asp:Label>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El numero de documento es obligatorio" ControlToValidate="txt_numDoc" class="text-danger"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidatornumDoc"
                     ControlToValidate="txt_numDoc"
                     ValidationExpression="^\d+$"
                     runat="server" ErrorMessage="Ingrese un número válido"
                     class="text-danger" />
                 <asp:TextBox ID="txt_numDoc" CssClass="form-control" placeholder="Ingrese Num doc" runat="server"></asp:TextBox>
             </div>
         </div>
         <div class="row g-3">
             <div class="col">
                 <asp:Label ID="lbl_docType" runat="server" Text="Tipo Doc"></asp:Label>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorTipoDoc" runat="server" ErrorMessage="El tipo documento es obligatorio" ControlToValidate="txt_pellido" class="text-danger"></asp:RequiredFieldValidator>
                 <asp:Label ID="lbl_mensaje" runat="server"></asp:Label>
                 <asp:DropDownList ID="Drop_docType" CssClass="form-control" runat="server"></asp:DropDownList>
             </div>
         </div>
         <div class="row g-3">
             <div class="col">
                 <asp:Label ID="lbl_usuario" CssClass="col-sm-2 col-form-label" runat="server" Text="usuario"></asp:Label>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="El usuario es obligatorio" ControlToValidate="txt_usuario" class="text-danger"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidatorUsuario"
                     ControlToValidate="txt_usuario"
                     ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                     runat="server" ErrorMessage="El formato de mail no es válido"
                     class="text-danger"></asp:RegularExpressionValidator>
                 <asp:TextBox ID="txt_usuario" CssClass="form-control" placeholder="Ingrese usuario" runat="server"></asp:TextBox>
             </div>
         </div>
         <div class="row g-3">
             <div class="col">
                 <asp:Label ID="lbl_contrasenia" CssClass="col-sm-2 col-form-label" runat="server" Text="contrasenia"></asp:Label>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorContrasenia" runat="server" ErrorMessage="La contrasenia es obligatoria" ControlToValidate="txt_contrasenia" class="text-danger"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidatorContrasenia"
                     ControlToValidate="txt_contrasenia"
                     ValidationExpression="^[^\s]{1,8}$"
                     runat="server" ErrorMessage="La contrasenia debe contener solo letras, números y caracteres especiales hasta 8 carcteres."
                     class="text-danger" />
                 <asp:TextBox ID="txt_contrasenia" CssClass="form-control" placeholder="Ingrese contrasenia" runat="server"></asp:TextBox>
             </div>
         </div>
     </div>

     <div class="col-md">
         <div class="row g-3">
             <div class="col">
                 <asp:Label ID="lbl_telefono" CssClass="col-sm-2 col-form-label" runat="server" Text="telefono"></asp:Label>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="El apellido es obligatorio" ControlToValidate="txt_telefono" class="text-danger"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidatorTelefono"
                     ControlToValidate="txt_telefono"
                     ValidationExpression="^\d+$"
                     runat="server" ErrorMessage="Ingrese un número válido"
                     class="text-danger" />
                 <asp:TextBox ID="txt_telefono" CssClass="form-control" placeholder="Ingrese telefono" runat="server"></asp:TextBox>
             </div>
         </div>
         <div class="row g-3">
             <div class="col">
                 <asp:Label ID="lbl_cumpleanios" CssClass="col-sm-2 col-form-label" runat="server" Text="Fecha nacimiento"></asp:Label>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorCumpleanios" runat="server" ErrorMessage="El cumpleanios es obligatorio" ControlToValidate="txt_cumpleanios" class="text-danger"></asp:RequiredFieldValidator>
                 <asp:CustomValidator runat="server"
                     ID="CustomValidatorCumpleanios"
                     ControlToValidate="txt_cumpleanios"
                     OnServerValidate="fecha_ServerValidacion"
                     ErrorMessage="ingrese una fecha válida" class="text-danger" />
                 <asp:CustomValidator runat="server"
                     ID="CustomValidatorEdad"
                     ControlToValidate="txt_cumpleanios"
                     OnServerValidate="edad_ServerValidacion"
                     ErrorMessage="La edad no coincide con la fecha de cumpleanios" class="text-danger" />
                 <asp:TextBox ID="txt_cumpleanios" CssClass="form-control" placeholder="Ingrese cumpleanios" TextMode="Date" runat="server"></asp:TextBox>
             </div>
         </div>
         <div class="row g-3">
             <div class="col">
                 <asp:Label ID="lbl_estado" CssClass="col-sm-2 col-form-label" runat="server" Text="estado"></asp:Label>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorEstado" runat="server" ErrorMessage="El apellido es obligatorio" ControlToValidate="txt_estado" class="text-danger"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                     ControlToValidate="txt_estado"
                     ValidationExpression="^(activo|inactivo|ACTIVO|INACTIVO)$"
                     runat="server" ErrorMessage="Ingrese estado válido: ACTIVO o INACTIVO"
                     class="text-danger" />
                 <asp:TextBox ID="txt_estado" CssClass="form-control" placeholder="Ingrese estado ACTIVO o INACTIVO" runat="server"></asp:TextBox>
             </div>
         </div>
         <div class="row g-3">
             <div class="col">
                 <asp:Label ID="lbl_direccion" CssClass="col-sm-2 col-form-label" runat="server" Text="direccion"></asp:Label>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="La direccion es obligatorio" ControlToValidate="txt_direccion" class="text-danger"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidatorDireccion"
                     ControlToValidate="txt_direccion"
                     ValidationExpression="^[a-zA-Z0-9\s]+$"
                     runat="server" ErrorMessage="La dirección debe contener solo letras, numeros y espacios"
                     class="text-danger" />
                 <asp:TextBox ID="txt_direccion" CssClass="form-control" placeholder="Ingrese direccion" runat="server"></asp:TextBox>
             </div>
         </div>
         <div class="row g-3">
             <div class="col">
                 <asp:Label ID="lbl_cantMaterias" CssClass="col-sm-2 col-form-label" runat="server" Text="cant materias"></asp:Label>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorMaterias" runat="server" ErrorMessage="La cantidad es obligatoria" ControlToValidate="txt_cantMaterias" class="text-danger"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidatorCantMat"
                     ControlToValidate="txt_cantMaterias"
                     ValidationExpression="^\d+$"
                     runat="server" ErrorMessage="Ingrese un número válido"
                     class="text-danger" />
                 <asp:RangeValidator ID="RangeValidatorMaterias" ControlToValidate="txt_cantMaterias" runat="server"
                     MinimumValue="1"
                     MaximumValue="8"
                     Type="Integer" ErrorMessage="La cantidad debe ser entre 1 y 8" class="text-danger"></asp:RangeValidator>
                 <asp:TextBox ID="txt_cantMaterias" CssClass="form-control" placeholder="Ingrese cantidad de materias" runat="server"></asp:TextBox>
             </div>
         </div>
         <div class="row g-3">
             <div class="col">
                 <asp:Label ID="lbl_legajo" CssClass="col-sm-2 col-form-label" runat="server" Text="legajo"></asp:Label>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorLegajo" runat="server" ErrorMessage="El legajo es obligatorio" ControlToValidate="txt_legajo" class="text-danger"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidatorLegajo"
                     ControlToValidate="txt_legajo"
                     ValidationExpression="^\d+$"
                     runat="server" ErrorMessage="Ingrese un número válido"
                     class="text-danger" />
                 <asp:RangeValidator ID="RangeValidatorLegajo" ControlToValidate="txt_legajo" runat="server"
                     MinimumValue="1"
                     MaximumValue="1000"
                     Type="Integer" ErrorMessage="El legajo debe ser entre 1 y 1000" class="text-danger"></asp:RangeValidator>
                 <asp:TextBox ID="txt_legajo" CssClass="form-control" placeholder="Ingrese legajo" runat="server"></asp:TextBox>
             </div>
         </div>
         <div class="row g-3">
             <div class="col">
                 <div class="col">
                     &nbsp
                     &nbsp
                 </div>
                 <asp:Button ID="btn_confirmar" runat="server" Text="Confirmar" OnClick="btn_confirmar_estudiante_Click" CssClass="btn btn-primary" />
                 <asp:Button ID="btn_volver" runat="server" Text="Volver" OnClick="btn_volver_Click" CssClass="btn btn-primary" />
             </div>
         </div>
     </div>
 </div>
</asp:Content>
