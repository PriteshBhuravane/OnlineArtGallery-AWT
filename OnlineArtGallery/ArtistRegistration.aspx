<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArtistRegistration.aspx.cs" Inherits="OnlineArtGallery.ArtistRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="registration-form">
        <h2>Artist Registration</h2>
        <p>Please fill out the form below to register as an artist.</p>
        <div>
            <label for="txtName">Name:</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Name is required." ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div>
            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required." ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid email format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
        </div>
        <div>
            <label for="ddlArtCategory">Art Category:</label>
            <asp:DropDownList ID="ddlArtCategory" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Category" Value=""></asp:ListItem>
                <asp:ListItem Text="Painting" Value="Painting"></asp:ListItem>
                <asp:ListItem Text="Sculpture" Value="Sculpture"></asp:ListItem>
                <asp:ListItem Text="Digital Art" Value="Digital Art"></asp:ListItem>
                <asp:ListItem Text="Photography" Value="Photography"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvArtCategory" runat="server" ControlToValidate="ddlArtCategory" ErrorMessage="Art category is required." ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div>
            <label for="fileArtwork">Upload Artwork:</label>
            <asp:FileUpload ID="fileArtwork" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvArtwork" runat="server" ControlToValidate="fileArtwork" ErrorMessage="Artwork is required." ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="message"></asp:Label>
        <div>
            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn" OnClick="btnRegister_Click" />
        </div>
    </div>
</asp:Content>
