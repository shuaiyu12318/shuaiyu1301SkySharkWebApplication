<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="shuaiyu1301SkySharkWebApplication.BM.Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Business Manager
    <style type="text/css">
        .auto-style1 {
            height: 39px;
        }
    </style>
    <style type="text/css">
        .auto-style1 {
            width: 449px;
        }
        .auto-style2 {
            width: 1061px;
        }
        .auto-style3 {
            width: 1061px;
            height: 31px;
        }
        .auto-style4 {
            height: 31px;
        }
        .auto-style5 {
            height: 31px;
            width: 557px;
        }
        .auto-style6 {
            width: 557px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form id="form1" runat="server">
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
          <Items>
              <asp:MenuItem NavigateUrl="~/BM/AddFI.aspx" Text="Add Flight" Value="Add Flight"></asp:MenuItem>
              <asp:MenuItem NavigateUrl="~/BM/RequestID.aspx" Text="Request ID" Value="Request ID"></asp:MenuItem>
              <asp:MenuItem NavigateUrl="~/BM/Reports.aspx" Selected="True" Text="Reports" Value="Reports"></asp:MenuItem>
              <asp:MenuItem NavigateUrl="~/BM/FreqFI.aspx" Text="Frequent Filers" Value="Frequent Filers"></asp:MenuItem>
          </Items>
          <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
          <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
          <StaticSelectedStyle BackColor="#5D7B9D" />
        </asp:Menu>
        <div class="tabContents">
            <table>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Label1" runat="server" Text="Generate Reports:"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ChangePassword.aspx">Change Password</asp:HyperLink></td>
                    <td>
                         &nbsp;&nbsp; <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Logoff.aspx">Logoff</asp:HyperLink></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Generate a flight usage report for all flights flown by airline"></asp:Label></td>
                    <td>
                        <asp:Button ID="Button1" runat="server" BackColor="Silver" BorderColor="Blue" Text="Generete Flight Usage Report" Width="403px" OnClick="Button1_Click" />
                        </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Generate a customer affinity report for top 100 customers"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="Button2" runat="server" BackColor="Silver" BorderColor="Blue" Text="Generate customer Affinity Report" Width="403px" OnClick="Button2_Click" />
                        </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Generate a total revenue report from month"></asp:Label>
                        <asp:ListBox ID="lstMonth" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                        </asp:ListBox>
                        <asp:ListBox ID="lstYear" runat="server">
                            <asp:ListItem>2002</asp:ListItem>
                            <asp:ListItem>2003</asp:ListItem>
                            <asp:ListItem>2004</asp:ListItem>
                            <asp:ListItem>2005</asp:ListItem>
                            <asp:ListItem>2022</asp:ListItem>
                        </asp:ListBox>
                    </td>
                    <td>
                        <asp:Button ID="Button3" runat="server" BackColor="Silver" BorderColor="Blue" Text="Generate Revenue Report" OnClick="Button3_Click" Width="403px" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="DataGrid1" runat="server" DataSourceID="SqlDataSource1">
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                    </td>

                </tr>
                </table>
            </div>
         </form>
</asp:Content>
