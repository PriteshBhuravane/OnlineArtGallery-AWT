<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewArtists.aspx.cs" Inherits="OnlineArtGallery.ViewArtists" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="view-artists">
        <h2>Registered Artists</h2>
        <asp:GridView ID="gvArtists" runat="server" AutoGenerateColumns="False" CssClass="artists-grid">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="ArtCategory" HeaderText="Art Category" />
                <asp:BoundField DataField="ArtworkFileName" HeaderText="Artwork File" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
