// Copyright (c) 2015 ZZZ Projects. All rights reserved
// Licensed under MIT License (MIT) (https://github.com/zzzprojects/Z.EntityFramework.Extensions)
// Full Version: http://www.zzzprojects.com/entity-framework-extensions/
// Website: http://www.zzzprojects.com/
// Feedback / Feature Requests / Issues : http://zzzprojects.uservoice.com/forums/283924
// All ZZZ Projects products: Entity Framework Extensions / Bulk Operations / Extension Methods /Icon Library

using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web.UI;

namespace Z.EntityFramework.Extensions.Demos.SqlServer
{
    public partial class BulkSaveChanges : Page
    {
        private const int MaxNbRecords = 100000;
        private const int MaxNbRecordsSaveChanges = 1000;
        private readonly Stopwatch Clock = new Stopwatch();
        private readonly StringBuilder SbOperation = new StringBuilder();
        private int NbRecords = 1000;

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "BulkSaveChanges Benchmarks | Entity Framework Extensions Library";

            if (!Page.IsPostBack)
            {
                uiNbRecords.Value = MaxNbRecordsSaveChanges.ToString();
                uiNbRecordsError.Visible = false;
            }

            uiBulkSaveChanges.ServerClick += (o, args) =>
            {
                if (!IsValid(MaxNbRecords)) return;

                PreAction();
                BulkSaveChangesHelper.BulkSaveChanges(NbRecords, Clock, SbOperation);
                PostAction();

                ShowSourceCode(@"BulkSaveChangesHelper\BulkSaveChanges.cs");
            };

            uiSaveChanges.ServerClick += (o, args) =>
            {
                if (!IsValid(MaxNbRecordsSaveChanges)) return;

                PreAction();
                BulkSaveChangesHelper.SaveChanges(NbRecords, Clock, SbOperation);
                PostAction();

                ShowSourceCode(@"BulkSaveChangesHelper\SaveChanges.cs");
            };
        }

        private bool IsValid(int maxNbRecords)
        {
            uiNbRecordsError.Visible = !int.TryParse(uiNbRecords.Value, out NbRecords) || NbRecords > maxNbRecords;

            return !uiNbRecordsError.Visible;
        }

        private void PreAction()
        {
            uiRecordCountBefore.InnerHtml = DbHelper.GetRecordCount("EntitySimple").ToString();
            uiRecordSumBefore.InnerHtml = DbHelper.GetRecordSum("EntitySimple").ToString();
        }

        private void PostAction()
        {
            uiOperation.InnerHtml = SbOperation.ToString();
            uiRecordCountAfter.InnerHtml = DbHelper.GetRecordCount("EntitySimple").ToString();
            uiRecordSumAfter.InnerHtml = DbHelper.GetRecordSum("EntitySimple").ToString();
            uiElapsedMilliseconds.InnerHtml = Clock.ElapsedMilliseconds.ToString();
            uiElapsedTicks.InnerHtml = Clock.ElapsedTicks.ToString();
        }

        private void ShowSourceCode(string path)
        {
            uiSourceCode.InnerHtml = File.ReadAllText(Server.MapPath(path));
        }
    }
}