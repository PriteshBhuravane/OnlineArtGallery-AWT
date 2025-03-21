<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="OnlineArtGallery.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="home-content">
        <h2>Welcome to the Online Art Gallery</h2>
        <p>
            Explore a world of creativity and inspiration. Our gallery features stunning artworks from talented artists around the globe.
            Whether you're an art enthusiast or an artist yourself, you'll find something to love here.
        </p>
        <p>
            <strong>Featured Artists:</strong>
            <ul>
                <li>John Doe - Abstract Paintings</li>
                <li>Jane Smith - Digital Art</li>
                <li>Alex Johnson - Sculptures</li>
            </ul>
        </p>
        <p>
            <a href="Gallery.aspx" class="btn">Visit the Gallery</a>
        </p>
    </div>
</asp:Content>
