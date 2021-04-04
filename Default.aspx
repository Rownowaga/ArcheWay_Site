<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ArcheWay_Site.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .bgimg {
            background-image: url('Images/bg.png');
            min-height: 100%;
            background-position: center;
            background-size: cover;
        }

        .w3-display-middle {
            border-radius: 15%;
            background-color: rgba(0, 0, 0, 0.5);
            padding: 15px;
            top:30%;
        }

        .iconImg {
            height: 64px;
            width: 64px;
        }

        #footerImg {
            height: 64px;
            width: 64px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="bgimg w3-display-container w3-animate-opacity w3-text-white">
        <div class="w3-display-middle">
            <h1 class="w3-jumbo w3-animate-top">COMING SOON</h1>
            <hr class="w3-border-grey" style="margin:auto;width:40%">
            <p class="w3-large w3-center">
	            Join the
                <asp:HyperLink runat="server" NavigateUrl="https://discord.gg/J39qgf3Ncu" Target="_blank" Text="Discord"></asp:HyperLink>
	            for updates!
            </p>
        </div>
        <div class="w3-display-bottomleft">
            <asp:Image runat="server" CssClass="iconImg" ImageUrl="~/Images/aa2.png"/>
        </div>
    </div>
</asp:Content>
