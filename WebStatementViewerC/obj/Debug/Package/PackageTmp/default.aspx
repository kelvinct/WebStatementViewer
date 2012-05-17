<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebStatementViewerC._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
	<meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no">
    <link href="style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 215px;
            height: 215px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <font face="arial"><b><small>WebStatement Import Viewer
        <asp:Label ID="Label1" runat="server"></asp:Label>
        </small></b></font>
    </div>
    <hr />
    <div id="dropdownlist" runat="server">
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            DataFormatString="{0:dd/MM/yyyy}" Width="100%" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
    </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" Font-Names="Arial" Font-Size="Smaller" ForeColor="Black" 
        GridLines="Vertical" RowHeaderColumn="1" Width="100%" 
        onselectedindexchanged="GridView1_SelectedIndexChanged" 
        onrowdatabound="RowDatebound">
        <AlternatingRowStyle BackColor="White" CssClass="table1" />
        <Columns>
            <asp:BoundField DataField="UploadTime" DataFormatString="{0:dd/MM/yyyy}" 
                HeaderText="UploadTime" ReadOnly="True" SortExpression="UploadTime" />
            <asp:BoundField DataField="ClientCode" HeaderText="ClientCode" ReadOnly="True" 
                SortExpression="ClientCode" />
            <asp:BoundField DataField="Status" HeaderText="Status" 
                SortExpression="Status" />
            <asp:BoundField DataField="StartTime" DataFormatString="{0:dd/MM/yyyy}" 
                HeaderText="StartTime" SortExpression="StartTime" />
            <asp:BoundField DataField="EndTime" DataFormatString="{0:dd/MM/yyyy}" 
                HeaderText="EndTime" SortExpression="EndTime" />
        </Columns>
        <EditRowStyle Font-Size="Small" />
        <FooterStyle BackColor="#CCFFCC" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" Font-Names="Arial" 
            Font-Size="X-Small" ForeColor="White" />
        <PagerStyle BackColor="#66FFFF" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#CCFFFF" />
       
                        </asp:GridView>
    </form>
    <hr />
    <div align="center">
        CamsView 2.0</div>

        
</body>
</html>
