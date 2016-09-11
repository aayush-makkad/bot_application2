using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace Bot_Application2
{
    [LuisModel("", "")]
    [Serializable]
    public class Simpledialog : LuisDialog<object>
    {
        data dt = new data();
        Google2 gg = new Google2();
        [LuisIntent("")]
        
        public async Task none(IDialogContext context , LuisResult result)
        {
            await context.PostAsync("I really have no idea about this ");
            context.Wait(MessageReceived);
        }

        [LuisIntent("country")]
        public async Task show(IDialogContext context, LuisResult result)
        {
            string res;
            string country;
            EntityRecommendation erc;
            if (result.TryFindEntity("countryname", out erc))
            {
                country = erc.Entity;
                res = dt.getdata(country);
                await context.PostAsync($"capital of {country} is {res}");


            }
            else
            {
                await context.PostAsync("Sorry, can't find that country");

            }
        }

             [LuisIntent("googleSearch")]
        public async Task search(IDialogContext context, LuisResult result)
        {
            string res;

            string link;
            string search;
            EntityRecommendation erc;
            if (result.TryFindEntity("searchString", out erc))
            {
                search = erc.Entity;
                res = gg.tittle(search);
                link = gg.linkk(search);
                await context.PostAsync($"This is what i found : {res} on link : {link} ");


            }
            else
            {
                await context.PostAsync("oh!snap");

            }
            context.Wait(MessageReceived);

        }

        
        
    }
}