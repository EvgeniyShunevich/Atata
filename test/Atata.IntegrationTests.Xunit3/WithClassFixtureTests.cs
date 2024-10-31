﻿using Atata.Xunit;
using FluentAssertions;
using Xunit;

namespace Atata.IntegrationTests.Xunit3;

public sealed class WithClassFixtureTests :
    AtataTestSuite,
    IClassFixture<SomeClassFixture<WithClassFixtureTests>>
{
    [Fact]
    public void Context_ParentContext() =>
        Context.ParentContext.Test.Should().Be(new TestInfo(typeof(WithClassFixtureTests)));

    [Fact]
    public void Context_ParentContext_ParentContext() =>
        Context.ParentContext.ParentContext.Should().NotBeNull().And.Be(AtataContext.Global);

    [Fact]
    public void Context_Variables() =>
        Context.Variables[nameof(SomeClassFixture<WithClassFixtureTests>)].Should().Be(true);

    [Fact]
    public void Context_Artifacts() =>
        Context.Artifacts.FullName.Value
            .Replace(AtataContext.GlobalProperties.ArtifactsRootPath, null)
            .Should().Be(@$"\{nameof(WithClassFixtureTests)}\{nameof(Context_Artifacts)}");
}
