using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace MyTest_With_Gherkin_Specflow_NUnit.Hooks
{
    [Binding]
    public sealed class AllHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        ScenarioContext _scenarioContext;
        TestContext _testContext;

        public AllHooks(ScenarioContext scenarioContext, TestContext testContext) {
            _scenarioContext = scenarioContext;
            _testContext = testContext;
        }

        [BeforeTestRun]
        public static void DoSomethingBeforeTestRun()
        {
            // This runs before the constructor
        }

        [AfterTestRun]
        public static void DoSomethingAfterTestRun()
        {
            //This runs after test is run
        }

        [BeforeFeature]
        public static void DoSomethingBeforeFeature()
        {
            //This runs before constructor
        }

        [AfterFeature]
        public static void DoSomethingAfterFeature()
        {

        }

        [BeforeScenario(Order = 0)]
        public void DoSomethingBeforeScenario()
        {
            _scenarioContext.Add("BeforeScenario", "BeforeScenarioValue");
        }

        [BeforeScenario(Order = 1)]
        public void DoSomethingBeforeScenario1()
        {
            _scenarioContext.Add("BeforeScenario1", "BeforeScenario1Value");
        }

        [AfterScenario]
        public void DoSomethingAfterScenario()
        {
            _scenarioContext.Remove("BeforeScenario");
            _scenarioContext.Remove("BeforeScenario1");
            _testContext.WriteLine("Title: {0}",_scenarioContext.ScenarioInfo.Title);
            _scenarioContext.ScenarioInfo.Tags.ToList().ForEach(tag => { _testContext.WriteLine("Tag: {0}",tag); });
        }

        [BeforeScenarioBlock]
        public void DoSomethingBeforeScenarioBlock()
        {
            _scenarioContext.Add("BeforeScenarioBlock", "BeforeScenarioBlockValue");
        }

        [AfterScenarioBlock]
        public void DoSomethingAfterScenarioBlock()
        {
            _scenarioContext.Remove("BeforeScenarioBlock");
        }

        [BeforeStep]
        public void DoSomethingBeforeStep()
        {
            _scenarioContext.Add("BeforeStep", "BeforeStepValue");
        }

        [AfterStep]
        public void DoSomethingAfterStep()
        {
            _scenarioContext.Remove("BeforeStep");
        }
    }
}
