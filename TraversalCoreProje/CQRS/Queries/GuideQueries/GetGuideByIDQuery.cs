using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.CQRS.Results.GuideResult;


namespace TraversalCoreProje.CQRS.Queries.GuideQueries
{
    public class GetGuideByIDQuery : IRequest<GetGuideByIDQueryResult>
    {
        public int id { get; set; }

        public GetGuideByIDQuery(int id)
        {
            this.id = id;
        }
    }
}
