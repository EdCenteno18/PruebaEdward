<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="admin-create-vacancy.aspx.cs" Inherits="PG.LST.PSC.TSVACANCY.pages.admin_create_vacancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
          <div class="col-xs-12">
            <h1 class="text-center">Create New Vacancy</h1>
          </div>
        </div>
      </div>
      <div class="container">
        <div class="row">
          <div class="col-xs-12">
            <div class="form-container">
              <form>
                <div class="row">
                  <div class="col-sm-4">
                    <div class="form-group">
                      <label>Department</label>
                      <input class="form-control" id="input-department" type="text" placeholder="Type Department">
                    </div>
                  </div>
                  <div class="col-sm-4">
                    <div class="form-group">
                      <label>Cost Center</label>
                      <input class="form-control" id="input-cost" type="text" placeholder="Type Cost Center">
                    </div>
                  </div>
                  <div class="col-sm-4">
                    <div class="form-group">
                      <label>Hiring Manager</label>
                        
                      <input class="form-control" id="input-type-hiring" type="text" placeholder="Type Hiring Manager">
                    </div>
                  </div>
                  <div class="col-sm-4">
                    <div class="form-group">
                      <label>Quantity</label>
                      <input class="form-control" id="input-quantity" type="text" placeholder="Type Quantity">
                    </div>
                  </div>
                  <div class="col-sm-4">
                    <div class="form-group">
                      <label for="select-position">Position Title</label>
                      <select class="form-control" id="select-position">
                        <option>1</option>
                        <option>2</option>
                        <option>3</option>
                        <option>4</option>
                        <option>5</option>
                      </select>
                    </div>
                  </div>
                  <div class="col-sm-4">
                      <div class="form-group">
                        <label for="select-function">Function</label>
                        <select class="form-control" id="select-function">
                          <option>1</option>
                          <option>2</option>
                          <option>3</option>
                          <option>4</option>
                          <option>5</option>
                        </select>
                      </div>
                  </div>
                  <div class="col-sm-4">
                      <label for="select-country">Country</label>
                    <select class="form-control" id="select-country">
                      <option>1</option>
                      <option>2</option>
                      <option>3</option>
                      <option>4</option>
                      <option>5</option>
                    </select>
                  </div>
                  <div class="col-sm-4">
                    <div class="form-group">
                      <label for="select-candidate-level">Level Candidate</label>
                      <select class="form-control" id="select-candidate-level">
                        <option>1</option>
                        <option>2</option>
                        <option>3</option>
                        <option>4</option>
                        <option>5</option>
                      </select>
                    </div>
                  </div>
                  <div class="col-sm-4">
                    <div class="form-group">
                      <label>Start Date</label>
                      <input class="form-control" id="input-datetime" type="datetime-local" value="2011-08-19T13:45:00">
                    </div>
                  </div>
                  <div class="col-xs-12">
                    <div class="form-group">
                      <label for="text-comment">Comments</label>
                      <textarea class="form-control" id="text-comment" rows="3"></textarea>
                    </div>
                  </div>
                  <div class="col-xs-12">
                    <div class="form-group">
                      <label for="input-skills">skills</label>
                      <input class="form-control" id="input-skills" type="text"  placeholder="Enter skill">
                    </div>
                  </div>
                  <div class="col-xs-12">
                    <button class="btn btn-success pull-right ss" type="button">Save</button>
                    <button class="btn btn-primary pull-right" type="button">Update</button>
                  </div>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
</asp:Content>
