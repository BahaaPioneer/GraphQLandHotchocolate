using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Platform> GetPlatform([Service(ServiceKind.Pooled)] AppDbContext context)
        {
            return context.Platforms;
        }
    }
}