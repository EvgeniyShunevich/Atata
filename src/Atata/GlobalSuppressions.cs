﻿using System.Diagnostics.CodeAnalysis;

#pragma warning disable S103 // Lines should not be too long

[assembly: SuppressMessage("Sonar Code Smell", "S4041:Type names should not match namespaces", Justification = "<Pending>", Scope = "type", Target = "~T:Atata.Text`1")]
[assembly: SuppressMessage("Sonar Code Smell", "S4023:Interfaces should not be empty", Justification = "<Pending>", Scope = "type", Target = "~T:Atata.INavigable`2")]
[assembly: SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1513:Closing brace must be followed by blank line", Justification = "<Pending>", Scope = "member", Target = "~P:Atata.AtataContext.Current")]
[assembly: SuppressMessage("Sonar Code Smell", "S1541:Methods and properties should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.UntilExtensions.GetWaitUnits(Atata.Until,Atata.WaitOptions)~Atata.WaitUnit[]")]
[assembly: SuppressMessage("Sonar Code Smell", "S3427:Method overloads with default parameter values should not overlap ", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.WaitForElementAttribute.#ctor(Atata.WaitBy,System.String,Atata.Until,Atata.TriggerEvents,Atata.TriggerPriority)")]
[assembly: SuppressMessage("Critical Code Smell", "S1541:Methods and properties should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.ObjectExpressionStringBuilder.VisitMember(System.Linq.Expressions.MemberExpression)~System.Linq.Expressions.Expression")]
[assembly: SuppressMessage("Sonar Code Smell", "S1541:Methods and properties should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.ExpressionStringBuilder.FormatBinder(System.Runtime.CompilerServices.CallSiteBinder)~System.String")]
[assembly: SuppressMessage("Sonar Code Smell", "S1541:Methods and properties should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.ExpressionStringBuilder.GetBinaryOperator(System.Linq.Expressions.ExpressionType)~System.String")]
[assembly: SuppressMessage("Sonar Code Smell", "S1541:Methods and properties should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.ExpressionStringBuilder.VisitUnary(System.Linq.Expressions.UnaryExpression)~System.Linq.Expressions.Expression")]
[assembly: SuppressMessage("Critical Code Smell", "S1541:Methods and properties should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.AtataContextBuilder.Build~Atata.AtataContext")]
[assembly: SuppressMessage("Minor Code Smell", "S3240:The simplest possible condition syntax should be used", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.ExpressionStringBuilder.VisitUnary(System.Linq.Expressions.UnaryExpression)~System.Linq.Expressions.Expression")]
[assembly: SuppressMessage("Minor Code Smell", "S3240:The simplest possible condition syntax should be used", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.ExpressionStringBuilder.VisitParameter(System.Linq.Expressions.ParameterExpression)~System.Linq.Expressions.Expression")]
[assembly: SuppressMessage("Minor Code Smell", "S3240:The simplest possible condition syntax should be used", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.ExpressionStringBuilder.VisitExtension(System.Linq.Expressions.Expression)~System.Linq.Expressions.Expression")]
[assembly: SuppressMessage("Critical Code Smell", "S1541:Methods and properties should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.StringExtensions.SplitIntoWords(System.String)~System.String[]")]
[assembly: SuppressMessage("Minor Code Smell", "S3240:The simplest possible condition syntax should be used", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.UIComponentMetadata.FilterAndOrderByTarget``1(System.Collections.Generic.IEnumerable{``0},Atata.AttributeFilter{``0},Atata.UIComponentMetadata.AttributeTargetFilterOptions)~System.Collections.Generic.IEnumerable{``0}")]
[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1204:Static elements must appear before instance elements", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.AtataContextBuilder.LogRetrySettings(Atata.AtataContext)")]
[assembly: SuppressMessage("Security", "CA2119:Seal methods that satisfy private interfaces", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.PageObject`1.SwitchToRoot``1(``0)~``0")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:Atata.PopupWindow`1.WindowTitleValues")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:Atata.ComponentScopeFindOptions.Terms")]
[assembly: SuppressMessage("Minor Code Smell", "S4136:Method overloads should be grouped together", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.TermResolver.RetrieveValueFromString(System.String,System.String)~System.String")]
[assembly: SuppressMessage("Naming", "CA1717:Only FlagsAttribute enums should have plural names", Justification = "<Pending>", Scope = "type", Target = "~T:Atata.FindAs")]
[assembly: SuppressMessage("Design", "CA1008:Enums should have zero value", Justification = "<Pending>", Scope = "type", Target = "~T:Atata.AtataContextModeOfCurrent")]
[assembly: SuppressMessage("Critical Code Smell", "S1067:Expressions should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.StringExtensions.SplitIntoWords(System.String)~System.String[]")]
[assembly: SuppressMessage("Critical Code Smell", "S2302:\"nameof\" should be used", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.Randomizer.GetString(System.String,System.Int32)~System.String")]
[assembly: SuppressMessage("Minor Code Smell", "S4261:Methods should be named according to their synchronicities", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.UIComponentScriptExecutor`1.ExecuteAsync(System.String,System.Object[])~`0")]
[assembly: SuppressMessage("Major Code Smell", "S1172:Unused method parameters should be removed", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.TypeFinder.FilterByDeclaringTypeNames(System.Collections.Generic.IEnumerable{System.Type},System.Collections.Generic.IEnumerable{System.String})~System.Collections.Generic.IEnumerable{System.Type}")]
[assembly: SuppressMessage("Minor Code Smell", "S1125:Boolean literals should not be redundant", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.TypeFinder.FilterByDeclaringTypeNames(System.Collections.Generic.IEnumerable{System.Type},System.Collections.Generic.IEnumerable{System.String})~System.Collections.Generic.IEnumerable{System.Type}")]
[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1204:Static elements should appear before instance elements", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.ObjectMapper.BuildMappingExceptionMessage(System.Type,System.String,System.String)~System.String")]
[assembly: SuppressMessage("Critical Code Smell", "S2302:\"nameof\" should be used", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.ObjectCreator.RetrievePairByName(System.Collections.Generic.Dictionary{System.String,System.Object},System.Collections.Generic.Dictionary{System.String,System.String},System.Reflection.ParameterInfo)~System.Collections.Generic.KeyValuePair{System.String,System.Object}")]
[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1204:Static elements should appear before instance elements", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.ObjectCreator.RetrievePairByName(System.Collections.Generic.Dictionary{System.String,System.Object},System.Collections.Generic.Dictionary{System.String,System.String},System.Reflection.ParameterInfo)~System.Collections.Generic.KeyValuePair{System.String,System.Object}")]
[assembly: SuppressMessage("Critical Code Smell", "S1541:Methods and properties should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.ObjectConverter.Convert(System.Object,System.Type)~System.Object")]
[assembly: SuppressMessage("Critical Code Smell", "S1541:Methods and properties should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~P:Atata.MulticastAttribute.IsTargetSpecified")]
[assembly: SuppressMessage("Critical Code Smell", "S1067:Expressions should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~P:Atata.MulticastAttribute.IsTargetSpecified")]
[assembly: SuppressMessage("Critical Code Smell", "S1067:Expressions should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.MulticastAttribute.IsNameApplicable(System.String)~System.Boolean")]
[assembly: SuppressMessage("Style", "IDE0075:Simplify conditional expression", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.TypeFinder.FilterByDeclaringTypeNames(System.Collections.Generic.IEnumerable{System.Type},System.Collections.Generic.IEnumerable{System.String})~System.Collections.Generic.IEnumerable{System.Type}")]
[assembly: SuppressMessage("Critical Code Smell", "S1067:Expressions should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.MulticastAttribute.AreTagsApplicable(System.Collections.Generic.IEnumerable{System.String})~System.Boolean")]
[assembly: SuppressMessage("Critical Code Smell", "S1541:Methods and properties should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.MulticastAttribute.CalculateTargetRank(Atata.UIComponentMetadata)~System.Nullable{System.Int32}")]
[assembly: SuppressMessage("Critical Code Smell", "S1541:Methods and properties should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.ImprovedExpressionStringBuilder.VisitMember(System.Linq.Expressions.MemberExpression)~System.Linq.Expressions.Expression")]
[assembly: SuppressMessage("Critical Code Smell", "S1067:Expressions should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.ImprovedExpressionStringBuilder.IsCharComparison(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)~System.Boolean")]
[assembly: SuppressMessage("Critical Code Smell", "S1067:Expressions should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.ImprovedExpressionStringBuilder.IsEnumComparison(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)~System.Boolean")]
[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1204:Static elements should appear before instance elements", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.ImprovedExpressionStringBuilder.IsIndexer(System.Linq.Expressions.MethodCallExpression)~System.Boolean")]
[assembly: SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.IEnumerableProviderExtensions.Single``2(Atata.IEnumerableProvider{``0,``1})~``0")]
[assembly: SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.IEnumerableProviderExtensions.Single``2(Atata.IEnumerableProvider{``0,``1},System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}})~``0")]
[assembly: SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.IObjectProviderEnumerableExtensions.Single``2(Atata.IObjectProvider{System.Collections.Generic.IEnumerable{``0},``1})~Atata.ValueProvider{``0,``1}")]
[assembly: SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.IObjectProviderEnumerableExtensions.Single``2(Atata.IObjectProvider{System.Collections.Generic.IEnumerable{``0},``1},System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}})~Atata.ValueProvider{``0,``1}")]
[assembly: SuppressMessage("Design", "CA1063:Implement IDisposable Correctly", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.DisposableSubject`1.Dispose")]
[assembly: SuppressMessage("Critical Code Smell", "S1541:Methods and properties should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.UIComponent.GetScopeElement(Atata.SearchOptions)~OpenQA.Selenium.IWebElement")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.ControlList`2.ResolveSearchOptions~Atata.SearchOptions")]
[assembly: SuppressMessage("Critical Code Smell", "S1541:Methods and properties should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.ClearCacheAttribute.GetTargetComponent``1(Atata.IUIComponent{``0},Atata.ClearCacheTarget)~Atata.IUIComponent{``0}")]
[assembly: SuppressMessage("Minor Code Smell", "S3267:Loops should be simplified with \"LINQ\" expressions", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.EventBus.UnsubscribeHandler(System.Object)")]
[assembly: SuppressMessage("Critical Code Smell", "S1541:Methods and properties should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.FindByXPathStrategy.Build(Atata.ComponentScopeXPathBuilder,Atata.ComponentScopeFindOptions)~System.String")]
[assembly: SuppressMessage("Usage", "CA2213:Disposable fields should be disposed", Justification = "<Pending>", Scope = "member", Target = "~F:Atata.AtataContext._driver")]
[assembly: SuppressMessage("Minor Code Smell", "S4261:Methods should be named according to their synchronicities", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.UIComponentScriptExecutor`1.ExecuteAsync``1(System.String,System.Object[])~Atata.ValueProvider{``0,`0}")]
[assembly: SuppressMessage("Minor Code Smell", "S4136:Method overloads should be grouped together", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.IObjectVerificationProviderExtensions.Contain``1(Atata.IObjectVerificationProvider{System.String,``0},System.String)~``0")]
[assembly: SuppressMessage("Globalization", "CA1309:Use ordinal string comparison", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.IObjectVerificationProviderExtensions.EqualIgnoringCase``1(Atata.IObjectVerificationProvider{System.String,``0},System.String)~``0")]
[assembly: SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "<Pending>", Scope = "member", Target = "~P:Atata.ObjectProvider`2.Object")]
[assembly: SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "<Pending>", Scope = "member", Target = "~P:Atata.SubjectBase`2.Object")]
[assembly: SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "<Pending>", Scope = "member", Target = "~P:Atata.IObjectProvider`1.Object")]
[assembly: SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "<Pending>", Scope = "member", Target = "~P:Atata.EnumerableValueProvider`2.Object")]
[assembly: SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "<Pending>", Scope = "member", Target = "~P:Atata.IObjectSource`1.Object")]
[assembly: SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "<Pending>", Scope = "member", Target = "~P:Atata.LazyObjectSource`1.Object")]
[assembly: SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "<Pending>", Scope = "member", Target = "~P:Atata.LazyObjectSource`2.Object")]
[assembly: SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "<Pending>", Scope = "member", Target = "~P:Atata.DynamicObjectSource`1.Object")]
[assembly: SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "<Pending>", Scope = "member", Target = "~P:Atata.DynamicObjectSource`2.Object")]
[assembly: SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "<Pending>", Scope = "member", Target = "~P:Atata.StaticObjectSource`1.Object")]
[assembly: SuppressMessage("Critical Code Smell", "S1541:Methods and properties should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.AtataPathTemplateStringFormatter.Format(System.String,System.Object,System.IFormatProvider)~System.String")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Pending>", Scope = "member", Target = "~P:Atata.IVerificationProvider`1.TypeEqualityComparerMap")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Pending>", Scope = "member", Target = "~P:Atata.VerificationProvider`2.TypeEqualityComparerMap")]
[assembly: SuppressMessage("Minor Code Smell", "S2292:Trivial properties should be auto-implemented", Justification = "<Pending>", Scope = "member", Target = "~P:Atata.VerificationProvider`2.Atata#IVerificationProvider<TOwner>#TypeEqualityComparerMap")]
[assembly: SuppressMessage("Critical Code Smell", "S1541:Methods and properties should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.AtataNavigator.GoToFollowingPageObject``1(Atata.UIComponent,``0,Atata.AtataNavigator.GoOptions)~``0")]
[assembly: SuppressMessage("Critical Code Smell", "S1067:Expressions should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.AtataNavigator.IsUrlHasPath(System.String)~System.Boolean")]
[assembly: SuppressMessage("Critical Code Smell", "S1067:Expressions should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.EnumExtensions.GetIndividualFlags(System.Enum)~System.Collections.Generic.IEnumerable{System.Enum}")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.WebDriverFullPageScreenshotStrategy.TakeScreenshot(Atata.AtataContext)~Atata.FileContentWithExtension")]
[assembly: SuppressMessage("Naming", "CA1708:Identifiers should differ by more than case", Justification = "<Pending>", Scope = "type", Target = "~T:Atata.UIComponent`1")]
[assembly: SuppressMessage("Naming", "CA1708:Identifiers should differ by more than case", Justification = "<Pending>", Scope = "type", Target = "~T:Atata.IUIComponent`1")]
[assembly: SuppressMessage("Naming", "CA1708:Identifiers should differ by more than case", Justification = "<Pending>", Scope = "type", Target = "~T:Atata.IUIComponentVerificationProviderExtensions")]
[assembly: SuppressMessage("Critical Code Smell", "S1541:Methods and properties should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.ContentExtractor.Get``1(Atata.IUIComponent{``0},Atata.ContentSource)~System.String")]
[assembly: SuppressMessage("Critical Code Smell", "S1067:Expressions should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.AtataPathTemplateStringFormatter.Format(System.String,System.Object,System.IFormatProvider)~System.String")]
[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1204:Static elements should appear before instance elements", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.AtataContextBuilder.EnableBrowserLogMonitoringOnDriverInitEvent(OpenQA.Selenium.IWebDriver,Atata.AtataContext,System.Collections.Generic.IEnumerable{Atata.IBrowserLogHandler})")]
[assembly: SuppressMessage("Design", "CA1030:Use events where appropriate", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.AtataContext.RaiseError(System.String,System.Exception)")]
[assembly: SuppressMessage("Design", "CA1030:Use events where appropriate", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.AtataContext.RaiseWarning(System.String,System.Exception)")]
[assembly: SuppressMessage("Style", "IDE0053:Use expression body for lambda expression", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.PopupBox`2.WaitForAppearance(System.Nullable{System.TimeSpan},System.Nullable{System.TimeSpan})~`0")]
[assembly: SuppressMessage("Critical Code Smell", "S1541:Methods and properties should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.DriverAtataContextBuilder`3.CreateDriver~OpenQA.Selenium.IWebDriver")]
[assembly: SuppressMessage("Critical Code Smell", "S2696:Instance members should not write to \"static\" fields", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.AtataContext.SetAsCurrent")]
[assembly: SuppressMessage("Minor Code Smell", "S3254:Default parameter values should not be passed as arguments", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.WindowTitleAttribute.#ctor(System.String[])")]
[assembly: SuppressMessage("Critical Code Smell", "S134:Control flow statements \"if\", \"switch\", \"for\", \"foreach\", \"while\", \"do\"  and \"try\" should not be nested too deeply", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.DriverAtataContextBuilder`1.Atata#IDriverFactory#Create~OpenQA.Selenium.IWebDriver")]
[assembly: SuppressMessage("Critical Code Smell", "S1541:Methods and properties should not be too complex", Justification = "<Pending>", Scope = "member", Target = "~M:Atata.LogManager.PrependHierarchyPrefixesToMessage(System.String,Atata.LogEventInfo,Atata.LogConsumerConfiguration)~System.String")]

#pragma warning restore S103 // Lines should not be too long
