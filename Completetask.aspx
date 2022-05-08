<%@ Page Title="" Language="C#" MasterPageFile="~/TaskTracker.master" AutoEventWireup="true" CodeFile="Completetask.aspx.cs" Inherits="Completetask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            margin-left: auto;
            margin-right: auto;
            width: 50%;
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Task Id"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Enabled="False" CssClass="form__input"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Customer name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Enabled="False" CssClass="form__input"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Datetxt" runat="server" Enabled="False" CssClass="form__input"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Time"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Timetxt" runat="server" Enabled="False" CssClass="form__input"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Description"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Textarea" runat="server" Rows="3" Height="100px" CssClass="form__input"></asp:TextBox>
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
                <asp:Button ID="Button1" runat="server" Text="Submit" Width="95px" OnClick="Button1_Click" CssClass="button1" />
                    </center>
            </td>

            </tr>
        </table>

    </form>
</asp:Content>

