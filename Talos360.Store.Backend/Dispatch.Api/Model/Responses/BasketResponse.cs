﻿using Dispatch.Data;
using System.Collections.Generic;

namespace Dispatch.Api.Model.Responses
{
    public class BasketResponse : ResponseBase
    {
        public List<GroupedBasketItem> BasketItems { get; set; } = new List<GroupedBasketItem>();
    }
}
