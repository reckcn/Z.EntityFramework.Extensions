<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="BulkOperationOptions.aspx.cs" Inherits="Z.EntityFramework.Extensions.Demos.SqlServer.BulkOperationOptions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="uiContentHolder" runat="server">
    <div class="row">
        <div class="col-sm-3 btn-benchmarks">
            <fieldset>
                <legend>Auditing</legend>
                <div>
                    <button id="uiUseAudit" runat="server" type="button" class="btn btn-default">
                        Audit
                    </button>
                </div>
            </fieldset>
            <br/>
            <fieldset>
                <legend>Logging</legend>
                <div>
                    <button id="uiLog" runat="server" type="button" class="btn btn-default">
                        Log Event
                    </button>
                </div>
                <br/>
                <div>
                    <button id="uiUseLogDump" runat="server" type="button" class="btn btn-default">
                        Log Dump
                    </button>
                </div>
            </fieldset>
            <br/>
            <fieldset>
                <legend>Transcient Error Handling</legend>
                <div>
                    <button id="uiRetryCount" runat="server" type="button" class="btn btn-default">
                        Retry Count
                    </button>
                </div>
                <br/>
                <div>
                    <button id="uiRetryInterval" runat="server" type="button" class="btn btn-default">
                        Retry Interval
                    </button>
                </div>
            </fieldset>
        </div>

        <div class="col-sm-9">
            <fieldset>
                <legend>Output</legend>
                <div class="form-horizontal">
                    <textarea id="uiOutput" runat="server" class="form-control" style="height: 400px;"></textarea>
                </div>
            </fieldset>
        </div>
    </div>
    <br/>
    <div class="bold">Source Code:</div>
    <pre id="uiSourceCode" runat="server" class="prettyprint linenums">// Execute an action to see the source code.</pre>

    <style>
        .btn-benchmarks .btn { width: 100%; }
    </style>
</asp:Content>