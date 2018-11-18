

using System;
using System.Threading.Tasks;
using GraphQL.API.Queries;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;


namespace GraphQL.API.Controllers
{
   [Route("api/GraphQL")]
    public class GraphqlController:Controller
    {
        private readonly StoreQuery _graphQlQuery;
        private IDocumentExecuter _documentExecuter { get; set; }
        private ISchema _schema { get; }

        public GraphqlController(StoreQuery graphQLQuery,IDocumentExecuter documentExecuter, ISchema schema)
        {
            _graphQlQuery = graphQLQuery;
            _documentExecuter = documentExecuter;
            _schema = schema;
        }


 

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQlParameter query)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }

            var executionOptions = new ExecutionOptions { Schema = _schema, Query = query.Query };

            try
            {
                var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

                if (result.Errors?.Count > 0)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
    }
}
