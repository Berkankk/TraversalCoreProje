﻿using DataAccessLayer.Concrete;
using TraversalCoreProje.CQRS.Queries.DestinationQuery;
using TraversalCoreProje.CQRS.Results.DestinationResult;

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIDQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public GetDestinationByIDQueryResult Handle(GetDestinationByIDQuery query)
        {
            var values = _context.Destinations.Find(query.id);
            return new GetDestinationByIDQueryResult
            {
                ID = values.DestinationID,
                City = values.City,
                DayNight = values.DayNight,
                Price = values.Price,
            };

        }
    }

}
