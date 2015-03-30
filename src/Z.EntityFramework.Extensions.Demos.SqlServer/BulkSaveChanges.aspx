<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="BulkSaveChanges.aspx.cs" Inherits="Z.EntityFramework.Extensions.Demos.SqlServer.BulkSaveChanges" %>
<asp:Content ID="Content1" ContentPlaceHolderID="uiContentHolder" runat="server">
    <div class="row">
        <div class="col-sm-6 btn-benchmarks">
            <fieldset>
                <legend>Performance Comparison</legend>
                <br/>
                <div class="row">
                    <div class="col-sm-5 center">
                        <button id="uiBulkSaveChanges" runat="server" type="button" class="btn btn-default">
                            BulkSaveChanges
                        </button>
                        <div class="bold">ZZZ Projects</div>
                    </div>
                    <div class="col-sm-2 bold center">
                        vs
                    </div>
                    <div class="col-sm-5 center">
                        <button id="uiSaveChanges" runat="server" type="button" class="btn btn-default">
                            SaveChanges
                        </button>
                        <div class="bold">Entity Framework</div>
                    </div>
                </div>
                <br /><br /><br /><br /><br/>
                <div class="block center font-size-lg">BulkSaveChanges works exactly like SaveChanges but... <span class="bold">faster</span>!</div>
                <br />
                <div class="block center font-size-lg">Increase your <span class="bold">performance by 50x</span> and more!</div>
                <br /> 
            </fieldset>
        </div>
        <div class="col-sm-6">
            <fieldset>
                <legend>Settings</legend>
                <div class="form-horizontal">
                    <div id="uiNbRecordsError" runat="server" class="alert alert-danger" role="alert"><span class="glyphicon glyphicon-exclamation-sign"></span>&nbsp;<span class="bold">Oops!</span> The online version is limited to 100,000 records for Bulk Method (ZZZ Projects) and 1,000 record for SaveChanges Method (Entity Framework).</div>
                    <div class="form-group">
                        <label for="serverName" class="col-sm-6 control-label">Nb Records:</label>
                        <div class="col-sm-6">
                            <input id="uiNbRecords" runat="server" class="form-control" type="text" value="1000" />
                        </div>
                    </div>
                </div>
            </fieldset>
            <br />
            <fieldset>
                <legend>Statistics</legend>
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-sm-6 control-label">Operations:</label>
                        <div id="uiOperation" runat="server" class="col-sm-6 label-value">
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-6 control-label">Elapsed Milliseconds:</label>
                        <div id="uiElapsedMilliseconds" runat="server" class="col-sm-6 label-value bold">
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-6 control-label">Elapsed Ticks:</label>
                        <div id="uiElapsedTicks" runat="server" class="col-sm-6 label-value">
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-6 control-label">Records Count Before:</label>
                        <div id="uiRecordCountBefore" runat="server" class="col-sm-6 label-value">
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-6 control-label">Records Sum Before:</label>
                        <div id="uiRecordSumBefore" runat="server" class="col-sm-6 label-value">
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-6 control-label">Records Count After:</label>
                        <div id="uiRecordCountAfter" runat="server" class="col-sm-6 label-value">
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-6 control-label">Records Sum After:</label>
                        <div id="uiRecordSumAfter" runat="server" class="col-sm-6 label-value">
                        </div>
                    </div>
                </div>
                <div class="italic">The table is shared between all users. Please note the record count & sum may not show the exact result in a concurrency scenario.</div>
            </fieldset>
        </div>
    </div>
    <br />
    <div class="bold">Source Code:</div>
    <pre id="uiSourceCode" runat="server" class="prettyprint linenums">// Execute an action to see the source code.</pre>

    <style>
        .btn-benchmarks .btn { width: 100%; }
    </style>
</asp:Content>