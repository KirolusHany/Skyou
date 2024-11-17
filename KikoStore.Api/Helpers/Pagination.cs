using System;

namespace KikoStore.Api.Helpers;

public class Pagination<T>(int pageSize , int pageIndex , int count , IReadOnlyList<T> data)
{
    public int PageSize { get; set; }=pageSize;
    public int PageINdex { get; set; }=pageIndex;
    public int Count { get; set; }=count;
    public IReadOnlyList<T> Data  { get; set; }=data;
}
