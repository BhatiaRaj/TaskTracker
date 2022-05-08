<%@ Page Title="" Language="C#" MasterPageFile="~/TaskTracker.master" AutoEventWireup="true" CodeFile="CustomerAndWork.aspx.cs" Inherits="CustomerAndWork" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 50%;
            margin-left: auto;
            margin-right: auto;
        }
        .form__input {
            width: 180px;
            height: 30px;
            margin: 4px 0;
            padding-left: 25px;
            font-size: 13px;
            letter-spacing: 0.15px;
            border: none;
            outline: none;
            font-family: 'Montserrat', sans-serif;
            transition: 0.25s ease;
            border-radius: 8px;
            box-shadow: inset 2px 2px 4px #d1d9e6, inset -2px -2px 4px #f9f9f9;
        }

        .button1 {
            width: 180px;
            height: 30px;
            background-color: #4CAF50; /* Green */
            border: none;
            outline: none;
            color: white;
            
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            margin: 4px 2px;
            border-radius: 12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
    <table class="auto-style1">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Customer Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="customername" runat="server" Enabled="False" CssClass="form__input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Date"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="date1" runat="server" Enabled="False" CssClass="form__input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Target Date"></asp:Label>
            </td>
            <td>
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Description"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="mobno" runat="server" Rows="4" CssClass="form__input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Work"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlwork" runat="server" CssClass="form__input">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Photo"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="180px" />
                </td>
            </tr>
        <tr>
            <td colspan="2">
                <center>
                <asp:Button ID="custandworksubmit" runat="server" OnClick="custandworksubmit_Click" CssClass="button1" Text="Submit" />
                </center>
             </td>
        </tr>
        
    </table>
    <table class="auto-style1">
    <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" Width="870px" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" />
                        <asp:BoundField DataField="date" HeaderText="Date" />
                        <asp:BoundField DataField="target" HeaderText="Target" />
                        <asp:BoundField DataField="description" HeaderText="Description" />
                        <asp:BoundField DataField="work" HeaderText="Work" />
                       
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </td>
        </tr>
     </table>
    </form>
</asp:Content>

