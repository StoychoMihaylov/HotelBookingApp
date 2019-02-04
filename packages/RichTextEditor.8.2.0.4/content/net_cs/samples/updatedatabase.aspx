<%@ Page Language="c#" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>

<script runat="server">
	void Page_Load(object sender, System.EventArgs e)
	{
		if (!IsPostBack)
		{
			BindData();
		}
	}

	void BindData()
	{
		OleDbConnection myConnection = CreateConnection();
		string sql = "Select EventID, Notes, EventDate from Events";
		OleDbCommand myCommand = new OleDbCommand(sql, myConnection);

		// Execute the command
		OleDbDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

		MyDataGrid.DataSource = result;
		MyDataGrid.DataBind();
	}


	void UpdateItem(Object sender, DataGridCommandEventArgs e)
	{
		OleDbConnection myConnection = CreateConnection();

		//Check if the CommandName ==Delete
		if (e.CommandName == "Delete")
		{
			OleDbCommand com = new OleDbCommand("DELETE FROM Events WHERE EventID = @id", myConnection);
			com.Parameters.Add("id", e.Item.Cells[0].Text);
			com.ExecuteNonQuery();
			myConnection.Close();
		}
		else if (e.CommandName == "Edit")
		{
			OleDbCommand command = new OleDbCommand("SELECT Notes FROM Events WHERE EventID = @id", myConnection);
			command.Parameters.Add("id", e.Item.Cells[0].Text);
			OleDbDataReader result = command.ExecuteReader();
			if (result.Read())
			{
				//set the editor text 
				Editor1.Text = result.GetString(0);
				eventid.Value = e.Item.Cells[0].Text;
				btnUpdate.Text = "Update";
			}
			else
			{
				Editor1.Text = "";
				eventid.Value = "";
				btnUpdate.Text = "Add";
			}
			result.Close();
		}
		BindData();
	}

	void Submit(object sender, System.EventArgs e)
	{
		if (!Page.IsValid)
			return;

		OleDbConnection myConnection = CreateConnection();
		OleDbCommand command = null;

		if (eventid.Value != "")
		{
			command = new OleDbCommand("UPDATE Events SET EventDate = Date(), Notes = @content WHERE EventID = @id", myConnection);
			command.Parameters.Add("content", Editor1.Text);
			command.Parameters.Add("id", Convert.ToInt32(eventid.Value));
		}
		else
		{
			command = new OleDbCommand("INSERT INTO Events (EventDate, Notes) VALUES (Date(), @content)", myConnection);
			command.Parameters.Add("content", Editor1.Text);
		}

		command.ExecuteNonQuery();
		myConnection.Close();
		BindData();
	}

	OleDbConnection CreateConnection()
	{
		OleDbConnection myConnection = new OleDbConnection();
		myConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Context.Server.MapPath("../uploads/Northwind.mdb") + ";";
		myConnection.Open();
		return myConnection;
	}
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
