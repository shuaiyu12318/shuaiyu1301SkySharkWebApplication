<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="WebApplication1.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            username<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            pasword<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            role<asp:ListBox ID="ListBox1" runat="server">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>LOB</asp:ListItem>
                <asp:ListItem></asp:ListItem>
            </asp:ListBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Username"  EmptyDataText="There are no data records to display.">
                <Columns>
                    <asp:BoundField DataField="Username" HeaderText="Username" ReadOnly="True" SortExpression="Username" />
                    <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                    <asp:BoundField DataField="Role" HeaderText="Role" SortExpression="Role" />
                    <asp:CheckBoxField DataField="PasswordChanged" HeaderText="PasswordChanged" SortExpression="PasswordChanged" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ARPDatabaseConnectionString %>" DeleteCommand="DELETE FROM [dtUsers] WHERE [Username] = @Username" InsertCommand="INSERT INTO [dtUsers] ([Username], [Password], [Role], [PasswordChanged]) VALUES (@Username, @Password, @Role, @PasswordChanged)" SelectCommand="SELECT [Username], [Password], [Role], [PasswordChanged] FROM [dtUsers]" UpdateCommand="UPDATE [dtUsers] SET [Password] = @Password, [Role] = @Role, [PasswordChanged] = @PasswordChanged WHERE [Username] = @Username">
                <DeleteParameters>
                    <asp:Parameter Name="Username" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Username" Type="String" />
                    <asp:Parameter Name="Password" Type="String" />
                    <asp:Parameter Name="Role" Type="String" />
                    <asp:Parameter Name="PasswordChanged" Type="Boolean" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Password" Type="String" />
                    <asp:Parameter Name="Role" Type="String" />
                    <asp:Parameter Name="PasswordChanged" Type="Boolean" />
                    <asp:Parameter Name="Username" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
