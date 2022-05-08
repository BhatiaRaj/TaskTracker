<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Forgot.aspx.cs" Inherits="forgot" %>

<html class="no-js" lang="en">
<!--<![endif]-->

<head>
    <link rel="shortcut icon" href="images/Logo.ico">
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0">
    <meta charset="utf-8">
    <link href="LoginCss/style.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;700;800&display=swap" rel="stylesheet">
</head>

<body>
     <div class="main ">
        <div class="container b-container" id="b-container">
            <form class="form" id="form1" method="" action="" runat="server">
                <h2 class="form_title title">Forgot Password</h2>
                <div class="form__icons">
                    <span class="form__span">or use your Email Account
                    </span>
                    <table>
                            <tr>
                                <td>
                                    <asp:TextBox ID="username" runat="server" class="form__input" placeholder="Mobile No."></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="username" ErrorMessage="*" ForeColor="#DB0000"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        
                            <tr>
                                <td colspan="2">
                                   <center> <asp:Button ID="forgotsubmit" runat="server" Text="Submit" OnClick="forgotsubmit_Click" class="form__button button submit" /></center>
                                </td>
                            </tr>
                        <tr>
                            <td colspan="2" style="text-align: right;">
                                <asp:LinkButton ID="LinkButton1" class="form__link" runat="server" PostBackUrl="~/Login.aspx" CausesValidation="false">Login</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
            </form>
        </div>
        <div class="switch" id="switch-cnt">
            <div class="switch__circle"></div>
            <div class="switch__circle switch__circle--t"></div>
            <div class="switch__container" id="switch-c1">
                <img src="images/Logo_03.png" height="300px" />
                <h2 class="switch__title title">Task Tracker</h2>
                <p class="switch__description description">Your Contributions Matters</p>
            </div>

        </div>
        
    </div>
    <script src="main.js"></script>

</body>

</html>

