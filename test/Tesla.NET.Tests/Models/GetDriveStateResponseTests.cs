﻿// Copyright (c) 2018 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Tesla.NET.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoFixture;
    using FluentAssertions;
    using Newtonsoft.Json.Linq;
    using Xunit;
    using Xunit.Abstractions;

    public class When_serializing_GetDriveStateResponse_Should_serialize : FixtureContext
    {
        private readonly ResponseDataWrapper<DriveState> _sut;
        private readonly JObject _json;

        public When_serializing_GetDriveStateResponse_Should_serialize(ITestOutputHelper output)
            : base(output)
        {
            _sut = Fixture.Create<ResponseDataWrapper<DriveState>>();
            _json = JObject.FromObject(_sut);

            output.WriteLine("Serialized JSON:" + Environment.NewLine + _json);
        }

        [Fact]
        public void one_properties() => _json.Count.Should().Be(1);
    }

    public class When_serializing_and_deserializing_GetDriveStateResponse : FixtureContext
    {
        private readonly ResponseDataWrapper<DriveState> _expected;
        private readonly ResponseDataWrapper<DriveState> _actual;

        public When_serializing_and_deserializing_GetDriveStateResponse(ITestOutputHelper output)
            : base(output)
        {
            _expected = Fixture.Create<ResponseDataWrapper<DriveState>>();
            JObject json = JObject.FromObject(_expected);

            output.WriteLine("Serialized JSON:" + Environment.NewLine + json);

            _actual = json.ToObject<ResponseDataWrapper<DriveState>>();
        }

        [Fact]
        public void Should_retain_all_properties() => _actual.ShouldBeEquivalentTo(_expected, WithStrictOrdering);
    }

    public class When_deserializing_GetDriveStateResponse_Should_deserialize : FixtureContext
    {
        private readonly ResponseDataWrapper<DriveState> _sut;
        private readonly JObject _json;
        private readonly DriveState _expectedResponse;

        public When_deserializing_GetDriveStateResponse_Should_deserialize(ITestOutputHelper output)
            : base(output)
        {
            _json = SampleJson.GetDriveStateResponse;
            _sut = _json.ToObject<ResponseDataWrapper<DriveState>>();
            _expectedResponse = SampleJson.DriveState.ToObject<DriveState>();

            output.WriteLine("Serialized JSON:" + Environment.NewLine + _json);
        }

        [Fact]
        public void response() => _sut.Response.ShouldBeEquivalentTo(_expectedResponse, WithStrictOrdering);
    }
}
