namespace TraversalCoreProje.CQRS.Results.DestinationResult
{
    public class GetAllDestinationQueryResult
    {
        public int ID { get; set; }
        public string City { get; set; }
        public int Capacity { get; set; }
        public double Price { get; set; }
        public string DayNight { get; set; }
    }
}
