<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="shuaiyu1301SkySharkWebApplication.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    HOME
    <style type="text/css">
        .auto-style1 {
            width: 155px;
        }
        .auto-style2 {
            width: 155px;
            height: 39px;
        }
        .auto-style3 {
            height: 39px;
        }
        .auto-style4 {
            width: 155px;
            height: 31px;
        }
        .auto-style5 {
            height: 31px;
        }
        .auto-style6 {
            width: 155px;
            height: 70px;
        }
        .auto-style7 {
            height: 70px;
        }
    </style>
    <style type="text/css">
        .auto-style4 {
            width: 198px;
        }
        .auto-style7 {
            height: 42px;
        }
        .auto-style8 {
            height: 42px;
            width: 198px;
        }
        .auto-style13 {
            height: 90px;
            width: 198px;
        }
        .auto-style14 {
            height: 90px;
        }
        .auto-style15 {
            height: 26px;
            width: 198px;
        }
        .auto-style16 {
            height: 26px;
        }
    </style>
    <style type="text/css">
        .auto-style1 {
            height: 83px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="txtUser" runat="server" Text="Changing Password for:"></asp:Label>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                     <td>
                        <asp:Label runat="server" Text="Password"></asp:Label>
                    </td>
                     <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please Specify a Valid Password"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                     <td>
                        <asp:Label ID="Label2" runat="server" Text="Confirm Password"></asp:Label>
                    </td>
                     <td>
                        <asp:TextBox ID="txtConfPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                     <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtConfPassword" ErrorMessage="Please Specify a Valid Password"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfPassword" ErrorMessage="The passwords specified by you do not match.Please try again."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                     <td></td>
                     <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    </td>
                     <td></td>
                </tr>
                <tr>
                     <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
