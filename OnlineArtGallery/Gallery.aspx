<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="OnlineArtGallery.Gallery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="gallery">
        <h2>Art Gallery</h2>
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
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
