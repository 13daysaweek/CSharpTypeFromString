namespace ThirteenDaysAWeek.TypeLoadFromString
{
    public class Domain<T>
        where T : IDomainModel
    {
        public T Model { get; set; }
    }
}
