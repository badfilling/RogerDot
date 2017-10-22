using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Linq;

namespace RogerDot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            if (activity.Type == ActivityTypes.ConversationUpdate)
            {
                if (activity.MembersAdded != null && activity.MembersAdded.Any())
                {
                    
                    var bot = activity.MembersAdded.First();
                    if (!(activity.MembersAdded.First().Name=="Bot"))
                        await context.PostAsync($"[RootDialog] Hi. This is a test version of bot. You can type \"info\"" +
                            $" to get know what can i do for you");
                }
            } else
            if (activity.Type == ActivityTypes.Message)
            {
                if (activity.Text.ToLower().Contains("info"))
                {
                    context.Call(new InfoDialog(), this.ResumeRootDialog);
                } else if (activity.Text.ToLower().Contains("deanery"))
                    context.Call(new DeaneryDialog(), this.ResumeRootDialog);
                else if (activity.Text.ToLower().Contains("week"))
                    context.Call(new WeekInfo.WeekInfoDialog(), this.ResumeRootDialog);
                else await context.PostAsync("Dont know that command sorry");
            } else


                //this.ShowOptions(context);
                context.Wait(MessageReceivedAsync);
        }

        private async Task ResumeRootDialog(IDialogContext context, IAwaitable<object> result)
        {
            try
            {
                var message = await result;
                await context.PostAsync("Now what would you like me to do?");
            } catch (Exception ex)
            {
                await context.PostAsync($"Failed with message: {ex.Message}");
            } finally
            {
                context.Wait(this.MessageReceivedAsync);
            }
        }
    }
}