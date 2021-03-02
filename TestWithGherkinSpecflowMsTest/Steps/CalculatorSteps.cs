using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TechTalk.SpecFlow;

namespace MyTestProject.Steps
{
    [Binding]
    public sealed class CalculatorSteps
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private readonly TestContext _testContext;

        public CalculatorSteps(ScenarioContext scenarioContext, TestContext testContext)
        {
            _scenarioContext = scenarioContext;
            _testContext = testContext;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            _scenarioContext.Add("FirstNumber", number);
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            _scenarioContext.Add("SecondNumber", number);
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            var firstNumber = _scenarioContext["FirstNumber"] as int?;
            var secondNumber = _scenarioContext["SecondNumber"] as int?;
            var sum = firstNumber + secondNumber;
            _scenarioContext.Add("sum", sum);
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            int? sum = _scenarioContext["sum"] as int?;
            Assert.AreEqual(sum, result);
            /*
            _testContext.WriteLine("Title: {0}", _scenarioContext.ScenarioInfo.Title);
            _scenarioContext.ScenarioInfo.Tags.ToList().ForEach(tag => _testContext.WriteLine("Tag: {0}", tag));

            _testContext.WriteLine("Fully qualified test class name: " + _testContext.FullyQualifiedTestClassName);
            _testContext.WriteLine("Test name: " + _testContext.TestName);
            _testContext.WriteLine("Test logs directory: " + _testContext.TestLogsDir);
            _testContext.WriteLine("Deployment directory: " + _testContext.DeploymentDirectory);
            _testContext.WriteLine("Test Results directory: " + _testContext.TestResultsDirectory);
            _testContext.WriteLine("Current test outcome: " + _testContext.CurrentTestOutcome);
            _testContext.WriteLine("Results directory: " + _testContext.ResultsDirectory);
            _testContext.WriteLine("Test deployment dir: " + _testContext.TestDeploymentDir);
            _testContext.WriteLine("Test directory: " + _testContext.TestDir);
            _testContext.WriteLine("Test run directory: " + _testContext.TestRunDirectory);
            _testContext.WriteLine("Test run results directory: " + _testContext.TestRunResultsDirectory);
            */
        }
    }
}
