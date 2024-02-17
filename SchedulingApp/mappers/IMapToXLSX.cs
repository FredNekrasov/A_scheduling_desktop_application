namespace SchedulingApp.mappers
{
    public interface IMapToXLSX<T, K>
    {
        T ToXLSX(K data);
        List<T> ToXLSXList(List<K> dataList);
    }
}
