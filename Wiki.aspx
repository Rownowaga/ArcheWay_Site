<%@ Page Title="Wiki" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wiki.aspx.cs" Inherits="ArcheWay_Site.Wiki" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Styles/wiki.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:Table runat="server" ID="mainTable" CellPadding="0">
        <asp:TableRow>
            <asp:TableCell VerticalAlign="Top" Width="300px">
                <asp:Panel runat="server" CssClass="wikiLinks">
                    <asp:Panel runat="server" Style="text-align:center;">
                        <asp:Image runat="server" CssClass="iconImg" ImageUrl="~/Images/aa3.png"/>
                    </asp:Panel>
                    <hr />
                
                    <!--Revision 1.2 -->
                    <asp:Panel runat="server">
                        <button class="accordion">Revision 1.2</button>
                        <asp:Panel runat="server" CssClass="subCat">
                            <button class="accordion">Login Breakdown</button>
                                <asp:Panel runat="server" CssClass="subCat"> <!--Login Breakdown-->

                                </asp:Panel>
                            <button class="accordion">Game Protocol</button>
                                <asp:Panel runat="server" CssClass="subCat"> <!--Game Protocol -->
                                    <asp:Literal runat="server" ID="gameRuleCats12" OnLoad="gameRuleCats12_Load"></asp:Literal>
                                </asp:Panel>
                        </asp:Panel>
                    </asp:Panel>
                    <!--End 1.2 -->
                    
                </asp:Panel>
            </asp:TableCell>

            <asp:TableCell VerticalAlign="Top" ID="anchor">
                <asp:Panel runat="server" CssClass="wikiContent">
                    <div style="padding-left: 35px;">
                        <h1 id="contentHeader">ArcheWay Wiki</h1>
                    </div>
                    <hr />
                    <!--Revision 1.2 Content -->
                    <asp:Literal runat="server" ID="gameRules12" OnLoad="gameRules12_Load"></asp:Literal>
                    <!--End 1.2 Content -->
                </asp:Panel>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <script type="text/javascript">

        contentExist(); //Makes existing content links blue, and missing content links red

        $(".accordion").click(function (e) {
            e.preventDefault();
            $(this).toggleClass("active");
            $(this).next().toggleClass("active")
            $(this).next().slideToggle();
        });

        $(".catLink").click(function (e) {
            e.preventDefault();

            //Set the content header
            var contentHeader = $(this).text()
            var category = $(this).parent().prev();
            while (category.is("button")) {
                contentHeader = category.text() + " ➣ " + contentHeader;
                category = category.parent().prev(); 
            }
            $("#contentHeader").text(contentHeader);

            //Show the content
            var href = $(this).attr("href");
            $(".catContent").fadeOut().promise().done(function () {
                $(href).fadeIn();
                $(".wikiContent").animate({
                    scrollTop: 0
                });
            });
        });

        $(".contentLink").click(function (e) {
            e.preventDefault();

            var href = $(this).attr("href");
            var contentHeader = $("#contentHeader").text();
            $("#contentHeader").text(contentHeader + " ➣ "  + $(this).text());
            $(".catContent").fadeOut().promise().done(function () {
                $(href).fadeIn();
                $(".wikiContent").animate({
                    scrollTop: 0
                });
            });
        });

        function contentExist() {
            $(".contentLink").each(function () {
                $content = $.find($(this).attr("href"));
                if ($content == '')
                    $(this).css("color", "red");
                else
                    $(this).css("color", "blue");
            });
        }

        $(".tablinks").click(function () {

            var href = $(this).attr("href");
            $(".tabcontent").fadeOut().promise().done(function () {
                $(href).fadeIn();
            });
        });
    </script>
</asp:Content>
