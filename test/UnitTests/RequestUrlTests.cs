﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using FluentAssertions;
using IdentityModel.Client;
using System.Collections.Generic;
using Xunit;

namespace IdentityModel.UnitTests
{
    public class RequestUrlTests
    {
        [Fact]
        public void null_value_should_return_base()
        {
            var request = new RequestUrl("http://server/authorize");

            var url = request.Create(null);

            url.Should().Be("http://server/authorize");
        }

        [Fact]
        public void empty_value_should_return_base()
        {
            var request = new RequestUrl("http://server/authorize");

            var values = new Dictionary<string, string>();
            var url = request.Create(values);

            url.Should().Be("http://server/authorize");
        }

        [Fact]
        public void Create_absolute_url_should_behave_as_expected()
        {
            var request = new RequestUrl("http://server/authorize");

            var parmeters = new
            {
                foo = "foo",
                bar = "bar"
            };

            var url = request.Create(parmeters);

            url.Should().Be("http://server/authorize?foo=foo&bar=bar");
        }

        [Fact]
        public void Create_relative_url_should_behave_as_expected()
        {
            var request = new RequestUrl("/authorize");

            var parmeters = new
            {
                foo = "foo",
                bar = "bar"
            };

            var url = request.Create(parmeters);

            url.Should().Be("/authorize?foo=foo&bar=bar");
        }
    }
}