﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model.ApiResponses;

namespace WX.Model.ApiRequests
{
    public class MessageMassDeleteRequest : ApiRequest<MessageMassDeleteResponse>
    {
        [JsonProperty("msgid")]
        public int MsgId { get; set; }

        internal override string Method
        {
            get { return "POST"; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com//cgi-bin/message/mass/delete?access_token={0}"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken);
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        public override string GetPostContent()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}