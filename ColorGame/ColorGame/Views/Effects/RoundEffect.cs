using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ColorGame.Views
{
    public class RoundEffect : RoutingEffect
    {
        public RoundEffect() : base($"ColorGame.{nameof(RoundEffect)}")
        {
        }
    }
}
