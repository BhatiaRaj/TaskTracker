<%@ Page Title="" Language="C#" MasterPageFile="~/TaskTracker.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 50%;
            margin-left: auto;
            margin-right: auto;
        }

        .form__input {
            width: 220px;
            height: 50px;
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
            width: 220px;
            height: 50px;
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
    <%--<div id="right-panel" class="right-panel">--%>

    <div class="breadcrumbs">
        <div class="col-sm-4">
            <div class="page-header float-left">
                <div class="page-title">
                    <h1>Change Password</h1>
                    <h6>Welcome, <asp:Label ID="Label3" runat="server"></asp:Label><asp:Label ID="Label4" runat="server"></asp:Label><asp:Label ID="Label5" runat="server"></asp:Label>
                    </h6>
                </div>
            </div>
        </div>
    </div>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="New Password"></asp:Label>
                </td>
                <td>

                    <asp:TextBox ID="newpassword" runat="server" TextMode="Password" CssClass="form__input" placeholder="New Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="newpassword" ErrorMessage="*" ForeColor="#DB0000"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Confirm New Password"></asp:Label>
                </td>
                <td>

                    <asp:TextBox ID="conformpassword" runat="server" TextMode="Password" CssClass="form__input" placeholder="Confirm Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="conformpassword" ErrorMessage="*" ForeColor="#DB0000"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <center>
                <asp:Button ID="changepasswordsubmit" runat="server" OnClick="changepasswordsubmit_Click" Text="Submit" CssClass="button1"  />
                </center>
                </td>
            </tr>
        </table>
    </form>

</asp:Content>

