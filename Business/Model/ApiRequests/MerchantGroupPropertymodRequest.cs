﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model.ApiResponses;

namespace WX.Model.ApiRequests
{
    public class MerchantGroupPropertymodRequest : ApiRequest<DefaultResponse>
    {
        public MerchantGroupDetail GroupDetail { get; set; }

        internal override string Method
        {
            get { return POSTMETHOD; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/merchant/group/propertymod?access_token={0}"; }
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
            return JsonConvert.SerializeObject(this.GroupDetail);
        }

        internal override void Validate()
        {
            base.Validate();
            if (this.GroupDetail != null)
            {
                this.GroupDetail.Product = null;
                this.GroupDetail.ProductList = null;
            }
        }
    }
}
