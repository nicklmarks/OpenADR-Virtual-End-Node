﻿//////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2014, Electric Power Research Institute (EPRI)
// All rights reserved.
//
// oadr2b-ven, oadrlib, and oadr-test ("this software") are licensed under the 
// BSD 3-Clause license.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//   * Redistributions of source code must retain the above copyright notice, this 
//     list of conditions and the following disclaimer.
//     
//   * Redistributions in binary form must reproduce the above copyright notice, 
//     this list of conditions and the following disclaimer in the documentation 
//     and/or other materials provided with the distribution.
//     
//   * Neither the name of EPRI nor the names of its contributors may 
//     be used to endorse or promote products derived from this software without 
//     specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
// IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
// INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
// PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace oadrlib.lib.oadr2b
{
    public class UpdateReport : OadrRequest2b
    {
        public oadrUpdateReportType request;
        public oadrUpdatedReportType response;
        
        /**********************************************************/

        public UpdateReport()
            : base("oadrUpdateReport", "oadrUpdatedReport")
        {
        }

        /**********************************************************/

        public string createUpdateReport(string venID, string requestID, ReportDescription reportDescription, List<string> reportSpecifierIDs, DateTime dtstartUTC)
        {
            request = new oadrUpdateReportType();

            request.requestID = requestID;
            request.schemaVersion = "2.0b";
            request.venID = venID;

            request.oadrReport = new oadrReportType[reportSpecifierIDs.Count];

            int index = 0;
            foreach (string reportSpecifierID in reportSpecifierIDs)
            {
                oadrReportType report = reportDescription.generateReport(reportSpecifierID, dtstartUTC);

                request.oadrReport[index++] = report;
            }

            return serializeObject(request);
        }

        /**********************************************************/

        public string createUpdateReport(string venID, string requestID, Dictionary<string, ReportWrapper> reports, string reportRequestID)
        {
            request = new oadrUpdateReportType();

            request.requestID = requestID;
            request.schemaVersion = "2.0b";
            request.venID = venID;

            request.oadrReport = new oadrReportType[reports.Count];

            int index = 0;
            foreach (ReportWrapper reportWrapper in reports.Values)
            {
                oadrReportType report = reportWrapper.generateReport(reportRequestID);

                request.oadrReport[index++] = report;
            }

            return serializeObject(request);
        }

        /**********************************************************/

        public string createUpdateReport(string venID, string requestID, oadrReportType report, string reportRequestID)
        {
            request = new oadrUpdateReportType();

            request.requestID = requestID;
            request.schemaVersion = "2.0b";
            request.venID = venID;

            request.oadrReport = new oadrReportType[1];

            request.oadrReport[0] = report;

            return serializeObject(request);
        }
    }
}
