using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace RogerDot.Dialogs
{
    [Serializable]
    public class InfoDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Avaliable commands: \"week\", \"deanery\". Write command name " +
                "to get info about it or any key to return.");
            context.Wait(this.MessageReceivedAsync);
        }
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            if (message.Text.ToLower().Contains("week"))
            {
                await context.PostAsync("tells you if the entered day(nearest to today) is x1 or x2");
                context.Wait(MessageReceivedAsync);
            } else
            if (message.Text.ToLower().Contains("deanery"))
            {
                await context.PostAsync("basic info about WEEIA deanery.");
                context.Wait(MessageReceivedAsync);
            } else
                context.Done<object>(new object());
        }
    }
}