using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalBanking.PresentationMVC.Extension
{
    public static  class CustomGreetings
    {
        public static HtmlString CustomGreetingsOnTime(this HtmlHelper htmlHelper)
        {
            if (DateTime.Now.Hour < 12)
            {
                var label = new TagBuilder("h3") { InnerHtml = "Good Morning" };
                return new HtmlString(label.ToString());
            }
            else if (DateTime.Now.Hour < 17)
            {
                var label = new TagBuilder("h3") { InnerHtml = "Good Afternoon" };
                return new HtmlString(label.ToString());
            }
            else
            {
                var label = new TagBuilder("h3") { InnerHtml = "Good Evening" };
                return new HtmlString(label.ToString());
            }
            
        }
    }
}