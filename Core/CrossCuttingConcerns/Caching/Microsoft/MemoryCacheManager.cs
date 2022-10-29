using Microsoft.Extensions.Caching.Memory;
using System.Reflection;
using System.Text.RegularExpressions;

namespace WebNetSample.Core.CrossCuttingConcerns.Caching.Microsoft;

public class MemoryCacheManager : ICacheService
{
    private readonly IMemoryCache _memoryCache;

    public MemoryCacheManager(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public void Add(string key, object value, int duration)
    {
        _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
    }

    public T Get<T>(string key)
    {
        return _memoryCache.Get<T>(key);
    }

    public object Get(string key)
    {
        return _memoryCache.Get(key);
    }

    public bool IsAdded(string key)
    {
        return _memoryCache.TryGetValue(key, out _);
    }

    public void Remove(string key)
    {
        _memoryCache.Remove(key);
    }

    public void RemoveByPattern(string pattern)
    {
        var cacheEntriesCollectionDefinition = 
            typeof(MemoryCache).GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance);

        var cacheEntriesCollection = 
            cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;

        var cacheCollectionValues = new List<ICacheEntry>();

        foreach (var cacheItem in cacheEntriesCollection)
        {
            ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
            cacheCollectionValues.Add(cacheItemValue);
        }

        var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
        
        var keysToRemove = cacheCollectionValues.Where(x => regex.IsMatch(x.Key.ToString())).Select(x => x.Key).ToString();

        foreach (var key in keysToRemove)
        {
            _memoryCache.Remove(key);
        }
    }
}