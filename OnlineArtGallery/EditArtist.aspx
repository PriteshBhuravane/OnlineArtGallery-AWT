<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditArtist.aspx.cs" Inherits="OnlineArtGallery.EditArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="edit-artist">
        <h2>Edit Artist</h2>
        <div>
            <label for="txtName">Name:</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <label for="ddlArtCategory">Art Category:</label>
            <asp:DropDownList ID="ddlArtCategory" runat="server" CssClass="form-control">
                <asp:ListItem Text="Painting" Value="Painting"></asp:ListItem>
                <asp:ListItem Text="Sculpture" Value="Sculpture"></asp:ListItem>
                <asp:ListItem Text="Digital Art" Value="Digital Art"></asp:ListItem>
                <asp:ListItem Text="Photography" Value="Photography"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <label for="fileArtwork">Upload Artwork:</label>
            <asp:FileUpload ID="fileArtwork" runat="server" CssClass="form-control" />
        </div>
        <div>
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="update-button" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="cancel-button" />
        </div>
    </div>
</asp:Content>
