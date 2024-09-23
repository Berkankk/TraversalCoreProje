﻿using DocumentFormat.OpenXml.Office2010.ExcelAc;
using MediatR;
using System.Collections.Generic;
using TraversalCoreProje.CQRS.Results.GuideResult;

namespace TraversalCoreProje.CQRS.Queries.GuideQueries
{
    public class GetAllGuideQuery : IRequest<List<GetAllGuideQueryResult>>
    {
        
    }
}
