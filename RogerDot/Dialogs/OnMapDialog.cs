using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RogerDot.Dialogs
{
    [Serializable]
    public class OnMapDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("What building you want me to show?");
            context.Wait(MessageReceivedAsync);
        }
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            if (message.Text.Contains("A10"))
            {
                var imagePath = HttpContext.Current.Server.MapPath("~/images/test.png");
                var imageData = Convert.ToBase64String(File.ReadAllBytes(imagePath));
                var replyMessage = context.MakeMessage();
                Attachment pic = new Attachment("image/png", $"data:image/png;base64,{imageData}", null, "A10 building", null);
                replyMessage.Attachments = new List<Attachment> { pic };
                await context.PostAsync(replyMessage);
                context.Done<object>(new object());
            } else
            {
                await context.PostAsync("now i cant show you that building sorry :D");
                context.Done<object>(new object());
            }
        }
    }
}