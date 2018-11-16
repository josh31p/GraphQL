

using System;
using System.Threading.Tasks;
using GraphQL.API.Queries;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;


namespace GraphQL.API.Controllers
{
    [Route("api/Store")]
    public class StoreController
    {
        private IDocumentExecuter _documentExecuter { get; set; }
        private ISchema _schema { get; }

        public StoreController(IDocumentExecuter documentExecuter, ISchema schema)
        {
            _documentExecuter = documentExecuter;
            _schema = schema;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return new OkResult();
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
                    return new BadRequestResult();
                }

                return new OkResult();
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}
