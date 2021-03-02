using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MyTestProject.Steps
{
    [Binding]
    public class CalculatorTableExampleSteps
    {
        private ScenarioContext _scenarioContext;
        private TestContext _testContext;

        public CalculatorTableExampleSteps(ScenarioContext scenarioContext, TestContext testContext)
        {
            _scenarioContext = scenarioContext;
            _testContext = testContext;
        }

        [Given(@"user keys following numbers in calculator")]
        public void GivenUserKeysFollowingNumbersInCalculator(Table table)
        {
            _scenarioContext.Add("numbers", table);
        }

        [When(@"two numbers in a row are added")]
        public void WhenTwoNumbersInARowAreAdded()
        {
            var table = _scenarioContext["numbers"] as Table;
            _scenarioContext.Remove("numbers");
            var numbers = table.CreateSet<Number>();
            numbers = numbers.Select(x => new Number { FirstNumber = x.FirstNumber, SecondNumber = x.SecondNumber, Sum = x.FirstNumber + x.SecondNumber });
            _scenarioContext.Add("numbers", numbers);
        }

        [Then(@"result will be in following table")]
        public void ThenResultWillBeInFollowingTable(Table table)
        {
            var numbers = _scenarioContext["numbers"] as IEnumerable<Number>;
            table.CompareToSet(numbers, true);
        }
    }

    public class Number
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public int Sum { get; set; }
    }

}
