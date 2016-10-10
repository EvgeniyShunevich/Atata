﻿using System;

namespace Atata
{
    /// <summary>
    /// Specifies the verification of the page content. Verifies whether the component content matches any of the specified values. By default occurs during the page object initialization.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true)]
    public class VerifyContentMatchesAttribute : TriggerAttribute
    {
        public VerifyContentMatchesAttribute(TermMatch match, params string[] values)
            : base(TriggerEvents.OnPageObjectInit)
        {
            Values = values;
            Match = match;
        }

        public new TermMatch Match { get; set; }

        public string[] Values { get; private set; }

        public override void Execute<TOwner>(TriggerContext<TOwner> context)
        {
            context.Component.Content.Should.WithRetry.MatchAny(Match, Values);
        }
    }
}
