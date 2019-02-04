<%@ Page Language="VB" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>

<script runat="server">
	Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		If Not IsPostBack Then
			BindData()
		End If
	End Sub

	Sub BindData()
		Dim myConnection As OleDbConnection = CreateConnection()
		Dim sql As String = "Select EventID, Notes, EventDate from Events"
		Dim myCommand As New OleDbCommand(sql, myConnection)

		' Execute the command
		Dim result As OleDbDataReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)

		MyDataGrid.DataSource = result
		MyDataGrid.DataBind()
	End Sub


	Sub UpdateItem(ByVal sender As [Object], ByVal e As DataGridCommandEventArgs)
		Dim myConnection As OleDbConnection = CreateConnection()

		'Check if the CommandName ==Delete
		If e.CommandName = "Delete" Then
			Dim com As New OleDbCommand("DELETE FROM Events WHERE EventID = @id", myConnection)
			com.Parameters.Add("id", e.Item.Cells(0).Text)
			com.ExecuteNonQuery()
			myConnection.Close()
		ElseIf e.CommandName = "Edit" Then
			Dim command As New OleDbCommand("SELECT Notes FROM Events WHERE EventID = @id", myConnection)
			command.Parameters.Add("id", e.Item.Cells(0).Text)
			Dim result As OleDbDataReader = command.ExecuteReader()
			If result.Read() Then
				'set the editor text 
				Editor1.Text = result.GetString(0)
				eventid.Value = e.Item.Cells(0).Text
				btnUpdate.Text = "Update"
			Else
				Editor1.Text = ""
				eventid.Value = ""
				btnUpdate.Text = "Add"
			End If
			result.Close()
		End If
		BindData()
	End Sub

	Sub Submit(ByVal sender As Object, ByVal e As System.EventArgs)
		If Not Page.IsValid Then
			Return
		End If

		Dim myConnection As OleDbConnection = CreateConnection()
		Dim command As OleDbCommand = Nothing

		If eventid.Value <> "" Then
			command = New OleDbCommand("UPDATE Events SET EventDate = Date(), Notes = @content WHERE EventID = @id", myConnection)
			command.Parameters.Add("content", Editor1.Text)
			command.Parameters.Add("id", Convert.ToInt32(eventid.Value))
		Else
			command = New OleDbCommand("INSERT INTO Events (EventDate, Notes) VALUES (Date(), @content)", myConnection)
			command.Parameters.Add("content", Editor1.Text)
		End If

		command.ExecuteNonQuery()
		myConnection.Close()
		BindData()
	End Sub

	Function CreateConnection() As OleDbConnection
		Dim myConnection As New OleDbConnection()
		myConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Context.Server.MapPath("../uploads/Northwind.mdb") + ";"
		myConnection.Open()
		Return myConnection
	End Function
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - Database example</title>
	<link rel="stylesheet" href="example.css" type="text/css" />
</head>
<body>
	<form id="Form1" method="post" runat="server">
		<h1>
			Updating a Database</h1>
		<p>
			This example shows how easy it can be to save the RichTextEditor's contents into
			a database.
		</p>
		<br />
		<asp:DataGrid runat="server" ID="MyDataGrid" CellPadding="3" CellSpacing="0" HeaderStyle-BackColor="#eeeeee"
			HeaderStyle-Font-Bold="True" BackColor="#f5f5f5" BorderWidth="1" Width="760"
			BorderColor="#999999" AutoGenerateColumns="False" OnItemCommand="UpdateItem">
			<Columns>
				<asp:BoundColumn DataField="EventID" Visible="False" />
				<asp:BoundColumn ItemStyle-Width="50px" DataField="EventID" HeaderText="ID" />
				<asp:BoundColumn ItemStyle-Width="430px" DataField="Notes" HeaderText="Note" />
				<asp:BoundColumn ItemStyle-Width="120px" DataField="EventDate" HeaderText="Date" />
				<asp:ButtonColumn ItemStyle-Width="50px" ButtonType="LinkButton" CommandName="Edit"
					HeaderText="Edit" Text="Edit" />
				<asp:ButtonColumn ItemStyle-Width="50px" ButtonType="LinkButton" CommandName="Delete"
					HeaderText="Delete" Text="Delete" />
			</Columns>
		</asp:DataGrid>
		<br />
		<p>
			<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" Skin="officexpblue" Toolbar="light" />
		</p>
		<asp:Button ID="btnUpdate" OnClick="Submit" runat="server" Text="Add"></asp:Button>
		<asp:Literal ID="Literal1" runat="server" />
		<br />
		<br />
		<input type="hidden" name="eventid" runat="server" id="eventid">
	</form>
</body>
</html>
