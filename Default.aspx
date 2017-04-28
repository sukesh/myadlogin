<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADLogin.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-family: Aharoni;
            font-size: x-large;
        }
        .style2
        {
            font-size: large;
            font-family: "Franklin Gothic Medium Cond";
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style1">
    
        <strong>
        <br />
        </strong><span class="style2"><strong>Employee Name&nbsp;&nbsp;&nbsp; </strong>
        <asp:TextBox ID="txtUsername" runat="server" Height="35px" 
            style="font-family: 'Franklin Gothic Demi Cond'; font-size: medium; font-weight: 700" 
            Width="175px"></asp:TextBox>
        <strong>
        <br />
        <br />
        <br />
        ESS Password&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
        <asp:TextBox ID="txtPassword" runat="server" Height="35px" 
            style="font-weight: 700; font-size: medium; font-family: 'Franklin Gothic Demi Cond'" 
            TextMode="Password" Width="175px"></asp:TextBox>
        <br />
        <br />
        <br />
        <strong>
        Address&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtAddress" runat="server" Height="35px" 
            
            style="font-weight: 700; font-size: medium; font-family: 'Franklin Gothic Demi Cond'" 
            Width="175px"></asp:TextBox>
        <br />
        </strong>
        <br />
        <br />
        <strong>
        Search User&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtSearchUser" runat="server" Height="35px" 
            
            style="font-weight: 700; font-size: medium; font-family: 'Franklin Gothic Demi Cond'" 
            Width="175px"></asp:TextBox>
        </strong>
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" Height="52px" 
            style="font-weight: 700; font-size: large; font-family: 'Franklin Gothic Book'" 
            Text="Submit" Width="131px" onclick="btnSubmit_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblMessage" runat="server" style="font-weight: 700"></asp:Label>
        </span>
    
    </div>
    </form>
</body>
</html>
