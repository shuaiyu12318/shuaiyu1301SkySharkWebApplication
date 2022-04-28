<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Logoff.aspx.cs" Inherits="shuaiyu1301SkySharkWebApplication.Logoff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    HOME
    <style type="text/css">
        #TextArea1 {
            height: 214px;
            width: 676px;
        }
        #form1 {
            height: 227px;
            width: 673px;
        }
    </style>
    <style type="text/css">
        .auto-style1 {
            width: 686px;
            height: 170px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div style="height: 275px; width: 683px">
     <textarea id="TextArea1" class="auto-style1">
         Thank you for using SkyShark Airlines.
         Looking forward to serving you again.
     </textarea>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/default.aspx">Click Here to Login</asp:HyperLink>
    </div>
    </form>
</asp:Content>
