using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;


namespace Bot_Application2
{
    public class Google2
    {
        public  string tittle(string querry)
        {
            
            const string apiKey = "YOUR_APP_KEY";
            const string searchEngineId = "YOUR_ENGINE_ID";
         string query = querry;
            string res="oh,snap!";
            CustomsearchService customSearchService = new CustomsearchService(new Google.Apis.Services.BaseClientService.Initializer() { ApiKey = apiKey });
            Google.Apis.Customsearch.v1.CseResource.ListRequest listRequest = customSearchService.Cse.List(query);
            listRequest.Cx = searchEngineId;
            Search search = listRequest.Execute();
            foreach (var item in search.Items)
            {
                res = item.Title;
                break;
            }
            return res;
        }
        public string linkk(string querry)
        {

            const string apiKey = "YOUR_APP_KEY";
            const string searchEngineId = "YOUR_ENGINE_ID";
            string query = querry;
            string res = "oh,snap!";
            CustomsearchService customSearchService = new CustomsearchService(new Google.Apis.Services.BaseClientService.Initializer() { ApiKey = apiKey });
            Google.Apis.Customsearch.v1.CseResource.ListRequest listRequest = customSearchService.Cse.List(query);
            listRequest.Cx = searchEngineId;
            Search search = listRequest.Execute();
            foreach (var item in search.Items)
            {

                res = item.Link;
                break;
            }
            return res;
        }

    }
}