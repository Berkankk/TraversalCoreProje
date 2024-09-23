namespace TraversalCoreProje.CQRS.Queries.DestinationQuery
{
    public class GetDestinationByIDQuery
    {
        public int id { get; set; }

        public GetDestinationByIDQuery(int id)
        {
            this.id = id;
        }
    }
}
