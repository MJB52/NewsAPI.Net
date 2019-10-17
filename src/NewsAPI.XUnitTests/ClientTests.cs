﻿using NewsAPI.Entities;
using NewsAPI.Entities.Enums;
using System;
using System.Threading.Tasks;
using Xunit;

namespace NewsAPI.XUnitTests
{
    public class ClientTests
    {
        private readonly NewsClient _newsClient;

        public ClientTests()
        {
            _newsClient = new NewsClient("364365705e724fc9a5f385b9e24f487e");
        }

        [Fact]
        public async Task NewsResponse_EverythingRequest_NotNull()
        {
            var request = new EverythingRequest("Arrow", SortType.PublishedDate);
            var result = await _newsClient.FetchNewsAsync(request);

            foreach (var article in result.Articles)
            {
                Console.WriteLine(article.Title);
                Console.WriteLine(article.Description);
                Console.WriteLine(article.Author);
                Console.WriteLine(article.Source.Name);
            }

            Assert.Equal(ResponseStatus.Ok, result.ResponseStatus);
            Assert.NotNull(result.Articles);
        }

        [Fact]
        public async Task NewsResponse_TopHeadlinesRequest_NotNull()
        {
            var request = new TopHeadlinesRequest("AI", NewsCategory.Technology);
            var result = await _newsClient.FetchNewsAsync(request);

            foreach (var article in result.Articles)
            {
                Console.WriteLine(article.Title);
                Console.WriteLine(article.Description);
                Console.WriteLine(article.Author);
                Console.WriteLine(article.Source.Name);
            }

            Assert.Equal(ResponseStatus.Ok, result.ResponseStatus);
            Assert.NotNull(result.Articles);
        }
    }
}
