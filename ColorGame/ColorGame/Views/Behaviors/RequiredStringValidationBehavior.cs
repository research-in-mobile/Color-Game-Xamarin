using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ColorGame.Behaviors
{
    public class RequiredStringValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            bool isValid = !string.IsNullOrEmpty(args.NewTextValue);

            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
            ((Entry)sender).PlaceholderColor = isValid ? Color.Default : Color.Red;
            ((Entry)sender).Placeholder = "Required";
        }
    }
}
