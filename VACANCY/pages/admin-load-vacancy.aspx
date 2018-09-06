<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="admin-load-vacancy.aspx.cs" Inherits="PG.LST.PSC.TSVACANCY.pages.admin_load_vacancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="main-container__vacancy-admin-grid">
        <div class="container main-container__vacancy-admin-container">
          <div class="row">
            <div class="col-xs-12">
                <div class="row">
                    <div class="col-xs-12">
                    <a class="btn btn-primary pull-left main-container__btn-create-vacancy" href="admin-create-vacancy.aspx">Create New Vacancy</a>
                        <!-- Material inline 1-->
                        <input class="ed-check" id="check1" type="checkbox">
                        <label class="ed-check-label" for="radio_1-1"></label>
                    </div>
                </div>
              <div class="row">
                  <div runat="server" id="divTabla">
                      <asp:Repeater ID="rptTable" runat="server"></asp:Repeater>
                  </div>
              </div>
            </div>
        </div>
    </section>
</asp:Content>
