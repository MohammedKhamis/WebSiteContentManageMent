<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pages.aspx.cs" Inherits="ContentWebSite.Pages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td colspan="3" style="text-align: center; text-decoration: underline; font-style: italic; font-weight: 700">
                    <h1>Pages</h1>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Title"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txt_title" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1">
                    <asp:Button ID="btn_Add_Pages" runat="server" OnClick="btn_Add_Pages_Click" Text="Add_Page" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Content"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="drp_Content" runat="server" DataSourceID="EntityDataSource1" DataTextField="content_name" DataValueField="content_id">
                    </asp:DropDownList>
                    <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=XDG_Content_Management_WebSiteEntities" DefaultContainerName="XDG_Content_Management_WebSiteEntities" EnableFlattening="False" EntitySetName="Contents_view">
                    </asp:EntityDataSource>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Number Of Content"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txt_number" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add_Contents" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btn_Ok" runat="server" OnClick="btn_Ok_Click" Text="Ok" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Home.aspx">Home</asp:HyperLink>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
