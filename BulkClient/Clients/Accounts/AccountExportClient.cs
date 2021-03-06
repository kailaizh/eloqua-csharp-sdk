﻿using RestSharp;
using Eloqua.Api.Bulk.Models.Exports;
using Eloqua.Api.Bulk.Models.Syncs;

namespace Eloqua.Api.Bulk.Clients.Accounts
{
    public class AccountExportClient
    {
        readonly BaseClient _client;

        public AccountExportClient(BaseClient client)
        {
            _client = client;
        }

        public Export CreateExport(Export export)
        {
            var request = new RestRequest(Method.POST)
            {
                Resource = "/account/export",
                RequestFormat = DataFormat.Json,
                RootElement = "export"
            };
            request.AddBody(export);

            return _client.Execute<Export>(request);
        }

        public Sync CreateSync(Sync sync)
        {
            return _client.Syncs.CreateSync(sync);
        }

        public IRestResponse ExportData(string exportUri)
        {
            return _client.JsonData.ExportData(exportUri);
        }
    }
}
