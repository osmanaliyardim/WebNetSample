namespace WebNetSample.Core.CrossCuttingConcerns.Caching;

public interface ICacheService
{
    void Add<T>(string key, T value, int duration);

    T Get<T>(string key);

    bool IsAdded(string key);

    void Remove(string key);

    void RemoveByPattern(string pattern);
}
