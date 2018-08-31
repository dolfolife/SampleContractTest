using System;
using System.Collections.Generic;
using System.Linq;
using PactNet.Matchers;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;
using Xunit;

namespace Consumer.Tests
{
    public class EventsApiConsumerTests : IClassFixture<ConsumerEventApiPact>
    {
        private readonly IMockProviderService _mockProviderService;
        private readonly string _mockProviderServiceBaseUri;

        public EventsApiConsumerTests(ConsumerEventApiPact data)
        {
            _mockProviderService = data.MockProviderService;
            _mockProviderServiceBaseUri = data.MockProviderServiceBaseUri;
            _mockProviderService.ClearInteractions();
        }

        [Fact]
        public void GetAllEvents_ShouldWork()
        {
            //Arrange
            _mockProviderService.Given("there is something happening")
                .UponReceiving("a request")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = "/events",
                    Headers = new Dictionary<string, object>
                    {
                        { "Accept", "application/json" },
                    }
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = new 
                    {
                        events = new string[] { "event1", "event2" }

                    }
                });

            var consumer = new EventsApiClient(_mockProviderServiceBaseUri);

            var events = consumer.GetAllEvents();

            Assert.Equal(2, events.events.Count());
            Assert.Equal("event1", events.events.ToList()[0]);
            Assert.Equal("event2", events.events.ToList()[1]);
            _mockProviderService.VerifyInteractions();
        }
    }
}
