<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="OnlineArtGallery.Gallery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="gallery">
        <h2>Art Gallery</h2>
        <div class="search-bar">
    <asp:TextBox ID="txtSearch" runat="server" placeholder="Search by name, email, or category..." CssClass="search-input"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="search-button" />
    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CssClass="search-button" />

</div>
        <asp:Label ID="lblNoResults" runat="server" Text="No artworks found." Visible="false" CssClass="no-results"></asp:Label>
        <div class="artwork-grid">
            <asp:Repeater ID="rptArtworks" runat="server">
    <ItemTemplate>
        <div class="artwork-card">
            <div class="artwork-image-container">
                <img src='<%# "Uploads/" + Eval("ArtworkFileName") %>' alt='<%# Eval("Name") %>' class="artwork-image" />
            </div>
            <div class="artwork-details">
                <h3><%# Eval("Name") %></h3>
                <p><strong>Email:</strong> <%# Eval("Email") %></p>
                <p><strong>Art Category:</strong> <%# Eval("ArtCategory") %></p>
                <div class="action-buttons">
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="edit-button" CommandArgument='<%# Eval("ArtistID") %>' OnClick="btnEdit_Click" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="delete-button" CommandArgument='<%# Eval("ArtistID") %>' OnClick="btnDelete_Click" />
                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
            
        </div>

    </div>
</asp:Content>

