using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.Web.Entities
{
    public class Author
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("birthCity")]
        public string BirthCity { get; set; }

        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("createdBy")]
        public object CreatedBy { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("lastModifiedBy")]
        public object LastModifiedBy { get; set; }

        [JsonProperty("lastModified")]
        public object LastModified { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Datum
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("pageNumbers")]
        public int PageNumbers { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }
    }

    public class Result
    {
        [JsonProperty("pageNumber")]
        public int PageNumber { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        [JsonProperty("recordsFiltered")]
        public int RecordsFiltered { get; set; }

        [JsonProperty("recordsTotal")]
        public int RecordsTotal { get; set; }

        [JsonProperty("succeeded")]
        public bool Succeeded { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("errors")]
        public object Errors { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }
    }

}
