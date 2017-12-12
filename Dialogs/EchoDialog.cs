using System;
using System.Threading.Tasks;

using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using System.Net.Http;


namespace Microsoft.Bot.Sample.SimpleEchoBot
{
    [Serializable]
    public class EchoDialog : IDialog<object>
    {
        private bool isSpanish;
        
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            if(message.Text == "es")
            {
                isSpanish = true;
            }
            else if(message.Text == "en")
            {
                isSpanish = false;
            }
            var responseTxt = isSpanish ? "Tu dijiste: " : "You said: "; 
            await context.PostAsync($"{responseTxt} {message.Text}");
            context.Wait(MessageReceivedAsync);
        }
    }
}