using CosmosAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class itemEntryController : ControllerBase
    {
        private readonly IDocumentClient _documentClient;
        readonly string databaseId;
        readonly string collectionId;
        public IConfiguration Configuration { get; }

        public itemEntryController(IDocumentClient documentClient, IConfiguration configuration)
        {
            _documentClient = documentClient;
            Configuration = configuration;

            databaseId = Configuration["DatabaseId"];
            collectionId = "itemEntry";

            BuildCollection().Wait();
        }

        private async Task BuildCollection()
        {
            await _documentClient.CreateDatabaseIfNotExistsAsync(new Database { Id = databaseId });
            await _documentClient.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(databaseId),
            new DocumentCollection { Id = collectionId }); 
        }

        [HttpGet]
        public IQueryable<itemEntry> Get()
        {
            return _documentClient.CreateDocumentQuery<itemEntry>(UriFactory.CreateDocumentCollectionUri(databaseId, collectionId));
        }

        [HttpGet("{id}")]
        public IQueryable<itemEntry> Get(string id)
        {
            return _documentClient.CreateDocumentQuery<itemEntry>(UriFactory.CreateDocumentCollectionUri(databaseId, collectionId), 
                new FeedOptions { MaxItemCount = 1 }).Where((i) => i.Id == id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] itemEntry item)
        {
            var response = await _documentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseId, collectionId), item);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] itemEntry item)
        {
            await _documentClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseId, collectionId, id),item);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _documentClient.DeleteDocumentAsync(UriFactory.CreateDocumentUri(databaseId, collectionId, id));
            return Ok();
        }

    }

}
