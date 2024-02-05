using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV1.Services
{
    internal class DialogBox
    {
        public string Title;
        public string Content;
        public string CloseButtonContent;
        public string PrimaryButton;
        public string SecondaryButton;

        public DialogBox(string title, string content, string closeButtonContent)
        {
            Title = title;
            Content = content;
            CloseButtonContent = closeButtonContent;
        }
        public DialogBox(string title, string content, string closeButtonContent, string primaryButton) : this(title, content, closeButtonContent)
        {
            PrimaryButton = primaryButton;
        }
        public DialogBox(string title, string content, string closeButtonContent, string primaryButton, string secondaryButton) : this(title, content, closeButtonContent, primaryButton)
        {
            SecondaryButton = secondaryButton;
        }

        public async void ShowDialogBox()
        {
            ContentDialog box = new ContentDialog
            {
                Title = this.Title,
                Content = this.Content,
                CloseButtonText = this.CloseButtonContent
            };
            if(this.PrimaryButton != null)
            {
                box.PrimaryButtonText = this.SecondaryButton;
                if(this.SecondaryButton != null)
                    box.SecondaryButtonText = this.SecondaryButton;
            }

            ContentDialogResult result = await box.ShowAsync();
        }
    }
}
