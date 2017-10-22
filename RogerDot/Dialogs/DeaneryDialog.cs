using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RogerDot.Dialogs
{
    [Serializable]
    public class DeaneryDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("WEEIA web page: http://.weeia.p.lodz.pl \n");
            await context.PostAsync("Deanery hours of working: TO BE DONE.");
            context.Wait(this.MessageReceivedAsync);
        }
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            await context.PostAsync("Surprise!");
            var message = context.MakeMessage();
            var audioCard = new AudioCard
            {
                Title = "We have a problem",
                Subtitle = "The Apollo 13",
                Text = "\"Houston, we have a problem\" is a popular but erroneous quote from the radio communications between the Apollo 13 astronaut Jack Swigert and the NASA Mission Control Center (\"Houston\") during the Apollo 13 spaceflight,[1] as the astronauts communicated their discovery of the explosion that crippled their spacecraft. The erroneous wording was popularized by the 1995 film Apollo 13, a dramatization of the Apollo 13 mission, in which actor Tom Hanks, portraying Mission Commander Jim Lovell, uses that wording, which became one of the film's taglines.",
                Image = new ThumbnailUrl
                {
                    Url = "https://docs.microsoft.com/en-us/bot-framework/media/how-it-works/architecture-resize.png",
                },
                Media = new List<MediaUrl>
                {
                    new MediaUrl()
                    {
                        Url = "http://www.wavlist.com/movies/098/a13-problem.wav"
                    }
                },
                Buttons = new List<CardAction>
                {
                    new CardAction()
                    {
                        Title = "Read about Apollo 13 film",
                        Type = ActionTypes.OpenUrl,
                        Value = "https://en.wikipedia.org/wiki/Apollo_13_(film)"
                    }
                }
            };
            message.Attachments.Add(audioCard.ToAttachment());
            await context.PostAsync(message);

            context.Done<object>(new object());
        }
    }
}