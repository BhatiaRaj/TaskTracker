﻿<%@ Page Title="" Language="C#" MasterPageFile="~/TaskTracker.master" AutoEventWireup="true" CodeFile="MyTask.aspx.cs" Inherits="MyTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 50%;
            margin-left: auto;
            margin-right: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs">
        <div class="col-sm-4">
            <div class="page-header float-left">
                <div class="page-title">
                    <h1>My Task</h1>
                </div>
            </div>
        </div>
    </div>
    <form id="form1" runat="server">
    <table class="auto-style1">
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="800px" DataKeyNames="Id" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="tow" HeaderText="Type of Work" />
                        <asp:BoundField DataField="customername" HeaderText="Customer Name" />
                        <asp:BoundField DataField="targetdate" HeaderText="Target Date" />
                        <asp:BoundField DataField="targettime" HeaderText="Target Time" />
                        <asp:BoundField DataField="description" HeaderText="Description" />
                        <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkupdate" runat="server" CausesValidation="false" OnClick="lnkupdate_Click"><%--<img src="images/upload.png" height="25px" width="25px"/>--%><i class="fa fa-upload"></i></asp:LinkButton>
                        </ItemTemplate>
                        </asp:TemplateField>
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

