﻿using SmartHomeAPI.Business.Abstractions.Dtos;

namespace SmartHomeAPI.Business.Dtos.PaginationDtos;

public class PagedResultDto<T> 
{
    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    public int Page { get; set; }
    public List<T> Items { get; set; }
}
