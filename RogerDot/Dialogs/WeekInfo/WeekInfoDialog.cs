using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RogerDot.Dialogs.WeekInfo
{
    [Serializable]
    public class WeekInfoDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Which day are you interested in?");
            context.Wait(this.MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            DateTime wantedDay = WeekInfo.ConvertToNextDay(message.Text);
            if (Array.Exists<DateTime>(WeekInfo.pairDays, days => days.Equals(wantedDay)))
                await context.PostAsync($"{wantedDay.Day}.{wantedDay.Month}.{wantedDay.Year} is x2");
            else await context.PostAsync($"{wantedDay.Day}.{wantedDay.Month}.{wantedDay.Year} is x1");
            context.Done<object>(new object());

        }

    }
}