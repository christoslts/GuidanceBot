using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;


namespace Bot_Application2.Dialogs
{
    public class RootDialog : IDialog<object>
    {
        private Task<IMessageActivity> result;

        public Task StartAsync(IDialogContext context)
        {
            context.PostAsync("hello, what is your name?");
            context.Wait(MessageReceivedStart);
            return Task.CompletedTask;
        }

        private async Task MessageReceivedStart(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as IMessageActivity;
            if (activity != null && activity.Type == ActivityTypes.Message)
            {
                int length = (activity.Text ?? string.Empty).Length;
                await context.PostAsync($"[RootDialog] You sent {activity.Text} which was {length} characters");
            }
            context.Wait(MessageReceivedStart);

        }
    }
}