using System.Collections.Generic;

namespace Shin.Services.ProductApi.Models.Dtos;

public class ResponseDto
{
    public bool IsSuccess { get; set; } = true;
    public object Result { get; set; }
    public string DisplayMessage { get; set; } = string.Empty;
    public List<string> ErrorMessages { get; set; }
}
