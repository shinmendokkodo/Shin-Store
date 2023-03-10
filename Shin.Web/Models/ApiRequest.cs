﻿using static Shin.Web.UrlConfig;

namespace Shin.Web.Models;

public class ApiRequest
{
    public ApiType ApiType { get; set; } = ApiType.GET;
    public string ApiUrl { get; set; }
    public object Data { get; set; }
    public string AccessToken { get; set; }
}
